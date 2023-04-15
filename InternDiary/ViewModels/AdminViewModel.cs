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

        // для удобства пользоваться регионами чтобы можно было скрывать ненужные куски кода

        // Готовый пример того как должны выглядеть преколы для списков
        #region Organization

        // для работы с сущностью и таблицами, экземпляр создаётся в конструкторе выше. В сами сервисы не лезнть, я там всё вроде настроил, только пользоваться их методами.
        #region services
        public OrganizationService OrganizationService { get; set; }
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

        // Пример добавления, редактирования и удаления
        #region Methods
        public void AddOrganization()
        {
            // проверка на то существует ли организаия с таким названием уже в базе
            if (!OrganizationService.GetOrganizations().Any(o => o.Title == OrganizationTitle)) // Any вернёт значение true если найдёт хотябы 1 тако элемент, в начале стоит ! это отрицание.
                OrganizationService.Insert(new Organization { Title=OrganizationTitle });
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

        #endregion

        // вызывать после того как происходят какие либо изменения в таблицах
        public void UpdateLists()
        {
            Organizations = new List<Organization>(OrganizationService.GetOrganizations());
            Practices = new List<Practice>(PracticeService.GetPractices());
        }
    }
}
