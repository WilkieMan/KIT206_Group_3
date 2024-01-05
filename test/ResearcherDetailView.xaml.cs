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
    /// Interaction logic for ResearcherDetailView.xaml.
    /// </summary>
    public partial class ResearcherDetailView : UserControl
    {
        private static ResearcherController researcherController = new ResearcherController(); // Creates a controller to manipulate the researchers
        private static PublicationsController pubicationsController = new PublicationsController(); // Creates a publications controller to manipulate publications
        private List<Publication> publications; // A list of the current researchers publications
        private Researcher researcher; // The current researcher 

        /// <summary>
        /// The constructor for the ResearcherDetailsView.
        /// </summary>
        public ResearcherDetailView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the current researcher to the current DataContext.
        /// </summary>
        public void setResearcher()
        {
            Researcher researcher = this.DataContext as Researcher;
            PublicationsListView.ItemsSource = researcher.Publications;
            publications = researcher.Publications;
        }

        /// <summary>
        /// Shows a table of the previous years and the number of produced publications in each using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void CummulativeCount_Click(object sender, RoutedEventArgs e)
        {
            Researcher r = this.DataContext as Researcher;
            MessageBox.Show("Cummulative Count" + r.Email );
            
        }

        /// <summary>
        /// Rearranges the order of publications chronologically to Oldest to Newest using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void OldestToNewest_Click(object sender, RoutedEventArgs e)
        {
            PublicationsListView.ItemsSource = pubicationsController.OldestToNewest(publications);
        }

        /// <summary>
        /// Rearranges the order of publications chronologically to Newest to Oldest using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void NewestToOldest_Click(object sender, RoutedEventArgs e)
        {
            PublicationsListView.ItemsSource = pubicationsController.NewestToOldest(publications);
        }

        /// <summary>
        /// Cause the publications to be filtered by the year they were published using two text boxes and an event handler. 
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void PublicationSearch_Click(object sender, RoutedEventArgs e)
        {
            Researcher temp = this.DataContext as Researcher;

            PublicationsListView.ItemsSource = pubicationsController.FilterByYears(temp.Publications, UpperLimit.Text, LowerLimit.Text);
        }

        /// <summary>
        /// Creates a pop-up window with the current supervisions of the researcher using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void Supervisions_Click(object sender, RoutedEventArgs e)
        {
            if (researcher.EmploymentLevel == Position.EmploymentLevel.Student)
            {
                MessageBox.Show("Students do not have supervisions");
            } else
            {
                Staff staff = researcher as Staff;
                List<Student> supervisions = staff.GetSupervisionsList();
                MessageBox.Show("Supervsions");
            } 

        }

        /// <summary>
        /// Changes the currently selected publication in the PublicationsDetailsView using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void Publication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
