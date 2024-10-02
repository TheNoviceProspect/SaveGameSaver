namespace SaveGameSaver
{
    partial class MainAppForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAppForm));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripSplitButton1 = new ToolStripSplitButton();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            listBox1 = new ListBox();
            button1 = new Button();
            AppIcons = new ImageList(components);
            button2 = new Button();
            statusStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripSplitButton1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(599, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(32, 20);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(listBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(button2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(599, 428);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // listBox1
            // 
            tableLayoutPanel1.SetColumnSpan(listBox1, 2);
            listBox1.Dock = DockStyle.Fill;
            listBox1.Enabled = false;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(20, 234);
            listBox1.Margin = new Padding(20);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(559, 174);
            listBox1.TabIndex = 0;
            listBox1.SelectedValueChanged += listBox1_SelectedValueChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.Dock = DockStyle.Fill;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button1.ImageIndex = 1;
            button1.ImageList = AppIcons;
            button1.Location = new Point(20, 20);
            button1.Margin = new Padding(20);
            button1.Name = "button1";
            button1.Padding = new Padding(5);
            button1.Size = new Size(259, 174);
            button1.TabIndex = 1;
            button1.Text = "Backup Dinkum Saves";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // AppIcons
            // 
            AppIcons.ColorDepth = ColorDepth.Depth32Bit;
            AppIcons.ImageStream = (ImageListStreamer)resources.GetObject("AppIcons.ImageStream");
            AppIcons.TransparentColor = Color.Transparent;
            AppIcons.Images.SetKeyName(0, "restore-settings.png");
            AppIcons.Images.SetKeyName(1, "cloud-backup-up-arrow.png");
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDark;
            button2.Dock = DockStyle.Fill;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button2.ImageIndex = 0;
            button2.ImageList = AppIcons;
            button2.Location = new Point(319, 20);
            button2.Margin = new Padding(20);
            button2.Name = "button2";
            button2.Size = new Size(260, 174);
            button2.TabIndex = 2;
            button2.Text = "Restore Save";
            button2.TextAlign = ContentAlignment.TopCenter;
            button2.UseVisualStyleBackColor = false;
            // 
            // MainAppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip1);
            Name = "MainAppForm";
            Text = "SaveMyDink";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox listBox1;
        private Button button1;
        private Button button2;
        protected internal ImageList AppIcons;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripStatusLabel toolStripStatusLabel2;
    }
}
