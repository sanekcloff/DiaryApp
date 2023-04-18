using InternDiaryV2.Data;
using InternDiaryV2.Entities;
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
    /// Логика взаимодействия для DiaryPage.xaml
    /// </summary>
    public partial class DiaryPage : Page
    {
        private DiaryViewModel _viewModel;
        public DiaryPage(Diary diary, ApplicationDbContext ctx)
        {
            InitializeComponent();
            DataContext = _viewModel = new DiaryViewModel(diary, ctx);
        }

        private void UpdateDayButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateDay();
        }
    }
}
