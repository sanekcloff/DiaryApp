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
    public class UserService
    {
        private ApplicationDbContext _ctx;
        public UserService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ICollection<User> GetUsers()
        {
            return _ctx.Users.Include(u=>u.Role)
                .Include(u => u.Diaries)
                .ToList();
        }
        public User? GetUser(int Id)
        {
            return _ctx.Users.Include(u => u.Role)
                .Include(u => u.Diaries)
                .SingleOrDefault(u=>u.Id==Id);
        }
        public void Insert(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }
        public void Update(User user)
        {
            _ctx.Users.Update(user);
            _ctx.SaveChanges();
        }
        public void Delete(User user)
        {
            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
        }
    }
}
