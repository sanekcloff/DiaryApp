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
    public class DiaryService
    {
        private ApplicationDbContext _ctx;
        public DiaryService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ICollection<Diary> GetDiaries()
        {
            return _ctx.Diaries.Include(d=>d.User).Include(d=>d.PracticeDiaries).ToList();
        }

        public Diary? GetDiary(int Id)
        {
            return _ctx.Diaries.Include(d => d.User).Include(d => d.PracticeDiaries).SingleOrDefault(d => d.Id == Id);
        }

        public void Insert(Diary diary)
        {
            _ctx.Diaries.Add(diary);
            _ctx.SaveChanges();
        }
        public void Update(Diary diary)
        {
            _ctx.Diaries.Update(diary);
            _ctx.SaveChanges();
        }
        public void Delete(Diary diary) 
        {
            _ctx.Diaries.Remove(diary);
            _ctx.SaveChanges();
        }
    }
}
