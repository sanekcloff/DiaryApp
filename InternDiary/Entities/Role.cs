using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
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
