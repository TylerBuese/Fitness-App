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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Fitness_2.Pages
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Page
    {
        public Navigation()
        {
            InitializeComponent();
            var rootDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var mealTrackerDocumentPath = rootDocumentPath + @"\Fitness\Fitness.txt";
            var weightTrackerDocumentPath = rootDocumentPath + @"\Fitness\weight.txt";
            Directory.CreateDirectory(rootDocumentPath + @"\Fitness");
            LoggedInUser logged = new LoggedInUser();

            var fileExists = File.Exists(mealTrackerDocumentPath);
            try
            {
                if (fileExists)
                {


                }
                else
                {
                    MessageBox.Show(fileExists.ToString());
                    File.Create(mealTrackerDocumentPath);
                    File.Create(weightTrackerDocumentPath);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create file in " + mealTrackerDocumentPath  + ". Last error: " + ex);
            }


        }

        private void buttonClick_TestPage(object sender, RoutedEventArgs e)
        {
            TestPage testPage = new TestPage();
            this.NavigationService.Navigate(testPage);
        }

        private void Button_Click_Meal_Tracker(object sender, RoutedEventArgs e)
        {
            MealTracker meal = new MealTracker();
            this.NavigationService.Navigate(meal);
        }

        private void Button_Click_Weight_Tracker(object sender, RoutedEventArgs e)
        {
            WeightTracking wt = new WeightTracking();
            this.NavigationService.Navigate(wt);
        }

        private void Button_Click_Recipie_Maker(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            this.NavigationService.Navigate(recipe);
        }
    }
}
