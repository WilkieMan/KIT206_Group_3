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
            Researcher r = this.DataContext as Researcher;
            MessageBox.Show("Cummulative Count" + r.Email );
            
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

        private void Publication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
