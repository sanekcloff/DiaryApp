using InternDiaryV2.Data;
using InternDiaryV2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiaryV2.Services
{
    public class CuratorService
    {
        private ApplicationDbContext _ctx;

        public CuratorService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<Curator> GetCurators()
        {
            return _ctx.Curators
                .Include(c=>c.Organization)
                .Include(c=>c.Practices)
                .ToList();
        }
        public Curator GetCurator(int Id)
        {
            return _ctx.Curators
                .Include(c => c.Organization)
                .Include(c => c.Practices)
                .SingleOrDefault(c=>c.Id==Id);
        }
        public void Insert(Curator curator)
        {
            _ctx.Curators.Add(curator);
            _ctx.SaveChanges();
        }
        public void Update(Curator curator)
        {
            _ctx.Curators.Update(curator);
            _ctx.SaveChanges();
        }
        public void Delete(Curator curator)
        {
            _ctx.Curators.Remove(curator);
            _ctx.SaveChanges();
        }
    }
}
