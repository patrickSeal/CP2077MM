namespace CP2077MM.Mod_Install
{
    partial class RequirementsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequirementsForm));
            lbl_01 = new Label();
            lbl_02 = new Label();
            lbl_03 = new Label();
            btn_installanyway = new Button();
            SuspendLayout();
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.Font = new Font("Play", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_01.Location = new Point(12, 9);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(138, 24);
            lbl_01.TabIndex = 0;
            lbl_01.Text = "Requirements";
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.Location = new Point(12, 42);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(481, 17);
            lbl_02.TabIndex = 1;
            lbl_02.Text = "This mod depends on the following other mods, it is suggested to install these first.";
            // 
            // lbl_03
            // 
            lbl_03.AutoSize = true;
            lbl_03.Location = new Point(12, 59);
            lbl_03.Name = "lbl_03";
            lbl_03.Size = new Size(447, 17);
            lbl_03.TabIndex = 2;
            lbl_03.Text = "The mod may not work if one ore more of the following mods is not installed.";
            // 
            // btn_installanyway
            // 
            btn_installanyway.BackColor = Color.LightCoral;
            btn_installanyway.ForeColor = Color.White;
            btn_installanyway.Location = new Point(514, 42);
            btn_installanyway.Name = "btn_installanyway";
            btn_installanyway.Size = new Size(171, 34);
            btn_installanyway.TabIndex = 3;
            btn_installanyway.Text = "Install anyway";
            btn_installanyway.UseVisualStyleBackColor = false;
            btn_installanyway.Click += btn_installanyway_Click;
            // 
            // RequirementsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(706, 761);
            Controls.Add(btn_installanyway);
            Controls.Add(lbl_03);
            Controls.Add(lbl_02);
            Controls.Add(lbl_01);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RequirementsForm";
            Text = "Requirements detected";
            FormClosing += RequirementsForm_FormClosing;
            Load += RequirementsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_01;
        private Label lbl_02;
        private Label lbl_03;
        private Button btn_installanyway;
    }
}