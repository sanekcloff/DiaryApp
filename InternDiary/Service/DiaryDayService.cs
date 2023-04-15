using InternDiary.Data;
using InternDiary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Service
{
    public class DiaryDayService
    {
        private ApplicationDbContext _ctx;

        public DiaryDayService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<DiaryDay> GetDiaryDays()
        {
            return _ctx.DiaryDays
                .Include(dd=>dd.Day)
                    .ThenInclude(d=>d.DiaryDays)
                .Include(dd=>dd.Diary)
                    .ThenInclude(d=>d.PracticeDiaries)
                .Include(dd=>dd.Diary) 
                    .ThenInclude(d=>d.User)
                .ToList();
        }

        public void Insert(DiaryDay diaryDay)
        {
            _ctx.DiaryDays.Add(diaryDay);
            _ctx.SaveChanges();
        }

        public void Update(DiaryDay diaryDay)
        {
            _ctx.DiaryDays.Update(diaryDay);
            _ctx.SaveChanges();
        }

        public void Delete(DiaryDay diaryDay) 
        {
            _ctx.DiaryDays.Remove(diaryDay);
            _ctx.SaveChanges();
        }
    }
}
