using CP2077MM.CP2077MM_Files;
using CP2077MM.Mod_Install;
using CP2077MM.Uninstall_Dialogs;
using CP2077MM.Web;
using Newtonsoft.Json.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using WinFormsApp1;


namespace CP2077MM
{
    enum INSTALLATION_TYPE
    {
        STANDARD,
        CUSTOM,
        JSON,
        SINGLE_FILE,
        SINGLE_DIR
    }

    enum PACKAGE_TYPE
    {
        ZIP_ARCHIVE,
        RAR_ARCHIVE,
        _7Z_ARCHIVE,
        DIRECTORY,
        FILE
    }


    class ModHandling
    {

        public ModHandling() { }

        public static async Task<int> MOD_INSTALL(string path, INSTALLATION_TYPE type, PACKAGE_TYPE ptype, ProgressBar pB)
        {
            // Init ProgressBar
            pB.Visible = true;
            pB.Minimum = 1;
            pB.Maximum = 10;
            pB.Value = 1;
            pB.Step = 1;
            // Check if file is from Nexus Mods using MD5 hash
            string hash = string.Empty;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    byte[] data = md5.ComputeHash(stream);
                    var sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    hash = sBuilder.ToString();
                }
            }

            // STEP 1: Check if mod is already installed
            ModIndex modIndex = ModIndex.OpenModIndex();
            if (modIndex.containsHash(hash))
            {
                // Mod is already installed
                MessageBox.Show("This mod is already installed!", "Mod Installer");
                return -1;
            }
            pB.PerformStep();

            // STEP 2: Verify mod integrity
            APIConnection con = new APIConnection(MainProgram.PROFILE_FILE.apikey);
            string result = await con.MODS_GET_md5hash(hash);
            if (result == string.Empty)
            {
                // Error occurred
                return -1;
            }
            pB.PerformStep();

            // STEP 3: Parse API Call
            dynamic response = JArray.Parse(result);
            JObject mod = (JObject)response[0]["mod"];
            string name = (string)mod["name"];
            long mod_id = (long)mod["mod_id"];
            JObject details = (JObject)response[0]["file_details"];
            string version = (string)mod["version"];
            pB.PerformStep();

            // Check if a different version of this mod is already installed
            ModEntry difVersion = modIndex.getEntry(mod_id);
            if (difVersion != null)
            {
                string msg = "[WARNING]: You have a different version of " + difVersion.name + " (version: " + difVersion.version + ") installed! Please uninstall the other version first! Aborting this installation...";
                MessageBox.Show(msg, "Warning");
                return -1;
            }
            // STEP 4: Check requirements
            List<Requirement> requirements = await Browser.getRequirements(mod_id);
            List<Requirement> unsatisfied = new List<Requirement>();
            List<Requirement> satisfied = new List<Requirement>();
            foreach (Requirement req in requirements)
            {
                if (modIndex.containsMOD_ID(req.mod_id) == -1)
                {
                    unsatisfied.Add(req);
                }
                else
                {
                    satisfied.Add(req);
                }
            }
            pB.PerformStep();

            // Show unsatisfied requirements
            if (unsatisfied.Count > 0)
            {
                RequirementsForm reqForm = new RequirementsForm(unsatisfied);
                var answer = reqForm.ShowDialog();
                if (answer == DialogResult.Cancel) return -1;
            }

