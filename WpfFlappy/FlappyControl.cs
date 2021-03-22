using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfFlappy
{
    class FlappyControl : FrameworkElement
    {
        FlappyModel model;
        FlappyLogic logic;
        FlappyRenderer renderer;
        DispatcherTimer timer;

        public FlappyControl()
        {
            Loaded += FlappyControl_Loaded;
        }

        private void FlappyControl_Loaded(object sender, RoutedEventArgs e)
        {
            Window wnd = Window.GetWindow(this);
            model = new FlappyModel(ActualWidth, ActualHeight);
            logic = new FlappyLogic(model);
            renderer = new FlappyRenderer(model);

            if(wnd != null) //Rendering and Timer run
            {
                wnd.KeyDown += Wnd_KeyDown;
                wnd.MouseDown += Wnd_MouseDown;
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(100);
                timer.Tick += Timer_Tick;
                timer.Start();
            }

            InvalidateVisual();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            logic.OneTick();
            InvalidateVisual();
        }

        private void Wnd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            logic.ClickScreen(e.GetPosition(this));
        }

        private void Wnd_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: logic.BirdBoost(-5); break;
                case Key.Down: logic.BirdBoost(5); break;
            }
            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (renderer != null) renderer.BuildDisplay(drawingContext);
        }
    }
}
