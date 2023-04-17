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
                       .ThenInclude(p => p.Curator)
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
