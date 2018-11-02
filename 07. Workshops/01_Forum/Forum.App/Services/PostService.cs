namespace Forum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using ViewModels;

    public class PostService : IPostService
    {
        private readonly ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            throw new NotImplementedException();
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            throw new NotImplementedException();
        }

        public string GetCategoryName(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            var categories = this.forumData.Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            throw new NotImplementedException();
        }
    }
}