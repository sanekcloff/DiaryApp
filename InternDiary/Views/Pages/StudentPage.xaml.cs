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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        private StudentViewModel _viewModel;
        public StudentPage(ApplicationDbContext ctx, User user, UserService userService)
        {
            InitializeComponent();
            DataContext = _viewModel = new StudentViewModel(ctx,user,userService);
            
        }
    }
}
