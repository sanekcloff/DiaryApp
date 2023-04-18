using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using InternDiaryV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternDiaryV2.ViewModels.Pages
{
    public class UserViewModel:ViewModelBase
    {
        public UserViewModel(User user, ApplicationDbContext ctx, UserService userService) 
        {
            DiaryDayService = new(ctx);
            DayService = new(ctx);
            User = user;
            UpdateLists();
        }

        public DiaryDayService DiaryDayService { get; set; }
        public DayService DayService { get; set; }

        private List<Day> _days;
        public List<Day> Days { get => _days; set => Set(ref _days, value, nameof(Days)); }

        private User _user;
        private Day _selectedDay;
        private string _content;
        public User User { get => _user; set => Set(ref _user, value, nameof(User)); }
        public Day SelectedDay
        {
            get => _selectedDay;
            set
            {
                Set(ref _selectedDay, value, nameof(SelectedDay));
                if (value!=null)
                    Content = value.Content;
            }
        }
        public string Content { get => _content; set => Set(ref _content, value, nameof(Content)); }

        public void UpdateDay()
        {
            if (SelectedDay!=null)
            {
                if (!string.IsNullOrEmpty(Content))
                {
                    SelectedDay.Content = Content;
                    DayService.Update(SelectedDay);
                    UpdateLists();
                }
                else
                    MessageBox.Show("Содержание работ за день должно быть заполнено!");
            }
            else
                MessageBox.Show("Выберите день!");
        }

        private void UpdateLists()
        {
            Days = new List<Day>(DiaryDayService.GetDiaryDays().Where(dd=>dd.Diary.User==User).Select(dd=>dd.Day));
        }
    }
}
