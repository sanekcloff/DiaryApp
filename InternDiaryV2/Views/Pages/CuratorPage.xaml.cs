using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using InternDiaryV2.Services;
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
        public CuratorPage(Curator curator, ApplicationDbContext ctx, UserService userService, CuratorService curatorService)
        {
            InitializeComponent();
        }
    }
}
