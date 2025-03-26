using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CP2077MM.Uninstall_Dialogs
{
    public partial class UninstallByID : Form
    {
        ProgressBar pb;
        public UninstallByID(ProgressBar pb)
        {
            InitializeComponent();
            this.pb = pb;
        }

        private void btn_uninstall_Click(object sender, EventArgs e)
        {
            int mod_id;
            try
            {
                mod_id = Int32.Parse(txB_02.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DEBUG] No integer provided as mod_id!");
                return;
            }
            Console.WriteLine("[DEBUG]: mod_id to be uninstalled " + mod_id);
            if (ModHandling.MOD_DELETE(mod_id, pb) == -1)
            {
                Console.WriteLine("[ERROR]: Something went wrong!!");
            }
            else
            {
                MessageBox.Show("Mod was successfully uninstalled!", "Info", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
