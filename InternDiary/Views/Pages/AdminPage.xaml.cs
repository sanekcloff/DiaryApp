using InternDiary.Data;
using InternDiary.Entities;
using InternDiary.Service;
using InternDiary.ViewModels;
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

namespace InternDiary.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private AdminViewModel _viewModel;
        public AdminPage(ApplicationDbContext ctx, User user, UserService userService)
        {
            InitializeComponent();
            DataContext = _viewModel = new AdminViewModel(ctx, user, userService);
        }

        private void AddOrganizationButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddOrganization();
        }

        private void UpdateOrganizationButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateOrganization();
        }

        private void DeleteOrganizationButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteOrganization();
        }

        private void AddPracticeButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddPractice();
        }

        private void OrganiztionListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedOrganization);
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddUser();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateUser();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteUser();
        }

        private void PracticesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _viewModel.OpenManagerWindow(_viewModel.SelectedPractice);
        }
    }
}
