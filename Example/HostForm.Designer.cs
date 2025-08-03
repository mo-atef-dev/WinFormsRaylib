namespace WinFormsRaylib
{
    partial class HostForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostForm));
            hostingPanel = new Panel();
            buttonChangeColor = new Button();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            changeCubeColorToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            labelIndicator = new Label();
            menuStrip.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // hostingPanel
            // 
            hostingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            hostingPanel.BorderStyle = BorderStyle.FixedSingle;
            hostingPanel.Location = new Point(12, 38);
            hostingPanel.Name = "hostingPanel";
            hostingPanel.Size = new Size(548, 400);
            hostingPanel.TabIndex = 0;
            hostingPanel.Click += hostingPanel_Click;
            // 
            // buttonChangeColor
            // 
            buttonChangeColor.Anchor = AnchorStyles.Top;
            buttonChangeColor.Location = new Point(3, 299);
            buttonChangeColor.Name = "buttonChangeColor";
            buttonChangeColor.Size = new Size(216, 23);
            buttonChangeColor.TabIndex = 1;
            buttonChangeColor.Text = "Change cube color";
            buttonChangeColor.UseVisualStyleBackColor = true;
            buttonChangeColor.Click += buttonChangeColor_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeCubeColorToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // changeCubeColorToolStripMenuItem
            // 
            changeCubeColorToolStripMenuItem.Name = "changeCubeColorToolStripMenuItem";
            changeCubeColorToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.C;
            changeCubeColorToolStripMenuItem.Size = new Size(212, 22);
            changeCubeColorToolStripMenuItem.Text = "Change cube color";
            changeCubeColorToolStripMenuItem.Click += changeCubeColorToolStripMenuItem_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(buttonChangeColor);
            flowLayoutPanel1.Controls.Add(labelIndicator);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(566, 38);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(222, 400);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(216, 296);
            label1.TabIndex = 2;
            label1.Text = resources.GetString("label1.Text");
            // 
            // labelIndicator
            // 
            labelIndicator.AutoSize = true;
            labelIndicator.Location = new Point(3, 325);
            labelIndicator.Name = "labelIndicator";
            labelIndicator.Size = new Size(61, 15);
            labelIndicator.TabIndex = 3;
            labelIndicator.Text = "State label";
            // 
            // HostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(hostingPanel);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "HostForm";
            Text = "Raylib Hosting Sample";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel hostingPanel;
        private Button buttonChangeColor;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem changeCubeColorToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label labelIndicator;
    }
}
