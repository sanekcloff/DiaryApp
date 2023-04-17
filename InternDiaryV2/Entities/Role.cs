using System.Collections.Generic;

namespace InternDiaryV2.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<User> Users { get; set; }
    }
}