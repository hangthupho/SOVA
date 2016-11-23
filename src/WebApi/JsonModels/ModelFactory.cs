using StackOverFLow.DomainModel;
using Microsoft.AspNetCore.Mvc;
using DatabaseService;
using DomainModel;
using Microsoft.AspNetCore.Mvc.Routing;

namespace WebApi.JsonModels
{
    public class ModelFactory
    {
        //============= Mapping Tags ==============
        public static TagModel MapTag(Tag tag, IUrlHelper urlHelper)
        {
            var tagViewModel = MappingConfig<Tag, TagModel>.Convert(tag);
            tagViewModel.Url = urlHelper.Link(Config.TagsRoute, new { id = tag.PostId });
            return tagViewModel;
        }

        //============= Mapping Question Posts as a List ==============
        public static PostListModel MapPostList(PostExtended post, IUrlHelper urlHelper)
        {
            var postListViewModel = MappingConfig<PostExtended, PostListModel>.Convert(post);
            postListViewModel.Url = urlHelper.Link(Config.PostRoute, new { id = post.PostId });
            return postListViewModel;
        }

        //============= Mapping Post Details ==============
        public static PostDetailModel MapPostDetail(PostExtended post, IUrlHelper urlHelper)
        {

            var postViewModel = MappingConfig<PostExtended, PostDetailModel>.Convert(post);
            postViewModel.Url = urlHelper.Link(Config.PostRoute, new { id = post.PostId });
            return postViewModel;
        }

        //=============== Mapping Comments ================
        public static CommentModel MapComment(CommentExtended comment, IUrlHelper urlHelper)
        {
            var commentViewModel = MappingConfig<CommentExtended, CommentModel>.Convert(comment);
            commentViewModel.Url = urlHelper.Link(Config.CommentRoute, new { id = comment.CommentId });
            return commentViewModel;
        }

        //=============== Mapping Annotations ================
        public static AnnotationModel MapAnnotation (Annotation annotation, IUrlHelper urlHelper)
        {
            var annotationViewModel = MappingConfig<Annotation, AnnotationModel>.Convert(annotation);
            annotationViewModel.Url = urlHelper.Link(Config.AnnotationRoute, new { id = annotation.AnnotationId });
            return annotationViewModel;
        }
        public static Annotation MapAnnotation(AnnotationModel model)
        {
            return MappingConfig<AnnotationModel, Annotation>.Convert(model);
        }

        //============= Mapping Users ==============
        public static UserModel MapUser(User user, IUrlHelper urlHelper)
        {
            var userViewModel = MappingConfig<User, UserModel>.Convert(user);
            userViewModel.Url = urlHelper.Link(Config.UserRoute, new { id = user.UserId });
            return userViewModel;
        }
        //============= Mapping History ==============
        public static HistoryModel MapHistory(History history, IUrlHelper urlHelper)
        {
            var historyViewModel = MappingConfig<History, HistoryModel>.Convert(history);
            historyViewModel.Url = urlHelper.Link(Config.HistoryRoute, new { id = history.sId });
            return historyViewModel;
        }



    }
}
