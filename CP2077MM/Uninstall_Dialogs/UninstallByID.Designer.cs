namespace CP2077MM.Uninstall_Dialogs
{
    partial class UninstallByID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UninstallByID));
            lbl_01 = new Label();
            lbl_02 = new Label();
            txB_02 = new TextBox();
            btn_uninstall = new Button();
            btn_close = new Button();
            SuspendLayout();
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.Font = new Font("Play", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_01.ForeColor = Color.Black;
            lbl_01.Location = new Point(12, 9);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(378, 27);
            lbl_01.TabIndex = 0;
            lbl_01.Text = "Uninstall a mod by its NexusMods ID";
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.ForeColor = Color.Black;
            lbl_02.Location = new Point(84, 76);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(55, 17);
            lbl_02.TabIndex = 1;
            lbl_02.Text = "mod_id:";
            // 
            // txB_02
            // 
            txB_02.BackColor = SystemColors.ControlLightLight;
            txB_02.ForeColor = Color.Red;
            txB_02.Location = new Point(145, 73);
            txB_02.Name = "txB_02";
            txB_02.Size = new Size(144, 23);
            txB_02.TabIndex = 2;
            txB_02.Text = "*mod_id*";
            // 
            // btn_uninstall
            // 
            btn_uninstall.Font = new Font("Play", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_uninstall.Location = new Point(202, 180);
            btn_uninstall.Name = "btn_uninstall";
            btn_uninstall.Size = new Size(94, 43);
            btn_uninstall.TabIndex = 3;
            btn_uninstall.Text = "Uninstall";
            btn_uninstall.UseVisualStyleBackColor = true;
            btn_uninstall.Click += btn_uninstall_Click;
            // 
            // btn_close
            // 
            btn_close.Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_close.Location = new Point(302, 180);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(94, 43);
            btn_close.TabIndex = 4;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // UninstallByID
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(408, 235);
            Controls.Add(btn_close);
            Controls.Add(btn_uninstall);
            Controls.Add(txB_02);
            Controls.Add(lbl_02);
            Controls.Add(lbl_01);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UninstallByID";
            Text = "Uninstall mod by ID";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_01;
        private Label lbl_02;
        private TextBox txB_02;
        private Button btn_uninstall;
        private Button btn_close;
    }
}