namespace Forum.App.Menus
{
	using System.Linq;
	using System.Collections.Generic;

	using Models;
	using Contracts;

	public class ViewPostMenu : Menu, IIdHoldingMenu
	{
		private const int LEFT_OFFSET = 18;
		private const int TOP_OFFSET = 7;

		private ILabelFactory labelFactory;
		private ISession session;

		private IForumViewEngine viewEngine;
		
		private int postId;
		private IPostViewModel post;

		//TODO: Inject Dependencies

		public override void Open()
		{		
			this.LoadPost();
			this.ExtendBuffer();

			var consoleCenter = Position.ConsoleCenter();

		    this.InitializeStaticLabels(consoleCenter);

		    this.InitializeButtons(consoleCenter);

			// Add replies
			var currentRow = consoleCenter.Top - (consoleCenter.Top - TOP_OFFSET - 3 - this.post.Content.Length) + 1;

			var repliesStartPosition = new Position(consoleCenter.Left - LEFT_OFFSET, currentRow++);
			var repliesCount = this.post.Replies.Length;

			ICollection<ILabel> replyLabels = new List<ILabel>();

			replyLabels.Add(this.labelFactory.CreateLabel($"Replies: {repliesCount}", repliesStartPosition));

			foreach (var reply in this.post.Replies)
			{
				var replyAuthorPosition = new Position(repliesStartPosition.Left, ++currentRow);

				replyLabels.Add(this.labelFactory.CreateLabel(reply.Author, replyAuthorPosition));

				foreach (var line in reply.Content)
				{
					var rowPosition = new Position(repliesStartPosition.Left, ++currentRow);
					replyLabels.Add(this.labelFactory.CreateLabel(line, rowPosition));
				}
				currentRow++;
			}

			this.Labels = this.Labels.Concat(replyLabels).ToArray();
		}

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			var titlePosition =
				new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 10);
			var authorPosition =
				new Position(consoleCenter.Left - this.post.Author.Length, consoleCenter.Top - 9);

			var labels = new List<ILabel>()
			{
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
			this.Buttons = new IButton[2];

			this.Buttons[0] = this.labelFactory.CreateButton("Back",
				new Position(consoleCenter.Left + 15, consoleCenter.Top - 3));
			this.Buttons[1] = this.labelFactory.CreateButton("Add Reply",
				new Position(consoleCenter.Left + 10, consoleCenter.Top - 4), !this.session.IsLoggedIn);
		}

		public void SetId(int id)
		{
			throw new System.NotImplementedException();
		}

		private void LoadPost()
		{
			throw new System.NotImplementedException();
		}

		public override IMenu ExecuteCommand()
		{
			throw new System.NotImplementedException();
		}

		private void ExtendBuffer()
		{
			var totalLines = 13 + this.post.Content.Length;

			foreach (var reply in this.post.Replies)
			{
				totalLines += 2 + reply.Content.Length;
			}

			if (totalLines > 30)
			{
			    this.viewEngine.SetBufferHeight(totalLines);
			}
		}
	}
}
