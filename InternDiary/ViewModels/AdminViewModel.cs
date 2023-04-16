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
    public class AdminViewModel:ViewModelBase
    {
        public AdminViewModel(ApplicationDbContext ctx, User user, UserService userService)
        {
            UserService = userService;
            RoleService=new RoleService(ctx);
            OrganizationService = new OrganizationService(ctx);
            PracticeService = new PracticeService(ctx);
            OrganizationUserService=new OrganizationUserService(ctx);

            StartDate=DateTime.Now;
            EndDate=DateTime.Now.AddDays(1);

            UpdateLists();
        }

        // для удобства пользоваться регионами чтобы можно было скрывать ненужные куски кода

        // Готовый пример того как должны выглядеть преколы для списков
        #region Organization

        // для работы с сущностью и таблицами, экземпляр создаётся в конструкторе выше. В сами сервисы не лезнть, я там всё вроде настроил, только пользоваться их методами.
        #region services
        public OrganizationService OrganizationService { get; set; }
        public OrganizationUserService OrganizationUserService { get; set; }
        #endregion

        // список который выводится, данные загружаются через сервис в методе UpdateLists(), 
        #region Lists
        private List<Organization> _organizations;
        public List<Organization> Organizations 
        { 
            get => _organizations;
            set => Set(ref _organizations, value, nameof(Organizations)); 
        }
        #endregion

        // поля для добавления и редактирования и удаления
        #region Properties & Fields
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

        // Пример добавления, редактирования и удаления
        #region Methods
        public void AddOrganization()
        {
            // проверка на то существует ли организаия с таким названием уже в базе
            if (!OrganizationService.GetOrganizations().Any(o => o.Title == OrganizationTitle)) // Any вернёт значение true если найдёт хотябы 1 тако элемент, в начале стоит ! это отрицание.
            {
                OrganizationService.Insert(new Organization { Title = OrganizationTitle });
            }
            else
                MessageBox.Show("Такая организация уже существует!");
            UpdateLists();
        }
        public void UpdateOrganization()
        {
            // проверка на пустую строку
            if (OrganizationTitle!=null || OrganizationTitle!=string.Empty)
            {
                // опять поиск на одинаковое название как выше
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
            // если после диалогового окна нажать кнопку нет, то удаления не будет, если да то удалится, var result хранит то что ты выберешь
            var result = MessageBox.Show($"Уверены что хотите удалить {SelectedOrganization.Title}?", "ВНИМАНИЕ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                OrganizationService.Delete(SelectedOrganization);
            UpdateLists();
        }
        #endregion

        #endregion

        #region Users

        #region Services
        public UserService UserService { get; set; }
        public RoleService RoleService { get; set; }
        #endregion

        #region Lists
        private List<User> _users;
        private List<Role> _roles;
        public List<User> Users 
        { 
            get => _users; 
            set => Set(ref _users, value, nameof(Users)); 
        }
        public List<Role> Roles 
        { 
            get => _roles; 
            set => Set(ref _roles, value, nameof(Roles)); 
        }
        #endregion

        #region Fields & Properties
        private User _selectedUser;
        public User SelectedUser 
        { 
            get => _selectedUser;
            set => Set(ref _selectedUser, value, nameof(SelectedUser));
        }
        #endregion

        #region Methods
        #endregion

        #endregion

        // сюда не лезть
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

        #region Properties & Fields
        private DateTime _startDate;
        private DateTime _endDate;
        private Practice _selectedPractice;

        public DateTime StartDate
        {
            get => _startDate;
            set
            { 
                Set(ref _startDate, value, nameof(StartDate)); 
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            { 
                Set(ref _endDate, value, nameof(EndDate)); 
            }
        }
        public Practice SelectedPractice 
        { 
            get => _selectedPractice;
            set => Set(ref _selectedPractice, value, nameof(SelectedPractice));
        }
        #endregion

        #region Methods
        public void AddPractice()
        {
            if (!PracticeService.GetPractices().Any(p => p.Organization == SelectedOrganization && p.StartDate == StartDate && p.EndDate == EndDate))
                PracticeService.Insert(new Practice { Organization = SelectedOrganization, StartDate = StartDate, EndDate = EndDate });
            else
                MessageBox.Show("Такая практика уже существует!");
            UpdateLists();
        }
        #endregion

        #endregion


        // вызывать после того как происходят какие либо изменения в таблицах
        public void UpdateLists()
        {
            Organizations = new List<Organization>(OrganizationService.GetOrganizations());
            Practices = new List<Practice>(PracticeService.GetPractices());
            Users = new List<User>(UserService.GetUsers());
            Roles = new List<Role>(RoleService.GetRoles());
        }

        public void OpenManagerWindow()
        {
            new ManagerWindow(SelectedOrganization, OrganizationUserService, UserService).ShowDialog();
           
            UpdateLists();
        }
    }
}
