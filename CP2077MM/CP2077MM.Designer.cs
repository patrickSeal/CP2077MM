﻿using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class CP2077MM
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP2077MM));
            img_cyberpunk = new PictureBox();
            lbl_premium = new Label();
            img_github = new PictureBox();
            lbl_premium_indicator = new Label();
            fileToolStripMenuItem = new ToolStripMenuItem();
            menu_install_zip = new ToolStripMenuItem();
            menu_install_file = new ToolStripMenuItem();
            browseModsToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            updateSingleModToolStripMenuItem = new ToolStripMenuItem();
            updateAllModsToolStripMenuItem = new ToolStripMenuItem();
            installedModsToolStripMenuItem = new ToolStripMenuItem();
            menu_installed_load = new ToolStripMenuItem();
            uninstallModByIDToolStripMenuItem = new ToolStripMenuItem();
            checkDependenciesToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            menu_user = new ToolStripMenuItem();
            menu_user_profile = new ToolStripMenuItem();
            menu_user_settings = new ToolStripMenuItem();
            chippinInToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            modView = new TreeView();
            lbl_modView = new Label();
            btn_view_refresh = new Button();
            ((System.ComponentModel.ISupportInitialize)img_cyberpunk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)img_github).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // img_cyberpunk
            // 
            img_cyberpunk.BackColor = Color.WhiteSmoke;
            img_cyberpunk.Image = (Image)resources.GetObject("img_cyberpunk.Image");
            img_cyberpunk.Location = new Point(1518, 0);
            img_cyberpunk.Name = "img_cyberpunk";
            img_cyberpunk.Size = new Size(234, 44);
            img_cyberpunk.SizeMode = PictureBoxSizeMode.StretchImage;
            img_cyberpunk.TabIndex = 2;
            img_cyberpunk.TabStop = false;
            img_cyberpunk.Click += img_cyberpunk_Click;
            img_cyberpunk.MouseLeave += img_cyberpunk_MouseLeave;
            img_cyberpunk.MouseHover += img_cyberpunk_MouseHover;
            // 
            // lbl_premium
            // 
            lbl_premium.AutoSize = true;
            lbl_premium.BackColor = Color.WhiteSmoke;
            lbl_premium.Font = new Font("Play", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_premium.Location = new Point(1207, 12);
            lbl_premium.Name = "lbl_premium";
            lbl_premium.Size = new Size(82, 21);
            lbl_premium.TabIndex = 3;
            lbl_premium.Text = "Premium:";
            // 
            // img_github
            // 
            img_github.BackColor = Color.WhiteSmoke;
            img_github.Image = (Image)resources.GetObject("img_github.Image");
            img_github.Location = new Point(1467, 0);
            img_github.Name = "img_github";
            img_github.Size = new Size(43, 43);
            img_github.SizeMode = PictureBoxSizeMode.StretchImage;
            img_github.TabIndex = 4;
            img_github.TabStop = false;
            img_github.Click += img_github_Click;
            img_github.MouseLeave += img_github_MouseLeave;
            img_github.MouseHover += img_github_MouseHover;
            // 
            // lbl_premium_indicator
            // 
            lbl_premium_indicator.AutoSize = true;
            lbl_premium_indicator.BackColor = Color.WhiteSmoke;
            lbl_premium_indicator.Font = new Font("Play", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_premium_indicator.Location = new Point(1289, 12);
            lbl_premium_indicator.Name = "lbl_premium_indicator";
            lbl_premium_indicator.Size = new Size(171, 21);
            lbl_premium_indicator.TabIndex = 6;
            lbl_premium_indicator.Text = "Don't have the eddies!";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor = Color.Transparent;
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menu_install_zip, menu_install_file, browseModsToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = SystemColors.ActiveCaptionText;
            fileToolStripMenuItem.Image = (Image)resources.GetObject("fileToolStripMenuItem.Image");
            fileToolStripMenuItem.ImageTransparentColor = Color.White;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(120, 28);
            fileToolStripMenuItem.Text = "Install Mods";
            // 
            // menu_install_zip
            // 
            menu_install_zip.BackColor = Color.Transparent;
            menu_install_zip.Image = (Image)resources.GetObject("menu_install_zip.Image");
            menu_install_zip.Name = "menu_install_zip";
            menu_install_zip.Size = new Size(315, 24);
            menu_install_zip.Text = "Install from Zip Archive";
            menu_install_zip.Click += menu_install_zip_Click;
            // 
            // menu_install_file
            // 
            menu_install_file.BackColor = Color.Transparent;
            menu_install_file.Image = (Image)resources.GetObject("menu_install_file.Image");
            menu_install_file.Name = "menu_install_file";
            menu_install_file.Size = new Size(315, 24);
            menu_install_file.Text = "Install Standalone Files/Directories";
            // 
            // browseModsToolStripMenuItem
            // 
            browseModsToolStripMenuItem.BackColor = Color.White;
            browseModsToolStripMenuItem.Image = (Image)resources.GetObject("browseModsToolStripMenuItem.Image");
            browseModsToolStripMenuItem.Name = "browseModsToolStripMenuItem";
            browseModsToolStripMenuItem.Size = new Size(315, 24);
            browseModsToolStripMenuItem.Text = "Browse Mods";
            browseModsToolStripMenuItem.Click += browseModsToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { updateSingleModToolStripMenuItem, updateAllModsToolStripMenuItem });
            updateToolStripMenuItem.Image = (Image)resources.GetObject("updateToolStripMenuItem.Image");
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(128, 28);
            updateToolStripMenuItem.Text = "Update Mods";
            // 
            // updateSingleModToolStripMenuItem
            // 
            updateSingleModToolStripMenuItem.Name = "updateSingleModToolStripMenuItem";
            updateSingleModToolStripMenuItem.Size = new Size(208, 24);
            updateSingleModToolStripMenuItem.Text = "Update Single Mod";
            // 
            // updateAllModsToolStripMenuItem
            // 
            updateAllModsToolStripMenuItem.Name = "updateAllModsToolStripMenuItem";
            updateAllModsToolStripMenuItem.Size = new Size(208, 24);
            updateAllModsToolStripMenuItem.Text = "Update All Mods";
            // 
            // installedModsToolStripMenuItem
            // 
            installedModsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menu_installed_load, uninstallModByIDToolStripMenuItem, checkDependenciesToolStripMenuItem });
            installedModsToolStripMenuItem.Image = (Image)resources.GetObject("installedModsToolStripMenuItem.Image");
            installedModsToolStripMenuItem.Name = "installedModsToolStripMenuItem";
            installedModsToolStripMenuItem.Size = new Size(137, 28);
            installedModsToolStripMenuItem.Text = "Installed Mods";
            // 
            // menu_installed_load
            // 
            menu_installed_load.Image = (Image)resources.GetObject("menu_installed_load.Image");
            menu_installed_load.Name = "menu_installed_load";
            menu_installed_load.Size = new Size(217, 24);
            menu_installed_load.Text = "Load Installed Mods";
            menu_installed_load.Click += menu_installed_load_Click;
            // 
            // uninstallModByIDToolStripMenuItem
            // 
            uninstallModByIDToolStripMenuItem.Image = (Image)resources.GetObject("uninstallModByIDToolStripMenuItem.Image");
            uninstallModByIDToolStripMenuItem.Name = "uninstallModByIDToolStripMenuItem";
            uninstallModByIDToolStripMenuItem.Size = new Size(217, 24);
            uninstallModByIDToolStripMenuItem.Text = "Uninstall Mod by ID";
            uninstallModByIDToolStripMenuItem.Click += uninstallModByIDToolStripMenuItem_Click;
            // 
            // checkDependenciesToolStripMenuItem
            // 
            checkDependenciesToolStripMenuItem.Name = "checkDependenciesToolStripMenuItem";
            checkDependenciesToolStripMenuItem.Size = new Size(217, 24);
            checkDependenciesToolStripMenuItem.Text = "Check Dependencies";
            checkDependenciesToolStripMenuItem.Click += checkDependenciesToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.BackColor = Color.Transparent;
            helpToolStripMenuItem.Image = (Image)resources.GetObject("helpToolStripMenuItem.Image");
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(69, 28);
            helpToolStripMenuItem.Text = "Help";
            // 
            // menu_user
            // 
            menu_user.BackColor = Color.Transparent;
            menu_user.DropDownItems.AddRange(new ToolStripItem[] { menu_user_profile, menu_user_settings });
            menu_user.Image = (Image)resources.GetObject("menu_user.Image");
            menu_user.Name = "menu_user";
            menu_user.Size = new Size(85, 28);
            menu_user.Text = "Choom";
            // 
            // menu_user_profile
            // 
            menu_user_profile.Image = (Image)resources.GetObject("menu_user_profile.Image");
            menu_user_profile.Name = "menu_user_profile";
            menu_user_profile.Size = new Size(136, 24);
            menu_user_profile.Text = "Profile";
            menu_user_profile.Click += menu_user_profile_Click;
            // 
            // menu_user_settings
            // 
            menu_user_settings.Image = (Image)resources.GetObject("menu_user_settings.Image");
            menu_user_settings.Name = "menu_user_settings";
            menu_user_settings.Size = new Size(136, 24);
            menu_user_settings.Text = "Settings";
            menu_user_settings.Click += menu_user_settings_Click;
            // 
            // chippinInToolStripMenuItem
            // 
            chippinInToolStripMenuItem.BackColor = Color.Yellow;
            chippinInToolStripMenuItem.Font = new Font("Play", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chippinInToolStripMenuItem.Name = "chippinInToolStripMenuItem";
            chippinInToolStripMenuItem.Size = new Size(114, 28);
            chippinInToolStripMenuItem.Text = "Chippin' in";
            chippinInToolStripMenuItem.Click += chippinInToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.WhiteSmoke;
            menuStrip1.Font = new Font("Play", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, updateToolStripMenuItem, installedModsToolStripMenuItem, helpToolStripMenuItem, menu_user, chippinInToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10);
            menuStrip1.Size = new Size(1754, 48);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // modView
            // 
            modView.BackColor = SystemColors.ButtonHighlight;
            modView.Location = new Point(12, 90);
            modView.Name = "modView";
            modView.Size = new Size(263, 761);
            modView.TabIndex = 7;
            // 
            // lbl_modView
            // 
            lbl_modView.AutoSize = true;
            lbl_modView.BackColor = Color.Transparent;
            lbl_modView.Font = new Font("Play", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_modView.Location = new Point(12, 54);
            lbl_modView.Name = "lbl_modView";
            lbl_modView.Size = new Size(188, 30);
            lbl_modView.TabIndex = 8;
            lbl_modView.Text = "Installed Mods:";
            // 
            // btn_view_refresh
            // 
            btn_view_refresh.Font = new Font("Play", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_view_refresh.Location = new Point(200, 53);
            btn_view_refresh.Name = "btn_view_refresh";
            btn_view_refresh.Size = new Size(75, 36);
            btn_view_refresh.TabIndex = 9;
            btn_view_refresh.Text = "Refresh";
            btn_view_refresh.UseVisualStyleBackColor = false;
            btn_view_refresh.Click += btn_view_refresh_Click;
            // 
            // CP2077MM
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1754, 863);
            Controls.Add(btn_view_refresh);
            Controls.Add(lbl_modView);
            Controls.Add(modView);
            Controls.Add(lbl_premium_indicator);
            Controls.Add(img_github);
            Controls.Add(lbl_premium);
            Controls.Add(img_cyberpunk);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            Font = new Font("Play", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CP2077MM";
            Text = "Cyberpunk 2077 Mod Manager";
            FormClosed += CP2077MM_FormClosed;
            Load += CP2077MM_LoadAsync;
            ((System.ComponentModel.ISupportInitialize)img_cyberpunk).EndInit();
            ((System.ComponentModel.ISupportInitialize)img_github).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox img_cyberpunk;
        private Label lbl_premium;
        private PictureBox img_github;
        private Label lbl_premium_indicator;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem menu_install_zip;
        private ToolStripMenuItem menu_install_file;
        private ToolStripMenuItem browseModsToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem updateSingleModToolStripMenuItem;
        private ToolStripMenuItem updateAllModsToolStripMenuItem;
        private ToolStripMenuItem installedModsToolStripMenuItem;
        private ToolStripMenuItem menu_installed_load;
        private ToolStripMenuItem uninstallModByIDToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem menu_user;
        private ToolStripMenuItem menu_user_profile;
        private ToolStripMenuItem menu_user_settings;
        private ToolStripMenuItem chippinInToolStripMenuItem;
        private MenuStrip menuStrip1;
        private TreeView modView;
        private Label lbl_modView;
        private Button btn_view_refresh;
        private ToolStripMenuItem checkDependenciesToolStripMenuItem;
    }
}
