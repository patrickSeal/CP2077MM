using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP2077MM.Custom_Graphics
{
    class RoundButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(1, 1, ClientSize.Width - 4, ClientSize.Height - 4);
            this.Region = new Region(path);
            base.OnPaint(pevent);
        }
    }
}
