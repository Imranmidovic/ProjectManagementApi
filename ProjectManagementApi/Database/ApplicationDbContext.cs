using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<SubProject> SubProjects { get; set; }
        public DbSet<Situation> Situations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>().HasKey(p => p.ID);
            builder.Entity<Project>().HasMany(p => p.SubProjects).WithOne().HasForeignKey(sp => sp.Fk);


            builder.Entity<SubProject>().HasKey(sp => sp.ID);
            builder.Entity<SubProject>().HasMany(sp => sp.Situations).WithOne().HasForeignKey(s => s.Fk);
         

            builder.Entity<Situation>().HasKey(s => s.ID);
            base.OnModelCreating(builder);
        }
    }
}
