using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WinFormsApp1;

// TODO: REWRITE THIS WHOLE THING AND USE DATASET CLASS DIRECTLY WITHOUT WRAPPER



namespace CP2077MM.CP2077MM_Files
{
    public class ModEntry
    {
        public long mod_id;
        public string hash;
        public string name;
        public string version;

        public ModEntry(long mod_id, string modHash, string name, string version)
        {
            this.mod_id = mod_id;
            this.hash = modHash;
            this.name = name;
            this.version = version;
        }
    }

    public class ModIndex
    {
        DataSet dataSet;
        DataTable mods;
        private readonly string ROOT = "installedMods";
        static string MOD_INDEX_PATH = String.Empty;

        private ModIndex()
        {
            dataSet = new DataSet();
            dataSet.Namespace = "ModIndex";
            mods = new DataTable(ROOT);
            DataColumn mod_id = new DataColumn("mod_id", typeof(long));
            DataColumn md5 = new DataColumn("md5", typeof(string));
            DataColumn name = new DataColumn("name", typeof(string));
            DataColumn version = new DataColumn("version", typeof(string));
            mods.Columns.Add(mod_id);
            mods.Columns.Add(md5);
            mods.Columns.Add(name);
            mods.Columns.Add(version);
            dataSet.Tables.Add(mods);
        }

        private ModIndex(DataSet dataSet)
        {
            this.dataSet = dataSet;
            mods = dataSet.Tables[ROOT];
            if(!mods.Columns.Contains("mod_id"))
            {
                mods.Columns.Add(new DataColumn("mod_id", typeof(long)));
            }
            if (!mods.Columns.Contains("md5"))
            {
                mods.Columns.Add(new DataColumn("md5", typeof(string)));
            }
            if (!mods.Columns.Contains("name"))
            {
                mods.Columns.Add(new DataColumn("name", typeof(string)));
            }
            if (!mods.Columns.Contains("version"))
            {
                mods.Columns.Add(new DataColumn("version", typeof(string)));
            }
        }

        public static ModIndex OpenModIndex()
        {
            string path = Path.Combine(MainProgram.CP2077MM_PATH, Constants.MOD_INDEX_JSON);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            string json = File.ReadAllText(path);
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            MOD_INDEX_PATH = path;
            if (dataSet == null) return new ModIndex();
            else return new ModIndex(dataSet);
        }

        public int addEntry(ModEntry entry)
        {
            DataRow row = mods.NewRow();
            row["mod_id"] = entry.mod_id;
            row["md5"] = entry.hash;
            row["name"] = entry.name;
            row["version"] = entry.version;
            mods.Rows.Add(row);
            return 0;
        }

        public int removeEntryByID(long mod_id)
        {
            int row = containsMOD_ID(mod_id);
            if (row == -1) return -1;
            mods.Rows.RemoveAt(row);
            return 0;
        }

        public bool containsEntry(ModEntry entry)
        {
            foreach (DataRow row in mods.Rows)
            {
                if ((int)row["mod_id"] == entry.mod_id && ((string)row["md5"]).Equals(entry.hash))
                {
                    // mod is already installed
                    return true;
                }
            }
            return false;
        }

        public bool containsHash(string md5)
        {
            foreach (DataRow row in mods.Rows)
            {
                if (((string)row["md5"]).Equals(md5)) return true;
            }
            return false;
        }

        /*
         * Returns the row number if present otherwise -1
         */
        public int containsMOD_ID(long mod_id)
        {
            int i = 0;
            foreach (DataRow row in mods.Rows)
            {
                if (((long)row["mod_id"]) == mod_id) return i;
                i++;
            }
            return -1;
        }

        public List<string> getInstalledModNames()
        {
            List<string> list = new List<string>();

            foreach (DataRow row in mods.Rows)
            {
                list.Add(row["name"] + " " + row["version"]);
            }
            return list;
        }

        public int getModID(string name)
        {
            foreach (DataRow row in mods.Rows)
            {
                if (name.Equals(row["name"])) return (int)row["mod_id"];
            }
            return -1;
        }

        public List<ModEntry> getEntries()
        {
            List<ModEntry > list = new List<ModEntry>();
            foreach (DataRow row in mods.Rows)
            {
                list.Add(new ModEntry((long)row["mod_id"], (string)row["md5"], (string)row["name"], (string)row["version"]));
            }
            return list;
        }

        public ModEntry getEntry(long mod_id)
        {
            foreach (DataRow row in mods.Rows)
            {
                if ((long)row["mod_id"] == mod_id)
                {
                    return new ModEntry(mod_id, (string)row["md5"], (string)row["name"], (string)row["version"]);
                }
            }
            return null;
        }

        public void Save()
        {
            dataSet.AcceptChanges();
            string json = JsonConvert.SerializeObject(this.dataSet, Formatting.Indented);
            File.WriteAllText(MOD_INDEX_PATH, json);
        }
    }
}
