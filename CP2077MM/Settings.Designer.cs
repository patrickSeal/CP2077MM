namespace CP2077MM
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            btn_close = new Button();
            btn_apply = new Button();
            lbl_01 = new Label();
            lbl_02 = new Label();
            lbl_03 = new Label();
            lbl_04 = new Label();
            lbl_05 = new Label();
            lbl_06 = new Label();
            txB_06 = new TextBox();
            btn_06 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            error = new Label();
            SuspendLayout();
            // 
            // btn_close
            // 
            btn_close.Location = new Point(682, 457);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(106, 41);
            btn_close.TabIndex = 0;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // btn_apply
            // 
            btn_apply.Location = new Point(568, 457);
            btn_apply.Name = "btn_apply";
            btn_apply.Size = new Size(108, 41);
            btn_apply.TabIndex = 1;
            btn_apply.Text = "Apply";
            btn_apply.UseVisualStyleBackColor = true;
            btn_apply.Click += btn_apply_Click;
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.BackColor = Color.Transparent;
            lbl_01.Font = new Font("Play", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_01.Location = new Point(12, 9);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(101, 24);
            lbl_01.TabIndex = 2;
            lbl_01.Text = "SETTINGS";
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.BackColor = Color.Transparent;
            lbl_02.Location = new Point(76, 51);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(37, 17);
            lbl_02.TabIndex = 3;
            lbl_02.Text = "Path:";
            // 
            // lbl_03
            // 
            lbl_03.AutoSize = true;
            lbl_03.BackColor = Color.Transparent;
            lbl_03.Location = new Point(67, 94);
            lbl_03.Name = "lbl_03";
            lbl_03.Size = new Size(46, 17);
            lbl_03.TabIndex = 4;
            lbl_03.Text = "Name:";
            // 
            // lbl_04
            // 
            lbl_04.AutoSize = true;
            lbl_04.BackColor = Color.Transparent;
            lbl_04.Location = new Point(59, 139);
            lbl_04.Name = "lbl_04";
            lbl_04.Size = new Size(54, 17);
            lbl_04.TabIndex = 5;
            lbl_04.Text = "Version:";
            // 
            // lbl_05
            // 
            lbl_05.AutoSize = true;
            lbl_05.BackColor = Color.Transparent;
            lbl_05.Location = new Point(63, 187);
            lbl_05.Name = "lbl_05";
            lbl_05.Size = new Size(50, 17);
            lbl_05.TabIndex = 6;
            lbl_05.Text = "Author:";
            // 
            // lbl_06
            // 
            lbl_06.AutoSize = true;
            lbl_06.BackColor = Color.Transparent;
            lbl_06.Location = new Point(36, 236);
            lbl_06.Name = "lbl_06";
            lbl_06.Size = new Size(77, 17);
            lbl_06.TabIndex = 7;
            lbl_06.Text = "CP2077 Dir:";
            // 
            // txB_06
            // 
            txB_06.Location = new Point(121, 233);
            txB_06.Name = "txB_06";
            txB_06.Size = new Size(472, 23);
            txB_06.TabIndex = 8;
            // 
            // btn_06
            // 
            btn_06.BackColor = Color.White;
            btn_06.Location = new Point(601, 226);
            btn_06.Name = "btn_06";
            btn_06.Size = new Size(144, 37);
            btn_06.TabIndex = 9;
            btn_06.Text = "Change";
            btn_06.UseVisualStyleBackColor = false;
            btn_06.Click += btn_06_Click;
            // 
            // error
            // 
            error.AutoSize = true;
            error.Location = new Point(121, 259);
            error.Name = "error";
            error.Size = new Size(0, 17);
            error.TabIndex = 10;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 510);
            Controls.Add(error);
            Controls.Add(btn_06);
            Controls.Add(txB_06);
            Controls.Add(lbl_06);
            Controls.Add(lbl_05);
            Controls.Add(lbl_04);
            Controls.Add(lbl_03);
            Controls.Add(lbl_02);
            Controls.Add(lbl_01);
            Controls.Add(btn_apply);
            Controls.Add(btn_close);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_close;
        private Button btn_apply;
        private Label lbl_01;
        private Label lbl_02;
        private Label lbl_03;
        private Label lbl_04;
        private Label lbl_05;
        private Label lbl_06;
        private TextBox txB_06;
        private Button btn_06;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label error;
    }
}