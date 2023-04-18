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
    public class DiaryViewModel : ViewModelBase
    {
        public DiaryViewModel(Diary diary, ApplicationDbContext ctx)
        {
            DayService = new DayService(ctx);
            DiaryDayService = new DiaryDayService(ctx);
            Diary=diary;
            SelectedGrade = Grades[0];
            SelectedAttendStatus = AttendStatuses[0];
            UpdateLists();
        }

        public List<int> Grades { get; } = new List<int>()
        {
            2,3,4,5
        };
        public List<string> AttendStatuses { get; } = new List<string>()
        {
            "Присутствовал","Отсутствовал"
        };
        private int _selectedGrade;
        private string _selectedAttendStatus;
        public int SelectedGrade { get => _selectedGrade; set => Set(ref _selectedGrade, value, nameof(SelectedGrade)); }
        public string SelectedAttendStatus { get => _selectedAttendStatus; set => Set(ref _selectedAttendStatus, value, nameof(SelectedAttendStatus)); }


        public DayService DayService { get; set; }
        public DiaryDayService DiaryDayService { get; set; }

        private List<Day> _days;
        public List<Day> Days 
        { 
            get => _days; 
            set => Set(ref _days, value, nameof(Days)); 
        }

        private Day _selectedDay;
        private Diary _diary;
        public Day SelectedDay 
        { 
            get => _selectedDay; 
            set => Set(ref _selectedDay, value, nameof(SelectedDay)); 
        }
        public Diary Diary 
        { 
            get => _diary; 
            set => Set(ref _diary, value, nameof(Diary)); 
        }

        public void UpdateDay()
        {
            if (SelectedDay != null)
            {
                SelectedDay.Result = SelectedGrade;
                SelectedDay.IsAttend = SelectedAttendStatus == "Присутствовал" ? true : false;
                DayService.Update(SelectedDay);
            }
            else
                MessageBox.Show("Выберите день!");
            UpdateLists();
        }

        private void UpdateLists()
        {
            Days = new List<Day>(DiaryDayService.GetDiaryDays().Where(dd=>dd.Diary==Diary).Select(dd=>dd.Day));
        }
    }
}
