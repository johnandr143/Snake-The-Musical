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
    class Snake
    {
        //declaring all the variables
        public Point _head;
        Canvas canvas;
        public Rectangle _headRectangle;
        Direction direction;
        public List<Point> _body;
        public List<Rectangle> _bodyRectangle;
        public bool SlimShady = false;
        public bool SilvesterStallone = false;
        public int counter = 0;

        public Snake(Canvas c, Window w)
        {
            //Random x and y point of the point head
            Random pointx1 = new Random();
            Random pointy1 = new Random();
            canvas = c;
            //Creating the random point head
            _head = new Point(pointx1.Next(3, 49), pointy1.Next(3, 49));
            _headRectangle = new Rectangle();
            _headRectangle.Fill = Brushes.Red;
            _headRectangle.Width = 10;
            _headRectangle.Height = 10;
            canvas.Children.Add(_headRectangle);

            //Creating the physical head with 
            //as coordinate the previous points
            Canvas.SetLeft(_headRectangle, _head.X * 10);
            Canvas.SetTop(_headRectangle, _head.Y * 10);
            direction = Direction.Right;
            _body = new List<Point>();
            _bodyRectangle = new List<Rectangle>();

        }
        public void update()
        {
            //Movement with WASD
            if (Keyboard.IsKeyDown(Key.W))
            {
                direction = Direction.Up;
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                direction = Direction.Left;
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                direction = Direction.Down;
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                direction = Direction.Right;
            }
            else if (Keyboard.IsKeyDown(Key.Left))
            {
                direction = Direction.Left;
            }
            else if (Keyboard.IsKeyDown(Key.Down))
            {
                direction = Direction.Down;
            }
            else if (Keyboard.IsKeyDown(Key.Right))
            {
                direction = Direction.Right;
            }
            else if (Keyboard.IsKeyDown(Key.Up))
            {
                direction = Direction.Up;
            }

            //Creation of body when they eat the food
            if (SlimShady == true)
            {
                //Keyboard.IsKeyUp(Key.Space);     
                if (_body.Count == 0)
                {
                    _body.Add(_head);
                }
                else
                {
                    _body.Add(_body[_body.Count - 1]);
                }
                _bodyRectangle.Add(new Rectangle());
                _bodyRectangle[_bodyRectangle.Count - 1].Fill = Brushes.Green;
                _bodyRectangle[_bodyRectangle.Count - 1].Width = 10;
                _bodyRectangle[_bodyRectangle.Count - 1].Height = 10;
                canvas.Children.Add(_bodyRectangle[_bodyRectangle.Count - 1]);
                Canvas.SetTop(_bodyRectangle[_bodyRectangle.Count - 1], _body[_body.Count - 1].X * 10);
                Canvas.SetLeft(_bodyRectangle[_bodyRectangle.Count - 1], _body[_body.Count - 1].Y * 10);
            }
            SlimShady = false;

            switch (direction)
            {
                //movement 
                case Direction.Right:
                    _head = new Point(_head.X + 1, _head.Y);
                    break;
                case Direction.Down:
                    _head = new Point(_head.X, _head.Y + 1);
                    break;
                case Direction.Left:
                    _head = new Point(_head.X - 1, _head.Y);
                    break;
                case Direction.Up:
                    _head = new Point(_head.X, _head.Y - 1);
                    break;
                //direction none is when they die
                case Direction.None:
                    Random pointx1 = new Random();
                    Random pointy1 = new Random();
                    _head = new Point(25, 25);
                    break;
            }
            Canvas.SetLeft(_headRectangle, _head.X * 10);
            Canvas.SetTop(_headRectangle, _head.Y * 10);

            for (int i = 0; i < _bodyRectangle.Count; i++)
            {
                Canvas.SetLeft(_bodyRectangle[i], _body[i].X * 10);
                Canvas.SetTop(_bodyRectangle[i], _body[i].Y * 10);

                //Add collision with the body
                if (_body[i].X * 10 == _head.X * 10 && _body[i].Y * 10 == _head.Y * 10)
                {
                    var result1 = MessageBox.Show("Do you want to play again?", "You Lost", MessageBoxButton.YesNo);
                    if (result1 == MessageBoxResult.Yes)
                    //restart the game and cleaning the canvas
                    {
                        direction = Direction.None;
                        for (int j = _bodyRectangle.Count - 1; j > 0; j--)
                        {
                            _bodyRectangle[_bodyRectangle.Count - j].Fill = Brushes.Black;
                            _bodyRectangle[0].Fill = Brushes.Black;
                        }
                        _bodyRectangle.Clear();
                        _body.Clear();
                    }
                    else
                    //close the application
                    {
                        System.Windows.Application.Current.Shutdown();
                    }
                }
            }
            for (int i = _bodyRectangle.Count - 1; i > 0; i--)
            {
                _body[i] = _body[i - 1];
            }
            if (_body.Count > 0)
            {
                _body[0] = _head;
            }
            //collision with borders and same options as before:restart or close
            if (_head.X * 10 + 2 > 499 || _head.X * 10 + 2 < 21)
            {
                counter = 0;
                var result = MessageBox.Show("Do you want to play again?", "You Lost", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = _bodyRectangle.Count; i > 0; i--)
                    {
                        _bodyRectangle[_bodyRectangle.Count - i].Fill = Brushes.Black;
                    }
                    _bodyRectangle.Clear();
                    direction = Direction.None;
                }
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
            //collision with borders
            if (_head.Y * 10 + 2 > 499 || _head.Y * 10 + 2 < 21)
            {
                counter = 0;
                var result1 = MessageBox.Show("Do you want to play again?", "You Lost", MessageBoxButton.YesNo);
                if (result1 == MessageBoxResult.Yes)
                //restart the game and cleaning the canvas
                {
                    direction = Direction.None;
                    for (int j = _bodyRectangle.Count - 1; j > 0; j--)
                    {
                        _bodyRectangle[_bodyRectangle.Count - j].Fill = Brushes.Black;
                        _bodyRectangle[0].Fill = Brushes.Black;
                    }
                    _bodyRectangle.Clear();
                    _body.Clear();
                }
                else
                //close the application
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        public void NewGame()
        {
            direction = Direction.None;

            //Random x and y point of the point head
            Random pointx1 = new Random();
            Random pointy1 = new Random();
            //Creating the random point head
            _head = new Point(pointx1.Next(3, 49), pointy1.Next(3, 49));
            _headRectangle = new Rectangle();
            _headRectangle.Fill = Brushes.Red;
            _headRectangle.Width = 10;
            _headRectangle.Height = 10;
            //canvas.Children.Remove(_headRectangle);
            canvas.Children.Add(_headRectangle);

            //Creating the physical head with 
            //as coordinate the previous points
            Canvas.SetLeft(_headRectangle, _head.X * 10);
            Canvas.SetTop(_headRectangle, _head.Y * 10);
        }
    }
}