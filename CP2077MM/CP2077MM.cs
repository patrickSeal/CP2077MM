using CP2077MM;
using CP2077MM.CP2077MM_Files;
using CP2077MM.Integrity;
using CP2077MM.Uninstall_Dialogs;
using CP2077MM.Update;
using CP2077MM.WPF;
using System.IO;


namespace WinFormsApp1
{
    public partial class CP2077MM : Form
    {

        public CP2077MM()
        {
            InitializeComponent();

        }
        // =====================================================================================
        /**
         * Form
         */
        private async void CP2077MM_LoadAsync(object sender, EventArgs e)
        {
            pgB_main.Visible = false;
            lbl_update.Text = "";
            /**
             * Check for Cyberpunk 2077 Installation Directory
             */
            if (MainProgram.SETTINGS_FILE.cyberpunk_install_dir.Equals(Constants.UNKNOWN_STRING))
            {
                Dialog_Cyberpunk_Install cpinst = new Dialog_Cyberpunk_Install();
                cpinst.ShowDialog();
            }


            if (MainProgram.PROFILE_FILE.is_premium)
            {
                lbl_premium_indicator.Text = "Active";
                lbl_premium_indicator.ForeColor = Color.DarkGreen;
            }

            updateModTree();

            // Check for auto updates
            if (MainProgram.PROFILE_FILE.auto_update_check)
            {
                Update update = new Update(pgB_main);
                List<(ModEntry, ModEntry)> entries = await update.getUpdates();
                if (entries.Count != 0)
                {
                    AvailableUpdates availableUpdates = new AvailableUpdates(entries);
                    availableUpdates.ShowDialog();
                }
            }
            // Check for Mod Manager updates
            APIConnection con = new APIConnection(MainProgram.PROFILE_FILE.apikey);
            Mod manager = await con.MODS_GET_retrieveMod("20439");
            Console.WriteLine(manager.version + " | " + MainProgram.SETTINGS_FILE.version);
            if (manager.version.Equals(MainProgram.SETTINGS_FILE.version))
            {
                lbl_update.Text = "";
            }
            else
            {
                lbl_update.Text = "Update available!";
            }
        }

        private void updateModTree()
        {
            ModIndex modIndex = ModIndex.OpenModIndex();
            List<ModEntry> modlist = modIndex.getEntries();
            modView.BeginUpdate();
            modView.Nodes.Clear();
            int i = 0;
            foreach (ModEntry mod in modlist)
            {
                modView.Nodes.Add(mod.name);
                modView.Nodes[i].Nodes.Add("version: " + mod.version);
                modView.Nodes[i].Nodes.Add("ID: " + mod.mod_id);
                i++;
            }
            modView.EndUpdate();
        }

