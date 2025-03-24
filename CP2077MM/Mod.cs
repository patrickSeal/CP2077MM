
using WinFormsApp1;

namespace CP2077MM
{
    class Mod
    {
        public string name { get; set; } = Constants.UNKNOWN_STRING;
        public string summary { get; set; } = Constants.UNKNOWN_STRING;
        public string description { get; set; } = Constants.UNKNOWN_STRING;
        public string picture_url { get; set; } = Constants.UNKNOWN_STRING;
        public long mod_downloads { get; set; } = 0;
        public long mod_unique_downloads { get; set; } = 0;
        public long uid { get; set; } = 0;
        public long mod_id { get; set; } = 0;
        public long game_id { get; set; } = 0;
        public bool allow_rating { get; set; } = false;
        public string domain_name { get; set; } = Constants.UNKNOWN_STRING;
        public long category_id { get; set; } = 0;
        public string version { get; set; } = Constants.UNKNOWN_STRING;
        public long endorsement_cont { get; set; } = 0;
        public long created_timestamp { get; set; } = 0;
        public string created_time { get; set; } = Constants.UNKNOWN_STRING;
        public long updated_timestamp { get; set; } = 0;
        public string updated_time { get; set; } = Constants.UNKNOWN_STRING;
        public string author { get; set; } = Constants.UNKNOWN_STRING;
        public string uploaded_by { get; set; } = Constants.UNKNOWN_STRING;
        public string uploaded_users_profile_url { get; set; } = Constants.UNKNOWN_STRING;
        public bool contains_adult_content { get; set; } = false;
        public string status { get; set; } = Constants.UNKNOWN_STRING;
        public bool available { get; set; } = false;

        // Missing properties: user (object), endorsement (object)
        public Mod() 
        {

        }

        /*
         * This function is a wrapper for the MODS_GET_retrieveMod API call
         * It returns a Mod object
         */
        public static async Task<Mod> retrieveMod(long mod_id)
        {
            APIConnection con = new APIConnection(MainProgram.PROFILE_FILE.apikey);
            Mod response = await con.MODS_GET_retrieveMod(mod_id.ToString());
            return response;
        }
    }
}
