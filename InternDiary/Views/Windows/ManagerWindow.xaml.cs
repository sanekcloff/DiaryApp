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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        //для организации
        public ManagerWindow(Organization organization, OrganizationUserService organizationUserService, UserService userService)
        {
            InitializeComponent();
            ManagerFrame.Navigate(new OrganizationPage(organization, organizationUserService, userService));
        }
    }
}
