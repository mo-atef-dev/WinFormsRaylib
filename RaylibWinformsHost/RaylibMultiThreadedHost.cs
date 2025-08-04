using Raylib_cs;
using System.Numerics;
using System.Windows.Forms;

namespace WinFormsRaylib
{
    /// <summary>
    /// A Raylib host that runs the Raylib loop in a separate background thread
    /// </summary>
    public class RaylibMultiThreadedHost : AbstractRaylibHost
    {
        private readonly object _lock = new();

        /// <summary>
        /// A Raylib host that runs the Raylib loop in a separate background thread
        /// </summary>
        /// <param name="hostingPanel">The Panel object that will host the Raylib window and set its size</param>
        /// <param name="windowTitle">The title of the Raylib window (this is not shown anyway but it is a required parameter to initialize Raylib and it can be left as the default)</param>
        public RaylibMultiThreadedHost(Panel hostingPanel, string windowTitle = "WinFormsRaylib") : base(hostingPanel, windowTitle)
        {
            _hostingPanel.Resize += hostingPanel_Resize;
        }

        public override void Start()
        {
            Thread raylibThread = new Thread(new ParameterizedThreadStart(RaylibThread));
            raylibThread.IsBackground = true;
            raylibThread.Start(_hostingPanel.Handle);
        }

        protected override void RaylibIteration()
        {
            
        }

        protected override void RaylibLoop()
        {
            while (!Raylib.WindowShouldClose())
            {
                lock (_lock)
                {
                    UpdateWindowSize();
                }

                RaylibIteration();
            }
            Raylib.CloseWindow();
        }

        protected override void RaylibThread(object? hostHandle)
        {
            RaylibAttachWindow(hostHandle);
            RaylibInit();
            RaylibLoop();
        }

        private void hostingPanel_Resize(object? sender, EventArgs e)
        {
            lock (_lock)
            {
                _hostPanelSize.X = _hostingPanel.Width;
                _hostPanelSize.Y = _hostingPanel.Height;
            }
        }
    }
}
