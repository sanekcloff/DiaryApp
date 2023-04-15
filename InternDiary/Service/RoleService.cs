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
