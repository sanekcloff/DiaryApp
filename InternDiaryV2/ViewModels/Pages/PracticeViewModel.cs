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

            UpdateLists();
        }

        public PracticeDiaryService PracticeDiaryService { get; set; }
        public DiaryService DiaryService { get; set; }
        public DiaryDayService DiaryDayService { get; set; }
        public DayService DayService { get; set; }
        public UserService UserService { get; set; }

        private List<PracticeDiary> _practiceDiaries;
        private List<User> _users;
        public List<PracticeDiary> PracticeDiaries 
        { 
            get => _practiceDiaries;
            set => Set(ref _practiceDiaries, value, nameof(PracticeDiaries));
        }
        public List<User> Users 
        { 
            get => _users; 
            set => Set(ref _users, value, nameof(Users)); 
        }

        private Practice _practice;
        private User _selectedUser;
        private PracticeDiary _selectedPracticeDiary;
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
        public PracticeDiary SelectedPracticeDiary 
        { 
            get => _selectedPracticeDiary; 
            set => Set(ref _selectedPracticeDiary, value, nameof(SelectedPracticeDiary)); 
        }

        public void AddDiary()
        {
            if (SelectedUser != null)
            {
                if (!PracticeDiaryService.GetPracticeDiaries().Any(pd => pd.Diary.User == SelectedUser && pd.Practice==Practice))
                {
                    var diary = new Diary { User = SelectedUser };
                    var days = new List<Day>();
                    for (DateTime date = Practice.StartDate; date.Day <= Practice.EndDate.Day; date = date.AddDays(1))
                    {
                        if(date.DayOfWeek!=DayOfWeek.Sunday)
                            days.Add(new Day { Date = date });
                    }
                    var diaryDays = new List<DiaryDay>();
                    foreach (var day in days)
                    {
                        diaryDays.Add(new DiaryDay { Day = day, Diary = diary });
                    }
                    DiaryService.Insert(diary);
                    DayService.Insert(days);
                    DiaryDayService.Insert(diaryDays);
                    PracticeDiaryService.Insert(new PracticeDiary { Diary = diary, Practice = Practice });
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такой дневник уже существует");  
            }
            else
                MessageBox.Show("Выберите практиканта");
        }
        public void RemoveDiary()
        {
            if (SelectedPracticeDiary != null)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var diaryDays = new List<DiaryDay>(SelectedPracticeDiary.Diary.DiaryDays);
                    var days = new List<Day>(SelectedPracticeDiary.Diary.DiaryDays.Select(dd => dd.Day));

                    PracticeDiaryService.Delete(SelectedPracticeDiary);
                    DiaryDayService.Delete(diaryDays);
                    DayService.Delete(days);
                    DiaryService.Delete(SelectedPracticeDiary.Diary);
                    UpdateLists();
                }
            }
            else
                MessageBox.Show("Выберите дневник!");
        }

        private void UpdateLists()
        {
            PracticeDiaries = new List<PracticeDiary>(PracticeDiaryService.GetPracticeDiaries().Where(pd=>pd.Practice==Practice));
            Users = new List<User>(UserService.GetUsers().Where(u=>u.RoleId==2));
        }
    }
}
