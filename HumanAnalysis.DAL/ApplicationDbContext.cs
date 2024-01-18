using HumAnalysis.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAnalysis.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<YearContour> YearContours { get; set; }

        public DbSet<MonthContour> MonthContours { get; set;}
        public DbSet<PhysicalContour> PhysicalContours { get; set;}
        public DbSet<EmotionalContour> EmotionalContours { get; set; }
        public DbSet<IntellectualContour> IntellectualContours { get; set; }
    }
}
