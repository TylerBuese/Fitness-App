using Fitness_2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

namespace Fitness_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bzFitNews.Navigate("https://tylerbuese.com/FitnessApp/News");
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoggedInUser loggedInUser = new LoggedInUser();
            bzFitUserNameInput.Text = "bzbz";
            bzFitPasswordInput.Password = "password";
            if (bzFitUserNameInput.Text == "bzbz" && bzFitPasswordInput.Password == "password")
            {
                loggedInUser.authenticated = true;
                bzFitStatus.Foreground = new SolidColorBrush(Colors.Green);
                bzFitStatus.Content = "Sign in successful!";
                MainMenu window = new MainMenu();
                window.Show();
                this.Hide();
                
            } else
            {
                bzFitStatus.Foreground = new SolidColorBrush(Colors.Red);
                bzFitStatus.Content = "Incorrect username of password";
                bzFitUserNameInput.Text = "";
            }
        }
    }
}
