using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using InternDiaryV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiaryV2.ViewModels.Pages
{
    public class PracticeViewModel:ViewModelBase
    {
        public PracticeViewModel(Practice practice, ApplicationDbContext ctx, UserService userService)
        {
            UserService=userService;
            PracticeDiaryService = new PracticeDiaryService(ctx);
            DiaryService = new DiaryService(ctx);
            DiaryDayService = new DiaryDayService(ctx);
            DayService = new DayService(ctx);

            Practice = practice;
        }

        public PracticeDiaryService PracticeDiaryService { get; set; }
        public DiaryService DiaryService { get; set; }
        public DiaryDayService DiaryDayService { get; set; }
        public DayService DayService { get; set; }
        public UserService UserService { get; set; }

        private List<Diary> _diaries;
        private List<User> _users;

        private Practice _practice;
        private User _selectedUser;
        public Practice Practice 
        { 
            get => _practice; 
            set => Set(ref _practice, value, nameof(Practice)); 
        }
        public User SelectedUser 
        { 
            get => _selectedUser;
            set => Set(ref _selectedUser, value, nameof(SelectedUser)); 
        }

        private void UpdateLists()
        {

        }
    }
}
