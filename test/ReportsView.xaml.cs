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
    /// Interaction logic for ReportsView.xaml.
    /// </summary>
    public partial class ReportsView : UserControl
    {

        private static ResearcherController researcherController = new ResearcherController(); // The controller used to manage the researchers
        private List<Researcher> reportResearchers = new List<Researcher>(); // The list used to create reports

        /// <summary>
        /// The constructor for the ReportsView.
        /// </summary>
        public ReportsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Generates the report for poor performing researchers using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void PoorButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("poor");
        }

        /// <summary>
        /// Generates the report for researchers performing below expectations using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void BelowExpectationButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("below expectation");
        }

        /// <summary>
        /// Generates the report for researchers that are meeting minimum using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void MeetingMinimumButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("meeting minimum");
        }

        /// <summary>
        /// Generates the report for star researchers using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void StarButton_Click(object sender, RoutedEventArgs e)
        {
            Reports.ItemsSource = researcherController.GenerateReports("star");
    
        }
    }
}
