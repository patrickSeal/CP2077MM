namespace WinFormsApp1
{
    partial class FirstInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstInstall));
            lbl_welcome = new Label();
            installDIR = new FolderBrowserDialog();
            btn_installDir = new Button();
            btn_Install = new Button();
            txB_installDir_01 = new TextBox();
            lbl_installdir_01 = new Label();
            pictureBox1 = new PictureBox();
            lbl_apikey_01 = new Label();
            txB_apikey = new TextBox();
            btn_apikey_02 = new Button();
            lbl_help_api = new Label();
            lbl_api_help_02 = new Label();
            lbl_api_imp01 = new Label();
            lbl_api_imp02 = new Label();
            info_pers01 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lbl_welcome
            // 
            lbl_welcome.AutoSize = true;
            lbl_welcome.BackColor = SystemColors.ControlLightLight;
            lbl_welcome.Font = new Font("Play", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_welcome.ForeColor = Color.Black;
            lbl_welcome.Location = new Point(153, 21);
            lbl_welcome.Name = "lbl_welcome";
            lbl_welcome.Size = new Size(636, 41);
            lbl_welcome.TabIndex = 0;
            lbl_welcome.Text = "Welcome to the unofficial Mod Manager for";
            lbl_welcome.Click += label1_Click;
            // 
            // installDIR
            // 
            installDIR.Description = "Select the Installation directory";
            installDIR.OkRequiresInteraction = true;
            installDIR.ShowHiddenFiles = true;
            installDIR.UseDescriptionForTitle = true;
            installDIR.HelpRequest += installDIR_HelpRequest;
            // 
            // btn_installDir
            // 
            btn_installDir.Location = new Point(649, 185);
            btn_installDir.Name = "btn_installDir";
            btn_installDir.Size = new Size(172, 40);
            btn_installDir.TabIndex = 1;
            btn_installDir.Text = "Select Directory...";
            btn_installDir.UseVisualStyleBackColor = true;
            btn_installDir.Click += button1_Click;
            // 
            // btn_Install
            // 
            btn_Install.BackColor = Color.White;
            btn_Install.Font = new Font("Play", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Install.Location = new Point(219, 392);
            btn_Install.Name = "btn_Install";
            btn_Install.Size = new Size(459, 77);
            btn_Install.TabIndex = 2;
            btn_Install.Text = "Install";
            btn_Install.UseVisualStyleBackColor = false;
            btn_Install.Click += btn_Install_Click;
            // 
            // txB_installDir_01
            // 
            txB_installDir_01.Location = new Point(270, 194);
            txB_installDir_01.Name = "txB_installDir_01";
            txB_installDir_01.Size = new Size(373, 23);
            txB_installDir_01.TabIndex = 3;
            // 
            // lbl_installdir_01
            // 
            lbl_installdir_01.AutoSize = true;
            lbl_installdir_01.Location = new Point(68, 197);
            lbl_installdir_01.Name = "lbl_installdir_01";
            lbl_installdir_01.Size = new Size(196, 17);
            lbl_installdir_01.TabIndex = 4;
            lbl_installdir_01.Text = "Select a directory for installation:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(235, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(443, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // lbl_apikey_01
            // 
            lbl_apikey_01.AutoSize = true;
            lbl_apikey_01.Location = new Point(68, 253);
            lbl_apikey_01.Name = "lbl_apikey_01";
            lbl_apikey_01.Size = new Size(174, 17);
            lbl_apikey_01.TabIndex = 6;
            lbl_apikey_01.Text = "Add your NexusMods API key:";
            // 
            // txB_apikey
            // 
            txB_apikey.Location = new Point(270, 250);
            txB_apikey.Name = "txB_apikey";
            txB_apikey.Size = new Size(373, 23);
            txB_apikey.TabIndex = 7;
            // 
            // btn_apikey_02
            // 
            btn_apikey_02.Location = new Point(649, 242);
            btn_apikey_02.Name = "btn_apikey_02";
            btn_apikey_02.Size = new Size(172, 40);
            btn_apikey_02.TabIndex = 8;
            btn_apikey_02.Text = "Retrieve API key...";
            btn_apikey_02.UseVisualStyleBackColor = true;
            btn_apikey_02.Click += btn_apikey_02_Click;
            // 
            // lbl_help_api
            // 
            lbl_help_api.AutoSize = true;
            lbl_help_api.Location = new Point(83, 290);
            lbl_help_api.Name = "lbl_help_api";
            lbl_help_api.Size = new Size(748, 17);
            lbl_help_api.TabIndex = 9;
            lbl_help_api.Text = "Info: To add your NexusMods API key go to the website linked by \"Retrieve API key...\" or go to  nexusmods.com -> Site preferences";
            // 
            // lbl_api_help_02
            // 
            lbl_api_help_02.AutoSize = true;
            lbl_api_help_02.Location = new Point(111, 307);
            lbl_api_help_02.Name = "lbl_api_help_02";
            lbl_api_help_02.Size = new Size(565, 17);
            lbl_api_help_02.TabIndex = 10;
            lbl_api_help_02.Text = "-> API Keys, than scroll to \"Personal API Key\". There you can generate a new one and paste it here.";
            // 
            // lbl_api_imp01
            // 
            lbl_api_imp01.AutoSize = true;
            lbl_api_imp01.ForeColor = Color.Maroon;
            lbl_api_imp01.Location = new Point(131, 336);
            lbl_api_imp01.Name = "lbl_api_imp01";
            lbl_api_imp01.Size = new Size(82, 17);
            lbl_api_imp01.TabIndex = 11;
            lbl_api_imp01.Text = "IMPORTANT:";
            // 
            // lbl_api_imp02
            // 
            lbl_api_imp02.AutoSize = true;
            lbl_api_imp02.Location = new Point(219, 336);
            lbl_api_imp02.Name = "lbl_api_imp02";
            lbl_api_imp02.Size = new Size(559, 17);
            lbl_api_imp02.TabIndex = 12;
            lbl_api_imp02.Text = "If you change your API key at any time you have to change it in the mod manager settings as well.";
            // 
            // info_pers01
            // 
            info_pers01.AutoSize = true;
            info_pers01.Location = new Point(131, 508);
            info_pers01.Name = "info_pers01";
            info_pers01.Size = new Size(621, 17);
            info_pers01.TabIndex = 13;
            info_pers01.Text = "Thank you for using my mod manager for CP2077, if there are any issues please leave a request on GitHub.";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(419, 529);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(52, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // FirstInstall
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(910, 591);
            Controls.Add(pictureBox2);
            Controls.Add(info_pers01);
            Controls.Add(lbl_api_imp02);
            Controls.Add(lbl_api_imp01);
            Controls.Add(lbl_api_help_02);
            Controls.Add(lbl_help_api);
            Controls.Add(btn_apikey_02);
            Controls.Add(txB_apikey);
            Controls.Add(lbl_apikey_01);
            Controls.Add(pictureBox1);
            Controls.Add(lbl_installdir_01);
            Controls.Add(txB_installDir_01);
            Controls.Add(btn_Install);
            Controls.Add(btn_installDir);
            Controls.Add(lbl_welcome);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FirstInstall";
            Text = "Cyberpunk 2077 Mod Manager";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_welcome;
        private FolderBrowserDialog installDIR;
        private Button btn_installDir;
        private Button btn_Install;
        private TextBox txB_installDir_01;
        private Label lbl_installdir_01;
        private PictureBox pictureBox1;
        private Label lbl_apikey_01;
        private TextBox txB_apikey;
        private Button btn_apikey_02;
        private Label lbl_help_api;
        private Label lbl_api_help_02;
        private Label lbl_api_imp01;
        private Label lbl_api_imp02;
        private Label info_pers01;
        private PictureBox pictureBox2;
    }
}