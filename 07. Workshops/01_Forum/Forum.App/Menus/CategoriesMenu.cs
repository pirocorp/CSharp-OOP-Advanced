namespace Forum.App.Menus
{
	using System.Linq;
	using System.Collections.Generic;

	using Contracts;
	using Models;

	public class CategoriesMenu : Menu, IPaginatedMenu
	{
		private const int PAGE_SIZE = 10;
		private const int CATEGORY_NAME_LENGTH = 36;

		private readonly ILabelFactory labelFactory;
	    private readonly IPostService postService;
	    private readonly ICommandFactory commandFactory;

		private ICategoryInfoViewModel[] categories;
		private int currentPage;

	    public CategoriesMenu(ILabelFactory labelFactory, 
	        IPostService postService, ICommandFactory commandFactory)
	    {
	        this.labelFactory = labelFactory;
	        this.postService = postService;
	        this.commandFactory = commandFactory;

            this.Open();
	    }

		private int LastPage => this.categories.Length / 11;

		private bool IsFirstPage => this.currentPage == 0;

		private bool IsLastPage => this.currentPage == this.LastPage;

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			var labelContent = new string[] { "CATEGORIES", "Name", "Posts" };
			var labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // CATEGORIES
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left + 14, consoleCenter.Top - 10), // Posts
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
				ICategoryInfoViewModel category = null;

				var categoryIndex = i + this.currentPage * PAGE_SIZE;

				if (categoryIndex < this.categories.Length)
				{					
					category = this.categories[categoryIndex];
				}

				var postsCount = category?.PostCount.ToString();
				var buffer = new string(' ', CATEGORY_NAME_LENGTH - category?.Name.Length ?? 0 - postsCount?.Length ?? 0);
				var buttonText = category?.Name + buffer + postsCount;

				var button = this.labelFactory.CreateButton(buttonText, categoryButtonPositions[i], category == null);

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
	}
}
