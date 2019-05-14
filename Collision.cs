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
    class Collision
    {
        Canvas canvas;
        Snake snake;
        Food food;
        Satellites satellites;

        public Collision(Canvas c, Window w, Food f, Snake s, Satellites sat)
        {
            food = f;
            snake = s;
            satellites = sat;
            snake.update();
            canvas = c;

        }
        public void Collide()
        {

        }
    }
}
