using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace CP2077MM.CP2077MM_Files
{
    public enum DIR_TYPE
    {
        CYBERPUNK2077,
        MOD
    }

    public class DirectoryManager
    {
        private static string BASE_PATH;

        public List<string> cp2077DIRs { get; set; } = new List<string>();
        public List<string> multimodDIRs { get; set; } = new List<string>();

        public static DirectoryManager OpenDirectoryManager()
        {
            BASE_PATH = MainProgram.SETTINGS_FILE.cyberpunk_install_dir;

            if(!File.Exists(MainProgram.DIR_MANAGER_PATH))
            {
                File.Create(MainProgram.DIR_MANAGER_PATH).Dispose();
            }
            DirectoryManager dM;
            try
            {
                string json = File.ReadAllText(MainProgram.DIR_MANAGER_PATH);
                dM = JsonConvert.DeserializeObject<DirectoryManager>(json);
            }
            catch (Exception ex)
            {
                return new DirectoryManager();
            }
            if (dM == null) return new DirectoryManager();
            else return dM;
        }

        /**
         * Returns 1 with a directory is already in the DirectoryManager file
         * Returns 0 if not
         * Returns -1 if an unexpected error arises
         */
        public int containsDirectory(string directory, DIR_TYPE type)
        {
            string relativePath = Path.GetRelativePath(BASE_PATH, directory);

            if (type == DIR_TYPE.CYBERPUNK2077)
            {
                if (cp2077DIRs.Contains(relativePath)) return 1;
            }
            else if (type == DIR_TYPE.MOD)
            {
                if (multimodDIRs.Contains(relativePath)) return 1;
            }
            else
            {
                // Unexpected error
                return -1;
            }
            return 0;
        }

        public int addDirectory(string directory, DIR_TYPE type)
        {
            string relativePath = Path.GetRelativePath(BASE_PATH, directory);

            if (type == DIR_TYPE.CYBERPUNK2077)
            {
                if(cp2077DIRs.Contains(relativePath)) return 0;
                cp2077DIRs.Add(relativePath);
            }
            else if (type == DIR_TYPE.MOD)
            {
                if(multimodDIRs.Contains(relativePath)) return 0;
                multimodDIRs.Add(relativePath);
            }
            else
            {
                // Unexpected error
                return -1;
            }
            return 0;
        }

        public int removeDirectory(string directory, DIR_TYPE type)
        {
            string relativePath = Path.GetRelativePath(BASE_PATH, directory);
            if (type == DIR_TYPE.CYBERPUNK2077)
            {
                if (cp2077DIRs.Contains(relativePath))
                {
                    cp2077DIRs.Remove(relativePath);
                }
            }
            else if (type == DIR_TYPE.MOD)
            {
                if (multimodDIRs.Contains(relativePath))
                {
                    multimodDIRs.Remove(relativePath);
                }
            }
            else
            {
                // Unexpected error
                return -1;
            }
            return 0;
        }

        /**
         * Clears all directory entries
         */
        public void clearAll(DIR_TYPE type)
        {
            if(type == DIR_TYPE.CYBERPUNK2077) cp2077DIRs = new List<string>();
            if(type == DIR_TYPE.MOD) multimodDIRs = new List<string>();
        }

        /**
         * Stores changes to the DirectoryManager file
         * 
         */
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(MainProgram.DIR_MANAGER_PATH, json);
        }
    }
}
