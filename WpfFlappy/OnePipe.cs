using System.Windows;
using System.Windows.Media;

namespace WpfFlappy
{
    class OnePipe : GameItem
    {
        public const int Gap = 120; // gap between upper and lower halfpipe
        public const int RectW = 20; // width

        public OnePipe(double h, double newcx)
        {
            CX = newcx;
            CY = h / 2;

            double RectH = 2 * h;
            GeometryGroup g = new GeometryGroup();
            Rect r1 = new Rect(-RectW / 2, -RectH - Gap / 2, RectW, RectH);
            Rect r2 = new Rect(-RectW / 2, Gap / 2, RectW, RectH);
            g.Children.Add(new RectangleGeometry(r1));
            g.Children.Add(new RectangleGeometry(r2));
            area = g;
        }
    }
}
