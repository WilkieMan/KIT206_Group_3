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
       
        

        public ResearcherDetailView()
        {
            InitializeComponent();   
        }

        private void CummulativeCount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cummulative Count");
            
        }

        private void OldestToNewest_Click(object sender, RoutedEventArgs e)
        {
            publications = PublicationsListView.ItemsSource as List<Publication>;

            PublicationsListView.ItemsSource = pubicationsController.OldestToNewest(publications);
        }

        private void NewestToOldest_Click(object sender, RoutedEventArgs e)
        {

            publications = PublicationsListView.ItemsSource as List<Publication>;

            PublicationsListView.ItemsSource = pubicationsController.NewestToOldest(publications);
        }

        private void PublicationSearch_Click(object sender, RoutedEventArgs e)
        {
            publications = PublicationsListView.ItemsSource as List<Publication>;

            PublicationsListView.ItemsSource = pubicationsController.FilterByYears(publications, UpperLimit.Text, LowerLimit.Text);
        }

        private void Supervisions_Click(object sender, RoutedEventArgs e)
        {
            Researcher r = this.DataContext as Researcher;

            if (r.EmploymentLevel == Position.EmploymentLevel.Student)
            {
                MessageBox.Show("Students do not have supervisions");
            } else
            {
                Staff s = this.DataContext as Staff;
                s.PopulateSupervisionsList();
                MessageBox.Show("Supervsions" + s.SupervisionsList); //fix
            }
        }

        private void Publication_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
