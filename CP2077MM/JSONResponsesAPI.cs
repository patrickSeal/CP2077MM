using CP2077MM;

namespace WinFormsApp1
{
    public class USER_GET_VALIDATE
    {
        public int user_id { get; set; } = 0;
        public string apikey { get; set; } = Constants.UNKNOWN_STRING;
        public string name { get; set; } = Constants.UNKNOWN_STRING;
        public bool is_premium { get; set; } = false;
        public bool is_supporter { get; set; } = false;
        public string email { get; set; } = Constants.UNKNOWN_STRING;
        public string profile_url { get; set; } = Constants.UNKNOWN_STRING;
    }

    public class MODS_GET_RETRIEVEMOD
    {
        public string name { get; set; } = string.Empty;
        public long mod_id { get; set; } = 0;
        public string version { get; set; } = string.Empty;

        // Missing properties
    }

    class JSONResponsesAPI
    {
    }
}
