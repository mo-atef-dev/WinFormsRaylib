using Raylib_cs;
using System.Numerics;

namespace WinFormsRaylib
{
    internal class RaylibUIThreadHost : RaylibHost
    {
        private readonly object _lock = new();

        private Camera3D cam = new Camera3D();

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
            Raylib.UpdateCamera(ref cam, CameraMode.Orbital);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
            Raylib.DrawFPS(10, 10);
            Raylib.BeginMode3D(cam);
            {
                Raylib.DrawGrid(100, 1.0f);
                Raylib.DrawCube(new Vector3(0.0f, 0.0f, 0.0f), 2.0f, 2.0f, 2.0f, Raylib_cs.Color.Red);
                Raylib.DrawCubeWires(new Vector3(0.0f, 0.0f, 0.0f), 2.0f, 2.0f, 2.0f, Raylib_cs.Color.Black);
            }
            Raylib.EndMode3D();

            Raylib.EndDrawing();
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

        protected void RaylibInit()
        {
            Raylib.SetTargetFPS(60);

            Raylib.SetWindowPosition(0, 0);

            cam.Projection = CameraProjection.Perspective;
            cam.Position = new Vector3(10.0f, 10.0f, 10.0f);
            cam.Target = new Vector3(0.0f, 0.0f, 0.0f);
            cam.Up = new Vector3(0.0f, 1.0f, 0.0f);
            cam.FovY = 45.0f;

            Raylib.SetExitKey(0);
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
