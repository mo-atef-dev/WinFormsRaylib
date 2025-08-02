using Raylib_cs;
using System.Numerics;
using Color = Raylib_cs.Color;

namespace WinFormsRaylib
{
    internal class ExampleUIThreadHost : RaylibUIThreadHost, IExampleHost
    {
        private HostForm _parentForm;

        /* Scene state */
        private Camera3D _cam = new Camera3D();
        private Color _cubeColor = Color.Red;
        private Vector3 _cubeCenter = new Vector3(0.0f, 0.0f, 0.0f);
        private Vector3 _cubeDimensions = new Vector3(2.0f, 2.0f, 2.0f);
        private const float _selectionBoxOffset = 0.2f;

        private bool _isBoxSelected = false;
        private bool IsBoxSelected
        {
            get => _isBoxSelected;
            set
            {
                _isBoxSelected = value;
                OnBoxSelectedChanged();
            }
        }

        private void OnBoxSelectedChanged()
        {
            string message = IsBoxSelected ? "Box selected" : "Box not selected";

             _parentForm.SetIndicatorText(message);
        }

        private Ray _ray;
        private RayCollision _rayCollision;

        public ExampleUIThreadHost(Panel hostingPanel, HostForm parentForm, string windowTitle = "WinFormsRaylib") : base(hostingPanel, windowTitle)
        {
            _parentForm = parentForm;
        }

        public void ChangeCubeColor(Color color)
        {
            _cubeColor = color;
        }

        protected override void RaylibIteration()
        {
            Raylib.UpdateCamera(ref _cam, CameraMode.Orbital);

            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                var cubeBoundingBox = new BoundingBox(_cubeCenter - _cubeDimensions / 2.0f, _cubeCenter + _cubeDimensions / 2.0f);
                _ray = Raylib.GetScreenToWorldRay(Raylib.GetMousePosition(), _cam);
                _rayCollision = Raylib.GetRayCollisionBox(_ray, cubeBoundingBox);
                if (_rayCollision.Hit)
                {
                    IsBoxSelected = true;
                }
                else
                {
                    IsBoxSelected = false;
                }
            }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.RayWhite);
            Raylib.DrawFPS(10, 10);
            Raylib.BeginMode3D(_cam);
            {
                Raylib.DrawGrid(100, 1.0f);
                Raylib.DrawCube(_cubeCenter, _cubeDimensions.X, _cubeDimensions.Y, _cubeDimensions.Z, _cubeColor);
                Raylib.DrawCubeWires(_cubeCenter, _cubeDimensions.X, _cubeDimensions.Y, _cubeDimensions.Z, Raylib_cs.Color.Black);
                if (IsBoxSelected)
                {
                    Raylib.DrawCubeWires(_cubeCenter, _cubeDimensions.X + _selectionBoxOffset,
                        _cubeDimensions.Y + _selectionBoxOffset, _cubeDimensions.Z + _selectionBoxOffset,
                        Raylib_cs.Color.Green);
                }
            }
            Raylib.EndMode3D();

            Raylib.EndDrawing();
        }

        protected override void RaylibInit()
        {
            // Default initialization
            base.RaylibInit();

            _cam.Projection = CameraProjection.Perspective;
            _cam.Position = new Vector3(10.0f, 10.0f, 10.0f);
            _cam.Target = new Vector3(0.0f, 0.0f, 0.0f);
            _cam.Up = new Vector3(0.0f, 1.0f, 0.0f);
            _cam.FovY = 45.0f;
        }
    }
}
