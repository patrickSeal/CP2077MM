using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace CP2077MM
{
    public partial class Profile : Form
    {
        private ProfileFile profile = MainProgram.PROFILE_FILE;

        public Profile()
        {
            InitializeComponent();
        }
        private void Profile_Load(object sender, EventArgs e)
        {
            txB_02.Text = profile.apikey;
            lbl_03.Text = lbl_03.Text + "    " + profile.username;

            if (profile.is_premium == true)
            {
                lbl_07.Text = "Activated";
                lbl_07.ForeColor = Color.DarkGreen;
            }
            else
            {
                lbl_07.Text = "Don't have the eddies!";
                lbl_07.ForeColor = Color.Black;
            }
            lbl_05.Text = lbl_05.Text + "    " + profile.email;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /**
         * Used only for applying the new apikey
         */
        private async void btn_apply_Click(object sender, EventArgs e)
        {
            /**
             * TODO:    - Put Connection in another thread
             *          - Update text box with "Invoke" from this other thread
             *          - ref: https://stackoverflow.com/questions/661561/how-do-i-update-the-gui-from-another-thread
             * 
             * 
             */
            error_lbl.Text = "";
            string newAPIkey = txB_02.Text;
            APIConnection con = new APIConnection(newAPIkey);
            USER_GET_VALIDATE validate = await con.USER_GET_validate();

            if (validate == null)
            {
                error_lbl.Text = "Could not authorize the API key! Wrong key?";
                error_lbl.ForeColor = Color.Red;
            }
            else
            {
                MainProgram.PROFILE_FILE.apikey = newAPIkey;
                this.Close();
            }
        }

        /**
         * Synchronize NexusMods premium with the Mod Manager
         */
        private async void btn_sync_Click(object sender, EventArgs e)
        {
            APIConnection con = new APIConnection(profile.apikey);
            USER_GET_VALIDATE validate = await con.USER_GET_validate();
            if (validate.is_premium)
            {
                MainProgram.PROFILE_FILE.is_premium = true;
                lbl_07.Text = "Activated";
                lbl_07.ForeColor = Color.DarkGreen;
            } else
            {
                MainProgram.PROFILE_FILE.is_premium = false;
                lbl_07.Text = "Don't have the eddies!";
                lbl_07.ForeColor = Color.Black;
            }
        }

        /**
         * Goes to the users profile page
         */
        private void btn_profile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = profile.profile_url,
                UseShellExecute = true
            });
        }
    }
}
