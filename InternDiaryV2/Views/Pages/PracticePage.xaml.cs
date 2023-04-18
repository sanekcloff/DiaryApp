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
    /// Логика взаимодействия для PracticePage.xaml
    /// </summary>
    public partial class PracticePage : Page
    {
        private PracticeViewModel _viewModel;
        public PracticePage(Practice practice, ApplicationDbContext ctx, UserService userService)
        {
            InitializeComponent();
            DataContext = _viewModel = new PracticeViewModel(practice, ctx, userService);
        }

        private void AddDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddDiary();
        }

        private void DeleteDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.RemoveDiary();
        }
    }
}
