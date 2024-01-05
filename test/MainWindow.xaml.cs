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
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ResearcherController researcherController = new ResearcherController(); // The controller to control all the researchers
        private static List<Researcher> researcherList; // The list to be displayed as the ResearcherListView
        
        /// <summary>
        /// Constructor for the MainWindow.
        /// </summary>
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

        /// <summary>
        /// Creates the ResearcherDetailsView using a event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ResearcherDetailView();
        }

        /// <summary>
        /// Creates the ReportsView using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void ReportsView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportsView();
        }

        /// <summary>
        /// Updates the ResearcherDeatils view if it is already showing a researcher using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void ResearcherList_Changed(object sender, SelectionChangedEventArgs e)
        {
            ResearcherDetailView researcherDetailView = new ResearcherDetailView();

            Researcher researcher = ResearcherListView.SelectedItem as Researcher;

            if (researcher != null)
            {
                if (researcher.EmploymentLevel == Position.EmploymentLevel.Student)
                {
                    Student student = new Student(researcher.NameTitle, researcher.GivenName, researcher.FamilyName, researcher.EmploymentLevel, researcher.ID);
                    DBAdapter.FetchAllDetail(student);
                    researcherDetailView.DataContext = student;
                    researcherDetailView.setResearcher();

                }
                else
                {
                    Staff staff = new Staff(researcher.NameTitle, researcher.GivenName, researcher.FamilyName, researcher.EmploymentLevel, researcher.ID);
                    DBAdapter.FetchAllDetail(staff);
                    researcherDetailView.DataContext = staff;
                    researcherDetailView.setResearcher();
                }

            }

            DataContext = researcherDetailView;
        }

        /// <summary>
        /// Applies filters when the FilterByTitleBox is changed using an event handler.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void FilterTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Applies filters when the FilterByTextBox's text is changed.
        /// </summary>
        /// <param name="sender">The object that sent the event.</param>
        /// <param name="e">The event.</param>
        private void FilterName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        /// <summary>
        /// Applies the current filters to the ResearcherList by getting the value of the FilterByTitleBox and the FilterByNameBox.
        /// </summary>
        private void ApplyFilters()
        {
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
