using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService
{
    public class SovaContext : DbContext
    {

        public DbSet<posts> post { get; set; }
        public DbSet<users> user { get; set; }
        public DbSet<comments> comment { get; set; }
        public DbSet<answers> answer { get; set; }
        public DbSet<questions> question { get; set; }
        public DbSet<linkposts> linkpost { get; set; }
        public DbSet<markings> marking { get; set; }
        public DbSet<tags> tag { get; set; }
        public DbSet<history> history { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<posts>().ToTable("posts");
            modelBuilder.Entity<posts>().Property(t => t.postID).HasColumnName("postid");
            modelBuilder.Entity<posts>().Property(t => t.score).HasColumnName("score");
            modelBuilder.Entity<posts>().Property(t => t.postBody).HasColumnName("postbody");
            modelBuilder.Entity<posts>().Property(t => t.createdDate).HasColumnName("createddate");
            modelBuilder.Entity<posts>().Property(t => t.userID).HasColumnName("userid");

            modelBuilder.Entity<users>().ToTable("users");
            modelBuilder.Entity<users>().Property(t => t.userID).HasColumnName("userid");
            modelBuilder.Entity<users>().Property(t => t.userName).HasColumnName("username");
            modelBuilder.Entity<users>().Property(t => t.userLocation).HasColumnName("userlocation");
            modelBuilder.Entity<users>().Property(t => t.userAge).HasColumnName("userage");
            modelBuilder.Entity<users>().Property(t => t.userCreationDate).HasColumnName("usercreationdate");

            modelBuilder.Entity<answers>().ToTable("answers");
            modelBuilder.Entity<answers>().Property(t => t.postID).HasColumnName("postid");
            modelBuilder.Entity<answers>().Property(t => t.parentID).HasColumnName("parentid");

            modelBuilder.Entity<comments>().Property(t => t.commentID).HasColumnName("commentid");
            modelBuilder.Entity<comments>().Property(t => t.postID).HasColumnName("postid");
            modelBuilder.Entity<comments>().Property(t => t.userID).HasColumnName("userid");
            modelBuilder.Entity<comments>().Property(t => t.commentBody).HasColumnName("commentbody");
            modelBuilder.Entity<comments>().Property(t => t.commentCreationDate).HasColumnName("commentcreationdate");

            modelBuilder.Entity<history>().Property(t => t.sID).HasColumnName("sid");
            modelBuilder.Entity<history>().Property(t => t.searchString).HasColumnName("searchstring");
            modelBuilder.Entity<history>().Property(t => t.searchTime).HasColumnName("searchtime");

            modelBuilder.Entity<linkposts>().Property(t => t.pID).HasColumnName("pid");
            modelBuilder.Entity<linkposts>().Property(t => t.linkPostID).HasColumnName("linkpostid");
            modelBuilder.Entity<linkposts>().Property(t => t.postID).HasColumnName("postid");

            modelBuilder.Entity<markings>().Property(t => t.mID).HasColumnName("mid");
            modelBuilder.Entity<markings>().Property(t => t.postID).HasColumnName("postid");
            modelBuilder.Entity<markings>().Property(t => t.status).HasColumnName("status");

            modelBuilder.Entity<questions>().Property(t => t.postID).HasColumnName("postid");
            modelBuilder.Entity<questions>().Property(t => t.closedDate).HasColumnName("closeddate");
            modelBuilder.Entity<questions>().Property(t => t.title).HasColumnName("title");

            modelBuilder.Entity<tags>().Property(t => t.postID).HasColumnName("postid");
            modelBuilder.Entity<tags>().Property(t => t.tag).HasColumnName("tag");

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=wt-220.ruc.dk;database=raw7;uid=raw7;pwd=raw7");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
