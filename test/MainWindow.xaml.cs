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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ResearcherController researcherController = new ResearcherController();
        private static List<Researcher> researcherList;
        
        public MainWindow()
        {
            InitializeComponent();
            ResearcherListView.ItemsSource = researcherController.GetMasterList();

            List<Position.EmploymentLevel> employmentLevels = new List<Position.EmploymentLevel>();

            employmentLevels.Add(Position.EmploymentLevel.Any);
            employmentLevels.Add(Position.EmploymentLevel.A);
            employmentLevels.Add(Position.EmploymentLevel.B);
            employmentLevels.Add(Position.EmploymentLevel.C);
            employmentLevels.Add(Position.EmploymentLevel.D);
            employmentLevels.Add(Position.EmploymentLevel.E);
            employmentLevels.Add(Position.EmploymentLevel.Student);
       
            FilterByTitleBox.ItemsSource = employmentLevels;
            FilterByTitleBox.SelectedItem = 0;
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ResearcherDetailView();
        }

        private void ReportsView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportsView();
        }

        private void ResearcherList_Changed(object sender, SelectionChangedEventArgs e)
        {
            ResearcherDetailView researcherDetailView = new ResearcherDetailView();

            Researcher researcher = ResearcherListView.SelectedItem as Researcher;

            if (researcher.EmploymentLevel == Position.EmploymentLevel.Student)
            {
                Student student = new Student(researcher.NameTitle, researcher.GivenName, researcher.FamilyName, researcher.EmploymentLevel, researcher.ID);
                DBAdapter.FetchAllDetail(student);
                researcherDetailView.DataContext = student;
            } else
            {
                Staff staff = new Staff(researcher.NameTitle, researcher.GivenName, researcher.FamilyName, researcher.EmploymentLevel, researcher.ID);
                DBAdapter.FetchAllDetail(staff);
                researcherDetailView.DataContext = staff;
            }

            DataContext = researcherDetailView;
        }

        private void FilterTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void FilterName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            ResearcherDetailView researcherDetailView = new ResearcherDetailView();

            researcherList = researcherController.GetMasterList();

            Position.EmploymentLevel selctedLevel = (Position.EmploymentLevel)FilterByTitleBox.SelectedItem;

            researcherList = researcherController.FilterByJobTitle(researcherList, selctedLevel);
            ResearcherListView.ItemsSource = researcherList;

            string text = FilterByNameBox.Text;

            researcherList = researcherController.FilterByName(researcherList, text);
            ResearcherListView.ItemsSource = researcherList;
        }   
    }
}
