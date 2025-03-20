using CP2077MM.CP2077MM_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2077MM.Integrity
{
    class Dependencies
    {
        ModIndex modIndex;
        List<ModEntry> mods;
        Dictionary<long, List<Dependency_Raw>> missingReqs = new Dictionary<long, List<Dependency_Raw>>();
        public Dependencies()
        {
            modIndex = ModIndex.OpenModIndex();
            mods = modIndex.getEntries();
        }
        public int checkRequirements()
        {
            foreach (ModEntry mod in mods)
            {
                checkModRequirements(mod);
            }
            return 0;
        }

        private int checkModRequirements(ModEntry mod)
        {
            ModFile modFile = ModFile.Open(mod.mod_id);

            Dependency_Raw[] reqs = modFile.getRequirements();

            List<Dependency_Raw> missing = new List<Dependency_Raw>();

            foreach (Dependency_Raw req in reqs)
            {
                try
                {
                    ModFile reqFile = ModFile.Open(req.mod_id);
                    // requirement is installed
                    modFile.setReqInstalled(req.mod_id, true);
                }
                catch (Exception e)
                {
                    // requirement is not installed
                    modFile.setReqInstalled(req.mod_id, false);
                    missing.Add(req);
                }
            }
            missingReqs.Add(mod.mod_id, missing);

            modFile.Save();
            return 0;
        }

        public Dictionary<long, List<Dependency_Raw>> getMissingReqs()
        {
            return missingReqs;
        }
    }
}
