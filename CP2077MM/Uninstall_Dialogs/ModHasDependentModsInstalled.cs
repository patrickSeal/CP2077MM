using CP2077MM.CP2077MM_Files;
using System.Windows;

namespace CP2077MM.Uninstall_Dialogs
{
    public partial class ModHasDependentModsInstalled : Form
    {
        List<Dependency_Raw> dependent_mods;
        ModIndex modIndex;
        string modName;

        public ModHasDependentModsInstalled(List<Dependency_Raw> dependent_mods, ModIndex modIndex, string modName)
        {
            InitializeComponent();
            this.dependent_mods = dependent_mods;
            this.modName = modName;
            this.modIndex = modIndex;
        }

        private void ModHasDependentModsInstalled_Load(object sender, EventArgs e)
        {
            int x = 0, y = 100, i = 1;
            Label first = new Label();
            first.Location = new System.Drawing.Point(x + 12, y);
            first.Text = "The following mods which depend on " + modName + " are currently installed:";
            first.AutoSize = true;
            Controls.Add(first);

            foreach (Dependency_Raw dep in dependent_mods)
            {
                ModEntry ent = modIndex.getEntry(dep.mod_id);
                Label name = new Label();
                y += 20;
                name.Location = new System.Drawing.Point(x + 30, y);
                name.Text = i.ToString() + ".   " + ent.name;
                name.AutoSize = true;
                Controls.Add(name);

                Label version = new Label();
                y += 20;
                version.Location = new System.Drawing.Point(x + 50, y);
                version.Text = "version: " + ent.version;
                version.AutoSize = true;
                Controls.Add(version);
                i++;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_deleteAnyway_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
