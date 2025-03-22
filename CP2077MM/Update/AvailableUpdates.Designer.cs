namespace CP2077MM.Update
{
    partial class AvailableUpdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableUpdates));
            lbl_01 = new Label();
            lbl_02 = new Label();
            SuspendLayout();
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.Font = new Font("Play", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_01.Location = new Point(12, 9);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(146, 27);
            lbl_01.TabIndex = 0;
            lbl_01.Text = "Mod Updates";
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.Location = new Point(12, 45);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(337, 17);
            lbl_02.TabIndex = 1;
            lbl_02.Text = "The following installed mods have released a new update:";
            // 
            // AvailableUpdates
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 510);
            Controls.Add(lbl_02);
            Controls.Add(lbl_01);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AvailableUpdates";
            Text = "Available updates";
            Load += AvailableUpdates_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_01;
        private Label lbl_02;
    }
}