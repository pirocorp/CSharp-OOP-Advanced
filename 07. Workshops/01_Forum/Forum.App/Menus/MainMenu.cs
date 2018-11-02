namespace Forum.App.Menus
{
	using Contracts;
	using Models;

    public class MainMenu : Menu
    {
		private ISession session;
		private ILabelFactory labelFactory;

		public MainMenu(ISession session, ILabelFactory labelFactory, ICommandFactory commandFactory)
        {
            this.session = session;
			this.labelFactory = labelFactory;

            this.Open();
        }

        protected override void InitializeButtons(Position consoleCenter)
        {
            var buttonContents = new string[] { "Categories", "Log In", "Sign Up" };

            if (this.session?.IsLoggedIn ?? false)
            {
                buttonContents[1] = "Add Post";
                buttonContents[2] = "Log Out";
            }

            var buttonPositions = new Position[]
            {
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 2),
                new Position(consoleCenter.Left - 4, consoleCenter.Top + 6),
                new Position(consoleCenter.Left - 4, consoleCenter.Top + 8),
            };

            this.Buttons = new IButton[buttonContents.Length];

            for (var i = 0; i < this.Buttons.Length; i++)
            {
                this.Buttons[i] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
            }
        }

		protected override void InitializeStaticLabels(Position consoleCenter)
        {
            var labelContents = new string[] 
            {
                "FORUM",
                string.Format("Hi, {0}", this.session?.Username),
            };

            var labelPositions = new Position[]
            {
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 6),
                new Position(consoleCenter.Left - 4, consoleCenter.Top - 7),
            };

            this.Labels = new ILabel[labelContents.Length];

            var lastIndex = this.Labels.Length - 1;
            for (var i = 0; i < lastIndex; i++)
            {
                this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
            }

            this.Labels[lastIndex] = this.labelFactory
				.CreateLabel(labelContents[lastIndex], labelPositions[lastIndex], !this.session?.IsLoggedIn ?? true);
        }

		public override IMenu ExecuteCommand()
		{
			throw new System.NotImplementedException();
		}
    }
}
