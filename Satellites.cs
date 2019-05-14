using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml.Schema;

namespace Test_Game
{
    class Satellites
    {
        //declare variables
        Canvas canvas;
        Direction direction;
        public Point _satellite;
        Snake snake;
        Food food;
        public Rectangle _satelliteRectangle = new Rectangle();
        public Rectangle _satellite1Rectangle = new Rectangle();
        public Random rdmSatellite = new Random((int)DateTime.Now.Ticks);
        public bool SilvesterStallone = false;


        public Satellites(Canvas c, Window w)
        {
            canvas = c;
            _satellite.X = rdmSatellite.Next(3, 49);
            _satellite.Y = rdmSatellite.Next(3, 49);
            _satellite1Rectangle.Width = 20;
            _satellite1Rectangle.Height = 60;
            _satellite1Rectangle.Fill = Brushes.White;
            canvas.Children.Add(_satellite1Rectangle);
            Canvas.SetLeft(_satellite1Rectangle, _satellite.X * 10);
            Canvas.SetTop(_satellite1Rectangle, _satellite.Y * 10);
            if (SilvesterStallone == true)
            {
                for (int j = snake._bodyRectangle.Count - 1; j > 0; j--)
                {
                    snake._bodyRectangle[snake._bodyRectangle.Count - j].Fill = Brushes.Black;
                    snake._bodyRectangle[0].Fill = Brushes.Black;
                    snake._bodyRectangle.Clear();
                }
                Canvas.SetTop(_satellite1Rectangle, _satellite.Y * 10);
                Canvas.SetLeft(_satellite1Rectangle, _satellite.X * 10);
            }
        }


        public void CollisionWithObstacle()
        {
            //collision  with top left
            if ((Canvas.GetLeft(snake._headRectangle) > Canvas.GetLeft(_satellite1Rectangle)) &&
                (Canvas.GetLeft(snake._headRectangle) < Canvas.GetLeft(_satellite1Rectangle) + snake._headRectangle.Width) &&
                (Canvas.GetTop(snake._headRectangle) > Canvas.GetTop(_satellite1Rectangle)) &&
                (Canvas.GetTop(snake._headRectangle) < Canvas.GetTop(_satellite1Rectangle) + snake._headRectangle.Height))
            {
                snake.SilvesterStallone = true;
                food.update();
                MessageBox.Show("");
                Canvas.SetLeft(_satellite1Rectangle, _satellite.X * 10);
                Canvas.SetTop(_satellite1Rectangle, _satellite.Y * 10);
            }
        }
    }
}
