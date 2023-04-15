using InternDiary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternDiary.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string connectionString = @"Server=DESKTOP-I8L1GP6; Database=InternDiaryDB; Trusted_Connection=true; TrustServerCertificate=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Day> Days { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<DiaryDay> DiaryDays { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<PracticeDiary> PracticeDiaries { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaryDay>(entity =>
            {
                entity.HasKey(e => new { e.DiaryId, e.DayId });
            });
            modelBuilder.Entity<PracticeDiary>(entity =>
            {
                entity.HasKey(e => new { e.PracticeId, e.DiaryId });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
