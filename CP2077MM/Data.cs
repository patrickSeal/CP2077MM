
namespace CP2077MM
{
    class Data
    {
    }

    public class SettingsFile
    {
        public string path { get; set; } = Constants.UNKNOWN_STRING;
        public string name { get; set; } = Constants.UNKNOWN_STRING;
        public string version { get; set; } = Constants.UNKNOWN_STRING;
        public string author { get; set; } = Constants.UNKNOWN_STRING;
        public string description { get; set; } = Constants.UNKNOWN_STRING;
        public string cyberpunk_install_dir { get; set; } = Constants.UNKNOWN_STRING;
    }
    public class ProfileFile
    {
        public string apikey { get; set; } = Constants.UNKNOWN_STRING;
        public int user_id { get; set; } = 0;
        public string username { get; set; } = Constants.UNKNOWN_STRING;
        public bool is_premium { get; set; } = false;
        public bool is_supporter { get; set; } = false;
        public string email { get; set; } = Constants.UNKNOWN_STRING;
        public string profile_url { get; set; } = Constants.UNKNOWN_STRING;

        public bool auto_update_check { get; set; } = true;
    }

}
