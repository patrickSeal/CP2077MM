namespace CP2077MM
{
    partial class Dialog_Cyberpunk_Install
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog_Cyberpunk_Install));
            lbl_01 = new Label();
            lbl_02 = new Label();
            txB_01 = new TextBox();
            btn_01 = new Button();
            cp2077dirBrows = new FolderBrowserDialog();
            btn_ok = new Button();
            error = new Label();
            SuspendLayout();
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.Font = new Font("Play", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_01.Location = new Point(155, 15);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(386, 17);
            lbl_01.TabIndex = 0;
            lbl_01.Text = "Choom! Your Cyberpunk 2077 installation directory is not set.";
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.Location = new Point(94, 93);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(37, 17);
            lbl_02.TabIndex = 1;
            lbl_02.Text = "Path:";
            // 
            // txB_01
            // 
            txB_01.Location = new Point(137, 90);
            txB_01.Name = "txB_01";
            txB_01.Size = new Size(364, 23);
            txB_01.TabIndex = 2;
            // 
            // btn_01
            // 
            btn_01.Location = new Point(520, 82);
            btn_01.Name = "btn_01";
            btn_01.Size = new Size(145, 38);
            btn_01.TabIndex = 3;
            btn_01.Text = "Select Directory...";
            btn_01.UseVisualStyleBackColor = true;
            btn_01.Click += btn_01_Click;
            // 
            // btn_ok
            // 
            btn_ok.Location = new Point(248, 134);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new Size(201, 31);
            btn_ok.TabIndex = 4;
            btn_ok.Text = "Ok";
            btn_ok.UseVisualStyleBackColor = true;
            btn_ok.Click += btn_ok_Click;
            // 
            // error
            // 
            error.AutoSize = true;
            error.Location = new Point(167, 182);
            error.Name = "error";
            error.Size = new Size(0, 17);
            error.TabIndex = 5;
            // 
            // Dialog_Cyberpunk_Install
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(697, 208);
            Controls.Add(error);
            Controls.Add(btn_ok);
            Controls.Add(btn_01);
            Controls.Add(txB_01);
            Controls.Add(lbl_02);
            Controls.Add(lbl_01);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Dialog_Cyberpunk_Install";
            Text = "Cyberpunk Install Directory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_01;
        private Label lbl_02;
        private TextBox txB_01;
        private Button btn_01;
        private FolderBrowserDialog cp2077dirBrows;
        private Button btn_ok;
        private Label error;
    }
}