namespace Forum.App.Models
{
	using System;

	using Contracts;

	public class ForumConsoleReader : IForumReader
	{
		private bool CursorVisible { get => Console.CursorVisible; set => Console.CursorVisible = value; }

		public string ReadLine()
		{
			var cursorLeft = Console.CursorLeft;
			var cursorTop = Console.CursorTop;

			return this.ReadLine(cursorLeft, cursorTop);
		}

		public string ReadLine(int cursorLeft, int cursorTop)
		{
		    this.ClearRow(cursorLeft, cursorTop);

		    this.ShowCursor();
			var result = Console.ReadLine();
		    this.HideCursor();
			return result;
		}

		public void HideCursor()
		{
		    this.CursorVisible = false;
		}

		public void ShowCursor()
		{
		    this.CursorVisible = true;
		}

		private void ClearRow(int left, int top)
		{
			Console.SetCursorPosition(left, top);
			Console.Write(new string(' ', 60 - left));

			Console.SetCursorPosition(left, top);
		}
	}
}
