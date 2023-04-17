using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace InternDiaryV2.Entities
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

        public int CuratorId { get; set; }

        public Curator Curator { get; set; } = null!;

        public ICollection<PracticeDiary> PracticeDiaries { get; set; }

        [NotMapped]
        public string Dates { get => $"{StartDate.ToString("d")} - {EndDate.ToString("d")}"; }
        public string PracticeInfo { get => $"{Curator.Organization.Title}: {Dates}"; }
    }
}