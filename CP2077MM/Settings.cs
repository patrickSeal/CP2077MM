using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CP2077MM
{
    public partial class Settings : Form
    {
        SettingsFile settings = MainProgram.SETTINGS_FILE;

        public Settings()
        {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            lbl_02.Text = lbl_02.Text + "    " + settings.path;
            lbl_03.Text = lbl_03.Text + "    " + settings.name;
            lbl_04.Text = lbl_04.Text + "    " + settings.version;
            lbl_05.Text = lbl_05.Text + "    " + settings.author;
            txB_06.Text = settings.cyberpunk_install_dir;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_06_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string newPath = folderBrowserDialog1.SelectedPath;
            txB_06.Text = newPath;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txB_06.Text + @"\bin\x64\Cyberpunk2077.exe"))
            {
                error.Text = "Cyberpunk 2077 appears not to be installed in this directory!";
                error.ForeColor = Color.Red;
                error.BackColor = Color.Transparent;
            }
            else
            {
                MainProgram.SETTINGS_FILE.cyberpunk_install_dir = txB_06.Text + @"\";
                FileHandler.updateJSON_FILE(Constants.FILE_SETTINGS_PATH, MainProgram.SETTINGS_FILE);
                this.Close();
            }
        }
    }
}
