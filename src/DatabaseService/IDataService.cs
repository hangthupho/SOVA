using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;

namespace DatabaseService
{
    public interface IDataService
    {
        IList<posts> getPosts(int page, int pagesize);
        posts getPosts(int id);
        void addPost(posts post);
        bool updatePost(posts post);
        bool deletePost(int id);
        int GetNumberOfPosts();
    }
}
