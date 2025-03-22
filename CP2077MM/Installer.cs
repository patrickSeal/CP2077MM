using CP2077MM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace WinFormsApp1
{

    class Installer
    {
        public static async Task install(string instDir, string apikey)
        {
            // check for previous installations
            if (Directory.Exists(Constants.DIR_SETTINGS_PATH))
            {
                var result = MessageBox.Show("CP2077 Mod Manager Directory already exists in \"C:\\\\ProgramData\\\", please make sure to delete all files from any previous installation. Install anyway?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
            }
            // check installation path integrity
            if (!Directory.Exists(instDir))
            {
                MessageBox.Show("Installation Directory not found.", "Error");
                return;
            }

            APIConnection con = new APIConnection(apikey);
            USER_GET_VALIDATE validate = await con.USER_GET_validate();

            // Creating Settings Directory
            DirectoryInfo dirInf = Directory.CreateDirectory(Constants.DIR_SETTINGS_PATH);

            // Encrypting APIKEY

            // Creating Settings File
            string settingsFile = Constants.DIR_SETTINGS_PATH + @"\settings.json";
            if (File.Exists(settingsFile)) File.Delete(settingsFile);
            File.Create(settingsFile).Dispose();

            string instDir_full = instDir + @"\CP2077 Mod Manager\";
            var settings = new SettingsFile
            {
                path = instDir_full,
                name = Constants.NAME,
                version = Constants.VERSION,
                author = Constants.AUTHOR,
                description = Constants.DESCRIPTION
            };
            FileHandler.updateJSON_FILE(settingsFile, settings);

            // Create Program Directory:
            DirectoryInfo programDir = Directory.CreateDirectory(instDir_full);

            // Copy exe
            File.Copy(@".\CP2077MM.exe", programDir + @"CP2077ModManager.exe", true);
            File.Copy(@".\CP2077MM.dll", programDir + @"CP2077MM.dll", true);
            File.Copy(@".\CP2077MM.runtimeconfig.json", programDir + @"CP2077MM.runtimeconfig.json", true);
            File.Copy(@".\CP2077MM.deps.json", programDir + @"CP2077MM.deps.json", true);
            File.Copy(@".\CP2077MM.deps.json", programDir + @"CP2077MM.deps.json", true);
            File.Copy(@".\CP2077MM.pdb", programDir + @"CP2077MM.pdb", true);
            File.Copy(@".\Newtonsoft.Json.dll", programDir + @"Newtonsoft.Json.dll", true);
            File.Copy(@".\Newtonsoft.Json.dll", programDir + @"SharpCompress.dll", true);
            File.Copy(@".\Newtonsoft.Json.dll", programDir + @"ZstdSharp.dll", true);
            File.Copy(@".\Newtonsoft.Json.dll", programDir + @"dirManager.json", true);
            File.Copy(@".\Newtonsoft.Json.dll", programDir + @"dirManager.json.backup", true);

            // Creating Profile File

            string profileFile = programDir + Constants.FILE_PROFILE_JSON;
            if(File.Exists(profileFile)) File.Delete(profileFile);
            File.Create(profileFile).Dispose();
            var profile = new ProfileFile
            {
                apikey = apikey,
                user_id = validate.user_id,
                username = validate.name,
                is_premium = validate.is_premium,
                is_supporter = validate.is_supporter,
                email = validate.email,
                profile_url = validate.profile_url,
            };
            FileHandler.updateJSON_FILE(profileFile, profile);

            Console.WriteLine("[INFO]: Installation was successfull!");
            var start = MessageBox.Show("Installation was successfull! Do you want to start the Mod Manager?", "Installer", MessageBoxButtons.YesNo);
            if (start == DialogResult.Yes)
            {
                Process.Start(programDir + @"CP2077ModManager.exe");
            }
        }
    }
}
