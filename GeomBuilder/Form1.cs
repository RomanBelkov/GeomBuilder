using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometryLibrary;

namespace GeomBuilder
{
    public partial class Form1 : Form
    {
        private Geometry.Point[] Points = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Satisfy_Click(object sender, EventArgs e)
        {
            var rnd = new System.Random();
            Func<int> next = () => rnd.Next(0, 400);
            Func<Geometry.Point> nextPt = () => new Geometry.Point(next(), next());
            Points = new Geometry.Point[4].Select(i => nextPt()).ToArray();

            var res = Geometry.Checker(Points[0], Points[1], Points[2], Points[3]);
            label1.Text = res ? "yes" : "no";
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Points != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Func<Geometry.Point, Point> convert = (p) => new Point((int)p.X, (int)p.Y);

                e.Graphics.DrawLine(new Pen(Color.Red), convert(Points[0]), convert(Points[1]));
                e.Graphics.DrawLine(new Pen(Color.CornflowerBlue), convert(Points[2]), convert(Points[3]));
            }
        }
    }
}
