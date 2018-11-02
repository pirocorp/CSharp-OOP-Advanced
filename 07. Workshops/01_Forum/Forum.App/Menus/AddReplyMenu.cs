﻿namespace Forum.App.Menus
{
	using System.Collections.Generic;

	using Models;
	using Contracts;

	public class AddReplyMenu : Menu, ITextAreaMenu, IIdHoldingMenu
    {
		private const int AUTHOR_OFFSET = 8;
		private const int LEFT_OFFSET = 18;
		private const int TOP_OFFSET = 7;
		private const int BUTTON_OFFSET = 14;

		private ILabelFactory labelFactory;
		private ITextAreaFactory textAreaFactory;
		private IForumReader reader;

		private bool error;
		private IPostViewModel post;

		//TODO: Inject Dependencies

		public ITextInputArea TextArea { get; private set; }

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			var errorPosition = 
				new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 12);
			var titlePosition =
				new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 10);
			var authorPosition =
				new Position(consoleCenter.Left - this.post.Author.Length, consoleCenter.Top - 9);

			var labels = new List<ILabel>()
			{
				this.labelFactory.CreateLabel("Cannot add an empty reply!", errorPosition, !this.error),
				this.labelFactory.CreateLabel(this.post.Title, titlePosition),
				this.labelFactory.CreateLabel($"Author: {this.post.Author}", authorPosition),
			};

			var leftPosition = consoleCenter.Left - LEFT_OFFSET;

			var lineCount = this.post.Content.Length;

			// Add post contents
			for (var i = 0; i < lineCount; i++)
			{
				var position = new Position(leftPosition, consoleCenter.Top - (TOP_OFFSET - i));
				var label = this.labelFactory.CreateLabel(this.post.Content[i], position);
				labels.Add(label);
			}

			this.Labels = labels.ToArray();
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			var left = consoleCenter.Left + BUTTON_OFFSET;
			var top = consoleCenter.Top - (TOP_OFFSET - this.post.Content.Length);

			this.Buttons = new IButton[3];

			this.Buttons[0] = this.labelFactory.CreateButton("Write", new Position(left, top + 1));
			this.Buttons[1] = this.labelFactory.CreateButton("Submit", new Position(left - 1, top + 11));
			this.Buttons[2] = this.labelFactory.CreateButton("Back", new Position(left + 1, top + 12));
		}

		private void InitializeTextArea()
		{
			var consoleCenter = Position.ConsoleCenter();

			var top = consoleCenter.Top - (TOP_OFFSET + this.post.Content.Length) + 5;

			this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, top, false);
		}

		public void SetId(int id)
		{
			throw new System.NotImplementedException();
		}

		public override IMenu ExecuteCommand()
		{
			throw new System.NotImplementedException();
		}
	}
}
