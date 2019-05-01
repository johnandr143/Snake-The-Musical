using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for menuPause.xaml
    /// </summary>
    public partial class menuPause : Window
    {
        Window creatingForm;
        Window superForm;
        public Window setCreatingForm
        {
            get { return creatingForm; }
            set { creatingForm = value; }
        }
        public menuPause()
        {
            InitializeComponent();
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            
        }


        public Window setSuperForm
        {
            get { return superForm; }
            set { superForm = value; }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            creatingForm.Close();
            superForm.Show();
            this.Close();
        }
    }
}
