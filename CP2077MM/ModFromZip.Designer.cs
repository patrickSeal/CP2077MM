namespace CP2077MM
{
    partial class ModFromZip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModFromZip));
            btn_close = new Button();
            btn_Install = new Button();
            lbl_01 = new Label();
            lbl_02 = new Label();
            txB_01 = new TextBox();
            btn_select = new Button();
            file_dialog_select_zip = new OpenFileDialog();
            radio_standard = new RadioButton();
            radio_custom = new RadioButton();
            btn_help_01 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btn_close
            // 
            btn_close.Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_close.Location = new Point(682, 517);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(106, 47);
            btn_close.TabIndex = 3;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // btn_Install
            // 
            btn_Install.BackColor = Color.Yellow;
            btn_Install.Font = new Font("Play", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Install.Location = new Point(570, 517);
            btn_Install.Name = "btn_Install";
            btn_Install.Size = new Size(106, 47);
            btn_Install.TabIndex = 4;
            btn_Install.Text = "Install";
            btn_Install.UseVisualStyleBackColor = false;
            btn_Install.Click += btn_Install_Click;
            // 
            // lbl_01
            // 
            lbl_01.AutoSize = true;
            lbl_01.Font = new Font("Play", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_01.Location = new Point(12, 11);
            lbl_01.Name = "lbl_01";
            lbl_01.Size = new Size(287, 27);
            lbl_01.TabIndex = 5;
            lbl_01.Text = "Installing from a zip archive";
            // 
            // lbl_02
            // 
            lbl_02.AutoSize = true;
            lbl_02.Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_02.Location = new Point(73, 89);
            lbl_02.Name = "lbl_02";
            lbl_02.Size = new Size(87, 17);
            lbl_02.TabIndex = 6;
            lbl_02.Text = "Select zip file:";
            // 
            // txB_01
            // 
            txB_01.Location = new Point(166, 87);
            txB_01.Name = "txB_01";
            txB_01.Size = new Size(457, 23);
            txB_01.TabIndex = 7;
            // 
            // btn_select
            // 
            btn_select.Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_select.Location = new Point(629, 79);
            btn_select.Name = "btn_select";
            btn_select.Size = new Size(107, 39);
            btn_select.TabIndex = 8;
            btn_select.Text = "Select";
            btn_select.UseVisualStyleBackColor = true;
            btn_select.Click += btn_select_Click;
            // 
            // file_dialog_select_zip
            // 
            file_dialog_select_zip.FileName = "Select a mod archive";
            // 
            // radio_standard
            // 
            radio_standard.AutoSize = true;
            radio_standard.Location = new Point(166, 142);
            radio_standard.Name = "radio_standard";
            radio_standard.Size = new Size(144, 21);
            radio_standard.TabIndex = 9;
            radio_standard.TabStop = true;
            radio_standard.Text = "Standard Installation";
            radio_standard.UseVisualStyleBackColor = true;
            radio_standard.Click += radio_standard_Click;
            // 
            // radio_custom
            // 
            radio_custom.AutoSize = true;
            radio_custom.Location = new Point(166, 169);
            radio_custom.Name = "radio_custom";
            radio_custom.Size = new Size(136, 21);
            radio_custom.TabIndex = 10;
            radio_custom.TabStop = true;
            radio_custom.Text = "Custom Installation";
            radio_custom.UseVisualStyleBackColor = true;
            radio_custom.Click += radio_custom_Click;
            // 
            // btn_help_01
            // 
            btn_help_01.Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_help_01.Location = new Point(316, 140);
            btn_help_01.Name = "btn_help_01";
            btn_help_01.Size = new Size(25, 25);
            btn_help_01.TabIndex = 11;
            btn_help_01.Text = "?";
            btn_help_01.UseVisualStyleBackColor = true;
            btn_help_01.Click += btn_help_01_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(316, 167);
            button1.Name = "button1";
            button1.Size = new Size(25, 25);
            button1.TabIndex = 12;
            button1.Text = "?";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ModFromZip
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 578);
            Controls.Add(button1);
            Controls.Add(btn_help_01);
            Controls.Add(radio_custom);
            Controls.Add(radio_standard);
            Controls.Add(btn_select);
            Controls.Add(txB_01);
            Controls.Add(lbl_02);
            Controls.Add(lbl_01);
            Controls.Add(btn_Install);
            Controls.Add(btn_close);
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ModFromZip";
            Text = "Install mod from zip archive";
            Load += ModFromZip_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_close;
        private Button btn_Install;
        private Label lbl_01;
        private Label lbl_02;
        private TextBox txB_01;
        private Button btn_select;
        private OpenFileDialog file_dialog_select_zip;
        private RadioButton radio_standard;
        private RadioButton radio_custom;
        private Button btn_help_01;
        private Button button1;
    }
}