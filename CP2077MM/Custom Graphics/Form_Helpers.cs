using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2077MM.Custom_Graphics
{
    public class Form_Helpers
    {

        public static void initProgressBar(ProgressBar pb, int min, int max, int step, int start)
        {
            pb.Minimum = min;
            pb.Maximum = max;
            pb.Step = step;
            pb.Value = start;
            pb.Visible = true;
        }
    }
}
