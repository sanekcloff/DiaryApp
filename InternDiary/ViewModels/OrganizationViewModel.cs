using InternDiary.Entities;
using InternDiary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.ViewModels
{
    public class OrganizationViewModel : ViewModelBase
    {
        public OrganizationViewModel(Organization organization, OrganizationUserService organizationUserService, UserService userService)
        {
            OrganizationUserService = organizationUserService;
            UserService = userService;
            Organization = organization;

            UpdateLists();
        }

        #region Services
        public OrganizationUserService OrganizationUserService { get;set;}
        public UserService UserService { get;set;}
        #endregion

        #region Lists
        private List<OrganizationUser> _organizationUsers;
        private List<User> _curators;
        public List<OrganizationUser> OrganizationUsers 
        { 
            get => _organizationUsers; 
            set => Set(ref _organizationUsers, value, nameof(OrganizationUsers)); 
        }
        public List<User> Curators 
        { 
            get => _curators; 
            set => Set(ref _curators, value, nameof(Curators)); 
        }
        #endregion

        #region Fields & Properties
        private Organization _organization;
        private User _selectedCurator;
        private OrganizationUser _selectedOrgniztionUser;
        public Organization Organization 
        { 
            get => _organization; 
            set => Set(ref _organization, value, nameof(Organization)); 
        }
        public User SelectedCurator 
        { 
            get => _selectedCurator; 
            set => Set(ref _selectedCurator, value, nameof(SelectedCurator)); 
        }
        public OrganizationUser SelectedOrganiztionUser 
        { 
            get => _selectedOrgniztionUser; 
            set => Set(ref _selectedOrgniztionUser, value, nameof(SelectedOrganiztionUser)); 
        }
        #endregion

        #region Methods
        public void AddCurator()
        {
            if (SelectedCurator!=null)
            {
                OrganizationUserService.Insert(new OrganizationUser { Organization=Organization, User=SelectedCurator});
            }
            UpdateLists();
        }
        public void UpdateCurator()
        {
            if (SelectedOrganiztionUser != null && SelectedCurator != null)
            {
                SelectedOrganiztionUser.User = SelectedCurator;
                OrganizationUserService.Update(SelectedOrganiztionUser);
            }
            UpdateLists();
        }
        public void DeleteCurator()
        {
            if (SelectedOrganiztionUser != null)
            {
                OrganizationUserService.Delete(SelectedOrganiztionUser);
            }
            UpdateLists();
        }
        #endregion

        private void UpdateLists()
        {
            OrganizationUsers = new List<OrganizationUser>(OrganizationUserService.GetOrganizationUsers().Where(ou => ou.Organization == Organization));
            Curators = new List<User>(UserService.GetUsers().Where(u=>u.RoleId==2 && u.OrganizationUsers.Count==0));
        }
    }
}
