namespace Forum.App.Menus
{
	using Models;
	using Contracts;

	public abstract class Menu : IMenu
	{
		protected int CurrentIndex;

		public Menu()
		{
			this.CurrentIndex = 0;
		}

		public ILabel[] Labels { get; protected set; }

		public IButton[] Buttons { get; protected set; }

		public IButton CurrentOption => this.Buttons[this.CurrentIndex];

		public abstract IMenu ExecuteCommand();

		public virtual void Open()
		{
			var consoleCenter = Position.ConsoleCenter();

			this.InitializeStaticLabels(consoleCenter);

			this.InitializeButtons(consoleCenter);
		}

		protected abstract void InitializeStaticLabels(Position consoleCenter);

		protected abstract void InitializeButtons(Position consoleCenter);

		public void NextOption()
		{
			this.CurrentIndex++;

			var totalOptions = this.Buttons.Length;

			if (this.CurrentIndex >= totalOptions)
			{
				this.CurrentIndex -= totalOptions;
			}

			if (this.CurrentOption.IsHidden)
			{
				this.NextOption();
			}
		}

		public void PreviousOption()
		{
			this.CurrentIndex--;

			if (this.CurrentIndex < 0)
			{
				this.CurrentIndex += this.Buttons.Length;
			}

			if (this.CurrentOption.IsHidden)
			{
				this.PreviousOption();
			}
		}
	}
}
