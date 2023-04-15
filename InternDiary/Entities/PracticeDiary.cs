using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
{
    public class PracticeDiary
    {
        public int PracticeId { get; set; }
        public int DiaryId { get; set; }

        public Practice Practice { get; set; } = null!;
        public Diary Diary { get; set; } = null!;
    }
}
