using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiaryV2.Entities
{
    public class Diary
    {
        public Diary()
        {
            PracticeDiaries = new HashSet<PracticeDiary>();
            DiaryDays = new HashSet<DiaryDay>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<PracticeDiary> PracticeDiaries { get; set; }
        public ICollection<DiaryDay> DiaryDays { get; set; }

        [NotMapped]
        public string DiaryInfo { get => $"Дневник студента: {User.FullName}"; }
    }
}
