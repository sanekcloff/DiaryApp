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
    public class PracticeDiaryService
    {
        private ApplicationDbContext _ctx;

        public PracticeDiaryService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<PracticeDiary> GetPracticeDiaries()
        {
            return _ctx.PracticeDiaries
                   .Include(pd => pd.Practice)
                       .ThenInclude(p => p.Organization)
                   .Include(pd => pd.Diary)
                       .ThenInclude(d => d.User)
                           .ThenInclude(u => u.Role)
                   .ToList();
        }
        public void Insert(PracticeDiary practiceDiary)
        {
            _ctx.PracticeDiaries.Add(practiceDiary);
            _ctx.SaveChanges();
        }
        public void Update(PracticeDiary practiceDiary)
        {
            _ctx.PracticeDiaries.Update(practiceDiary);
            _ctx.SaveChanges();
        }
        public void Delete(PracticeDiary practiceDiary)
        {
            _ctx.PracticeDiaries.Remove(practiceDiary);
            _ctx.SaveChanges();
        }
    }
}
