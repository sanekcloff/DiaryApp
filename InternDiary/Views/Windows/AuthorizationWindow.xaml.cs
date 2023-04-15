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
using System.Windows.Shapes;

namespace InternDiary.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        private AuthorizationViewModel _viewModel;
        public AuthorizationWindow()
        {
            InitializeComponent();
            _viewModel=(AuthorizationViewModel)DataContext;
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Authorization();
        }
    }
}
