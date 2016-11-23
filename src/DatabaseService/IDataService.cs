using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;
using DomainModel;

namespace DatabaseService
{
    public interface IDataService
    {

        //View list of question posts
        List<PostExtended> GetListOfPosts(int page, int pagesize);

        //View post details including list of answers
        PostExtended GetPostDetail(int id);
        int GetNumberOfPosts();
        
        //View a list of tags related to a specific post
        IList<Tag> GetPostTag(int id);

        //View users
        IList<User> GetUser(int page, int pagesize);
        User GetUser(int id);
        int GetNumberOfUsers();

        //View search history
        IList<History> GetHistory(int page, int pagesize);
        int GetNumberOfHistories();
        History GetHistory(int id);

        //View comments
        IList<CommentExtended> GetComment(int page, int pagesize);
        CommentExtended GetComment(int id);
        int GetNumberOfComments();

        //View, add, update, delete annotations
        IList<Annotation> GetAnnotation(int page, int pagesize);
        Annotation GetAnnotation(int id);
        int GetNumberOfAnnotations();

        Annotation AddAnnotation(Annotation annotation);
        bool UpdateAnnotation(Annotation annotation);
        bool DeleteAnnotation(int id);

        //Search procedure
        IList<SearchedResult> GetAllMatchPostsWithKeyword(string keyword);
        IList<WeightedSearch> GetSearchedPost(string keyword1);

    }
}
