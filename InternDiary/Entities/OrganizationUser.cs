using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
{
    public class OrganizationUser
    {
        public int Id { get; set; }
        public int OrganizationId { get;set; }
        public int UserId { get; set; }

        public Organization Organization { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
