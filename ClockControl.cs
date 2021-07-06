using System;
using System.Drawing;
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
        private void PaintClock(DateTime date)
        {
            DrawCircle();
            DrawArrows(date);
        }
        private void DrawArrows(DateTime date)
        {
            var draw = this.CreateGraphics();

            draw.DrawLine(new Pen(new SolidBrush(Color.Black), 1), new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
               new Point((int)(ClientRectangle.Width / 2 + (Lenght - 2) * Math.Sin(2 * Math.PI / oneMinute * date.Second)), (int)(ClientRectangle.Height / 2 - (Lenght - 2) * Math.Cos(2 * Math.PI / oneMinute * date.Second))));

            draw.DrawLine(new Pen(new SolidBrush(Color.Black), 2), new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (Lenght - 4) * Math.Sin(2 * Math.PI / oneMinute * date.Minute)), (int)(ClientRectangle.Height / 2 - (Lenght - 4) * Math.Cos(2 * Math.PI / oneMinute * date.Minute))));
            
            int hour = 0;
            if (date.Hour <= dayHalf)
                hour = date.Hour;
            else
                hour = date.Hour - dayHalf;

            draw.DrawLine(new Pen(new SolidBrush(Color.Black), 4), new Point((int)(ClientRectangle.Width / 2), (int)(ClientRectangle.Height / 2)),
                new Point((int)(ClientRectangle.Width / 2 + (Lenght - 10) * Math.Sin(2 * Math.PI / dayHalf * hour + 2 * Math.PI / (dayHalf * oneMinute) * date.Minute)), (int)(ClientRectangle.Height / 2 - (Lenght - 10) * Math.Cos(2 * Math.PI / dayHalf * hour + 2 * Math.PI / (dayHalf * oneMinute) * date.Minute))));
        }
        private void DrawCircle()
        {
            var draw = this.CreateGraphics();

            for (int i = 0; i < dayHalf; i++)
            {
                draw.FillEllipse(new SolidBrush(Color.Black), new Rectangle(new Point((int)(this.Width / 2 + Lenght * Math.Cos(Math.PI / 6 * i)), 
                                                                            (int)(this.Height / 2 + Lenght * Math.Sin(Math.PI / 6 * i))),
                                                                            new Size(7, 7)));
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
