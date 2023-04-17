using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiaryV2.Entities
{
    public class Curator
    {
        public Curator()
        {
            Practices=new HashSet<Practice>();
        }

        public int Id { get; set; }

        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; } = null!;

        public ICollection<Practice> Practices { get; set; } = null!;

        [NotMapped]
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }
        public string CuratorInfo { get => $"{Organization.Title}: {FullName}"; }
    }
}
