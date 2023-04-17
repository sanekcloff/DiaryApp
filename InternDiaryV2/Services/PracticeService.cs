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
    public class PracticeService
    {
        private ApplicationDbContext _ctx;

        public PracticeService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Practice> GetPractices()
        {
            return _ctx.Practices
                .Include(p => p.PracticeDiaries)
                    .ThenInclude(pd => pd.Diary)
                        .ThenInclude(d=>d.User)
                            .ThenInclude(u=>u.Role)
                .Include(p => p.PracticeDiaries)
                    .ThenInclude(pd => pd.Diary)
                        .ThenInclude(d => d.DiaryDays)
                            .ThenInclude(dd=>dd.Day)
                .Include(p=>p.Curator)
                    .ThenInclude(c=>c.Organization)
                .ToList();
        }
        public Practice? GetPractice(int Id)
        {
            return _ctx.Practices
                .Include(p => p.PracticeDiaries)
                    .ThenInclude(pd => pd.Diary)
                        .ThenInclude(d => d.User)
                            .ThenInclude(u => u.Role)
                .Include(p => p.PracticeDiaries)
                    .ThenInclude(pd => pd.Diary)
                        .ThenInclude(d => d.DiaryDays)
                            .ThenInclude(dd => dd.Day)
                .Include(p => p.Curator)
                    .ThenInclude(c => c.Organization)
                .SingleOrDefault(p=>p.Id==Id);
        }
        
        public void Insert(Practice practice)
        {
            _ctx.Practices.Add(practice);
            _ctx.SaveChanges();
        }
        public void Update(Practice practice)
        {
            _ctx.Practices.Update(practice);
            _ctx.SaveChanges();
        }
        public void Delete(Practice practice)
        {
            _ctx.Practices.Remove(practice);
            _ctx.SaveChanges();
        }
    }
}
