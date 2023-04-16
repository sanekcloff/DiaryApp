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
    /// Логика взаимодействия для OrganizationPage.xaml
    /// </summary>
    public partial class OrganizationPage : Page
    {
        private OrganizationViewModel _viewModel;
        public OrganizationPage(Organization organization, OrganizationUserService organizationUserService, UserService userService)
        {
            InitializeComponent();
            DataContext = _viewModel = new OrganizationViewModel(organization, organizationUserService, userService);
        }

        private void AddOrganiztionUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCurator();
        }

        private void UpdateOrganiztionUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateCurator();
        }

        private void RemoveOrganiztionUserButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteCurator();
        }
    }
}
