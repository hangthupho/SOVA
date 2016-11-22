using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;
using Microsoft.EntityFrameworkCore;
using DomainModel;

namespace DatabaseService
{
    public class SovaContext : DbContext
    {

        public DbSet<Post> post { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Comment> comment { get; set; }
        public DbSet<Answer> answer { get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Linkpost> linkpost { get; set; }
        public DbSet<Marking> marking { get; set; }
        public DbSet<Tag> tag { get; set; }
        public DbSet<History> history { get; set; }
        public DbSet<Annotation> annotation { get; set; }
        public DbSet<SearchedResult> searchedResult { get; set; }
        public DbSet<WeightedSearch> weightedSearch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Question>().ToTable("questions");
            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Linkpost>().ToTable("linkposts");
            modelBuilder.Entity<Marking>().ToTable("marks");
            modelBuilder.Entity<History>().ToTable("search_history");

            modelBuilder.Entity<Annotation>().ToTable("annotations");
            modelBuilder.Entity<Annotation>().Property(t => t.AnnotationId).HasColumnName("aId");

            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().Property(t => t.TagName).HasColumnName("tag");
            modelBuilder.Entity<Tag>().HasKey(t => new { t.PostId, t.TagName });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=sova;uid=root;pwd=root");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
