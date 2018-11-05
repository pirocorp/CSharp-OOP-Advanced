namespace Forum.App.Menus
{
    using System;
    using Models;
	using Contracts;

	public class AddPostMenu : Menu, ITextAreaMenu
	{
		private readonly ILabelFactory labelFactory;
		private readonly ITextAreaFactory textAreaFactory;
		private readonly IForumReader reader;
	    private readonly ICommandFactory commandFactor;

		private bool error;

	    public AddPostMenu(ILabelFactory labelFactory, ITextAreaFactory textAreaFactory, IForumReader reader, ICommandFactory commandFactor, bool error)
	    {
	        this.labelFactory = labelFactory;
	        this.textAreaFactory = textAreaFactory;
	        this.reader = reader;
	        this.commandFactor = commandFactor;

            this.InitializeTextArea();
            this.Open();
	    }

		private string TitleInput => this.Buttons[0].Text.TrimStart();

		private string CategoryInput => this.Buttons[1].Text.TrimStart();
		
		public ITextInputArea TextArea { get; private set; }

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			var labelContents = new string[] { "All fields must be filled!", "Title:", "Category:", "", "" };
			var labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - 18, consoleCenter.Top - 14), // Error: 
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // Title: 
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Category:
                new Position(consoleCenter.Left - 9, consoleCenter.Top - 12),  // Title: 
                new Position(consoleCenter.Left - 7, consoleCenter.Top - 10),  // Category:
            };

			this.Labels = new ILabel[labelContents.Length];
			this.Labels[0] = this.labelFactory.CreateLabel(labelContents[0], labelPositions[0], !this.error);

			for (var i = 1; i < this.Labels.Length; i++)
			{
				this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
			}
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			var buttonContents = new string[] { "Write", "Post" };
			var fieldPositions = new Position[]
			{
				new Position(consoleCenter.Left - 10, consoleCenter.Top - 12), // Title: 
                new Position(consoleCenter.Left - 8, consoleCenter.Top - 10),  // Category:
            };

			var buttonPositions = new Position[]
			{
				new Position(consoleCenter.Left + 14, consoleCenter.Top - 8),  // Write
                new Position(consoleCenter.Left + 14, consoleCenter.Top + 12)  // Post
            };

			this.Buttons = new IButton[fieldPositions.Length + buttonPositions.Length];

			for (var i = 0; i < fieldPositions.Length; i++)
			{
				this.Buttons[i] = this.labelFactory.CreateButton(" ", fieldPositions[i], false, true);
			}

			for (var i = 0; i < buttonPositions.Length; i++)
			{
				this.Buttons[i + fieldPositions.Length] = this.labelFactory.CreateButton(buttonContents[i], buttonPositions[i]);
			}

			this.TextArea.Render();
		}

		private void InitializeTextArea()
		{
			var consoleCenter = Position.ConsoleCenter();
			this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, consoleCenter.Top - 7);
		}

		public override IMenu ExecuteCommand()
		{
		    if (this.CurrentOption.IsField)
		    {
		        var fieldInput =
		            $" {this.reader.ReadLine(this.CurrentOption.Position.Left + 1, this.CurrentOption.Position.Top)}";

		        this.Buttons[this.currentIndex] = this.labelFactory.CreateButton(
                    fieldInput, this.CurrentOption.Position,
                    this.CurrentOption.IsHidden, this.CurrentOption.IsField);

		        return this;
		    }

		    try
		    {
		        var commandName = string.Join("", this.CurrentOption.Text.Split());
		        var command = this.commandFactor.CreateCommand(commandName);
		        var view = command.Execute(this.TitleInput, this.CategoryInput, this.TextArea.Text);

		        return view;
		    }
		    catch (Exception e)
		    {
		        this.error = true;
                this.InitializeStaticLabels(Position.ConsoleCenter());
		        return this;
		    }
		}
	}
}
