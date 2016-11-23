using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;
using Microsoft.EntityFrameworkCore;
using DomainModel;
using MySql.Data.MySqlClient;

namespace DatabaseService
{
    public class MysqlDataService : IDataService
    {


        public int GetNumberOfPosts()
        {
            using (var db = new SovaContext())
            {
                return db.post.Count();
            }
        }

        //======= CRUD on annotations =============
        public IList<Annotation> GetAnnotation(int page, int pagesize)
        {
            using (var db = new SovaContext())
            {
                var tmp = (from a in db.annotation
                           select a)
                           .OrderBy(o => o.AnnotationId)
                           .Skip(page * pagesize)
                           .Take(pagesize)
                           .ToList();
                return tmp;
            }
        }

        public Annotation GetAnnotation(int id)
        {
            using (var db = new SovaContext())
            {
                var result = (from p in db.annotation
                              where p.AnnotationId == id
                              select p).FirstOrDefault();
                return result;
            }
        }

        public Annotation AddAnnotation(Annotation annotation)
        {
            using (var db = new SovaContext())
            {
                //annotation.AnnotationId = db.annotation.Max(c => c.AnnotationId) + 1;
                db.Add(annotation);
                db.SaveChanges();
            }
            return GetAnnotation(annotation.AnnotationId);
        }

        public bool UpdateAnnotation(Annotation annotation)
        { 
            using (var db = new SovaContext())

                try
                {
                    db.Attach(annotation);
                    db.Entry(annotation).State = EntityState.Modified;
                    return db.SaveChanges() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

        }

        public bool DeleteAnnotation(int id)
        {
            using (var db = new SovaContext())
            {
                var annotation = db.annotation.FirstOrDefault(c => c.AnnotationId == id);
                if (annotation == null)
                {
                    return false;
                }
                db.Remove(annotation);
                return db.SaveChanges() > 0;
            }
        }

        public int GetNumberOfAnnotations()
        {
            using (var db = new SovaContext())
            {
                return db.annotation.Count();
            }
        }
        //======= Get question posts as a list =============
        public List<PostExtended> GetListOfPosts(int page, int pagesize)
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
                           }) .OrderBy(o => o.PostId)
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
                                  UserName = p.User.UserName,
                                  Answers = getAnswerList
                              }).FirstOrDefault();
                return result;            
            }
        }
        //======= Get tags related to a post =============
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

        public int GetNumberOfComments()
        {
            using (var db = new SovaContext())
            {
                return db.comment.Count();
            }
        }
        //======= Get users =============
        public IList<User> GetUser(int page, int pagesize)
        {
            using (var db = new SovaContext())
            {
    
                var tmp = (from u in db.user
                           select u)
                          .OrderBy(o => o.UserId)
                              .Skip(page * pagesize)
                              .Take(pagesize)
                              .ToList();
                return tmp;
            }
        }

        public User GetUser(int id)
        {
            using (var db = new SovaContext())
            {
                return (from u in db.user
                        where u.UserId == id
                        select u).FirstOrDefault();
            }
        }
        public int GetNumberOfUsers()
        {
            using (var db = new SovaContext())
            {
                return db.user.Count();
            }
        }
        //======= Get history =============
        public IList<History> GetHistory(int page, int pagesize)
        {
            using (var db = new SovaContext())
            {
                var tmp = (from h in db.history
                           select new History
                           {
                               sId = h.sId,
                               SearchString = h.SearchString,
                               SearchTime = h.SearchTime                         
                           }).OrderBy(o => o.sId)
                              .Skip(page * pagesize)
                              .Take(pagesize)
                              .ToList();
                return tmp;
            }
        }

        public History GetHistory(int id)
        {
            using (var db = new SovaContext())
            {
                return (from h in db.history
                        where h.sId == id
                        select new History
                        {
                            sId = h.sId,
                            SearchString = h.SearchString,
                            SearchTime = h.SearchTime
                        }).FirstOrDefault();
            }
        }
        public int GetNumberOfHistories()
        {
            using (var db = new SovaContext())
            {
                return db.history.Count();
            }
        }
        //======= Search posts =============
        public IList<WeightedSearch> GetSearchedPost(string keyword1)
        {
            using (var db = new SovaContext())
            {
                var result = db.weightedSearch.FromSql("call weighted_Search({0})", keyword1);
                var result1 = new List<WeightedSearch>();
                foreach (var data in result)
                {
                    result1.Add(data);
                }
                return result1;
            }
        }

        public IList<SearchedResult> GetAllMatchPostsWithKeyword(string keyword)
        {
            using (var db = new SovaContext())
            {
                var conn = (MySqlConnection)db.Database.GetDbConnection();
                conn.Open();
                var cmd = new MySqlCommand("call post", conn);
                var result = new List<SearchedResult>();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        result.Add(new SearchedResult()
                        {
                            PostId = rdr.GetInt16(0),
                            Score = rdr.GetInt16(2),
                            PostBody = rdr.GetString(1),
                            UserId = rdr.GetInt16(3)
                        });
                    }
                }
                return result.ToList();
            }
        }
    }
}
