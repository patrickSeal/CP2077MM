using Newtonsoft.Json;
using System.IO;
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
        public List<Dependency_Raw> dependencies { get; set; } = new List<Dependency_Raw>();
        public Dependency_Raw[] requirements { get; set; } = new Dependency_Raw[0];
        
    }



    class ModFile
    {
        string[] files;
        public Dependency_Raw[] requirements;
        List<Dependency_Raw> dependencies;
        long mod_id;
        string PATH;

        ModFile_Raw raw { get; set; } = new ModFile_Raw();
        public ModFile(string[] files, long mod_id)
        {
            raw.mod_id = mod_id;
            raw.files = files;
            dependencies = new List<Dependency_Raw>();
            this.files = files;
            this.mod_id = mod_id;
            this.PATH = Path.Combine(MainProgram.INSTALLED_MODS_PATH, mod_id.ToString() + ".json");
        }
        private ModFile(ModFile_Raw raw, long mod_id)
        {
            raw.mod_id = mod_id;
            this.raw = raw;
            this.files = raw.files;
            if (raw.dependencies == null) dependencies = new List<Dependency_Raw>();
            else dependencies = raw.dependencies;
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
        public string[] GetFiles() { return files; }

        /**
         *  Deletes all the tracked files and directories of a mod
         */
        public void DeleteModFiles()
        {
            // check for each directory if the directoryManager has an entry
            DirectoryManager dirManager = DirectoryManager.OpenDirectoryManager();
            foreach (string file in files)
            {
                string path = Path.Combine(MainProgram.SETTINGS_FILE.cyberpunk_install_dir, file);
                bool isFile = File.Exists(path);
                bool isDirectory = Directory.Exists(path);
                if (isFile)
                {
                    string dirPath = Path.GetDirectoryName(path);
                    File.Delete(path);
                    if (dirManager.containsDirectory(dirPath, DIR_TYPE.MOD) == 1)
                    {
                        // directory is a mulimod directory
                        if(!Directory.EnumerateFileSystemEntries(dirPath).Any())
                        {
                            // directory is empty -> can be deleted
                            Directory.Delete(dirPath, true);
                            dirManager.removeDirectory(dirPath, DIR_TYPE.MOD);
                        }
                    }
                }
                else if (isDirectory)
                {
                    if (dirManager.containsDirectory(path, DIR_TYPE.MOD) == 1)
                    {
                        // directory is a mulimod directory
                        if (!Directory.EnumerateFileSystemEntries(path).Any())
                        {
                            // directory is empty -> can be deleted
                            Directory.Delete(path, true);
                            dirManager.removeDirectory(path, DIR_TYPE.MOD);
                        }
                    }
                    else
                    {
                        Directory.Delete(path, true);
                    }
                }
                else
                {
                    Console.WriteLine("[WARNING]: ModFile entry referenced a non existend file or directory!");
                }
            }
            dirManager.Save();
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

        public bool containsRequirement(long mod_id)
        {
            foreach(Dependency_Raw req in requirements)
            {
                if (req.mod_id == mod_id) return true;
            }
            return false;
        }

        public Dependency_Raw[] getRequirements() { return requirements; }


        public bool containsDependency(Dependency_Raw dep)
        {
            foreach(Dependency_Raw dep_raw in dependencies)
            {
                if(dep_raw.mod_id == dep.mod_id) return true;
            }
            return false;
        }

        public List<Dependency_Raw> GetDependencies() { return dependencies; }

        public void addDependency(long mod_id)
        {
            Dependency_Raw dependency = new Dependency_Raw();
            dependency.mod_id = mod_id;
            dependency.installed = true;
            if (!containsDependency(dependency))
            {
                dependencies.Add(dependency);
            }
        }

        public void removeDependency(long mod_id)
        {
            Dependency_Raw dependency = new Dependency_Raw();
            dependency.mod_id = mod_id;
            dependency.installed = true;
            foreach(Dependency_Raw dep_raw in dependencies.ToList())
            {
                if(dep_raw.mod_id == dependency.mod_id)
                {
                    dependencies.Remove(dep_raw);
                }
            }
        }

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
