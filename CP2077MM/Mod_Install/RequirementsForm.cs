using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CP2077MM.Mod_Install
{
    public partial class RequirementsForm : Form
    {
        public List<Web.Requirement> reqs;
        public RequirementsForm(List<Web.Requirement> reqs)
        {
            InitializeComponent();
            this.reqs = reqs;
        }

        public void RequirementsForm_Load(object sender, EventArgs e)
        {
            int x = 30, y = 90, i = 1;
            foreach (Web.Requirement req in reqs)
            {
                //CheckBox checkBox = new CheckBox();
                //checkBox.Location = new Point(x, y);
                //this.Controls.Add(checkBox);

                Label name = new Label();
                name.Location = new Point(x + 10, y);
                name.Text = i.ToString() + ".   " + req.name;
                name.AutoSize = true;
                this.Controls.Add(name);

                Label notes = new Label();
                y += 20;
                notes.Location = new Point(x + 30, y);
                notes.Text = "Author notes: " + req.note;
                notes.AutoSize = true;
                this.Controls.Add(notes);

                LinkLabel linkLabel = new LinkLabel();
                y += 20;
                linkLabel.Location = new Point(x + 30, y);
                linkLabel.Text = req.url;
                linkLabel.AutoSize = true;
                this.Controls.Add(linkLabel);

                linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkClicked);

                y += 30;
                i++;
            }
        }

        private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var linkLabel = (LinkLabel)sender;
            var url = linkLabel.Text;

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void btn_installanyway_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void RequirementsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
