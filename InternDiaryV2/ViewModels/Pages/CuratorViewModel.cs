using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using InternDiaryV2.Services;
using InternDiaryV2.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiaryV2.ViewModels.Pages
{
    public class CuratorViewModel : ViewModelBase
    {
        public CuratorViewModel(Curator curator, ApplicationDbContext ctx, UserService userService, CuratorService curatorService)
        {
            _ctx = ctx;
            PracticeDiaryService = new(ctx);

            Curator = curator;

            UpdateLists();
        }
        private ApplicationDbContext _ctx;
        public PracticeDiaryService PracticeDiaryService { get; set; }

        private List<PracticeDiary> _practiceDiaries;
        public List<PracticeDiary> PracticeDiaries 
        { 
            get => _practiceDiaries; 
            set => Set(ref _practiceDiaries, value, nameof(PracticeDiaries)); 
        }

        private Curator _curator;
        private PracticeDiary _selectedPracticeDiary;
        public Curator Curator 
        { 
            get => _curator; 
            set => Set(ref _curator, value, nameof(Curator)); 
        }
        public PracticeDiary SelectedPracticeDiary 
        { 
            get => _selectedPracticeDiary; 
            set => Set(ref _selectedPracticeDiary, value, nameof(SelectedPracticeDiary)); 
        }

        public void OpenManagerWindow()
        {
            if (SelectedPracticeDiary != null)
                new ManagerWindow(SelectedPracticeDiary.Diary, _ctx).ShowDialog();
        }

        private void UpdateLists()
        {
            PracticeDiaries = new List<PracticeDiary>(PracticeDiaryService.GetPracticeDiaries().Where(pd=>pd.Practice.Curator==Curator && ( DateTime.Now>=pd.Practice.StartDate && DateTime.Now<=pd.Practice.EndDate)));
        }
        
    }
}
