using System;
using System.Data;
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

namespace KIT206_RAP
{

    /// <summary>
    /// Interaction logic for ResearcherDetailView.xaml
    /// </summary>
    public partial class ResearcherDetailView : UserControl
    {
        private static ResearcherController researcherController = new ResearcherController();              //researcher controller object
        private static PublicationsController pubicationsController = new PublicationsController();         //publcation controller object
        private List<Publication> publications;                                                             //Current reseacher's publications
        private Researcher researcher;                                                                      //Current researcher

        /// <summary>
        /// The constructor for the ResearcherDetailView.
        /// </summary>
        public ResearcherDetailView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the researcher to the data context of the Window so list boxes can be filled
        /// </summary>
        public void setResearcher()
        {
            researcher = this.DataContext as Researcher;
            PublicationsListView.ItemsSource = researcher.Publications;
            PastPositionsBox.ItemsSource = researcher.Positions;
            publications = researcher.Publications;
        }

        /// <summary>
        /// Generates a pop-up window that shows the researcher's cummulative count table
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void CummulativeCount_Click(object sender, RoutedEventArgs e)
        {
            researcher.PopulateCummulatives(researcher.Publications);

            MessageBox.Show("Cummulative Count: \n" + researcherController.GenerateCummulativeTable(researcher));
            
        }

        /// <summary>
        /// Orders the content of the PublicationsListView from oldest to newest by year of publication
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void OldestToNewest_Click(object sender, RoutedEventArgs e)
        {
            PublicationsListView.ItemsSource = pubicationsController.OldestToNewest(publications);
        }

        /// <summary>
        /// Orders the content of the PublicationsListView from newest to oldest by year of publication
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void NewestToOldest_Click(object sender, RoutedEventArgs e)
        {
            PublicationsListView.ItemsSource = pubicationsController.NewestToOldest(publications);
        }

        /// <summary>
        /// Filters the content of the PublicationsListView from by year of publication based on an upper and lower limit
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void PublicationSearch_Click(object sender, RoutedEventArgs e)
        {
            PublicationsListView.ItemsSource = pubicationsController.FilterByYears(researcher.Publications, UpperLimit.Text, LowerLimit.Text);
        }

        /// <summary>
        /// Displays the supervisions of a researcher in a pop-up window
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
                Staff staff = new Staff(researcher.NameTitle, researcher.GivenName, researcher.FamilyName, researcher.EmploymentLevel, researcher.ID);
                List<Student> supervisions = staff.GetSupervisionsList();
                
                if(supervisions.Count == 0)
                {
                    MessageBox.Show("Researcher has no supervisions");
                } else
                {
                    var listToString = string.Join(Environment.NewLine, supervisions);
                    MessageBox.Show("Supervisions:\n" + listToString);
                }
            } 
        }

        /// <summary>
        /// Displays the PublicationDetailView as a pop-up
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void Publication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Publication selected = PublicationsListView.SelectedItem as Publication;

            MessageBox.Show("Publication Details:\n " + selected.ToDetailedString());
        }
    }
}
