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
        private Color color;
        public Timer timer;
        private readonly int oneMinute;
        private readonly int dayHalf;
        private readonly double Lenght;
        public ClockControl()
        {
            oneMinute = 60;
            dayHalf = 12; 
            Lenght = 140;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.Paint += ClockControl_Paint;
        }

        public ClockControl(Size size, Point point, Color color) : this()
        {
            this.Size = size;
            this.Location = point;
            this.color = color;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ClockControl_Paint(object sender, PaintEventArgs e)
        {
            PaintClock(DateTime.Now);
        }
        private void PaintClock(DateTime dtArg)
        {
            DrawCircle();
            //PaintArrows(dtArg);
        }
        
        private void DrawCircle()
        {
            var draw = this.CreateGraphics();

            for (int i = 0; i < dayHalf; i++)
            {
                draw.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point((int)(ClientRectangle.Width / 2 + Lenght * Math.Cos(Math.PI / 6 * i)), 
                                                                            (int)(ClientRectangle.Height / 2 + Lenght * Math.Sin(Math.PI / 6 * i))),
                                                                            new Size(10, 10)));
                if (i == 3)
                {
                    float x = (float)(ClientRectangle.Width / 2 + Lenght * Math.Cos(Math.PI / 6 * i));
                    float y = (float)(ClientRectangle.Height / 2 + Lenght * Math.Sin(Math.PI / 6 * i));
                }
            }

            draw.FillEllipse(new SolidBrush(this.color), new Rectangle(new Point((int)(this.ClientRectangle.Width / 2 - Lenght + 10),
                        (int)(this.ClientRectangle.Height / 2 - Lenght + 10)), new Size((int)(Lenght - 10) * 2, (int)(Lenght - 10) * 2)));

        }
    }
}
