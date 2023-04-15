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
    public class AdminViewModel:ViewModelBase
    {
        public AdminViewModel(ApplicationDbContext ctx, User user, UserService userService)
        {
            OrganizationService = new OrganizationService(ctx);
            PracticeService = new PracticeService(ctx);

            UpdateLists();
        }

        #region Organization

        #region services
        public OrganizationService OrganizationService { get; set; }
        #endregion

        #region Lists
        private List<Organization> _organizations;
        public List<Organization> Organizations 
        { 
            get => _organizations;
            set => Set(ref _organizations, value, nameof(Organizations)); 
        }
        #endregion

        #region fields & properties
        private string _organizationTitle;
        private Organization _selectedOrganization;

        public string OrganizationTitle 
        { 
            get => _organizationTitle; 
            set => Set(ref _organizationTitle, value, nameof(OrganizationTitle)); 
        }
        public Organization SelectedOrganization
        {
            get => _selectedOrganization;
            set => Set(ref _selectedOrganization, value, nameof(SelectedOrganization));
        }
        #endregion

        #region Methods
        public void AddOrganization()
        {
            if (!OrganizationService.GetOrganizations().Any(o => o.Title == OrganizationTitle))
                OrganizationService.Insert(new Organization { Title=OrganizationTitle });
            else
                MessageBox.Show("Такая организация уже существует!");
            UpdateLists();
        }
        public void UpdateOrganization()
        {
            if (OrganizationTitle!=null || OrganizationTitle!=string.Empty)
            {
                if (!OrganizationService.GetOrganizations().Any(o => o.Title == OrganizationTitle))
                {
                    SelectedOrganization.Title = OrganizationTitle;
                    OrganizationService.Update(SelectedOrganization);
                }
                else
                    MessageBox.Show($"Название {OrganizationTitle} уже используется!");
            }
            else
                MessageBox.Show("Заполните поля!");
            UpdateLists();
        }
        public void DeleteOrganization()
        {
            var result = MessageBox.Show($"Уверены что хотите удалить {SelectedOrganization.Title}?", "ВНИМАНИЕ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                OrganizationService.Delete(SelectedOrganization);
            UpdateLists();
        }
        #endregion

        #endregion

        #region Practice

        #region services
        public PracticeService PracticeService { get; set; }
        #endregion

        #region Lists
        private List<Practice> _practices;
        public List<Practice> Practices 
        { 
            get => _practices;
            set => Set(ref _practices, value, nameof(Practices)); 
        }
        #endregion 

        #endregion

        public void UpdateLists()
        {
            Organizations = new List<Organization>(OrganizationService.GetOrganizations());
            Practices = new List<Practice>(PracticeService.GetPractices());
        }
    }
}
