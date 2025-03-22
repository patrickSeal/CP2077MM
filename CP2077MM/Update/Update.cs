using CP2077MM.CP2077MM_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CP2077MM.Update
{
    public class Update
    {
        ModIndex mods;
        List<ModEntry> indexedMods;
        ProgressBar pB;
        public Update(ProgressBar pB) 
        {
            mods = ModIndex.OpenModIndex();
            indexedMods = mods.getEntries();
            this.pB = pB;
        }

        public async Task<List<(ModEntry, ModEntry)>> getUpdates()
        {
            List<(ModEntry, ModEntry)> updates = new List<(ModEntry, ModEntry)>();
            if (updates.Count == 0) return updates;
            pB.Visible = true;
            pB.Minimum = 1;
            pB.Maximum = indexedMods.Count;
            pB.Value = 1;
            pB.Step = 1;
            foreach (ModEntry ent in indexedMods)
            {
                Mod mod = await Mod.retrieveMod(ent.mod_id);
                /* newest mod has a different version than the currently installed mod */
                if (ent.version != mod.version)
                {
                    // md5 hash is not needed for updates
                    ModEntry updated = new ModEntry(mod.mod_id, Constants.UNKNOWN_STRING, mod.name, mod.version);
                    updates.Add((ent, updated));
                }
                pB.PerformStep();
            }
            pB.Visible = false;
            return updates;
        }
    }
}
