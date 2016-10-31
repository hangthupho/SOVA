using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;

namespace DatabaseService
{
    public interface IDataService
    {
        IList<post> GetPosts(int page, int pagesize);
        posts GetPosts(int id);
        void AddPost(posts post);
        bool UpdatePost(posts post);
        bool DeletePost(int id);
        int GetNumberOfPosts();
    }
}
