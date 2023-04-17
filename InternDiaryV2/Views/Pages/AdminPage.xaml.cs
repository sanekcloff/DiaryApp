using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using InternDiaryV2.Services;
using InternDiaryV2.ViewModels.Pages;
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

namespace InternDiaryV2.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private AdminViewModel _viewModel;
        public AdminPage(User user, ApplicationDbContext ctx, UserService userService, CuratorService curatorService)
        {
            InitializeComponent();
            DataContext = _viewModel = new AdminViewModel(user, ctx, userService, curatorService);
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddUser();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateUser();
        }

        private void RemoveUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteUser();
        }

        private void AddCuratorButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCurator();
        }

        private void UpdateCuratorButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateCurator();
        }

        private void RemoveCuratorButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteCurator();
        }

        private void AddOrganizationButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddOrganization();
        }

        private void UpdateOrganizationButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateOrganization();
        }

        private void RemoveOrganizationButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteOrganization();
        }

        private void AddPracticeButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddPractice();
        }

        private void UpdatePracticeButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdatePractice();
        }

        private void RemovePracticeButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeletePractice();
        }
    }
}
