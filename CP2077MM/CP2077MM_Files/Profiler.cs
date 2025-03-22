using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace CP2077MM.CP2077MM_Files
{
    public class Profiler
    {
        private DirectoryManager directoryManager;

        public Profiler()
        { 
            directoryManager = DirectoryManager.OpenDirectoryManager();
        }

        public string[] profileDirectory(string path)
        {
            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            return dirs;
        }

        public void profileCyberpunk2077()
        {
            string[] dirs = profileDirectory(MainProgram.SETTINGS_FILE.cyberpunk_install_dir);
            directoryManager.clearAll(DIR_TYPE.CYBERPUNK2077);
            foreach (string dir in dirs)
            {
                directoryManager.addDirectory(dir, DIR_TYPE.CYBERPUNK2077);
            }
            directoryManager.Save();
        }
    }
}
