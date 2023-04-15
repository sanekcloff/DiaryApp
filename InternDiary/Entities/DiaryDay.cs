using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
{
    public class DiaryDay
    {
        public int DiaryId { get; set; }
        public int DayId { get; set; }

        public Diary Diary { get; set; } = null!;
        public Day Day { get; set; } = null!;
    }
}
