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
    /// Логика взаимодействия для CuratorPage.xaml
    /// </summary>
    public partial class CuratorPage : Page
    {
        private CuratorViewModel _viewModel;
        public CuratorPage(Curator curator, ApplicationDbContext ctx, UserService userService, CuratorService curatorService)
        {
            InitializeComponent();
            DataContext = _viewModel = new CuratorViewModel(curator, ctx, userService, curatorService);
        }

        private void PracticeDiariesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _viewModel.OpenManagerWindow();
        }
    }
}
