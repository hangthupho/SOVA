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
        public static PostModel MapPost(PostExtended post, IUrlHelper urlHelper)
        {
            // AutoMapper
            Mapper.Initialize(config => config.CreateMap<Post, PostModel>());
            var postViewModel = Mapper.Map<Post, PostModel>(post);

            // Manually mapping extra properties
            postViewModel.Url = urlHelper.Link(Config.PostRoute, new { id = post.PostId });
            postViewModel.Title = post.Title;
            postViewModel.UserName = post.UserName;

            return postViewModel;
        }

        public static CommentModel MapComment(CommentExtended comment, IUrlHelper urlHelper)
        {
            Mapper.Initialize(config => config.CreateMap<Comment, CommentModel>());
            var commentViewModel = Mapper.Map<Comment, CommentModel>(comment);

            commentViewModel.Url = urlHelper.Link(Config.CommentRoute, new { id = comment.CommentId });
            commentViewModel.PostTitle = comment.PostTitle;
            commentViewModel.UserName = comment.UserName;

            return commentViewModel;
        }

        public static Comment MapComment(CommentModel model)
        {
            Mapper.Initialize(config => config.CreateMap<CommentModel, Comment>());
            var comment = Mapper.Map<CommentModel, Comment>(model);
            comment.PostId = model.PostId;
            comment.UserId = model.UserId;

            return comment;
        }

    }
}
