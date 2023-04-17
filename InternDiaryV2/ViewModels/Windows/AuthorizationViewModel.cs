using InternDiaryV2.Data;
using InternDiaryV2.Services;
using InternDiaryV2.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternDiaryV2.ViewModels.Windows
{
    public class AuthorizationViewModel:ViewModelBase
    {
        public AuthorizationViewModel()
        {
            _ctx = new ApplicationDbContext();

            UserService = new UserService(_ctx);
            CuratorService = new CuratorService(_ctx);
        }

        private ApplicationDbContext _ctx;

        public UserService UserService { get; set; }
        public CuratorService CuratorService { get; set; }
        
        private string _login;
        private string _password;
        public string Login 
        {
            get => _login; 
            set => Set(ref _login,value, nameof(Login)); 
        }
        public string Password 
        { 
            get => _password; 
            set => Set(ref _password, value, nameof(Password)); 
        }

        public void Authorization()
        {
            var user = UserService.GetUsers().SingleOrDefault(u => u.Login == Login && u.Password == Password);
            var curator = CuratorService.GetCurators().SingleOrDefault(c => c.Login == Login && c.Password == Password);
            if (user != null)
            {
                new MainWindow(user,_ctx, UserService, CuratorService).ShowDialog();
            }
            else if (curator != null)
            {
                new MainWindow(curator, _ctx, UserService, CuratorService).ShowDialog();
            }
            else
                MessageBox.Show("Учётная запись отсутсвует!");
        }
    }
}
