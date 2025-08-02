using Raylib_cs;
using System.Numerics;

namespace WinFormsRaylib
{
    public class RaylibUIThreadHost : RaylibHost
    {
        public RaylibUIThreadHost(Panel hostingPanel, string windowTitle = "WinFormsRaylib") : base(hostingPanel, windowTitle)
        {
            _hostingPanel.Resize += hostingPanel_Resize;
        }

        public override void Start()
        {
            RaylibAttachWindow(_hostingPanel.Handle);
            RaylibThread(null);
        }

        protected override void RaylibIteration()
        {
        }

        protected override void RaylibLoop()
        {
            if (!Raylib.WindowShouldClose())
            {
                UpdateWindowSize();
                RaylibIteration();

                if (_hostingPanel.IsHandleCreated)
                {
                    _hostingPanel.BeginInvoke(() =>
                    {
                        RaylibLoop();
                    });
                }
            }
            else
            {
                Raylib.CloseWindow();
            }
        }

        protected override void RaylibThread(object? obj)
        {
            RaylibInit();
            RaylibLoop();
        }

        private void hostingPanel_Resize(object? sender, EventArgs e)
        {
            _hostPanelSize.X = _hostingPanel.Width;
            _hostPanelSize.Y = _hostingPanel.Height;
        }
    }
}
