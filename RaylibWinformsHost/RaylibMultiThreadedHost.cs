using Raylib_cs;
using System.Numerics;
using System.Windows.Forms;

namespace WinFormsRaylib
{
    public class RaylibMultiThreadedHost : RaylibHost
    {
        private readonly object _lock = new();

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
