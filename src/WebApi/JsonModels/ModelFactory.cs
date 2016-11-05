using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackOverFLow.DomainModel;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DatabaseService;

namespace WebApi.JsonModels
{
    public class ModelFactory
    {
        public static PostModel Map(PostExtended post, IUrlHelper urlHelper)
        {
            // hint: use AutoMapper
            //post = AutoMapper.Mapper.Map<Post, PostModel>(post);
            //url = url.Link(Config.CategoryRoute, new { id = post.postID });

            return new PostModel
            {
                Url = urlHelper.Link(Config.PostRoute, new { id = post.PostId }),
                Tiltle = post.Title,
                Body = post.PostBody,
                Score = post.Score,
                CreationDate = post.CreatedDate,
                UserID = post.UserId,
                UserName = post.UserName
            };
        }

        //public static PostExtended Map(PostModel model)
        //{
        //    // hint: use AutoMapper
        //    return new PostExtended
        //    {
        //        PostBody = model.Body,
        //        Score = model.Score,
        //        CreatedDate = model.CreationDate,
        //        UserId = model.UserID,
        //        //UserName = model.UserName
        //    };
        //}
    }
}
