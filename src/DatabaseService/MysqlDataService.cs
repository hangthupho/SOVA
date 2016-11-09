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
        //======= Get posts =============
        //public IList<PostExtended> GetPost(int page, int pagesize)
        //{
        //    using (var db = new SovaContext())
        //    {
        //        var tmp = (from p in db.post
        //                   select new PostExtended
        //                   {
        //                       PostId = p.PostId,
        //                       Title = p.Question.Title,
        //                       Score = p.Score,
        //                       PostBody = p.PostBody,
        //                       CreatedDate = p.CreatedDate,
        //                       UserId = p.UserId,
        //                       UserName = p.User.UserName
        //                   }) .OrderBy(o => o.PostId)
        //                      .Skip(page * pagesize)
        //                      .Take(pagesize)
        //                      .ToList();
        //        return tmp;
        //    }
        //}

        //public PostExtended GetPost(int id)
        //{
        //    using (var db = new SovaContext())
        //    {
        //        return (from p in db.post
        //                where p.PostId == id
        //                   select new PostExtended
        //                   {
        //                       PostId = p.PostId,
        //                       Title = p.Question.Title,
        //                       Score = p.Score,
        //                       PostBody = p.PostBody,
        //                       CreatedDate = p.CreatedDate,
        //                       UserId = p.UserId,
        //                       UserName = p.User.UserName
        //                   }).FirstOrDefault();             
        //     }
        //}

        public int GetNumberOfPosts()
        {
            using (var db = new SovaContext())
            {
                return db.post.Count();
            }
        }
        //======= Get posts as a list =============
        public IList<PostExtended> GetListOfPosts(int page, int pagesize)
        {
            using (var db = new SovaContext())
            {
                var list = (from p in db.post
                            where !db.answer.Any(f => f.PostId == p.PostId) //select those which are post questions, not answers                           
                           select new PostExtended
                           {
                               PostId = p.PostId,
                               Title = p.Question.Title,                              
                               UserName = p.User.UserName
                           }).OrderBy(o => o.PostId)
                              .Skip(page * pagesize)
                              .Take(pagesize)
                              .ToList();
                return list;
            }
        }

        public PostExtended GetPostDetail(int id)
        {
            using (var db = new SovaContext())
            {
                var getParentId = from a in db.answer
                        where a.ParentId == id
                        select a.PostId;

                //select posts.postBody from posts
                //where postID in (select answers.postID
                //from answers
                //where answers.parentID = id);
                var getAnswerList = (from item in db.post where getParentId.Contains(item.PostId) select item.PostBody).ToList();               

                var result = (from p in db.post
                              where !db.answer.Any(f => f.PostId == p.PostId)
                              where p.PostId == id
                              select new PostExtended
                              {
                                  PostId = p.PostId,
                                  Title = p.Question.Title,
                                  Score = p.Score,
                                  PostBody = p.PostBody,
                                  CreatedDate = p.CreatedDate,
                                  UserId = p.UserId,
                                  UserName = p.User.UserName,
                                  AnswerBody = getAnswerList.ToList()
                                  //CommentBody = p.Comment.CommentBody.ToString().ToList(),
                                  //CommentUserName = p.Comment.User.UserName,                         
                              }).FirstOrDefault();
                return result;            
            }
        }

        public IList<Tag> GetPostTag(int id)
        {
            using (var db = new SovaContext())
            {
                var result = (from t in db.tag
                            where t.PostId == id
                            select new Tag
                            {
                                PostId = t.PostId,
                                TagName = t.TagName
                            }).ToList();
                return result;                       
            }
        }

        //======= CRUD on Comment Table =============
        public IList<CommentExtended> GetComment(int page, int pagesize)
        {
            using (var db = new SovaContext())
            {
                var tmp = (from c in db.comment
                           select new CommentExtended
                           {
                               CommentId = c.CommentId,
                               PostId = c.PostId,
                               UserId = c.UserId,
                               CommentBody = c.CommentBody,
                               PostTitle = c.Post.Question.Title,
                               CommentCreationDate = c.CommentCreationDate,   
                               UserName = c.User.UserName                          
                           }).OrderBy(o => o.CommentId)
                              .Skip(page * pagesize)
                              .Take(pagesize)
                              .ToList();
                return tmp;
            }
        }

        public CommentExtended GetComment(int id)
        {
            using (var db = new SovaContext())
            {
                return (from c in db.comment
                        where c.CommentId == id
                        select new CommentExtended
                        {
                            CommentId = c.CommentId,
                            PostId = c.PostId,
                            UserId = c.UserId,
                            CommentBody = c.CommentBody,
                            PostTitle = c.Post.Question.Title,
                            CommentCreationDate = c.CommentCreationDate,
                            UserName = c.User.UserName
                        }).FirstOrDefault();
            }
        }

        public CommentExtended AddComment(Comment comment)
        {
            using (var db = new SovaContext())
            {
                comment.CommentId = db.comment.Max(c => c.CommentId) + 1;
                db.Add(comment);
                db.SaveChanges();
            }
            return GetComment(comment.CommentId);
        }

        public bool UpdateComment(Comment comment)
        {
            using (var db = new SovaContext())

                try
                {
                    db.Attach(comment);
                    db.Entry(comment).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeleteComment(int id)
        {
            using (var db = new SovaContext())
            {
                var comment = db.comment.FirstOrDefault(c => c.CommentId == id);
                if (comment == null)
                {
                    return false;
                }
                db.Remove(comment);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfComments()
        {
            using (var db = new SovaContext())
            {
                return db.comment.Count();
            }
        }
    }
}
