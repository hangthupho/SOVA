using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService
{
    public class MysqlDataService : IDataService
    {

        public IList<PostExtended> GetPost(int page, int pagesize)
        {
            using (var db = new SovaContext())
            {
                var tmp = (from p in db.post
                           select new PostExtended
                           {
                               PostId = p.PostId,
                               Title = p.Question.Title,
                               Score = p.Score,
                               PostBody = p.PostBody,
                               CreatedDate = p.CreatedDate,
                               UserId = p.UserId,
                               UserName = p.User.UserName
                           }) .OrderBy(o => o.PostId)
                              .Skip(page * pagesize)
                              .Take(pagesize)
                              .ToList();
                return tmp;
            }
        }


        public PostExtended GetPost(int id)
        {
            using (var db = new SovaContext())
            {
                return (from p in db.post
                        where p.PostId == id
                           select new PostExtended
                           {
                               PostId = p.PostId,
                               Title = p.Question.Title,
                               Score = p.Score,
                               PostBody = p.PostBody,
                               CreatedDate = p.CreatedDate,
                               UserId = p.UserId,
                               UserName = p.User.UserName
                           }).FirstOrDefault();             
             }
        }

        //public void AddPost(Post post)
        //{
        //    using (var db = new SovaContext())
        //    {
        //        post.postID = db.post.Max(c => c.postID) + 1;
        //        db.Add(post);
        //        db.SaveChanges();
        //    }
        //}

        //public bool UpdatePost(Post post)
        //{
        //    using (var db = new SovaContext())

        //        try
        //        {
        //            db.Attach(post);
        //            db.Entry(post).State = EntityState.Modified;
        //            return db.SaveChanges() > 0;
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return false;
        //        }

        //}

        //public bool DeletePost(int id)
        //{
        //    using (var db = new SovaContext())
        //    {
        //        var post = db.post.FirstOrDefault(c => c.postID == id);
        //        if (post == null)
        //        {
        //            return false;
        //        }
        //        db.Remove(post);
        //        return db.SaveChanges() > 0;
        //    }
        //}

        public int GetNumberOfPosts()
        {
            using (var db = new SovaContext())
            {
                return db.post.Count();
            }
        }
    }
}
