using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
{
    public class Organization
    {
        public Organization()
        {
            Practices = new HashSet<Practice>();
        }

        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ICollection<Practice> Practices { get; set; }
    }
}
