﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Entities
{
    public class Day
    {
        public Day()
        {
            DiaryDays = new HashSet<DiaryDay>();
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string? Content { get; set; } = null!;
        public int? Result { get; set; }
        public bool? IsAttend { get; set; }

        public ICollection<DiaryDay> DiaryDays { get; set; }
    }
}
