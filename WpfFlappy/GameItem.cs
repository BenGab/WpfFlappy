using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfFlappy
{
    abstract class GameItem
    {
        protected Geometry area; // (0;0) centered!
        protected double rotDegree = 0; // rotation in degrees

        public double CX { get; set; } // center position when rendering
        public double CY { get; set; }

        public double Rad
        {
            get
            {
                return rotDegree * Math.PI / 180;
            }
            set
            {
                rotDegree = 180 * value / Math.PI;
            }
        }

        public Geometry RealArea
        {
            get
            {
                TransformGroup tg = new TransformGroup();
                tg.Children.Add(new TranslateTransform(CX, CY));
                tg.Children.Add(new RotateTransform(rotDegree, CX, CY));
                area.Transform = tg;
                return area.GetFlattenedPathGeometry();
            }
        }

        public bool IsCollision(GameItem other)
        {
            return Geometry.Combine(RealArea, other.RealArea,
                GeometryCombineMode.Intersect, null).GetArea() > 0;
        }
    }
}
