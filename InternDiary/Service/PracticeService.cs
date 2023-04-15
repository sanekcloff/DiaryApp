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
                .Include(p=>p.PracticeDiaries)
                .Include(p=>p.Organization)
                .ToList();
        }
        public Practice? GetPractice(int Id)
        {
            return _ctx.Practices
                .Include(p => p.PracticeDiaries)
                .Include(p => p.Organization)
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
