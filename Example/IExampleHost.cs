using Color = Raylib_cs.Color;

namespace WinFormsRaylib.Example
{
    internal interface IExampleHost
    {
        void ChangeCubeColor(Color color);
        void Start();
    }
}
