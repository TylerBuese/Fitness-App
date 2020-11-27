using Fitness_2.Pages.Classes;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
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

namespace Fitness_2.Pages
{
    /// <summary>
    /// Interaction logic for MealTracker.xaml
    /// </summary>
    public partial class MealTracker : Page
    {
        public MealTracker()
        {
            InitializeComponent();
            displayData();
            
        }

        private void Button_Click_BackToNavigation(object sender, RoutedEventArgs e)
        {
            Navigation navigation = new Navigation();
            this.NavigationService.Navigate(navigation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meal meal = new Meal();
            meal.protien = bzFitTextBoxProtien.Text;
            meal.fat = bzFitTextBoxFat.Text;
            meal.carbs = bzFitTextBoxCarbs.Text;
            meal.calories = bzFitTextBoxCalories.Text;
            meal.dateAdded = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            System.Windows.Controls.TextBox[] textBoxArrayJustData = { bzFitTextBoxFoodName, bzFitTextBoxProtien, bzFitTextBoxFat, bzFitTextBoxCarbs, bzFitTextBoxCalories };
            string[] textBoxArray = { meal.dateAdded.ToString() + ", \n", "Food Name: " + bzFitTextBoxFoodName.Text + ", \n", "Protien: " + bzFitTextBoxProtien.Text + ", \n", "Fat: " + bzFitTextBoxFat.Text + ", \n", "Carbs: " + bzFitTextBoxCarbs.Text + ", \n", "Calories: " + bzFitTextBoxCalories.Text + "|", "\n" };
            string[] textBoxArrayVerbose = { "Protien: " + bzFitTextBoxProtien.Text, "Fat: " + bzFitTextBoxFat.Text, "Carbs: " +  bzFitTextBoxCarbs.Text, "Calories: " + bzFitTextBoxCalories.Text, "Food Name: " + bzFitTextBoxFoodName.Text, "Date Added: " + meal.dateAdded  };
            var i = 0;
            foreach (var data in textBoxArrayJustData)
            {
                if (data.Text == "")
                {
                    MessageBox.Show("You must fill out all of the text boxes");
                    i++;
                    if (i == 1) break;
                    
                }
            }
            foreach (var item in textBoxArrayVerbose)
            {
                sb.Append(item);
                sb.AppendLine();
            }

            sb.Clear();
            
            var rootDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var documentPath = rootDocumentPath + @"\Fitness\Fitness.txt";
            
            foreach (var item in textBoxArray)
            {
                sb.Append(item);
            }
            
            try
            {
                using (StreamWriter sw = new StreamWriter(documentPath, true))
                {
                    sw.WriteLine(sb.ToString());
                    sw.Flush();
                    sw.Close();
                }
            } catch (Exception ex)
            {
              MessageBox.Show("Unable to write data. Last error: " + ex);
            }
            foreach (var item in textBoxArrayJustData)
            {
                item.Text = "";
            }

            displayData();
        }

        private void displayData()
        {
            var rootDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var documentPath = rootDocumentPath + @"\Fitness\Fitness.txt";
            var directoryPath = rootDocumentPath + @"\Fitness\";
            StreamReader sr = new StreamReader(documentPath);
            var content = sr.ReadToEnd();
            var date = DateTime.Now.ToString("MM/dd/yyy");
            var matchingComma = content.Split(',');
            var matchingPipe = content.Split('|');
            StringBuilder sb = new StringBuilder();
            List<string> array5 = new List<string>();
            foreach (var item in matchingComma)
            {
                array5.Add(item);
                if (array5.Count > 30)
                {
                    break;
                } else
                {

                }
            }

            var selectedDate = "";
            if (bzFitCalendarDatePick.Text.Length > 1)
            {
                selectedDate = bzFitCalendarDatePick.Text;
            } else
            {
                selectedDate = DateTime.Now.ToString("MM/dd/yyy");
                bzFitCalendarDatePick.Text = selectedDate;
            }

            var dataSet = matchingPipe.Select((x, i) => new { Line = x, LineNumber = i })
                      .Where(x => x.Line.Contains(selectedDate))
                      .ToList();
            List<string> todaysFood = new List<string>();
            StringBuilder foodToday = new StringBuilder();
            foreach (var line in dataSet)
            {
                foodToday.Append(line.Line);
            }
            bzFitTodaysFoodLabel.Content = foodToday.ToString();
        }

        private void Button_Click_Refresh_Food(object sender, RoutedEventArgs e)
        {
            displayData();
        }
    }
}
