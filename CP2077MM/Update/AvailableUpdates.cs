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

namespace CP2077MM.Update
{
    public partial class AvailableUpdates : Form
    {
        List<(ModEntry, ModEntry)> entries;
        public AvailableUpdates(List<(ModEntry, ModEntry)> entries)
        {
            InitializeComponent();
            this.entries = entries;
        }

        private async void AvailableUpdates_Load(object sender, EventArgs e)
        {

            int x = 20, y = 70, j = 1;
            foreach (var (current, updated) in entries)
            {
                //CheckBox checkBox = new CheckBox();
                //checkBox.Location = new Point(x, y);
                //this.Controls.Add(checkBox);
                Label mod = new Label();
                mod.Location = new Point(x, y);
                mod.Text = j.ToString() + ". " + current.name;
                mod.AutoSize = true;
                Controls.Add(mod);

                Label curINFO = new Label();
                y += 20;
                curINFO.Location = new Point(x + 10, y);
                curINFO.Text = "\u2022 Currently installed version: " + current.version;
                curINFO.AutoSize = true;
                Controls.Add(curINFO);

                Label newINFO = new Label();
                y += 20;
                newINFO.Location = new Point(x + 10, y);
                newINFO.Text = "\u2022 New version is available: " + updated.version;
                newINFO.AutoSize = true;
                Controls.Add(newINFO);


                LinkLabel linkLabel = new LinkLabel();
                y += 20;
                linkLabel.Location = new Point(x + 19, y);
                linkLabel.Text = Constants.NEXUSMODS_WEB + "/" + current.mod_id;
                linkLabel.AutoSize = true;
                Controls.Add(linkLabel);

                linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkClicked);
                y += 20;
                j++;
            }
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
