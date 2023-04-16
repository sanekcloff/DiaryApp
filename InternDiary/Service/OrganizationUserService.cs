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
    public class OrganizationUserService
    {
        private ApplicationDbContext _ctx;

        public OrganizationUserService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<OrganizationUser> GetOrganizationUsers()
        {
            return _ctx.OrganizationUsers
                .Include(ou=>ou.Organization)
                    .ThenInclude(o=>o.Practices)
                .Include(ou=>ou.User)
                    .ThenInclude(u=>u.Role)
                .ToList();
        }
        public void Insert(OrganizationUser organizationUser)
        {
            _ctx.OrganizationUsers.Add(organizationUser);
            _ctx.SaveChanges();
        }
        public void Update(OrganizationUser organizationUser)
        {
            _ctx.OrganizationUsers.Update(organizationUser);
            _ctx.SaveChanges();
        }
        public void Delete(OrganizationUser organizationUser)
        {
            _ctx.OrganizationUsers.Remove(organizationUser);
            _ctx.SaveChanges();
        }
    }
}
