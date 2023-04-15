using InternDiary.Data;
using InternDiary.Entities;
using InternDiary.Service;
using InternDiary.Views.Pages;
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

namespace InternDiary.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ApplicationDbContext ctx,User user, UserService userService)
        {
            InitializeComponent();
            Title = $"{user.Role.Title}: {user.FullName}";
            switch (user.Role.Id)
            {
                case 1:
                    MainFrame.Navigate(new AdminPage(ctx, user, userService));
                    break;
                case 2:
                    MainFrame.Navigate(new Curator(ctx, user, userService));
                    break;
                case 3:
                    MainFrame.Navigate(new StudentPage(ctx, user, userService));
                    break;
            }
        }
    }
}