            // STEP 5: PACKAGE TYPES:
            string extractionPath = Path.Combine(MainProgram.CP2077MM_PATH, "tmp");
            Directory.CreateDirectory(extractionPath);
            if (ptype == PACKAGE_TYPE.ZIP_ARCHIVE)
            {
                // STEP 5.1 ZIP ARCHIVES
                ZipFile.ExtractToDirectory(path, extractionPath, true);
            }else if(ptype == PACKAGE_TYPE.RAR_ARCHIVE)
            {
                // STEP 5.2 RAR ARCHIVES 
                using (var archive = RarArchive.Open(path))
                {
                    foreach (var rarentry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        rarentry.WriteToDirectory(extractionPath, new SharpCompress.Common.ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true,
                        });
                    }
                }
            } else if(ptype == PACKAGE_TYPE._7Z_ARCHIVE)
            {
                // STEP 5.3 7z Archive
                SevenZipArchive archive = SevenZipArchive.Open(path);
                archive.ExtractToDirectory(extractionPath);
                archive.Dispose();
            }
            else
            {
                // Unsupported package type
                MessageBox.Show("This package type is not supported.", "Error: unexpected mod package format");
                return -1;
            }
            pB.PerformStep();

            // STEP 6: Indexing the archive into a mod_id.json file
            string[] files = Directory.GetFiles(extractionPath, ".", SearchOption.AllDirectories);
            List<string> relativePaths = new List<string>();
            int j = 0;
            foreach (string file in files) 
            {
                Console.WriteLine(file);
                relativePaths.Add(Path.GetRelativePath(extractionPath, file));
                Console.WriteLine(relativePaths[j]);
                j++;
            }
            pB.PerformStep();

            DirectoryManager dirManager = DirectoryManager.OpenDirectoryManager();

            List<string> createdDirectories = new List<string>();
            // STEP 7: What installation Method is chosen?
            if (type == INSTALLATION_TYPE.STANDARD)
            {
                // STEP 8.1: Paste all files into the main cyberpunk 2077 installation directory
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo mFile = new FileInfo(files[i]);
                    string installPath = Path.Combine(MainProgram.SETTINGS_FILE.cyberpunk_install_dir, relativePaths[i]);
                    string dirPath = Path.GetDirectoryName(installPath);
                    if(dirPath == null)
                    {
                        // Clean up Missing
                        // TODO
                    }
                        
                    // Check if the file exists already that needs to be installed
                    if (new FileInfo(installPath).Exists == false)
                    {
                        FileInfo dInfo = new FileInfo(installPath);
                        try
                        {
                            // this fails if the path is incomplete -> Director(ies) have to be created
                            mFile.MoveTo(installPath);

                            // if the path exists need to check if it is a native cyberpunk path or if it was created by another mod
                            if (dirManager.containsDirectory(dirPath, DIR_TYPE.CYBERPUNK2077) == 0 && !createdDirectories.Contains(dirPath))
                            {
                                // directory is not cyberpunk2077 native directory => path was created by another mod, add this path to multipurpose mod folders
                                dirManager.addDirectory(dirPath, DIR_TYPE.MOD);
                            }

                        }
                        catch (Exception e)
                        {
                            if(dInfo.Directory == null)
                            {
                                Error.UnexpectedError("ModHandling.MOD_INSTALL() - dInfo.Directory was NULL -> aborthing Mod installation!");
                                return -1;
                            }
                            DirectoryInfo dI = dInfo.Directory;
                            string directory = dI.ToString();
                            relativePaths.Add(directory);
                            if(dInfo.Directory == null)
                            {
                                Error.UnexpectedError("ModHandling.MOD_INSTALL() - newFile.Directory was NULL -> aborthing Mod installation!");
                                return -1;
                            }
                            DirectoryInfo dNew = dInfo.Directory;
                            dNew.Create();
                            createdDirectories.Add(dInfo.DirectoryName);

                            // try again after creating the directory
                            mFile.MoveTo(installPath);
                        }
                    }
                    else
                    {
                        // File already exists in the cyberpunk install directory
                        // TODO:
                    }
                }


                string[] filesAndDirs = new string[relativePaths.Count];
                for(int i = 0; i < relativePaths.Count; i++)
                {
                    filesAndDirs[i] = relativePaths[i];
                }
                // Step 8.1: Save indexed mod files to mod_id.json in installedMods directory
                ModFile modFile = new ModFile(filesAndDirs, mod_id);

                long[] req_ids = new long[requirements.Count];
                int k = 0;
                foreach (Requirement requirement in requirements)
                {
                    Console.WriteLine(requirement.mod_id);
                    req_ids[k] = requirement.mod_id;
                    k++;
                }

                modFile.addRequirements(req_ids);
                foreach(Requirement requirement in satisfied)
                {
                    modFile.setReqInstalled(requirement.mod_id, true);

                    // add a dependency to the modfile of the satisfied requirement
                    ModFile relation = ModFile.Open(requirement.mod_id);
                    relation.addDependency(mod_id);
                    relation.Save();
                }

                // check if there are mods installed that depend on this mod
                foreach(ModEntry dependent_mods in modIndex.getEntries())
                {
                    ModFile file = ModFile.Open(dependent_mods.mod_id);
                    if (file.containsRequirement(mod_id))
                    {
                        modFile.addDependency(dependent_mods.mod_id);
                        file.setReqInstalled(mod_id, true);
                    }
                    file.Save();
                }

                modFile.Save();
            }
            else
            {
                MessageBox.Show("This type of installation is not supported right now!", "Installation Method");
                return -1;
            }
            pB.PerformStep();

            // saving muliMod directories
            dirManager.Save();

            // STEP 9: UPDATE MOD INDEX
            ModEntry entry = new ModEntry(mod_id, hash, name, version);
            modIndex.addEntry(entry);
            modIndex.Save();
            pB.PerformStep();

            Directory.Delete(extractionPath, true);
            pB.PerformStep();
            MessageBox.Show("Nova Choom! Your mod was installed successully! Have fun playing <3", "Chromed-Up!");
            pB.Visible = false;
            return 0;
        }

        public static int MOD_UPDATE()
        {
            return 0;
        }

        public static int MOD_DELETE(long mod_id, ProgressBar pb)
        {
            pb.Visible = true;
            pb.Minimum = 1;
            pb.Maximum = 5;
            pb.Value = 1;
            pb.Step = 1;
            // STEP 1: Check if mod is actually installed
            ModIndex modIndex = ModIndex.OpenModIndex();
            if (modIndex.containsMOD_ID(mod_id) == -1) return -1;
            ModEntry modEntry = modIndex.getEntry(mod_id);
            pb.PerformStep();

            // STEP 2: Remove associated files
            ModFile modFile = ModFile.Open(mod_id);
            pb.PerformStep();
            // STEP 3: check for dependent mods
            List<Dependency_Raw> dependent_mods = modFile.GetDependencies();
            if (dependent_mods.Count > 0)
            {
                ModHasDependentModsInstalled dependencyDialog = new ModHasDependentModsInstalled(dependent_mods, modIndex, modEntry.name);
                var response = dependencyDialog.ShowDialog();
                // abort uninstallation if the user does not want to continue
                if (response == DialogResult.Cancel)
                {
                    pb.Visible = false;
                    return -1;
                }
            }
            foreach(Dependency_Raw req in modFile.getRequirements())
            {
                if (req.installed)
                {
                    ModFile reqFile = ModFile.Open(req.mod_id);
                    reqFile.removeDependency(mod_id);
                    reqFile.Save();
                }
            }


            pb.PerformStep() ;
            // STEP 4:
            // Delete the mod files
            modFile.DeleteModFiles();
            pb.PerformStep();
            // STEP 5:
            // Remove entry from ModIndex file
            modIndex.removeEntryByID(mod_id);
            modIndex.Save();
            string msg = modEntry.name + " was deleted successfully, all files should be deleted!";
            MessageBox.Show(msg, "Info");
            pb.Visible = false;
            return 0;
        }
    }
}
