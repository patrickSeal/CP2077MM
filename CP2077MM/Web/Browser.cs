using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace CP2077MM.Web
{
    public class Requirement
    {
        public long mod_id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string url { get; set; }
    }

    class Browser
    {

        private static readonly Regex sWhitespace = new Regex(@"\s+");

        public static async Task<List<Requirement>> getRequirements(long mod_id)
        {
            List<Requirement> reqs = new List<Requirement>();

            HttpClient client = new HttpClient();
            string url = Constants.NEXUSMODS_WEB + "/" + mod_id.ToString();
            string page = await client.GetStringAsync(url);
            int startIndx = page.IndexOf("Nexus requirements");
            if (startIndx == -1) return reqs;
            string firstCut = page.Substring(startIndx);
            int endIndx = firstCut.IndexOf("</table>");
            string table = firstCut.Substring(0, endIndx);

            int idx = 0;
            string key = "href=\"" + Constants.NEXUSMODS_WEB + "/";
            while ((idx = table.IndexOf(key)) != -1)
            {
                Requirement req = new Requirement();

                // 1. get link and mod_id
                string tmp = table.Substring(idx + key.Length);
                int endIdx = tmp.IndexOf("\"");
                string req_id = table.Substring(idx + key.Length, endIdx);
                table = tmp.Substring(endIdx);

                // get the Name of the mod
                int startIdx = table.IndexOf('>');
                table = table.Substring(startIdx);
                endIdx = table.IndexOf('<');
                string name = table.Substring(1, endIdx-1);
                table = table.Substring(endIdx);

                // get the notes of the mod
                string key_notes = "-notes\">";
                startIdx = table.IndexOf(key_notes);
                table = table.Substring(startIdx);
                endIdx = table.IndexOf('<');
                string notes = table.Substring(key_notes.Length, endIdx - key_notes.Length);
                table = table.Substring(endIdx);

                req.mod_id = Int64.Parse(req_id);
                req.name = sWhitespace.Replace(name, "");
                req.note = notes;
                req.url = Constants.NEXUSMODS_WEB + "/" + req_id;
                // adding the Requirement object
                reqs.Add(req);
            }
            return reqs;
        }
    }
}
