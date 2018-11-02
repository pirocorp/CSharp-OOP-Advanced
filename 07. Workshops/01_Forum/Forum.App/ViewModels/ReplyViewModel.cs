namespace Forum.App.ViewModels
{
    using Contracts;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string content, string author) 
            : base(content)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}