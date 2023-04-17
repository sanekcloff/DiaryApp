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
    public class RoleService
    {
        private ApplicationDbContext _ctx;

        public RoleService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Role> GetRoles()
        {
            return _ctx.Roles.Include(r=>r.Users).ToList();
        }
        public Role? GetRole(int Id)
        {
            return _ctx.Roles.Include(r => r.Users).SingleOrDefault(u=>u.Id==Id);
        }
    }
}
