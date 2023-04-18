using Microsoft.EntityFrameworkCore;
using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiaryV2.Services
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
                .Include(dd=>dd.Diary)
                .ToList();
        }

        public void Insert(DiaryDay diaryDay)
        {
            _ctx.DiaryDays.Add(diaryDay);
            _ctx.SaveChanges();
        }
        public void Insert(List<DiaryDay> diaryDays)
        {
            _ctx.DiaryDays.AddRange(diaryDays);
            _ctx.SaveChanges();
        }
        public void Update(DiaryDay diaryDay)
        {
            _ctx.DiaryDays.Update(diaryDay);
            _ctx.SaveChanges();
        }
        public void Update(List<DiaryDay> diaryDays)
        {
            _ctx.DiaryDays.UpdateRange(diaryDays);
            _ctx.SaveChanges();
        }
        public void Delete(DiaryDay diaryDay) 
        {
            _ctx.DiaryDays.Remove(diaryDay);
            _ctx.SaveChanges();
        }
        public void Delete(List<DiaryDay> diaryDays)
        {
            _ctx.DiaryDays.RemoveRange(diaryDays);
            _ctx.SaveChanges();
        }
    }
}
