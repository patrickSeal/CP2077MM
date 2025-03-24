//LICENSES:
/*
- Sharpcompress
LICENSE Copyright (c) 2000 - 2011 The Legion Of The Bouncy Castle (http://www.bouncycastle.org)
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions

- Newtonsoft.Json
The MIT License (MIT)
Copyright (c) 2007 James Newton-King
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
*/
using CP2077MM;
using CP2077MM.WPF;
using System.IO;
using System.Text.Json;

namespace WinFormsApp1
{
    internal static class MainProgram
    {
        // Set this to false when running the app or building a release
        public static readonly bool TEST = false;

        public static SettingsFile SETTINGS_FILE = new SettingsFile();
        public static ProfileFile PROFILE_FILE = new ProfileFile();
        public static string PROFILE_FILE_PATH = Constants.UNKNOWN_STRING;
        public static string CP2077MM_PATH = Constants.UNKNOWN_STRING;
        public static string INSTALLED_MODS_PATH = Constants.UNKNOWN_STRING;
        public static string DIR_MANAGER_PATH = Constants.UNKNOWN_STRING;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();


            if (File.Exists(Constants.FILE_SETTINGS_PATH))
            {
                if(init() == -1) return;

                // This code is only used for testing background features. Set TEST to false, when building a release or when testing the whole app
                if (TEST)
                {
                    TEST_MAIN();
                    return;
                }


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
            SETTINGS_FILE.version = Constants.VERSION;
            SETTINGS_FILE.author = Constants.AUTHOR;
            SETTINGS_FILE.description = Constants.DESCRIPTION;
            FileHandler.updateJSON_FILE(Constants.FILE_SETTINGS_PATH, SETTINGS_FILE);
            DIR_MANAGER_PATH = Path.Combine(CP2077MM_PATH, Constants.NAME_DIRECTORY_MANAGER_JSON);
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

        private static void TEST_MAIN()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            
        }
    }
}