using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FirstInstall : Form
    {
        private static string NEXUSMODS_APIKEY_WEBPAGE = "https://www.nexusmods.com/users/myaccount?tab=api";
        private string installationPath = string.Empty;

        public FirstInstall()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void installDIR_HelpRequest(object sender, EventArgs e)
        {

        }
        /**
         * Selects the installation path for the Mod Manager files.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            installDIR.ShowDialog();
            installationPath = installDIR.SelectedPath;
            txB_installDir_01.Text = installationPath;
        }
        /**
         * Provide a linke to the API Key from Nexus Mods
         * 
         */
        private void btn_apikey_02_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = NEXUSMODS_APIKEY_WEBPAGE,
                UseShellExecute = true
            });
        }

        private async void btn_Install_Click(object sender, EventArgs e)
        {
            await Installer.install(txB_installDir_01.Text, txB_apikey.Text).ConfigureAwait(false);
            Application.Exit();
        }
    }
}
