using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternDiaryV2.Entities
{
    public class User
    {
        public User()
        {
            Diaries = new HashSet<Diary>();
        }

        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public ICollection<Diary> Diaries { get; set; }

        [NotMapped]
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }
    }
}