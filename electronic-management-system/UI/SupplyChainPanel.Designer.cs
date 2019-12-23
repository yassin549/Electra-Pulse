namespace itcrafts.UI
{
    partial class SupplyChainPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyChainPanel));
            pictureBox1 = new PictureBox();
            Title = new Label();
            MPLBtn = new Button();
            MWBtn = new Button();
            GoBackBtn = new Button();
            MMBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 25);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(74, 59);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // Title
            // 
            Title.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Title.ForeColor = Color.White;
            Title.Location = new Point(105, 25);
            Title.Margin = new Padding(4, 0, 4, 0);
            Title.Name = "Title";
            Title.Size = new Size(239, 59);
            Title.TabIndex = 13;
            Title.Text = "Supply Chain Panel";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MPLBtn
            // 
            MPLBtn.Location = new Point(23, 135);
            MPLBtn.Margin = new Padding(4);
            MPLBtn.Name = "MPLBtn";
            MPLBtn.Size = new Size(159, 46);
            MPLBtn.TabIndex = 14;
            MPLBtn.Text = "Manage Devices";
            MPLBtn.UseVisualStyleBackColor = true;
            MPLBtn.Click += MDClick;
            // 
            // MWBtn
            // 
            MWBtn.Location = new Point(190, 135);
            MWBtn.Margin = new Padding(4);
            MWBtn.Name = "MWBtn";
            MWBtn.Size = new Size(176, 46);
            MWBtn.TabIndex = 15;
            MWBtn.Text = "Manage Components";
            MWBtn.UseVisualStyleBackColor = true;
            MWBtn.Click += MCCLick;
            // 
            // GoBackBtn
            // 
            GoBackBtn.Location = new Point(23, 189);
            GoBackBtn.Margin = new Padding(4);
            GoBackBtn.Name = "GoBackBtn";
            GoBackBtn.Size = new Size(527, 46);
            GoBackBtn.TabIndex = 16;
            GoBackBtn.Text = "Go Back";
            GoBackBtn.UseVisualStyleBackColor = true;
            GoBackBtn.Click += GoBack;
            // 
            // MMBtn
            // 
            MMBtn.Location = new Point(374, 135);
            MMBtn.Margin = new Padding(4);
            MMBtn.Name = "MMBtn";
            MMBtn.Size = new Size(176, 46);
            MMBtn.TabIndex = 17;
            MMBtn.Text = "Manage Material";
            MMBtn.UseVisualStyleBackColor = true;
            MMBtn.Click += MMCLick;
            // 
            // SupplyChainPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(574, 261);
            ControlBox = false;
            Controls.Add(MMBtn);
            Controls.Add(GoBackBtn);
            Controls.Add(MWBtn);
            Controls.Add(MPLBtn);
            Controls.Add(Title);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SupplyChainPanel";
            Opacity = 0.9D;
            Padding = new Padding(19, 42, 19, 42);
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label Title;
        private Button MPLBtn;
        private Button MWBtn;
        private Button GoBackBtn;
        private Button MMBtn;
    }
}