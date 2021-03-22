using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfFlappy
{
    class OneBird : GameItem
    {
        public double DY { get; set; }
        public double DX { get; set; }

        public OneBird(double newcx, double newcy)
        {
            CX = newcx;
            CY = newcy;
            DX = 10;

            Point p1 = new Point(10, 0);
            Point p2 = new Point(-10, -10);
            Point p3 = new Point(-10, 10);

            GeometryGroup g = new GeometryGroup();
            g.Children.Add(new LineGeometry(p1, p2));
            g.Children.Add(new LineGeometry(p1, p3));
            g.Children.Add(new LineGeometry(p2, p3));
            area = g.GetWidenedPathGeometry(new Pen(Brushes.Black, 2));
        }
    }
}
