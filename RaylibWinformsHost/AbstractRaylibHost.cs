using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsRaylib
{
    /// <summary>
    /// Abstract base class for a WinForms Raylib host
    /// </summary>
    public abstract class AbstractRaylibHost
    {
        protected readonly Panel _hostingPanel;
        protected readonly string _windowTitle;
        protected Vector2 _hostPanelSize = new(800, 600);

        public AbstractRaylibHost(Panel hostingPanel, string windowTitle = "WinFormsRaylib")
        {
            _hostingPanel = hostingPanel;
            _windowTitle = windowTitle;

            _hostPanelSize.X = hostingPanel.Width;
            _hostPanelSize.Y = hostingPanel.Height;
        }

        /// <summary>
        /// Performs any required initialization and starts the Raylib thread
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// This is called once before entering the main Raylib loop but after starting the Raylib thread
        /// Override this function for custom initialization before running the Raylib loop
        /// </summary>
        protected virtual void RaylibInit()
        {
            Raylib.SetTargetFPS(60);

            Raylib.SetWindowPosition(0, 0);

            Raylib.SetExitKey(0);
        }

        /// <summary>
        /// This is the Raylib thread function (where the main loop is called)
        /// Override this for complete control on what happens once the thread starts
        /// </summary>
        /// <param name="hostHandle">The handle to the hosting WinForms Panel</param>
        protected abstract void RaylibThread(object? hostHandle);

        /// <summary>
        /// This funciton runs the main Raylib loop
        /// Override this function for custom control of the Raylib loop
        /// </summary>
        protected abstract void RaylibLoop();

        /// <summary>
        /// This is the function called each iteration of the Raylib loop
        /// Override this function for your custom Raylib loop iteration
        /// </summary>
        protected abstract void RaylibIteration();

        /// <summary>
        /// Attaches the Raylib window to the WinForms Panel
        /// </summary>
        /// <param name="hostHandle">The handle to the hosting WinForms Panel</param>
        protected virtual void RaylibAttachWindow(object? hostHandle)
        {
            if (hostHandle == null)
            {
                return;
            }

            IntPtr raylibWindowHandle;
            Raylib.SetConfigFlags(ConfigFlags.UndecoratedWindow);
            Raylib.InitWindow((int)_hostPanelSize.X, (int)_hostPanelSize.Y, _windowTitle);
            unsafe
            {
                raylibWindowHandle = (nint)Raylib.GetWindowHandle();
            }

            // Modify the Raylib window to become a child window
            uint style = Win32.GetWindowLong(raylibWindowHandle, Win32.GWL_STYLE);
            style &= ~(Win32.WS_POPUP);
            Win32.SetWindowLong(raylibWindowHandle, Win32.GWL_STYLE, style | Win32.WS_CHILD | Win32.WS_VISIBLE);

            // Set the Raylib window as a child of the WinForms Panel
            Win32.SetParent(raylibWindowHandle, (nint)hostHandle);

            // Ensure the Raylib window is positioned at (0, 0) within the Panel
            Win32.SetWindowPos(raylibWindowHandle, IntPtr.Zero, 0, 0, 0, 0, Win32.SWP_NOZORDER | Win32.SWP_NOSIZE);

            // Set focus to the main window
            Win32.SetFocus((nint)hostHandle);
        }

        /// <summary>
        /// Update the size of the Raylib window to match the host panel size
        /// </summary>
        protected virtual void UpdateWindowSize()
        {
            // Update the window size to match the parent
            Raylib.SetWindowSize((int)_hostPanelSize.X, (int)_hostPanelSize.Y);
        }
    }
}
