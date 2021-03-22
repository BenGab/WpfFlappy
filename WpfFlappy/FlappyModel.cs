using System.Collections.Generic;

namespace WpfFlappy
{
    class FlappyModel
    {
        public const int YStep = 300; // up-down movements of pipes
        const int NumPipes = 3;

        public int Errors { get; set; }
        public OneBird Bird { get; private set; }
        public List<OnePipe> Pipes { get; private set; }
        public double GameWidth { get; private set; }
        public double GameHeight { get; private set; }

        public FlappyModel(double w, double h)
        {
            GameWidth = w;
            GameHeight = h;

            Bird = new OneBird(50, h / 2);
            Pipes = new List<OnePipe>();
            for (int i = 0; i < NumPipes; i++)
            {
                Pipes.Add(new OnePipe(h, i * w / NumPipes));
            }
        }
    }
}
