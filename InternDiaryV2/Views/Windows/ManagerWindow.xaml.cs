using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using InternDiaryV2.Services;
using InternDiaryV2.Views.Pages;
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
using System.Windows.Shapes;

namespace InternDiaryV2.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow(Practice practice, ApplicationDbContext ctx, UserService userService)
        {
            InitializeComponent();
            Title = "Добавление дневников";
            ManagerFrame.Navigate(new PracticePage(practice, ctx, userService));
        }
        public ManagerWindow(Diary diary, ApplicationDbContext ctx)
        {
            InitializeComponent();
            Title = "Работа с дневником";
            ManagerFrame.Navigate(new DiaryPage(diary, ctx));
        }
    }
}
