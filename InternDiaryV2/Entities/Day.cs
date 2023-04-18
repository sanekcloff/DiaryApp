﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiaryV2.Entities
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

        [NotMapped]
        public string Attend
        {
            get
            {
                string result = "Не отмечено";
                if (IsAttend != null)
                {
                    if ((bool)IsAttend)
                        result = "Присутствовал";
                    else
                        result = "Отсутствовал";
                }
                return result;
            }
        }
        public bool ContentNullOrEmpty { get => string.IsNullOrEmpty(Content); }
        public bool ResultNullOrEmpty 
        { 
            get
            {
                if (Result==null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
