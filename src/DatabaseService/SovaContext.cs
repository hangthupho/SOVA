using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService
{
    public class SovaContext : DbContext
    {

        public DbSet<post> posts { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<answer> answer { get; set; }
        public DbSet<question> questions { get; set; }
        public DbSet<linkpost> linkposts { get; set; }
        public DbSet<marking> markings { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<history> history { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<post>().ToTable("posts");
           
            modelBuilder.Entity<post>().Property(t => t.Id).HasColumnName("postid");
            modelBuilder.Entity<post>().Property(t => t.Id).HasColumnName("score");
            modelBuilder.Entity<post>().Property(t => t.Id).HasColumnName("postbody");
            modelBuilder.Entity<post>().Property(t => t.Id).HasColumnName("createddate");
            modelBuilder.Entity<post>().Property(t => t.Id).HasColumnName("userid");
            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=wt-220.ruc.dk;database=raw7;uid=raw7;pwd=raw7");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
