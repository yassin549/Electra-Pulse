namespace itcrafts.UI
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            pictureBox1 = new PictureBox();
            Title = new Label();
            RoleButtonsPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            CloseBtn = new Button();
            LogOutBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(19, 42);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(830, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // Title
            // 
            Title.Dock = DockStyle.Top;
            Title.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Title.ForeColor = Color.White;
            Title.Location = new Point(19, 141);
            Title.Margin = new Padding(4, 0, 4, 0);
            Title.Name = "Title";
            Title.Size = new Size(830, 55);
            Title.TabIndex = 12;
            Title.Text = "Welcome";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            Title.Click += label1_Click;
            // 
            // RoleButtonsPanel
            // 
            RoleButtonsPanel.Dock = DockStyle.Top;
            RoleButtonsPanel.Location = new Point(19, 196);
            RoleButtonsPanel.Margin = new Padding(4, 4, 4, 4);
            RoleButtonsPanel.Name = "RoleButtonsPanel";
            RoleButtonsPanel.Padding = new Padding(75, 0, 75, 0);
            RoleButtonsPanel.Size = new Size(830, 209);
            RoleButtonsPanel.TabIndex = 13;
            RoleButtonsPanel.Paint += RoleButtonsPanel_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(CloseBtn);
            panel1.Controls.Add(LogOutBtn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(19, 405);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(830, 50);
            panel1.TabIndex = 14;
            panel1.Paint += panel1_Paint;
            // 
            // CloseBtn
            // 
            CloseBtn.Location = new Point(271, 0);
            CloseBtn.Margin = new Padding(4, 4, 4, 4);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(141, 46);
            CloseBtn.TabIndex = 1;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseApp;
            // 
            // LogOutBtn
            // 
            LogOutBtn.Location = new Point(419, 0);
            LogOutBtn.Margin = new Padding(4, 4, 4, 4);
            LogOutBtn.Name = "LogOutBtn";
            LogOutBtn.Size = new Size(141, 46);
            LogOutBtn.TabIndex = 0;
            LogOutBtn.Text = "Log Out";
            LogOutBtn.UseVisualStyleBackColor = true;
            LogOutBtn.Click += LogOut;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(868, 497);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(RoleButtonsPanel);
            Controls.Add(Title);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Dashboard";
            Opacity = 0.9D;
            Padding = new Padding(19, 42, 19, 42);
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.FlowLayoutPanel RoleButtonsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}