namespace Forum.App.Commands
{
    using Contracts;

    public class SubmitCommand : ICommand
    {
        private readonly ISession session;
        private readonly IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            var replyText = args[0];
            var postId = int.Parse(args[1]);
            var authorId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyText, authorId);
            return this.session.Back();
        }
    }
}