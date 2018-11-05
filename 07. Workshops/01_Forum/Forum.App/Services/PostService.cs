namespace Forum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using DataModels;
    using ViewModels;

    public class PostService : IPostService
    {
        private readonly ForumData forumData;
        private readonly IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            var emptyCategory = string.IsNullOrWhiteSpace(postCategory);
            var emptyTitle = string.IsNullOrWhiteSpace(postTitle);
            var emptyContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyContent || emptyCategory || emptyTitle)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            var category = this.EnsureCategory(postCategory);

            var postId = this.forumData.Posts.Any() ? this.forumData.Posts.Last().Id + 1 : 1;

            var author = this.userService.GetUserById(userId);

            var post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

            this.forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            this.forumData.SaveChanges();

            return post.Id;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            if (String.IsNullOrWhiteSpace(replyContents))
            {
                throw new ArgumentException("Cannot add an emty reply.");
            }

            Post post = this.forumData.Posts.Find(p => p.Id == postId);
            User author = this.userService.GetUserById(userId);

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            Reply reply = new Reply(replyId, replyContents, userId, postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(reply.Id);

            this.forumData.SaveChanges();
        }

        public string GetCategoryName(int categoryId)
        {
            var categoryName = this.forumData.Categories.Find(c => c.Id == categoryId)?.Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            var categories = this.forumData.Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> posts = this.forumData.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return posts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);
            var postView = new PostViewModel(post.Title, 
                this.userService.GetUserName(post.AuthorId), post.Content, this.GetPostReplies(postId));

            return postView;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            var replies = this.forumData.Replies
                .Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }

        private Category EnsureCategory(string postCategory)
        {
            var category = this.forumData.Categories.FirstOrDefault(c => c.Name == postCategory);

            if (category == null)
            {
                var categoryId = this.forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;
                category = new Category(categoryId, postCategory, new List<int>());
                this.forumData.Categories.Add(category);
            }

            return category;
        }
    }
}