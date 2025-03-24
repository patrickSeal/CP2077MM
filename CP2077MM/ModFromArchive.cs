using System.IO;

namespace CP2077MM
{
    public partial class ModFromArchive : Form
    {
        private ProgressBar pB;
        public ModFromArchive(ProgressBar pB)
        {
            InitializeComponent();
            this.pB = pB;
        }

        private void ModFromZip_Load(object sender, EventArgs e)
        {
            file_dialog_select_zip.Filter = "Archives|*.zip;*.rar;*.7z";
            radio_standard.Checked = true;
            radio_custom.Checked = false;
        }

        /*
         * Running the Mod Installation
         */
        private async void btn_Install_Click(object sender, EventArgs e)
        {
            string modPath = txB_01.Text;
            if (radio_standard.Checked)
            {
                this.Close();
                string file_type = Path.GetExtension(modPath);
                if (file_type == ".zip") {
                    await ModHandling.MOD_INSTALL(modPath, INSTALLATION_TYPE.STANDARD, PACKAGE_TYPE.ZIP_ARCHIVE, pB);
                }else if(file_type == ".rar")
                {
                    await ModHandling.MOD_INSTALL(modPath, INSTALLATION_TYPE.STANDARD, PACKAGE_TYPE.RAR_ARCHIVE, pB);
                }else if(file_type == ".7z")
                {
                    await ModHandling.MOD_INSTALL(modPath, INSTALLATION_TYPE.STANDARD, PACKAGE_TYPE._7Z_ARCHIVE, pB);
                }
                else
                {
                    MessageBox.Show("This file type is not supported!", "Error: unexpected file type");
                }
            }
            else if (radio_custom.Checked)
            {
                // Todo
                Custom_Mod_Installation.CustomInstall customDialog = new Custom_Mod_Installation.CustomInstall();
                customDialog.ShowDialog();
            }
            else
            {
                // UNREACHABLE STATE
            }
            pB.Visible = false;
        }

        /*
         * Select zip archive
         */
        private void btn_select_Click(object sender, EventArgs e)
        {
            file_dialog_select_zip.ShowDialog();
            string archivePath = file_dialog_select_zip.FileName;
            txB_01.Text = archivePath;
        }

        /*
         * Abort Mod installation
         */
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radio_standard_Click(object sender, EventArgs e)
        {
            radio_standard.Checked = true;
            radio_custom.Checked = false;
        }

        private void radio_custom_Click(object sender, EventArgs e)
        {
            radio_standard.Checked = false;
            radio_custom.Checked = true;
        }

        private void btn_help_01_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You should select this option if the mod is installed to the standard Cyberpunk 2077 Installation directory.", "Info");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You should select this option if the mod has to be installed into specific directories, or single files need to be placed into specific directories. You can also choose this option if you have a CP2077MM.json file which is compatible with this mod manager.", "Info");
        }
    }
}
