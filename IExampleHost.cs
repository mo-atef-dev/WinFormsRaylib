using Color = Raylib_cs.Color;

namespace WinFormsRaylib
{
    internal interface IExampleHost
    {
        void ChangeCubeColor(Color color);
        void Start();
    }
}
