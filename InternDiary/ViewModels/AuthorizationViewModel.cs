using InternDiary.Data;
using InternDiary.Entities;
using InternDiary.Service;
using InternDiary.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternDiary.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        public UserService UserService { get; set; }

        private string _login;
        private string _password;
        public string Login { get => _login; set => Set(ref _login, value, nameof(Login)); }
        public string Password { get => _password; set => Set(ref _password, value, nameof(Password)); }

        public AuthorizationViewModel()
        {
            _context = new ApplicationDbContext();

            UserService = new UserService(_context);
        }
        public void Authorization()
        {
            var user = UserService.GetUsers().Where(u => u.Login == Login && u.Password == Password).SingleOrDefault();
            if ( user != null)
            {
                new MainWindow(_context, user, UserService).ShowDialog();
            }
            else
                MessageBox.Show("Такого пользователя нет!");
        }
    }
}
