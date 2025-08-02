using Raylib_cs;
using System.Numerics;
using Color = Raylib_cs.Color;

namespace WinFormsRaylib
{
    public partial class HostForm : Form
    {
        IExampleHost raylibHost;

        public HostForm()
        {
            InitializeComponent();
            raylibHost = new ExampleUIThreadHost(hostingPanel, this);
            //raylibHost = new ExampleMultiThreadedHost(hostingPanel, this);
            Load += HostForm_Load;
        }

        public void SetIndicatorText(string text)
        {
            labelIndicator.Text = text;
        }

        private void HostForm_Load(object? sender, EventArgs e)
        {
            raylibHost.Start();
        }


        private void hostingPanel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            raylibHost.ChangeCubeColor(new Color(Random.Shared.Next(0, 255), Random.Shared.Next(0, 255), Random.Shared.Next(0, 255), 255));
        }

        private void changeCubeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonChangeColor_Click(sender, e);
        }
    }
}
