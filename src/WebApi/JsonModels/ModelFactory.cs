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
        //public static PostModel MapPost(PostExtended post, IUrlHelper urlHelper)
        public static PostModel MapPost(PostExtended post, IUrlHelper urlHelper)
        {
            // hint: use AutoMapper
           Mapper.Initialize(config => config.CreateMap<Post, PostModel>());

            var model = Mapper.Map<Post, PostModel>(post);
            model.Url = urlHelper.Link(Config.PostRoute, new { id = post.PostId });
            model.Title = post.Title;
            model.UserName = post.UserName;

            return model;

            //return new PostModel
            //{
            //    Url = urlHelper.Link(Config.PostRoute, new { id = post.PostId }),               
            //    Title = post.Title,
            //    Body = post.PostBody,
            //    Score = post.Score,
            //    CreationDate = post.CreatedDate,
            //    UserID = post.UserId,
            //    UserName = post.UserName
            //};
        }


        public static CommentModel MapComment(CommentExtended comment, IUrlHelper urlHelper)
        {
             return new CommentModel
            {
                Url = urlHelper.Link(Config.CommentRoute, new { id = comment.CommentId }),
                CommentBody = comment.CommentBody,
                CreationDate = comment.CommentCreationDate,
                PostTitle = comment.PostTitle,
                UserName = comment.UserName
            };
        }

        public static Comment MapComment(CommentModel model)
        {
            // hint: use AutoMapper
            return new Comment
            {
                PostId = model.PostId,
                UserId = model.UserId,
                CommentBody = model.CommentBody,
                CommentCreationDate = model.CreationDate,
                //UserName = model.UserName
            };
        }

    }
}
