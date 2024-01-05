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

namespace test
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {

        private static ResearcherController researcherController = new ResearcherController();
        private List<Researcher> reportResearchers = new List<Researcher>();

        public ReportsView()
        {
            InitializeComponent();
            
        }

        private void PoorButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("poor");
        }

        private void BelowExpectationButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("below expectation");
        }

        private void MeetingMinimumButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("meeting minimum");
        }

        private void StarButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("star");
          
        }
    }
}
