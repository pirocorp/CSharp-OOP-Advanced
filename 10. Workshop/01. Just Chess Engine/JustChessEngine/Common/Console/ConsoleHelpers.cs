namespace JustChessEngine.Common.Console
{
    using System;

    public static class ConsoleHelpers
    {
        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            var centerRow = Console.WindowHeight / 2;
            var centerCol = Console.WindowWidth / 2 - lengthOfMessage / 2;
            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void SetCursorAtCenterInARow(int lengthOfMessage, int centerRow = 5)
        {
            var centerCol = Console.WindowWidth / 2 - lengthOfMessage / 2;

            Console.SetCursorPosition(0, centerRow);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Brown:
                    return ConsoleColor.DarkBlue;
                case ChessColor.Blue:
                    return ConsoleColor.Blue;
                case ChessColor.Red:
                    return ConsoleColor.Red;
                case ChessColor.Purple:
                    return ConsoleColor.Magenta;
                default:
                    throw new InvalidOperationException("Invalid Chess Color");
            }
        }
    }
}