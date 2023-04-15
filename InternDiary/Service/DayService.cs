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
