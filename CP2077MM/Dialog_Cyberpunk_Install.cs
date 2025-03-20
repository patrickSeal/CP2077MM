using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace CP2077MM
{
    public partial class Dialog_Cyberpunk_Install : Form
    {
        public Dialog_Cyberpunk_Install()
        {
            InitializeComponent();
        }

        private void btn_01_Click(object sender, EventArgs e)
        {
            cp2077dirBrows.ShowDialog();
            string path = cp2077dirBrows.SelectedPath;
            txB_01.Text = path;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txB_01.Text + @"\bin\x64\Cyberpunk2077.exe"))
            {
                error.Text = "Cyberpunk 2077 appears not to be installed in this directory!";
                error.ForeColor = Color.Red;
            }
            else
            {
                MainProgram.SETTINGS_FILE.cyberpunk_install_dir = txB_01.Text + @"\";
                FileHandler.updateJSON_FILE(Constants.FILE_SETTINGS_PATH, MainProgram.SETTINGS_FILE);
                this.Close();
            }
        }
    }
}
