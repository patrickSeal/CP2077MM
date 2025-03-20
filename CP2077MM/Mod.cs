using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2077MM
{
    class Mod
    {
        public string name { get; set; } = Constants.UNKNOWN_STRING;
        public string summary { get; set; } = Constants.UNKNOWN_STRING;
        public string description { get; set; } = Constants.UNKNOWN_STRING;
        public int uid { get; set; } = 0;
        public int mod_id { get; set; } = 0;
        public int category_id { get; set; } = 0;
        public string version { get; set; } = Constants.UNKNOWN_STRING;
        public string author { get; set; } = Constants.UNKNOWN_STRING;
        public string uploaded_users_profile_url { get; set; } = Constants.UNKNOWN_STRING;
        public string status { get; set; } = Constants.UNKNOWN_STRING;
        public bool available { get; set; } = false;

        public Mod() 
        {
        }
    }
}
