using CP2077MM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class APIConnection
    {
        private string API_KEY = "";
        private string URL = "https://api.nexusmods.com/";
        private string MODS_BASE_ADDRESS = "v1/games/cyberpunk2077/mods/";
        public readonly static string UNAUTHORIZED = "unauthorized";
        public readonly static string UNEXPECTED_API_ERROR = "unexpected_api_error";

        static readonly HttpClient client = new HttpClient();
        static HttpRequestHeaders headers = client.DefaultRequestHeaders;

        public APIConnection(string apikey)
        {
            Console.WriteLine("[INFO]: API Connection created.");
            API_KEY = apikey;
            if(!headers.Contains("accept")) headers.Add("accept", "application/json");
            if (!headers.Contains("apikey")) headers.Add("apikey", API_KEY);
            else
            {
                headers.Remove("apikey");
                headers.Add("apikey", API_KEY);
            }
        }

        /**
         * Underlying HTTP GET request for every API request.
         */
        private async Task<string> HTTP_GET_REQUEST(string request, string fullURL)
        {
            string req_complete;
            if (fullURL.Equals(""))
            {
                req_complete = URL + request;
            }
            else
            {
                req_complete = fullURL;
            }
            Console.WriteLine("[INFO]: Connecting to server " + req_complete);
            Console.WriteLine("[INFO]: Header Information: " + headers);
            using HttpResponseMessage response = await client.GetAsync(req_complete);
            Console.WriteLine("[INFO]: " + response.StatusCode + " " + response.ReasonPhrase);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // apikey not working
                MessageBox.Show("NexusMods API authorization failed, is your APIKEY up to date? Please add a new file key in Choom -> Profile -> Apikey", "HTTP error: unauthorized");
                return UNAUTHORIZED;
            }
            if(!response.IsSuccessStatusCode)
            {
                return UNEXPECTED_API_ERROR;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return responseBody;
        }

        /**
         * Underlying HTTP DELETE request for every API request.
         */
        private async Task<string> HTTP_DELETE_REQUEST(string request, HttpContent httpContent)
        {
            string req_complete = URL + request;
            //headers.Add("accept", "application/json");
            //headers.Add("apikey", API_KEY);

            var HTTPrequest = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(req_complete),
                Content = httpContent
            };
            HTTPrequest.Headers.Add("accept", "application/json");
            HTTPrequest.Headers.Add("apikey", API_KEY);

            using HttpResponseMessage response = await client.SendAsync(HTTPrequest);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("NexusMods API authorization failed, is your APIKEY up to date? Please add a new file key in Choom -> Profile -> Apikey", "HTTP error: unauthorized");
                return UNAUTHORIZED;
            }
            if (!response.IsSuccessStatusCode)
            {
                return UNEXPECTED_API_ERROR;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return responseBody;
        }

        /**
         * Underlying HTTP POST request for every API request.
         */
        private async Task<string> HTTP_POST_REQUEST(string request, HttpContent httpContent)
        {
            string req_complete = URL + request;
            //headers.Add("accept", "application/json");
            //headers.Add("apikey", API_KEY);
            using HttpResponseMessage response = await client.PostAsync(req_complete, httpContent);
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                MessageBox.Show("NexusMods API authorization failed, is your APIKEY up to date? Please add a new file key in Choom -> Profile -> Apikey", "HTTP error: unauthorized");
                return UNAUTHORIZED;
            }
            if (!response.IsSuccessStatusCode)
            {
                return UNEXPECTED_API_ERROR;
            }
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            return responseBody;
        }

        /**
         * Returns a list of mods that have been updated in a given period, with timestamps of their last update. Cached for 5 minutes.
         * 
         * Accepted periods: 1d, 1w, 1m
         */
        public async Task<string> MODS_GET_update(string period)
        {
            string request = MODS_BASE_ADDRESS + "updated.json?period=" + period;
            return await HTTP_GET_REQUEST(request, "");
        }
        /**
         * Returns list of changelogs for mod
         */
        public async Task<string> MODS_GET_changelogs(string mod_id)
        {
            string request = MODS_BASE_ADDRESS + mod_id + "/changelogs.json";
            return await HTTP_GET_REQUEST(request, "");
        }

        /**
         * Retrieve 10 latest added mods for a specified game
         */
        public async Task<string> MODS_GET_latest_added()
        {
            string request = MODS_BASE_ADDRESS + "latest_added.json";
            return await HTTP_GET_REQUEST(request, "");
        }

        /**
         * Retrieve 10 latest updated mods for a specified game
         */
        public async Task<string> MODS_GET_latest_updated()
        {
            string request = MODS_BASE_ADDRESS + "latest_updated.json";
            return await HTTP_GET_REQUEST(request, "");
        }

        /**
         * Retrieve 10 trending mods for a specified game
         */
        public async Task<string> MODS_GET_trending()
        {
            string request = MODS_BASE_ADDRESS + "trending.json";
            return await HTTP_GET_REQUEST(request, "");
        }

        /**
         * Retrieve specified mod, from a specified game. Cached for 5 minutes.
         */
        public async Task<Mod> MODS_GET_retrieveMod(string mod_id)
        {
            string request = MODS_BASE_ADDRESS + mod_id + ".json";
            string answer = await HTTP_GET_REQUEST(request, "");
            return JsonConvert.DeserializeObject<Mod>(answer);
        }

        /**
         * Looks up a file MD5 file hash
         */
        public async Task<string> MODS_GET_md5hash(string md5hash)
        {
            string request = MODS_BASE_ADDRESS + "md5_search/" + md5hash + ".json";
            return await HTTP_GET_REQUEST(request, "");
        }

        //-----------------------------------------------------------------------------------------
        // MOD FILES API CALLS

        /**
         * Lists all files for a specific mod
         * 
         * Possibly available categories: main, update, optional, old_version, miscellaneous
         */
        public async Task<string> MODFILES_GET_files(string mod_id, string category)
        {
            string request = MODS_BASE_ADDRESS + mod_id + "/files.json?category=" + category;
            return await HTTP_GET_REQUEST(request, "");
        }

        /**
         * View a specified mod file, using a specified game and mod
         * 
         */
        public async Task<string> MODFILES_GET_modFile(string mod_id, string file_id)
        {
            string request = MODS_BASE_ADDRESS + mod_id + "/files/" + file_id + ".json";
            return await HTTP_GET_REQUEST(request, "");
        }

        /**
         * Can be used to compare file structures of manually installed mods.
         */
        public async Task<string> MODFILES_GET_preview(string link)
        {
            string escaped_link = "";
            for (int i = 0; i< link.Length; i++)
            {
                if (link[i] == ' ')
                {
                    escaped_link += "%20";
                }else escaped_link += link[i];
            }
            return await HTTP_GET_REQUEST("", escaped_link);
        }

        /**
         * Generate download link for mod file. For premium users, will return array of download links with their prefered download location in the first element.
         * 
         * IMPORTANT: FOR PREMIUM USERS ONLY
         */
        public async Task<string> MODFILES_GET_downloadLink(string mod_id, string file_id, string premiumKey, string expires)
        {
            string request = MODS_BASE_ADDRESS + mod_id + "/files.json?key=" + premiumKey + "&expires=" + expires;
            return await HTTP_GET_REQUEST(request, "");
        }


        //-----------------------------------------------------------------------------------------
        // GAMES API CALLS

        /**
         * Returns specified game, along with download count, file count and categories.
         */
        public async Task<string> GAMES_GET_Cyberpunk2077()
        {
            string request = "v1/games/cyberpunk2077.json";
            return await HTTP_GET_REQUEST(request, "");
        }


        //-----------------------------------------------------------------------------------------
        // USER API CALLS

        /**
         * Checks an API key is valid and returns the user's details.
         */
        public async Task<USER_GET_VALIDATE> USER_GET_validate()
        {
            string request = "v1/users/validate.json";
            string result = await HTTP_GET_REQUEST(request, "");
            if (result.Equals(UNAUTHORIZED)) return null;
            return JsonConvert.DeserializeObject<USER_GET_VALIDATE>(result);
        }

        /**
         * Fetch all the mods being tracked by the current user
         */
        public async Task<string> USER_GET_trackedMods()
        {
            string request = "v1/user/tracked_mods.json";
            return await HTTP_GET_REQUEST(request, "");
        }

        /**
         * Track this mod with the current user
         */
        public async Task<string> USER_POST_trackMod(string mod_id)
        {
            string request = "v1/user/tracked_mods.json?domain_name=cyberpunk2077";

            StringContent content = new StringContent("mod_id=" + mod_id, Encoding.UTF8, "application/x-www-form-urlencoded");

            return await HTTP_POST_REQUEST(request, content);
        }

        /**
         * Stop tracking this mod with the current user
         */
        public async Task<string> USER_DELETE_untrackMod(string mod_id)
        {
            string request = "v1/user/tracked_mods.json?domain_name=cyberpunk2077";

            StringContent content = new StringContent("mod_id=" + mod_id, Encoding.UTF8, "application/x-www-form-urlencoded");

            return await HTTP_DELETE_REQUEST(request, content);
        }
    }
}
