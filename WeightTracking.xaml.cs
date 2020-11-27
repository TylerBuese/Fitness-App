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
using System.Windows.Forms.DataVisualization.Charting;
//wil come back to this - need to find a way to chart out data points, chart object in toolbox not working?
namespace Fitness_2.Pages
{
    /// <summary>
    /// Interaction logic for WeightTracking.xaml
    /// </summary>
    public partial class WeightTracking : Page
    {
        public WeightTracking()
        {
            InitializeComponent();
            drawLine();
            getWeight();
        }

        private void bzFitWeightTrackTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bzFitBackToNavigation_Click(object sender, RoutedEventArgs e)
        {
            Navigation navigation = new Navigation();
            this.NavigationService.Navigate(navigation);
        }

        private void bzFitWeightTrackButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            var presentableEnteredWeight = /*DateTime.Now + ", " + */bzFitWeightTrackTextBox.Text + ",";
            
            if (bzFitWeightTrackTextBox.Text == "")
            {
                MessageBox.Show("Please enter a valid weight");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                WriteWeight(presentableEnteredWeight);
            }

           
            
        }

        private void WriteWeight(string weight)
        {
            var rootDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var weightTrackerDocumentPath = rootDocumentPath + @"\Fitness\weight.txt";
            using (StreamWriter sw = new StreamWriter(weightTrackerDocumentPath, true))
            {
                sw.WriteLine(weight);
                sw.Flush();
                sw.Close();
            }
        }

        private void getWeight()
        {
            var rootDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var weightTrackerDocumentPath = rootDocumentPath + @"\Fitness\weight.txt";
            StreamReader sr = new StreamReader(weightTrackerDocumentPath);
            StringBuilder sb = new StringBuilder();
            var content = sr.ReadToEnd();
            var splitContent = content.Split(',');

            
            
            
        }

        private void drawLine()
        {

            var series = new Series("Weight");
            series.Points.AddXY(1, 10);
            series.ChartType = SeriesChartType.Line;
            Chart chart = new Chart();
            
            
        }
    }
}
