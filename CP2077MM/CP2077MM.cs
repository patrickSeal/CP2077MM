using CP2077MM;
using CP2077MM.CP2077MM_Files;
using CP2077MM.Integrity;
using CP2077MM.Mod_Install;
using CP2077MM.Uninstall_Dialogs;
using CP2077MM.Web;
using System.Drawing.Imaging;
using static System.Net.WebRequestMethods;

namespace WinFormsApp1
{
    public partial class CP2077MM : Form
    {
        string selectedTreeNode;

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
            //APIConnection con = new APIConnection("M0wlumMY6lzMJfgDa7oSjo4U/FGzRN35BGYHFp9FwPTqQVQPYFq+Mncs4w==--DLbZRJxQv9VUpdS1--ro5le+A+jqCcv3ipUhGuzg==");
            //await con.MODFILES_GET_files("19991", "main");
            //await con.MODFILES_GET_modFile("19991", "102700");
            //await con.MODFILES_GET_preview("https://file-metadata.nexusmods.com/file/nexus-files-s3-meta/3333/19991/Steel and Ink Tattoo - CCXL-19991-1-0-1-1741777635.zip.json");

            updateModTree();

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
            ModFromZip modFromZip_Form = new ModFromZip();
            modFromZip_Form.ShowDialog();
        }

        private void uninstallModByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UninstallByID uninstallByID = new UninstallByID();
            uninstallByID.ShowDialog();
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
            var result = MessageBox.Show("Requirements check was done. Do you want to see which mods are missing?", "Info", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                MissingRequirements mRform = new MissingRequirements(deps.getMissingReqs());
                mRform.ShowDialog();
            }
        }
    }
}
