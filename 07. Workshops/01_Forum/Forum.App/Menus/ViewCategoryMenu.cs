namespace Forum.App.Menus
{
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	using Models;

	public class ViewCategoryMenu : Menu, IIdHoldingMenu, IPaginatedMenu
	{
		private const int PAGE_SIZE = 10;
		private const int CATEGORY_NAME_LENGTH = 36;

		private ILabelFactory labelFactory;
		private IPostService postService;
	    private ICommandFactory commandFactory;

		private int categoryId;
		private int currentPage;
		private IPostInfoViewModel[] posts;

	    public ViewCategoryMenu(ILabelFactory labelFactory, IPostService postService, ICommandFactory commandFactory)
	    {
	        this.labelFactory = labelFactory;
	        this.postService = postService;
	        this.commandFactory = commandFactory;
	    }

		private int LastPage => this.posts.Length / 11;

		private bool IsFirstPage => this.currentPage == 1;

		private bool IsLastPage => this.currentPage == this.LastPage;

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			var categoryName = this.postService.GetCategoryName(this.categoryId);

			var labelContent = new string[] { categoryName, "Name", "Replies" };
			var labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // Category name
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left + 12, consoleCenter.Top - 10), // Replies
            };

			this.Labels = new ILabel[labelContent.Length];

			for (var i = 0; i < this.Labels.Length; i++)
			{
				this.Labels[i] = this.labelFactory.CreateLabel(labelContent[i], labelPositions[i]);
			}
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			var defaultButtonContent = new string[] { "Back", "Previous Page", "Next Page" };
			var defaultButtonPositions = new Position[]
			{
				new Position(consoleCenter.Left + 15, consoleCenter.Top - 12), // Back   
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 12), // Previous Page
                new Position(consoleCenter.Left + 10, consoleCenter.Top + 12), // Next Page
            };

			var categoryButtonPositions = new Position[PAGE_SIZE];

			for (var i = 0; i < PAGE_SIZE; i++)
			{
				categoryButtonPositions[i] = new Position(consoleCenter.Left - 18, consoleCenter.Top - 8 + i * 2);
			}

			IList<IButton> buttons = new List<IButton>();
			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[0], defaultButtonPositions[0]));

			for (var i = 0; i < categoryButtonPositions.Length; i++)
			{
				IPostInfoViewModel post = null;

				var categoryIndex = i + this.currentPage * PAGE_SIZE;

				if (categoryIndex < this.posts.Length)
				{
					post = this.posts[categoryIndex];
				}

				var postsCount = post?.ReplyCount.ToString();
				var buffer = new string(' ', CATEGORY_NAME_LENGTH - post?.Title.Length ?? 0 - postsCount?.Length ?? 0);
				var buttonText = post?.Title + buffer + postsCount;

				var button = this.labelFactory.CreateButton(buttonText, categoryButtonPositions[i], post == null);

				buttons.Add(button);
			}

			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[1], defaultButtonPositions[1], this.IsFirstPage));
			buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[2], defaultButtonPositions[2], this.IsLastPage));

			this.Buttons = buttons.ToArray();
		}

		public override IMenu ExecuteCommand()
		{
			throw new System.NotImplementedException();
		}

		public void ChangePage(bool forward = true)
		{
			throw new System.NotImplementedException();
		}

		public void SetId(int id)
		{
			throw new System.NotImplementedException();
		}

	    public override void Open()
	    {
            this.LoadPosts();

            base.Open();
	    }

	    private void LoadPosts()
	    {
	        this.posts = this.postService.GetCategoryPostsInfo(this.categoryId).ToArray();
	    }
    }
}
