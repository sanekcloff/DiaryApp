using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
{
    public class Practice
    {
        public Practice()
        {
            PracticeDiaries = new HashSet<PracticeDiary>();
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; } = null!;

        public ICollection<PracticeDiary> PracticeDiaries { get; set; }

        [NotMapped]
        public string Dates { get => $"{StartDate.ToString("d")} - {EndDate.ToString("d")}"; }
    }
}
