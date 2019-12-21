namespace itcrafts.UI
{
    partial class ManufacturingEngineerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManufacturingEngineerPanel));
            pictureBox1 = new PictureBox();
            Title = new Label();
            GoBackBtn = new Button();
            ManufactureBtn = new Button();
            DeviceBox = new ComboBox();
            label5 = new Label();
            WorkstationBox = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            MainPanel = new FlowLayoutPanel();
            EstimatedBudgetBox = new NumericUpDown();
            QuantityBox = new NumericUpDown();
            ProcessStepBtn = new Button();
            RawMaterialsBtn = new Button();
            ComponentsBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EstimatedBudgetBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)QuantityBox).BeginInit();
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
            Title.Size = new Size(285, 59);
            Title.TabIndex = 13;
            Title.Text = "Device Manufacturing";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GoBackBtn
            // 
            GoBackBtn.Location = new Point(215, 524);
            GoBackBtn.Margin = new Padding(4);
            GoBackBtn.Name = "GoBackBtn";
            GoBackBtn.Size = new Size(175, 31);
            GoBackBtn.TabIndex = 16;
            GoBackBtn.Text = "Go Back";
            GoBackBtn.UseVisualStyleBackColor = true;
            GoBackBtn.Click += GoBack;
            // 
            // ManufactureBtn
            // 
            ManufactureBtn.Location = new Point(28, 524);
            ManufactureBtn.Margin = new Padding(4);
            ManufactureBtn.Name = "ManufactureBtn";
            ManufactureBtn.Size = new Size(179, 31);
            ManufactureBtn.TabIndex = 24;
            ManufactureBtn.Text = "Manufacture";
            ManufactureBtn.UseVisualStyleBackColor = true;
            ManufactureBtn.Click += ManufactureClick;
            // 
            // DeviceBox
            // 
            DeviceBox.FormattingEnabled = true;
            DeviceBox.Location = new Point(23, 133);
            DeviceBox.Name = "DeviceBox";
            DeviceBox.Size = new Size(367, 25);
            DeviceBox.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(23, 105);
            label5.Name = "label5";
            label5.Size = new Size(56, 21);
            label5.TabIndex = 31;
            label5.Text = "Device";
            // 
            // WorkstationBox
            // 
            WorkstationBox.FormattingEnabled = true;
            WorkstationBox.Location = new Point(24, 201);
            WorkstationBox.Name = "WorkstationBox";
            WorkstationBox.Size = new Size(366, 25);
            WorkstationBox.TabIndex = 37;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(23, 172);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 36;
            label3.Text = "Workstation";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(24, 241);
            label4.Name = "label4";
            label4.Size = new Size(131, 21);
            label4.TabIndex = 38;
            label4.Text = "Estimated Budget";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(24, 314);
            label6.Name = "label6";
            label6.Size = new Size(70, 21);
            label6.TabIndex = 40;
            label6.Text = "Quantity";
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.FlowDirection = FlowDirection.TopDown;
            MainPanel.Location = new Point(458, 105);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(740, 450);
            MainPanel.TabIndex = 42;
            MainPanel.Paint += ProcessStepsPanel_Paint;
            // 
            // EstimatedBudgetBox
            // 
            EstimatedBudgetBox.Location = new Point(24, 271);
            EstimatedBudgetBox.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            EstimatedBudgetBox.Name = "EstimatedBudgetBox";
            EstimatedBudgetBox.Size = new Size(366, 25);
            EstimatedBudgetBox.TabIndex = 44;
            // 
            // QuantityBox
            // 
            QuantityBox.Location = new Point(24, 343);
            QuantityBox.Name = "QuantityBox";
            QuantityBox.Size = new Size(366, 25);
            QuantityBox.TabIndex = 45;
            // 
            // ProcessStepBtn
            // 
            ProcessStepBtn.Location = new Point(458, 53);
            ProcessStepBtn.Margin = new Padding(4);
            ProcessStepBtn.Name = "ProcessStepBtn";
            ProcessStepBtn.Size = new Size(179, 31);
            ProcessStepBtn.TabIndex = 46;
            ProcessStepBtn.Text = "Process Steps";
            ProcessStepBtn.UseVisualStyleBackColor = true;
            ProcessStepBtn.Click += ProcessStepBtn_Click;
            // 
            // RawMaterialsBtn
            // 
            RawMaterialsBtn.Location = new Point(645, 53);
            RawMaterialsBtn.Margin = new Padding(4);
            RawMaterialsBtn.Name = "RawMaterialsBtn";
            RawMaterialsBtn.Size = new Size(179, 31);
            RawMaterialsBtn.TabIndex = 47;
            RawMaterialsBtn.Text = "Raw Materials";
            RawMaterialsBtn.UseVisualStyleBackColor = true;
            RawMaterialsBtn.Click += RawMaterialsBtnClick;
            // 
            // ComponentsBtn
            // 
            ComponentsBtn.Location = new Point(832, 53);
            ComponentsBtn.Margin = new Padding(4);
            ComponentsBtn.Name = "ComponentsBtn";
            ComponentsBtn.Size = new Size(179, 31);
            ComponentsBtn.TabIndex = 48;
            ComponentsBtn.Text = "Components";
            ComponentsBtn.UseVisualStyleBackColor = true;
            ComponentsBtn.Click += ComponentsBtnClick;
            // 
            // ManufacturingEngineerPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1232, 587);
            ControlBox = false;
            Controls.Add(ComponentsBtn);
            Controls.Add(RawMaterialsBtn);
            Controls.Add(ProcessStepBtn);
            Controls.Add(QuantityBox);
            Controls.Add(EstimatedBudgetBox);
            Controls.Add(MainPanel);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(WorkstationBox);
            Controls.Add(label3);
            Controls.Add(DeviceBox);
            Controls.Add(label5);
            Controls.Add(ManufactureBtn);
            Controls.Add(GoBackBtn);
            Controls.Add(Title);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManufacturingEngineerPanel";
            Opacity = 0.9D;
            Padding = new Padding(19, 42, 19, 42);
            StartPosition = FormStartPosition.CenterScreen;
            Load += ManufacturingEngineerPanel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)EstimatedBudgetBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)QuantityBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label Title;
        private Button GoBackBtn;
        private Button ManufactureBtn;
        private ComboBox DeviceBox;
        private Label label5;
        private ComboBox WorkstationBox;
        private Label label3;
        private Label label4;
        private Label label6;
        private FlowLayoutPanel MainPanel;
        private NumericUpDown EstimatedBudgetBox;
        private NumericUpDown QuantityBox;
        private Button ProcessStepBtn;
        private Button RawMaterialsBtn;
        private Button ComponentsBtn;
    }
}