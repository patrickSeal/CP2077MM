using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CP2077MM
{
    public partial class ModFromZip : Form
    {
        public ModFromZip()
        {
            InitializeComponent();
        }

        private void ModFromZip_Load(object sender, EventArgs e)
        {
            file_dialog_select_zip.Filter = "zip archives (*.zip)|*.zip";
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
                await ModHandling.MOD_INSTALL(modPath, INSTALLATION_TYPE.STANDARD);
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
