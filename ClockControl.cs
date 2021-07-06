using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public class ClockControl : Control
    {
        public Timer timer;
        public ClockControl()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.Paint += ClockControl_Paint;
        }

        public ClockControl(Size size, Point point)
        {
            this.Size = size;
            this.Location = point;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
