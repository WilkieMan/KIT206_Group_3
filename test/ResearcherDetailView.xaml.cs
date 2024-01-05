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

        }

        private void NewestToOldest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PublicationSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Supervisions_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Supervisions: ");
        }
    }
}
