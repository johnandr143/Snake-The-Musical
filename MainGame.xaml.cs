using System;
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
using System.Windows.Shapes;

namespace Test_Game
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : Window
    {
        objCreate obj = new objCreate();
        menuPause mp;
        Window creatingForm;
        public MainGame()
        {
            InitializeComponent();
            
        }
        public Window setCreatingForm
        {
            get { return creatingForm; }
            set { creatingForm = value; }
        }
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mp = new menuPause();
            mp.setCreatingForm = this;
            mp.setSuperForm = creatingForm;
            //mp.setMain = 
            mp.Show();
        }
    }
}
