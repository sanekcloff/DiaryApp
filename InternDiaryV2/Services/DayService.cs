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
    public class DayService
    {
        private ApplicationDbContext _ctx;

        public DayService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Day> GetDays()
        {
            return _ctx.Days.Include(d => d.DiaryDays).ToList();
        }
        public Day? GetDay(int Id) 
        {
            return _ctx.Days.Include(d => d.DiaryDays).SingleOrDefault(d => d.Id == Id);
        }

        public void Insert(Day day)
        {
            _ctx.Days.Add(day);
            _ctx.SaveChanges();
        }

        public void Update(Day day)
        {
            _ctx.Days.Update(day);
            _ctx.SaveChanges();
        }

        public void Delete(Day day) 
        {
            _ctx.Days.Remove(day);
            _ctx.SaveChanges();
        }
    }
}
