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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(object obj, ApplicationDbContext ctx, UserService userService, CuratorService curatorService)
        {
            InitializeComponent();
            if (obj is User)
            {
                if ((obj as User).Role.Id == 1)
                {
                    MainFrame.Navigate(new AdminPage(obj as User, ctx, userService, curatorService));
                    Title = "Окно Администратора";
                }
                else
                {
                    MainFrame.Navigate(new UserPage(obj as User, ctx, userService, curatorService));
                    Title = "Окно Практиканта";
                } 
            }
            else
            {
                MainFrame.Navigate(new CuratorPage(obj as Curator, ctx, userService, curatorService));
                Title = "Окно Руководителя";
            }
        }
    }
}
