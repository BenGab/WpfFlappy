using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfFlappy
{
    class FlappyRenderer
    {
        private FlappyModel model;

        Pen black = new Pen(Brushes.Black, 2);
        Pen red = new Pen(Brushes.Red, 2);
        Typeface font = new Typeface("Arial");
        Point textLocation = new Point(10, 10);
        Rect bgRect;
        FormattedText formattedText;
        int oldErrorsValue = -1;

        public FlappyRenderer(FlappyModel model)
        {
            this.model = model;
            bgRect = new Rect(0, 0, model.GameWidth, model.GameHeight);
        }

        public void BuildDisplay(DrawingContext ctx)
        {
            DrawBackground(ctx);
            DrawBird(ctx);
            DrawPipes(ctx);
            DrawText(ctx);
        }

        private void DrawBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(Brushes.Gray, null, bgRect);
        }
        private void DrawBird(DrawingContext ctx)
        {
            ctx.DrawGeometry(Brushes.Red, red, model.Bird.RealArea);
        }
        private void DrawPipes(DrawingContext ctx)
        {
            foreach (OnePipe pipe in model.Pipes)
            {
                ctx.DrawGeometry(Brushes.Green, black, pipe.RealArea);
            }
        }
        private void DrawText(DrawingContext ctx)
        {
            if (oldErrorsValue != model.Errors)
            {
                formattedText = new FormattedText(
                    model.Errors.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    font,
                    16,
                    Brushes.Black, 1);
            }
            ctx.DrawText(formattedText, textLocation);
        }
    }
}
