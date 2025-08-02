using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsRaylib
{
    abstract class RaylibHost
    {
        protected readonly Panel _hostingPanel;
        protected readonly string _windowTitle;
        protected Vector2 _hostPanelSize = new(800, 600);

        public RaylibHost(Panel hostingPanel, string windowTitle = "WinFormsRaylib")
        {
            _hostingPanel = hostingPanel;
            _windowTitle = windowTitle;

            _hostPanelSize.X = hostingPanel.Width;
            _hostPanelSize.Y = hostingPanel.Height;
        }

        public abstract void Start();

        protected abstract void RaylibIteration();

        protected abstract void RaylibLoop();

        protected abstract void RaylibThread(object? hostHandle);

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

        protected virtual void UpdateWindowSize()
        {
            // Update the window size to match the parent
            Raylib.SetWindowSize((int)_hostPanelSize.X, (int)_hostPanelSize.Y);
        }
    }
}
