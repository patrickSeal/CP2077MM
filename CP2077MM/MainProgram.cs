using CP2077MM;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsApp1
{
    internal static class MainProgram
    {

        public static SettingsFile SETTINGS_FILE = new SettingsFile();
        public static ProfileFile PROFILE_FILE = new ProfileFile();
        public static string PROFILE_FILE_PATH = Constants.UNKNOWN_STRING;
        public static string CP2077MM_PATH = Constants.UNKNOWN_STRING;
        public static string INSTALLED_MODS_PATH = Constants.UNKNOWN_STRING;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            if (File.Exists(Constants.FILE_SETTINGS_PATH))
            {
                if(init() == -1) return;
                Application.Run(new CP2077MM());
            }
            else {
                Application.Run(new FirstInstall());
            }
        }
        /**
         * Initializes the parameters by reading the settings.json file.
         * 
         */
        static int init()
        {
            if (init_settings_json() != 0) return -1;
            if (init_profile_json() != 0) return -1;
            if (init_dir_structure() != 0) return -1;
            return 0;
        }

        private static int init_settings_json()
        {
            if (!File.Exists(Constants.FILE_SETTINGS_PATH))
            {
                MessageBox.Show("Missing settings.json file, is CP2077MM installed properly?", "File Error");
                return -1;
            }
            string raw = File.ReadAllText(Constants.FILE_SETTINGS_PATH);
            SETTINGS_FILE = JsonSerializer.Deserialize<SettingsFile>(raw)!;
            CP2077MM_PATH = SETTINGS_FILE.path;
            return 0;
        }

        private static int init_profile_json()
        {
            if (!File.Exists(SETTINGS_FILE.path + Constants.FILE_PROFILE_JSON))
            {
                MessageBox.Show("Missing profile.json file, is CP2077MM installed properly?", "File Error");
                return -1;
            }
            PROFILE_FILE_PATH = SETTINGS_FILE.path + Constants.FILE_PROFILE_JSON;
            string raw = File.ReadAllText(PROFILE_FILE_PATH);
            PROFILE_FILE = JsonSerializer.Deserialize<ProfileFile>(raw)!;
            return 0;
        }
        private static int init_dir_structure()
        {
            // Create installedMods directory
            string path = Path.Combine(CP2077MM_PATH, Constants.INSTALLED_MODS_DIR);
            if (!Directory.Exists(path))
            {
                DirectoryInfo dirInfo = Directory.CreateDirectory(path);
            }
            INSTALLED_MODS_PATH = path;

            return 0;
        }
    }
}