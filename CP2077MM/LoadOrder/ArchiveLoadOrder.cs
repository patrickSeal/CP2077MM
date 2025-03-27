
using CP2077MM.CP2077MM_Files;
using CP2077MM.Custom_Graphics;
using System.IO;
using System.Runtime.InteropServices;
using WinFormsApp1;

namespace CP2077MM.LoadOrder
{
    public class ArchiveLoadOrder
    {
        private ProgressBar pb;
        private ModIndex modIndex;
        private List<ModEntry> mods;
        private static readonly string FILE_MODLIST_TXT = Path.Combine(MainProgram.SETTINGS_FILE.cyberpunk_install_dir, Constants.DIR_ARCHIVES_PATH, Constants.FILE_MODLIST_TXT);
        private static readonly string DIR_MODLIST_TXT = Path.Combine(MainProgram.SETTINGS_FILE.cyberpunk_install_dir, Constants.DIR_ARCHIVES_PATH);
        List<(long, string, string)> archives;

        public ArchiveLoadOrder(ProgressBar pb)
        {
            this.pb = pb;
            modIndex = ModIndex.OpenModIndex();
            mods = modIndex.getEntries();
            archives = new List<(long, string, string)>();
        }

        public List<(long, string, string)> GetArchiveFiles() { return archives; }

        public int LoadArchiveFiles()
        {
            int steps = 2 + mods.Count;
            Form_Helpers.initProgressBar(pb, 1, steps, 1, 1);

            if(mods == null || mods.Count == 0)
            {
                MessageBox.Show("You don't have any mods installed!", "Info");
                pb.Visible = false;
                return -1;
            }
            pb.PerformStep();
            if(!Directory.Exists(DIR_MODLIST_TXT))
            {
                MessageBox.Show("None of your installed mods has an archive file!", "Info");
                pb.Visible = false;
                return -1;
            }
            pb.PerformStep();

            // modlist.txt file already exists
            if (File.Exists(FILE_MODLIST_TXT))
            {
                // TODO: Load previous load order!
            }


            // Load archive files
            foreach (ModEntry mod in mods)
            {
                ModFile modfile = ModFile.Open(mod.mod_id);
                string[] files = modfile.GetFiles();
                foreach (string file in files)
                {
                    // file is not an archive file
                    if(!Path.GetExtension(file).Equals(".archive")) continue;
                    string filename = Path.GetFileName(file);
                    archives.Add((mod.mod_id, mod.name, filename));
                }
                pb.PerformStep();
            }
            pb.Visible=false;
            return 0;
        }

        public static void SaveArchiveLoadOrder(List<string> archiveFiles)
        {
            if (!File.Exists(FILE_MODLIST_TXT))
            {
                File.Create(FILE_MODLIST_TXT).Dispose();
            }else
            {
                File.Delete(FILE_MODLIST_TXT);
                File.Create(FILE_MODLIST_TXT).Dispose();
            }
                TextWriter writer = new StreamWriter(FILE_MODLIST_TXT);
            foreach (string file in archiveFiles)
            {
                writer.WriteLine(file);
            }
            writer.Close();
        }
    }
}
