namespace CP2077MM
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            btn_apply = new Button();
            btn_close = new Button();
            lbl_01 = new Label();
            lbl_02 = new Label();
            lbl_03 = new Label();
            lbl_04 = new Label();
            lbl_05 = new Label();
            btn_profile = new Button();
            lbl_07 = new Label();
            txB_02 = new TextBox();
            btn_sync = new Button();
            error_lbl = new Label();
            cB_01 = new CheckBox();
            SuspendLayout();
            // 
            // btn_apply
            // 
            btn_apply.Location = new Point(568, 457);
            btn_apply.Name = "btn_apply";
            btn_apply.Size = new Size(108, 41);
            btn_apply.TabIndex = 3;
            btn_apply.Text = "Apply";
            btn_apply.UseVisualStyleBackColor = true;
            btn_apply.Click += btn_apply_Click;
            // 
            // btn_close
            // 
            btn_close.Location = new Point(682, 457);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(106, 41);
            btn_close.TabIndex = 2;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.BackColor = Color.Transparent;
            lbl_01.Font = new Font("Play", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_01.Location = new Point(12, 9);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(77, 21);
            lbl_01.TabIndex = 4;
            lbl_01.Text = "PROFILE";
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.BackColor = Color.Transparent;
            lbl_02.Location = new Point(50, 57);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(123, 17);
            lbl_02.TabIndex = 5;
            lbl_02.Text = "Nexusmods API Key:";
            // 
            // lbl_03
            // 
            lbl_03.AutoSize = true;
            lbl_03.BackColor = Color.Transparent;
            lbl_03.Location = new Point(102, 106);
            lbl_03.Name = "lbl_03";
            lbl_03.Size = new Size(71, 17);
            lbl_03.TabIndex = 6;
            lbl_03.Text = "Username:";
            // 
            // lbl_04
            // 
            lbl_04.AutoSize = true;
            lbl_04.BackColor = Color.Transparent;
            lbl_04.Location = new Point(109, 155);
            lbl_04.Name = "lbl_04";
            lbl_04.Size = new Size(64, 17);
            lbl_04.TabIndex = 7;
            lbl_04.Text = "Premium:";
            // 
            // lbl_05
            // 
            lbl_05.AutoSize = true;
            lbl_05.BackColor = Color.Transparent;
            lbl_05.Location = new Point(129, 205);
            lbl_05.Name = "lbl_05";
            lbl_05.Size = new Size(44, 17);
            lbl_05.TabIndex = 8;
            lbl_05.Text = "Email:";
            // 
            // btn_profile
            // 
            btn_profile.Location = new Point(394, 457);
            btn_profile.Name = "btn_profile";
            btn_profile.Size = new Size(168, 41);
            btn_profile.TabIndex = 9;
            btn_profile.Text = "Go to Nexusmods Profile";
            btn_profile.UseVisualStyleBackColor = true;
            btn_profile.Click += btn_profile_Click;
            // 
            // lbl_07
            // 
            lbl_07.AutoSize = true;
            lbl_07.BackColor = Color.Transparent;
            lbl_07.Font = new Font("Play", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_07.Location = new Point(178, 155);
            lbl_07.Name = "lbl_07";
            lbl_07.Size = new Size(144, 17);
            lbl_07.TabIndex = 10;
            lbl_07.Text = "Don't have the eddies!";
            // 
            // txB_02
            // 
            txB_02.Location = new Point(179, 54);
            txB_02.Name = "txB_02";
            txB_02.Size = new Size(444, 23);
            txB_02.TabIndex = 11;
            // 
            // btn_sync
            // 
            btn_sync.BackColor = Color.Transparent;
            btn_sync.BackgroundImage = (Image)resources.GetObject("btn_sync.BackgroundImage");
            btn_sync.BackgroundImageLayout = ImageLayout.Stretch;
            btn_sync.Location = new Point(330, 146);
            btn_sync.Name = "btn_sync";
            btn_sync.Size = new Size(35, 35);
            btn_sync.TabIndex = 12;
            btn_sync.UseVisualStyleBackColor = false;
            btn_sync.Click += btn_sync_Click;
            // 
            // error_lbl
            // 
            error_lbl.AutoSize = true;
            error_lbl.BackColor = Color.Transparent;
            error_lbl.Location = new Point(179, 80);
            error_lbl.Name = "error_lbl";
            error_lbl.Size = new Size(0, 17);
            error_lbl.TabIndex = 13;
            // 
            // cB_01
            // 
            cB_01.AutoSize = true;
            cB_01.BackColor = Color.Transparent;
            cB_01.Location = new Point(50, 249);
            cB_01.Name = "cB_01";
            cB_01.Size = new Size(209, 21);
            cB_01.TabIndex = 14;
            cB_01.Text = "Enable automatic update check";
            cB_01.TextAlign = ContentAlignment.TopLeft;
            cB_01.UseVisualStyleBackColor = false;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 510);
            Controls.Add(cB_01);
            Controls.Add(error_lbl);
            Controls.Add(btn_sync);
            Controls.Add(txB_02);
            Controls.Add(lbl_07);
            Controls.Add(btn_profile);
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
            Name = "Profile";
            Text = "Profile";
            Load += Profile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_apply;
        private Button btn_close;
        private Label lbl_01;
        private Label lbl_02;
        private Label lbl_03;
        private Label lbl_04;
        private Label lbl_05;
        private Button btn_profile;
        private Label lbl_07;
        private TextBox txB_02;
        private Button btn_sync;
        private Label error_lbl;
        private CheckBox cB_01;
    }
}