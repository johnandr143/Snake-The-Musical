using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Test_Game
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : Window
    {
        Snake snake;
        Food food;
        Satellites satellites;
        Settings settings;
        StackPanel stackPanel;
        public bool ScorePlusPlus = false;
        Direction direction;

        public static bool dead = false;
        objCreate obj = new objCreate();
        menuPause mp;
        System.Windows.Threading.DispatcherTimer gameTimer = new System.Windows.Threading.DispatcherTimer();
        int framesUntilMove = 200 / 120;
        int frameCount = 0;
        MediaPlayer gamesound = new MediaPlayer();
        int counter = 0;
        Window form1;
        public MainGame()
        {
           // form1 = creatingForm;
          //  snake.setSuperForm = setCreatingForm;
            //snake.setCreatingForm = this;
            InitializeComponent();
            food = new Food(canvas, this);
            satellites = new Satellites(canvas, this);
            snake = new Snake(canvas, form1);

            //start Timer
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1 );//fps
            gameTimer.Start();

            //start music
            gamesound.Open(new Uri("GameMusicCrabRave.mp3", UriKind.Relative));
            gamesound.Volume= (100);
            gamesound.Play();
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (frameCount > framesUntilMove)
            {
                frameCount = 0;
                snake.update();
                //Collision with obstacle


                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if ((satellites._satellite.X + j) * 10 == snake._head.X * 10 && (satellites._satellite.Y + i) * 10 == snake._head.Y * 10)
                        {
                            //when silvesterStallone = true the snake dies
                            snake.SilvesterStallone = true;
                            food.update();
                            snake.counter = 0;
                        }
                    }
                }

                //end collision w/ obstacle

                if (snake.SilvesterStallone == true)
                {
                    snake.NewGame();
                    for (int i = snake._bodyRectangle.Count; i > 0; i--)
                    {
                        snake._bodyRectangle[snake._bodyRectangle.Count - i].Fill = Brushes.Black;
                    }
                    snake._bodyRectangle.Clear();
                    direction = Direction.None;
                    snake.SilvesterStallone = false;
                }

                //Collision with food
                if (food._food.X * 10 == snake._head.X * 10 && food._food.Y * 10 == snake._head.Y * 10)
                {
                    food.Eat = true;
                    snake.SlimShady = true;
                    food.update();
                    ScorePlusPlus = true;
                }
                //end collison w/ food
            }
            else
            {
                frameCount++;
            }

            //open menu
            if (ScorePlusPlus == true)
            {
                snake.counter += 100;
                lblScore.Content = "Score: " + snake.counter.ToString();
            }
            if (Keyboard.IsKeyDown(Key.Escape))
            {
                btnExit.Visibility = Visibility.Visible;
                btnRestart.Visibility = Visibility.Visible;
                btnResume.Visibility = Visibility.Visible;
                //btnSettings.Visibility = Visibility.Visible;
                gameTimer.Stop();
            }
            ScorePlusPlus = false;
        }

        private void Collision()
        {
            satellites.CollisionWithObstacle();
            snake.update();
            //Food food;
            if (food._food.X * 10 == snake._head.X * 10 || food._food.Y * 10 == snake._head.Y * 10)
                //food.Eat = true;
                MessageBox.Show("True");
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            direction = Direction.None;
            btnExit.Visibility = Visibility.Hidden;
            btnRestart.Visibility = Visibility.Hidden;
            btnResume.Visibility = Visibility.Hidden;
            btnSettings.Visibility = Visibility.Hidden;
        }
        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            btnRestart.Visibility = Visibility.Hidden;
            btnResume.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
            btnSettings.Visibility = Visibility.Hidden;
        }
        private void BtnResume_Click(object sender, RoutedEventArgs e)
        {
            gameTimer.Start();
            btnRestart.Visibility = Visibility.Hidden;
            btnResume.Visibility = Visibility.Hidden;
            btnSettings.Visibility = Visibility.Hidden;
            btnExit.Visibility = Visibility.Hidden;
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

