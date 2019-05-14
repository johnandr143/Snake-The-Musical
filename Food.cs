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

    class Food
    {
        public Point _food;
        Canvas canvas;
        public Rectangle _foodRectangle;
        Snake snake;
        public Random rdmFood = new Random();
        private Collision collision;
        public bool Eat = false;

        public Food(Canvas c, Window w)
        {
            canvas = c;
            _foodRectangle = new Rectangle();
            _food.X = rdmFood.Next(7, 42);
            _food.Y = rdmFood.Next(7, 42);
            _foodRectangle.Width = 10;
            _foodRectangle.Height = 10;
            _foodRectangle.Fill = Brushes.Gold;
            canvas.Children.Add(_foodRectangle);
            Canvas.SetLeft(_foodRectangle, _food.X * 10);
            Canvas.SetTop(_foodRectangle, _food.Y * 10);
        }
        public void update()
        {
            if (Eat == true)
            {
                _food.X = rdmFood.Next(20, 45);
                _food.Y = rdmFood.Next(20, 45);
                Canvas.SetLeft(_foodRectangle, _food.X * 10);
                Canvas.SetTop(_foodRectangle, _food.Y * 10);
            }
        }
    }
}    