using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace CP2077MM.CP2077MM_Files
{

    public class Dependency_Raw
    {
        public long mod_id { get; set; }
        public bool installed { get; set; }
    }

    class ModFile_Raw
    {
        public long mod_id { get; set; } = 0;
        public string[] files { get; set; } = new string[0];
        public Dependency_Raw[] dependencies { get; set; } = new Dependency_Raw[0];
        public Dependency_Raw[] requirements { get; set; } = new Dependency_Raw[0];
        
    }



    class ModFile
    {
        string[] files;
        public Dependency_Raw[] dependencies, requirements;
        long mod_id;
        string PATH;

        ModFile_Raw raw { get; set; } = new ModFile_Raw();
        public ModFile(string[] files, long mod_id)
        {
            raw.mod_id = mod_id;
            raw.files = files;
            this.files = files;
            this.mod_id = mod_id;
            this.PATH = Path.Combine(MainProgram.INSTALLED_MODS_PATH, mod_id.ToString() + ".json");
        }
        private ModFile(ModFile_Raw raw, long mod_id)
        {
            raw.mod_id = mod_id;
            this.raw = raw;
            this.files = raw.files;
            this.dependencies = raw.dependencies;
            this.requirements = raw.requirements;
            this.mod_id = mod_id;
            this.PATH = Path.Combine(MainProgram.INSTALLED_MODS_PATH, raw.mod_id.ToString() + ".json");
        }

        public static ModFile Open(long mod_id)
        {
            string path = Path.Combine(MainProgram.INSTALLED_MODS_PATH, mod_id.ToString() + ".json");
            if (!File.Exists(path)) throw new FileNotFoundException($"[ERROR]: ModFile at location {path} could not be found!");
            
            string input = File.ReadAllText(path);
            ModFile_Raw mod_file = JsonConvert.DeserializeObject<ModFile_Raw>(input);

            return new ModFile(mod_file, mod_id);
        }

        public void DeleteModFiles()
        {
            foreach (string file in files)
            {
                string path = Path.Combine(MainProgram.SETTINGS_FILE.cyberpunk_install_dir, file);
                bool isFile = File.Exists(path);
                bool isDirectory = Directory.Exists(path);
                if (isFile)
                {
                    File.Delete(path);
                }
                else if (isDirectory)
                {
                    Directory.Delete(path, true);
                }
                else
                {
                    Console.WriteLine("[WARNING]: ModFile entry referenced a non existend file or directory!");
                }
            }
            // delete the ModFile itself
            File.Delete(PATH);
        }

        public void addRequirements(long[] mod_ids)
        {
            requirements = new Dependency_Raw[mod_ids.Length];
            for (int i = 0; i < mod_ids.Length; i++)
            {
                Dependency_Raw dependency_Raw = new Dependency_Raw();
                dependency_Raw.mod_id = mod_ids[i];
                dependency_Raw.installed = false;
                requirements[i] = dependency_Raw;
            }
        }

        public Dependency_Raw[] getRequirements() { return requirements; }

        public void setReqInstalled(long mod_id, bool value)
        {
            for (int i = 0; i < requirements.Length; i++)
            {
                if (requirements[i].mod_id == mod_id)
                {
                    requirements[i].installed = value;
                }
            }
        }

        public void Save()
        {
            raw.requirements = requirements;
            raw.dependencies = dependencies;
            if(File.Exists(PATH))
            {
                File.Delete(PATH);
            }

            File.Create(PATH).Dispose();
            string output = JsonConvert.SerializeObject(raw, Formatting.Indented);
            File.WriteAllText(PATH, output);
        }
    }
}
