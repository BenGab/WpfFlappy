using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfFlappy
{
    class FlappyLogic
    {
        static Random rnd = new Random();
        private FlappyModel model;

        public FlappyLogic(FlappyModel model)
        {
            this.model = model;
        }

        public void BirdBoost(double changeSpeed)
        {
            model.Bird.DY += changeSpeed;
        }

        public void ClickScreen(Point p)
        {
            int diff = 5 * Math.Sign(p.Y - model.Bird.CY);
            BirdBoost(diff);
        }

        void BirdTick()
        {
            model.Bird.CY += model.Bird.DY;
            model.Bird.DY += 0.8;
            model.Bird.Rad = Math.Atan2(model.Bird.DY, model.Bird.DX);
        }

        void PipeTick(OnePipe pipe)
        {
            pipe.CX -= model.Bird.DX;
            if (pipe.CX < 0)
            {
                pipe.CX = model.GameWidth;
                pipe.CY = rnd.Next(
                    (int)Math.Max(pipe.CY - FlappyModel.YStep, OnePipe.Gap / 2),
                    (int)Math.Min(pipe.CY + FlappyModel.YStep, model.GameHeight - OnePipe.Gap / 2)
                );
            }
        }

        public void OneTick()
        {
            BirdTick();
            foreach (OnePipe pipe in model.Pipes)
            {
                PipeTick(pipe);
                if (model.Bird.IsCollision(pipe)) model.Errors++;
            }
        }
    }
}
