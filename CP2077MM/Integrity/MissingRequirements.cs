using CP2077MM.CP2077MM_Files;
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

namespace CP2077MM.Integrity
{
    public partial class MissingRequirements : Form
    {
        Dictionary<long, List<Dependency_Raw>> reqs;
        ModIndex mods;
        APIConnection conn;
        ProgressBar pB;
        public MissingRequirements(Dictionary<long, List<Dependency_Raw>> reqs, ProgressBar pB)
        {
            InitializeComponent();
            this.reqs = reqs;
            conn = new APIConnection(MainProgram.PROFILE_FILE.apikey);
            mods = ModIndex.OpenModIndex();
            this.pB = pB;
        }

        private async void MissingRequirements_Load(object sender, EventArgs e)
        {
            if (reqs.Count == 0)
            {
                Close();
                MessageBox.Show("All your requirements are satisfied choom!", "Info");
                return;
            }
            pB.Visible = true;
            pB.Minimum = 1;
            pB.Maximum = reqs.Count;
            pB.Value = 1;
            pB.Step = 1;

            int x = 20, y = 50, j = 1;
            foreach (var (key, value) in reqs)
            {
                if(value.Count == 0) continue;
                //CheckBox checkBox = new CheckBox();
                //checkBox.Location = new Point(x, y);
                //this.Controls.Add(checkBox);
                Label mod = new Label();
                mod.Location = new Point(x + 10, y);
                ModEntry entry = mods.getEntry(key);
                mod.Text = j.ToString() + ". " + entry.name + " requires:";
                mod.AutoSize = true;
                Controls.Add(mod);

                int i = 1;
                foreach (Dependency_Raw dep in value)
                {

                    Mod ret = await conn.MODS_GET_retrieveMod(dep.mod_id.ToString());

                    Label name = new Label();
                    y += 20;
                    name.Location = new Point(x + 30, y);
                    name.Text = i.ToString() + ".   " + ret.name;
                    name.AutoSize = true;
                    this.Controls.Add(name);

                    Label version = new Label();
                    y += 20;
                    version.Location = new Point(x + 50, y);
                    version.Text = "version: " + ret.version;
                    version.AutoSize = true;
                    this.Controls.Add(version);

                    LinkLabel linkLabel = new LinkLabel();
                    y += 20;
                    linkLabel.Location = new Point(x + 50, y);
                    linkLabel.Text = Constants.NEXUSMODS_WEB + "/" + ret.mod_id;
                    linkLabel.AutoSize = true;
                    this.Controls.Add(linkLabel);

                    linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkClicked);

                    y += 10;
                    i++;
                }
                y += 20;
                j++;
                pB.PerformStep();
            }
            pB.Visible = false;
        }

        private void linkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            var linkLabel = (LinkLabel)sender;
            var url = linkLabel.Text;

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
