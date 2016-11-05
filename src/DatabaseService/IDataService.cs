using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;

namespace DatabaseService
{
    public interface IDataService
    {
        IList<PostExtended> GetPost(int page, int pagesize);
        PostExtended GetPost(int id);
        //Post GetPost(int id);
        //void AddPost(Post post);
        //bool UpdatePost(Post post);
        //bool DeletePost(int id);
        int GetNumberOfPosts();
    }
}
