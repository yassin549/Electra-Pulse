namespace itcrafts.UI
{
    partial class QualityAssurancePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityAssurancePanel));
            pictureBox1 = new PictureBox();
            Title = new Label();
            DTBtn = new Button();
            MDDBtn = new Button();
            GoBackBtn = new Button();
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
            Title.Size = new Size(234, 59);
            Title.TabIndex = 13;
            Title.Text = "Quality Assurance";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DTBtn
            // 
            DTBtn.Location = new Point(23, 135);
            DTBtn.Margin = new Padding(4);
            DTBtn.Name = "DTBtn";
            DTBtn.Size = new Size(236, 46);
            DTBtn.TabIndex = 14;
            DTBtn.Text = "Device Testing";
            DTBtn.UseVisualStyleBackColor = true;
            DTBtn.Click += DTClick;
            // 
            // MDDBtn
            // 
            MDDBtn.Location = new Point(267, 135);
            MDDBtn.Margin = new Padding(4);
            MDDBtn.Name = "MDDBtn";
            MDDBtn.Size = new Size(232, 46);
            MDDBtn.TabIndex = 15;
            MDDBtn.Text = "Managing Device Defects";
            MDDBtn.UseVisualStyleBackColor = true;
            MDDBtn.Click += MDDClick;
            // 
            // GoBackBtn
            // 
            GoBackBtn.Location = new Point(23, 189);
            GoBackBtn.Margin = new Padding(4);
            GoBackBtn.Name = "GoBackBtn";
            GoBackBtn.Size = new Size(476, 46);
            GoBackBtn.TabIndex = 16;
            GoBackBtn.Text = "Go Back";
            GoBackBtn.UseVisualStyleBackColor = true;
            GoBackBtn.Click += GoBack;
            // 
            // QualityAssurancePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(522, 261);
            ControlBox = false;
            Controls.Add(GoBackBtn);
            Controls.Add(MDDBtn);
            Controls.Add(DTBtn);
            Controls.Add(Title);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "QualityAssurancePanel";
            Opacity = 0.9D;
            Padding = new Padding(19, 42, 19, 42);
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label Title;
        private Button DTBtn;
        private Button MDDBtn;
        private Button GoBackBtn;
    }
}