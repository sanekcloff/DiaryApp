using InternDiary.Data;
using InternDiary.Entities;
using InternDiary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternDiary.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public StudentViewModel(ApplicationDbContext ctx, User user, UserService userService)
        {
            
        }
    }
}
