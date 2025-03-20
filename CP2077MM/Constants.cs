using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CP2077MM
{

    class Constants
    {
        public readonly static string NAME = "Cyberpunk 2077 Mod Manager";
        public readonly static string VERSION = "0.1.0";
        public readonly static string AUTHOR = "SealsAreCute";
        public readonly static string FILE_SETTINGS_PATH = @"C:\\ProgramData\CP2077ModManager\settings.json";
        public readonly static string DIR_SETTINGS_PATH = @"C:\\ProgramData\CP2077ModManager";
        public readonly static string DESCRIPTION = "Cyberpunk 2077 Mod Manager ";
        public readonly static string UNKNOWN_STRING = "unknown";
        public readonly static string GIT_REPO = @"https://www.cyberpunk.net/";
        public readonly static string CYBERPUNK2077_NET = @"https://www.cyberpunk.net/";
        public readonly static string NEXUSMODS_WEB = @"https://www.nexusmods.com/cyberpunk2077/mods";

        // File names
        public readonly static string FILE_PROFILE_JSON = "profile.json";
        public readonly static string FILE_SETTINGS_JSON = "settings.json";
        public readonly static string MOD_INDEX_JSON = "modIndex.json";

        // Dir names
        public readonly static string INSTALLED_MODS_DIR = "installedMods";
    }
}