        private void CP2077MM_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Saveing files.
            FileHandler.updateJSON_FILE(Constants.FILE_SETTINGS_PATH, MainProgram.SETTINGS_FILE);
            FileHandler.updateJSON_FILE(MainProgram.PROFILE_FILE_PATH, MainProgram.PROFILE_FILE);
        }
        // =====================================================================================
        /*
         * Link to the official Cyberpunk 2077 website
         */
        private void img_cyberpunk_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = Constants.CYBERPUNK2077_NET,
                UseShellExecute = true
            });
        }

        private void img_cyberpunk_MouseHover(object sender, EventArgs e)
        {
            img_cyberpunk.Cursor = Cursors.Hand;
        }

        private void img_cyberpunk_MouseLeave(object sender, EventArgs e)
        {
            img_cyberpunk.Cursor = Cursors.Default;
        }

        // =====================================================================================
        /**
         * Github Image
         */
        private void img_github_MouseHover(object sender, EventArgs e)
        {
            img_github.Cursor = Cursors.Hand;
        }

        private void img_github_MouseLeave(object sender, EventArgs e)
        {
            img_github.Cursor = Cursors.Default;
        }

        private void img_github_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = Constants.GIT_REPO,
                UseShellExecute = true
            });
        }

        // =====================================================================================
        // Menu Items

        /**
         * Used for changing profile information
         */
        private void menu_user_profile_Click(object sender, EventArgs e)
        {
            Profile profile_Form = new Profile();
            profile_Form.ShowDialog();
        }

        /*
         * Used for changing app settings
         */
        private void menu_user_settings_Click(object sender, EventArgs e)
        {
            Settings settings_Form = new Settings();
            settings_Form.ShowDialog();
        }
        /*
         * Installs a new mod from a zip file
         */
        private void menu_install_zip_Click(object sender, EventArgs e)
        {
            ModFromArchive modFromZip_Form = new ModFromArchive(pgB_main);
            modFromZip_Form.ShowDialog();
            updateModTree();
        }

        private void uninstallModByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UninstallByID uninstallByID = new UninstallByID(pgB_main);
            uninstallByID.ShowDialog();
            updateModTree();
        }

        private void menu_installed_load_Click(object sender, EventArgs e)
        {
            loadInstalledMods();
        }

        private void loadInstalledMods()
        {
            updateModTree();
        }

        private void chippinInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = Path.Combine(MainProgram.SETTINGS_FILE.cyberpunk_install_dir, "REDprelauncher.exe"),
                UseShellExecute = true
            });
        }

        private void installedModsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btn_view_refresh_Click(object sender, EventArgs e)
        {
            updateModTree();
        }

        private void browseModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = @"https://www.nexusmods.com/games/cyberpunk2077/mods",
                UseShellExecute = true
            });
        }

        private void checkDependenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dependencies deps = new Dependencies();
            deps.checkRequirements();
            var reqs = deps.getMissingReqs();
            if (reqs.Count == 0)
            {
                MessageBox.Show("All requirements are satisfied choom!", "Info");
                return;
            }
            var result = MessageBox.Show("Requirements check was done. Do you want to see which mods are missing?", "Info", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MissingRequirements mRform = new MissingRequirements(reqs, pgB_main);
                mRform.ShowDialog();
            }
        }

        private void updateAllModsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /*
         * Shows the mods that need an update
         */
        private async void checkForUpdatedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update update = new Update(pgB_main);
            List<(ModEntry, ModEntry)> entries = await update.getUpdates();
            if (entries.Count == 0)
            {
                MessageBox.Show("All your mods are up to date choom!", "Update Info");
            }
            else
            {
                AvailableUpdates availableUpdates = new AvailableUpdates(entries);
                availableUpdates.ShowDialog();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = @"https://github.com/patrickSeal/CP2077MM/wiki",
                UseShellExecute = true
            });
        }

        private void lbl_update_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = @"https://www.nexusmods.com/cyberpunk2077/mods/20439?tab=files",
                UseShellExecute = true
            });
        }

        private void modView_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        /**
        * Opens a Mouse menu to give options for a mod
        * 
        */
        private void modView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                modView.SelectedNode = e.Node;
                if (e.Node == null)
                {
                    Error.UnexpectedError("CP2077MM.modView_NodeMouseClick() - e.Node was NULL");
                    return;
                }
                e.Node.ContextMenuStrip = mod_context;
                mod_context.Visible = true;
            }
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (modView.SelectedNode == null)
            {
                Error.UnexpectedError("CP2077MM.uninstallToolStripMenuItem_Click() - modView.SelectedNode was NULL");
                return;
            }
            if (modView.SelectedNode.FirstNode == null)
            {
                Error.UnexpectedError("CP2077MM.uninstallToolStripMenuItem_Click() - modView.SelectedNode.FirstNode was NULL");
                return;
            }
            if (modView.SelectedNode.FirstNode.NextNode == null)
            {
                Error.UnexpectedError("CP2077MM.uninstallToolStripMenuItem_Click() - modView.SelectedNode.FirstNode.NextNode was NULL");
                return;
            }
            TreeNode id = modView.SelectedNode.FirstNode.NextNode;
            long mod_id = Int64.Parse(id.Text.Substring(3));
            ModHandling.MOD_DELETE(mod_id, pgB_main);
            updateModTree();
        }

        private void profileCyberpunk2077ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Hey choom! Creating a profile of Cyberpunk2077 should only be done on a completely unmodded install. If your installation is modded, this can lead to mods being not properly deleted! Are you sure you want to continue?", "Not so fast choom!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Profiler profiler = new Profiler();
                profiler.profileCyberpunk2077();
            }
        }

        private void menu_install_file_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
