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
    public class OrganizationService
    {
        private ApplicationDbContext _ctx;

        public OrganizationService(ApplicationDbContext ctx)
        {
            _ctx= ctx;
        }

        public ICollection<Organization> GetOrganizations()
        {
            return _ctx.Organizations
                .Include(o=>o.Curators)
                .ToList();
        }
        public Organization? GetOrganization(int Id)
        {
            return _ctx.Organizations
                .Include(o => o.Curators)
                .SingleOrDefault(o=>o.Id==Id);
        }
        public void Insert(Organization organization)
        {
            _ctx.Organizations.Add(organization);
            _ctx.SaveChanges();
        }
        public void Update(Organization organization)
        { 
            _ctx.Organizations.Update(organization);
            _ctx.SaveChanges();
        }
        public void Delete(Organization organization) 
        {
            _ctx.Organizations.Remove(organization);
            _ctx.SaveChanges();
        }
    }
}
