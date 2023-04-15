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
    }
}
