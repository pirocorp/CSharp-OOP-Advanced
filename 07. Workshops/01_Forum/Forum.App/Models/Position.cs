namespace Forum.App.Models
{
	using System;

	public struct Position
    {
        private int left;
        private int top;

        public Position(int left, int top)
        {
            this.left = left;
            this.top = top;
        }

        public int Top
        {
            get => this.top;
            set => this.top = value;
        }

        public int Left
        {
            get => this.left;
            set => this.left = value;
        }

        public static Position ConsoleCenter()
        {
            var centerTop = Console.WindowHeight / 2;
            var centerLeft = Console.WindowWidth / 2;

            var center = new Position(centerLeft, centerTop);
            return center;
        }
    }
}
