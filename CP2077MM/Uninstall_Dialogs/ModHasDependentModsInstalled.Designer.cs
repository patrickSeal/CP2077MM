namespace CP2077MM.Uninstall_Dialogs
{
    partial class ModHasDependentModsInstalled
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModHasDependentModsInstalled));
            btn_deleteAnyway = new Button();
            lbl_warning = new Label();
            lbl_01 = new Label();
            btn_cancel = new Button();
            lbl_02 = new Label();
            SuspendLayout();
            // 
            // btn_deleteAnyway
            // 
            btn_deleteAnyway.BackColor = Color.LightCoral;
            btn_deleteAnyway.Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_deleteAnyway.Location = new Point(619, 9);
            btn_deleteAnyway.Name = "btn_deleteAnyway";
            btn_deleteAnyway.Size = new Size(169, 40);
            btn_deleteAnyway.TabIndex = 0;
            btn_deleteAnyway.Text = "Uninstall Anyway";
            btn_deleteAnyway.UseVisualStyleBackColor = false;
            btn_deleteAnyway.Click += btn_deleteAnyway_Click;
            // 
            // lbl_warning
            // 
            lbl_warning.AutoSize = true;
            lbl_warning.Font = new Font("Play", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_warning.Location = new Point(12, 13);
            lbl_warning.Name = "lbl_warning";
            lbl_warning.Size = new Size(118, 30);
            lbl_warning.TabIndex = 1;
            lbl_warning.Text = "Warning!";
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.Location = new Point(12, 53);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(569, 17);
            lbl_01.TabIndex = 2;
            lbl_01.Text = "You are about to install a mod that other mods depend on, these may not work properly anymore!";
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.PaleGreen;
            btn_cancel.Font = new Font("Play", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancel.Location = new Point(444, 9);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(169, 40);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.Location = new Point(12, 70);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(576, 17);
            lbl_02.TabIndex = 4;
            lbl_02.Text = "Please make sure to uninstall the other mods first or some directories may not be deleted properly.";
            // 
            // ModHasDependentModsInstalled
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 510);
            Controls.Add(lbl_02);
            Controls.Add(btn_cancel);
            Controls.Add(lbl_01);
            Controls.Add(lbl_warning);
            Controls.Add(btn_deleteAnyway);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModHasDependentModsInstalled";
            Text = "Other mods depend on this mod!";
            Load += ModHasDependentModsInstalled_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_deleteAnyway;
        private Label lbl_warning;
        private Label lbl_01;
        private Button btn_cancel;
        private Label lbl_02;
    }
}