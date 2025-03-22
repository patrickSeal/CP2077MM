﻿using CP2077MM.CP2077MM_Files;
using CP2077MM.Mod_Install;
using CP2077MM.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
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
        DIRECTORY,
        FILE
    }


    class ModHandling
    {
        public ModHandling() { }

        public static async Task<int> MOD_INSTALL(string path, INSTALLATION_TYPE type, PACKAGE_TYPE ptype)
        {
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

            // STEP 2: Verify mod integrity
            APIConnection con = new APIConnection(MainProgram.PROFILE_FILE.apikey);
            string result = await con.MODS_GET_md5hash(hash);
            if (result == string.Empty)
            {
                // Error occurred
                return -1;
            }


            // STEP 3: Parse API Call
            dynamic response = JArray.Parse(result);
            JObject mod = (JObject)response[0]["mod"];
            string name = (string)mod["name"];
            long mod_id = (long)mod["mod_id"];
            JObject details = (JObject)response[0]["file_details"];
            string version = (string)mod["version"];

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
                ZipFile.ExtractToDirectory(path, extractionPath);
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
            }else
            {
                // Unsupported package type
                MessageBox.Show("This package type is not supported.", "Error: unexpected mod package format");
                return -1;
            }

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
                }
                modFile.Save();
            }
            else
            {
                MessageBox.Show("This type of installation is not supported right now!", "Installation Method");
                return -1;
            }
            // saving muliMod directories
            dirManager.Save();

            // STEP 9: UPDATE MOD INDEX
            ModEntry entry = new ModEntry(mod_id, hash, name, version);
            modIndex.addEntry(entry);
            modIndex.Save();

            Directory.Delete(extractionPath, true);
            MessageBox.Show("Nova Choom! Your mod was installed successully! Have fun playing <3", "Chromed-Up!");
            return 0;
        }

        public static int MOD_UPDATE()
        {
            return 0;
        }

        public static int MOD_DELETE(long mod_id)
        {
            // STEP 1: Check if mod is actually installed
            ModIndex modIndex = ModIndex.OpenModIndex();
            if (modIndex.containsMOD_ID(mod_id) == -1) return -1;
            ModEntry modEntry = modIndex.getEntry(mod_id);

            // STEP 2: Remove associated files
            ModFile modFile = ModFile.Open(mod_id);
            modFile.DeleteModFiles();

            // STEP 3: Remove entry from ModIndex file
            modIndex.removeEntryByID(mod_id);
            modIndex.Save();
            string msg = modEntry.name + " was deleted successfully, all files should be deleted!";
            MessageBox.Show(msg, "Info");
            return 0;
        }
    }
}
