using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using InternDiaryV2.Services;
using InternDiaryV2.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InternDiaryV2.ViewModels.Pages
{
    public class AdminViewModel:ViewModelBase
    {
        private ApplicationDbContext _ctx;
        public AdminViewModel(User user, ApplicationDbContext ctx, UserService userService, CuratorService curatorService)
        {
            _ctx = ctx;

            UserService= userService;
            CuratorService= curatorService;
            OrganizationService = new OrganizationService(ctx);
            PracticeService = new PracticeService(ctx);
            RoleService = new RoleService(ctx);

            UpdateLists();

            SelectedRole = Roles[0];
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
        }

        #region Services
        public UserService UserService { get; set; }
        public CuratorService CuratorService { get; set; }
        public OrganizationService OrganizationService { get; set; }
        public PracticeService PracticeService { get; set; }
        public RoleService RoleService { get; set; }
        #endregion

        #region Lists
        private List<User> _users;
        private List<Curator> _curators;
        private List<Organization> _organizations;
        private List<Practice> _practices;
        private List<Role> _roles;
        public List<User> Users { get => _users; set => Set(ref _users, value, nameof(Users)); }
        public List<Curator> Curators { get => _curators; set => Set(ref _curators, value, nameof(Curators)); }
        public List<Organization> Organizations { get => _organizations; set => Set(ref _organizations, value, nameof(Organizations)); }
        public List<Practice> Practices { get => _practices; set => Set(ref _practices, value, nameof(Practices)); }
        public List<Role> Roles { get => _roles; set => Set(ref _roles, value, nameof(Roles)); }
        #endregion

        #region Fields & Properties

        #region User
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private string _login;
        private string _password;
        private Role _selectedRole;
        public string LastName { get => _lastName; set => Set(ref _lastName, value, nameof(LastName)); }
        public string FirstName { get => _firstName; set => Set(ref _firstName, value, nameof(FirstName)); }
        public string MiddleName { get => _middleName; set => Set(ref _middleName, value, nameof(MiddleName)); }
        public string Login { get => _login; set => Set(ref _login, value, nameof(Login)); }
        public string Password { get => _password; set => Set(ref _password, value, nameof(Password)); }
        public Role SelectedRole { get => _selectedRole; set => Set(ref _selectedRole, value, nameof(SelectedRole)); }
        #endregion
        #region Curator
        private string _clastName;
        private string _cfirstName;
        private string _cmiddleName;
        private string _clogin;
        private string _cpassword;
        private Organization _cselectedOrganization;
        public string ClastName { get => _clastName; set => Set(ref _clastName, value, nameof(ClastName)); }
        public string CfirstName { get => _cfirstName; set => Set(ref _cfirstName, value, nameof(CfirstName)); }
        public string CmiddleName { get => _cmiddleName; set => Set(ref _cmiddleName, value, nameof(CmiddleName)); }
        public string Clogin { get => _clogin; set => Set(ref _clogin, value, nameof(Clogin)); }
        public string Cpassword { get => _cpassword; set => Set(ref _cpassword, value, nameof(Cpassword)); }
        public Organization CselectedOrganization { get => _cselectedOrganization; set => Set(ref _cselectedOrganization, value, nameof(CselectedOrganization)); }
        #endregion
        #region Organizations
        private string _title;
        public string Title { get => _title; set => Set(ref _title, value, nameof(Title)); }
        #endregion
        #region Practice
        private DateTime _startDate;
        private DateTime _endDate;
        private Curator _pselectedCurator;
        public DateTime StartDate { get => _startDate; set => Set(ref _startDate, value, nameof(StartDate)); }
        public DateTime EndDate { get => _endDate; set => Set(ref _endDate, value, nameof(EndDate)); }
        public Curator PselectedCurator { get => _pselectedCurator; set => Set(ref _pselectedCurator, value, nameof(PselectedCurator)); }
        #endregion
        private User _selectedUser;
        private Curator _selectedCurator;
        private Organization _selectedOrganization;
        private Practice _selectedPractice;

        public User SelectedUser
        {
            get => _selectedUser; set
            {
                Set(ref _selectedUser, value, nameof(SelectedUser));
                if (value!=null)
                {
                    SelectedRole = value.Role;
                    LastName = value.LastName;
                    FirstName = value.FirstName;
                    MiddleName = value.MiddleName;
                    Login = value.Login;
                    Password = value.Password;
                }
            }
        }
        public Curator SelectedCurator
        {
            get => _selectedCurator;
            set
            {
                Set(ref _selectedCurator, value, nameof(SelectedCurator));
                if (value!=null)
                {
                    CselectedOrganization=value.Organization;
                    CfirstName=value.FirstName;
                    CmiddleName=value.MiddleName;
                    ClastName=value.LastName;
                    Clogin = value.Login;
                    Cpassword=value.Password;
                }
            }
        }
        public Organization SelectedOrganization
        {
            get => _selectedOrganization;
            set
            {
                Set(ref _selectedOrganization, value, nameof(SelectedOrganization));
                if (value!=null)
                    Title = value.Title;
            }
        }
        public Practice SelectedPractice
        {
            get => _selectedPractice;
            set
            {
                Set(ref _selectedPractice, value, nameof(SelectedPractice));
                if (value!=null)
                {
                    StartDate = value.StartDate;
                    EndDate = value.EndDate;
                    PselectedCurator = value.Curator;
                }
            }
        }
        #endregion

        #region Methods
        public void AddUser()
        {
            if (!(string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(MiddleName) || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || SelectedRole == null))
            {
                if (!(UserService.GetUsers().Any(u => u.FirstName == FirstName && u.LastName == LastName && u.MiddleName == MiddleName && u.Role == SelectedRole && u.Login == Login && u.Password == Password)))
                {
                    UserService.Insert(new User { FirstName = FirstName, LastName = LastName, MiddleName = MiddleName, Role = SelectedRole, Login = Login, Password = Password });
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такой пользователь уже существует!");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        public void UpdateUser()
        {
            if (!(string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(MiddleName) || string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password) || SelectedRole == null))
            {
                if (!(UserService.GetUsers().Any(u => u.FirstName == FirstName && u.LastName == LastName && u.MiddleName == MiddleName && u.Role == SelectedRole && u.Login == Login && u.Password == Password)))
                {
                    SelectedUser.LastName = LastName;
                    SelectedUser.FirstName = FirstName;
                    SelectedUser.MiddleName = MiddleName;
                    SelectedUser.Login = Login;
                    SelectedUser.Password = Password;
                    SelectedUser.Role = SelectedRole;
                    UserService.Update(SelectedUser);
                    UpdateLists();
                }   
                else
                    MessageBox.Show("Такой пользователь уже существует!");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");

        }
        public void DeleteUser()
        {
            if (SelectedUser != null)
            {
                var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    UserService.Delete(SelectedUser);
                    UpdateLists();
                }        
            }
            else
                MessageBox.Show("Выберите пользователя");
        }
        public void AddCurator()
        {
            if (!(string.IsNullOrEmpty(CfirstName) || string.IsNullOrEmpty(ClastName) || string.IsNullOrEmpty(CmiddleName) || string.IsNullOrEmpty(Clogin) || string.IsNullOrEmpty(Cpassword) || CselectedOrganization == null))
            {
                if(!(CuratorService.GetCurators().Any(u => u.FirstName == CfirstName && u.LastName == ClastName && u.MiddleName == CmiddleName && u.Organization == CselectedOrganization && u.Login == Clogin && u.Password == Cpassword)))
                {
                    CuratorService.Insert(new Curator { FirstName = CfirstName, LastName = ClastName, MiddleName = CmiddleName, Organization = CselectedOrganization, Login = Clogin, Password = Cpassword });
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такой руководитель уже существует!");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        public void UpdateCurator()
        {
            if (!(string.IsNullOrEmpty(CfirstName) || string.IsNullOrEmpty(ClastName) || string.IsNullOrEmpty(CmiddleName) || string.IsNullOrEmpty(Clogin) || string.IsNullOrEmpty(Cpassword) || CselectedOrganization == null))
            {
                if (!(CuratorService.GetCurators().Any(u => u.FirstName == CfirstName && u.LastName == ClastName && u.MiddleName == CmiddleName && u.Organization == CselectedOrganization && u.Login == Clogin && u.Password == Cpassword)))
                {
                    SelectedCurator.LastName = ClastName;
                    SelectedCurator.FirstName = CfirstName;
                    SelectedCurator.MiddleName = CmiddleName;
                    SelectedCurator.Login = Clogin;
                    SelectedCurator.Password = Cpassword;
                    SelectedCurator.Organization = CselectedOrganization;
                    CuratorService.Update(SelectedCurator);
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такой руководитель уже сущетсвует!");
            }  
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        public void DeleteCurator()
        {
            var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                CuratorService.Delete(SelectedCurator);
                UpdateLists();
            }
        }
        public void AddOrganization()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                if(!OrganizationService.GetOrganizations().Any(o=>o.Title==Title))
                {
                    OrganizationService.Insert(new Organization { Title = Title });
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такая организация существует!");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        public void UpdateOrganization()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                if (!OrganizationService.GetOrganizations().Any(o => o.Title == Title))
                {
                    SelectedOrganization.Title = Title;
                    OrganizationService.Update(SelectedOrganization);
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такая организация существует!");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        public void DeleteOrganization()
        {
            var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                OrganizationService.Delete(SelectedOrganization);
                UpdateLists();
            }
        }
        public void AddPractice()
        {
            if (PselectedCurator != null)
            {
                if (!PracticeService.GetPractices().Any(p=>p.StartDate==StartDate && p.EndDate==EndDate && p.Curator==PselectedCurator))
                {
                    PracticeService.Insert(new Practice { StartDate = StartDate, EndDate = EndDate, Curator = PselectedCurator });
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такая практика существует!");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        public void UpdatePractice()
        {
            if (PselectedCurator != null)
            {
                if (!PracticeService.GetPractices().Any(p => p.StartDate == StartDate && p.EndDate == EndDate && p.Curator == PselectedCurator))
                {
                    SelectedPractice.StartDate = StartDate;
                    SelectedPractice.EndDate = EndDate;
                    SelectedPractice.Curator = PselectedCurator;
                    PracticeService.Update(SelectedPractice);
                    UpdateLists();
                }
                else
                    MessageBox.Show("Такая практика существует!");
            }
            else
                MessageBox.Show("Все поля должны быть заполнены!");
        }
        public void DeletePractice()
        {
            var result = MessageBox.Show("Вы уверены что хотите удалить?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                PracticeService.Delete(SelectedPractice);
                DayService dayService = new(_ctx);
                DiaryService diaryService = new(_ctx);

                var diaries = new List<Diary>(SelectedPractice.PracticeDiaries.Select(pd => pd.Diary));
                diaryService.Delete(diaries);
                foreach (var diary in diaries)
                {
                    dayService.Delete(diary.DiaryDays.Select(dd=>dd.Day).ToList());
                }
                UpdateLists();
            }
        }
        #endregion

        public void OpenManagerWindow()
        {
            if (SelectedPractice != null)
                new ManagerWindow(SelectedPractice, _ctx, UserService).ShowDialog();
            UpdateLists();
        }
        private void UpdateLists()
        {
            Users = new List<User>(UserService.GetUsers());
            Curators = new List<Curator>(CuratorService.GetCurators());
            Organizations = new List<Organization>(OrganizationService.GetOrganizations());
            Practices= new List<Practice>(PracticeService.GetPractices());
            Roles = new List<Role>(RoleService.GetRoles());
        }
    }
}
