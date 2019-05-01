using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Test_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainGame mg;
        public MainWindow()
        {
            bool check = false;
            string line = " ", scores = "HighScores: \n";
            StreamReader sr = new StreamReader("HighScores.txt");
            for (int i = 0; i < 10; i++)
            {
                line = sr.ReadLine();
                if (line != null) { scores += line + "\n"; }
            }            
            InitializeComponent();
            lblScores.Content = scores;
            if (this.IsVisible == true || check == true)
            {
                check = true;
                if (this.IsVisible != true) { this.Close(); mg = new MainGame(); mg.Close(); }
            }
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            mg = new MainGame();
            mg.setCreatingForm = this;
            mg.Hide();
            this.Hide();
            mg.Show();
        }

        private void btnScores_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"NotePad.exe", "HighScores");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
                mg.Close();
            }
        }
    }
}
