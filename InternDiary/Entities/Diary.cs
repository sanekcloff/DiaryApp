using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
{
    public class Diary
    {
        public Diary()
        {
            PracticeDiaries = new HashSet<PracticeDiary>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<PracticeDiary> PracticeDiaries { get; set; }
    }
}
