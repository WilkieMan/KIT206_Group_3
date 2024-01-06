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
    /// Interaction logic for ResearcherDetailView.xaml
    /// </summary>
    public partial class ResearcherDetailView : UserControl
    {
        private static ResearcherController researcherController = new ResearcherController();
        private static PublicationsController pubicationsController = new PublicationsController();
        private List<Publication> publications;
        private Researcher researcher;

        public ResearcherDetailView()
        {
            InitializeComponent();
        }

        public void setResearcher()
        {
            Researcher researcher = this.DataContext as Researcher;
            PublicationsListView.ItemsSource = researcher.Publications;
            PastPositionsBox.ItemsSource = researcher.Positions;
            publications = researcher.Publications;
        }

        private void CummulativeCount_Click(object sender, RoutedEventArgs e)
        {
            Researcher researcher = this.DataContext as Researcher;

            researcher.PopulateCummulatives(researcher.Publications);

            MessageBox.Show("Cummulative Count\n");
            
        }

        private void OldestToNewest_Click(object sender, RoutedEventArgs e)
        {
            PublicationsListView.ItemsSource = pubicationsController.OldestToNewest(publications);
        }

        private void NewestToOldest_Click(object sender, RoutedEventArgs e)
        {
            PublicationsListView.ItemsSource = pubicationsController.NewestToOldest(publications);
        }

        private void PublicationSearch_Click(object sender, RoutedEventArgs e)
        {
            Researcher temp = this.DataContext as Researcher;

            PublicationsListView.ItemsSource = pubicationsController.FilterByYears(temp.Publications, UpperLimit.Text, LowerLimit.Text);
        }

        private void Supervisions_Click(object sender, RoutedEventArgs e)
        {

            Researcher temp = this.DataContext as Researcher;

            if (temp.EmploymentLevel == Position.EmploymentLevel.Student)
            {
                MessageBox.Show("Students do not have supervisions");
            } else
            {
                Staff staff = new Staff(temp.NameTitle, temp.GivenName, temp.FamilyName, temp.EmploymentLevel, temp.ID);
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

        private void Publication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Publication selected = PublicationsListView.SelectedItem as Publication;

            MessageBox.Show("Publication Details:\n " + selected.ToDetailedString());
        }
    }
}
