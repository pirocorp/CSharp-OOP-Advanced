namespace JustChessEngine.Renderers
{
    using System;
    using System.Threading;
    using System.Collections.Generic;

    using Contracts;
    using Common;
    using Common.Console;
    using JustChessEngine.Board.Contracts;
    using JustChessEngine.Figures.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const int CONSOLE_WIDTH = 100;
        private const int CONSOLE_HEIGHT = 100;
        private const int CONSOLE_ROW_FOR_COMMAND_AND_MESSAGES = 5;
        private const string LOGO = "JUST CHESS";
        private const int CHARACTERS_PER_ROW_PER_BOARD_SQUARE = 9;
        private const int CHARACTERS_PER_COL_PER_BOARD_SQUARE = 9;
        private const ConsoleColor DARK_SQUARE_CONSOLE_COLOR = ConsoleColor.DarkGray;
        private const ConsoleColor LIGHT_SQUARE_CONSOLE_COLOR = ConsoleColor.DarkYellow;

        private static readonly IDictionary<Type, bool[,]> Patterns = ConsoleFigurePatterns.GetFiguresPatterns();

        public void RenderMainMenu()
        {
            if (Console.WindowWidth < CONSOLE_WIDTH || Console.WindowHeight < CONSOLE_HEIGHT ||
                Console.BufferWidth < CONSOLE_WIDTH || Console.BufferHeight < CONSOLE_HEIGHT)
            {
                Console.SetWindowSize(CONSOLE_WIDTH, CONSOLE_HEIGHT);
                Console.SetBufferSize(CONSOLE_WIDTH, CONSOLE_HEIGHT);
            }

            ConsoleHelpers.SetCursorAtCenter(LOGO.Length);
            Console.WriteLine(LOGO);

            //TODO: add main menu
            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            //TODO: validate console dimensions
            Console.Clear();

            var startRowPrint = Console.WindowHeight / 2 - board.TotalRows / 2 * CHARACTERS_PER_ROW_PER_BOARD_SQUARE;
            var startColPrint = Console.WindowWidth / 2 - board.TotalCols / 2 * CHARACTERS_PER_COL_PER_BOARD_SQUARE;

            PrintBorder(board, startRowPrint, startColPrint);

            //Console.BackgroundColor = ConsoleColor.White;
            var counter = 0;

            for (var top = 0; top < board.TotalRows; top++)
            {
                for (var left = 0; left < board.TotalCols; left++)
                {
                    var currentColPrint = startRowPrint + left * CHARACTERS_PER_COL_PER_BOARD_SQUARE;
                    var currentRowPrint = startColPrint + top * CHARACTERS_PER_ROW_PER_BOARD_SQUARE;
                    Console.SetCursorPosition(currentColPrint, currentRowPrint);

                    ConsoleColor backGroundColor;

                    if (counter % 2 != 0)
                    {
                        backGroundColor = DARK_SQUARE_CONSOLE_COLOR;
                    }
                    else
                    {
                        backGroundColor = LIGHT_SQUARE_CONSOLE_COLOR;
                    }

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);
                    var figure = board.GetFigureAtPosition(position);
                    PrintFigure(figure, currentColPrint, currentRowPrint, backGroundColor);

                    counter++;
                }
                counter++;
            }

            Console.ResetColor();
            Console.SetCursorPosition(Console.WindowWidth / 2, 5);
        }

        private static void PrintBorder(IBoard board, int startRowPrint, int startColPrint)
        {
            var leftStart = startColPrint + CHARACTERS_PER_ROW_PER_BOARD_SQUARE / 2;
            var topStart = startRowPrint + CHARACTERS_PER_COL_PER_BOARD_SQUARE / 2;

            var startCharacter = 'A';
            var startNumber = 8;

            for (var i = 0; i < board.TotalCols; i++)
            {
                Console.SetCursorPosition(leftStart, startRowPrint - 1);
                Console.Write(startCharacter);

                Console.SetCursorPosition(leftStart, startRowPrint + board.TotalRows * CHARACTERS_PER_ROW_PER_BOARD_SQUARE);
                Console.Write(startCharacter);

                Console.SetCursorPosition(startColPrint - 1, topStart);
                Console.Write(startNumber);

                Console.SetCursorPosition(startColPrint + board.TotalCols * CHARACTERS_PER_COL_PER_BOARD_SQUARE, topStart);
                Console.Write(startNumber);

                leftStart += CHARACTERS_PER_ROW_PER_BOARD_SQUARE;
                topStart += CHARACTERS_PER_COL_PER_BOARD_SQUARE;

                startCharacter = (char) (startCharacter + 1);
                startNumber--;
            }

            for (var i = startRowPrint - 2; i < startRowPrint + board.TotalRows * CHARACTERS_PER_ROW_PER_BOARD_SQUARE + 2; i++)
            {
                Console.BackgroundColor = DARK_SQUARE_CONSOLE_COLOR;

                Console.SetCursorPosition(i, startRowPrint - 2);
                Console.Write(" ");

                Console.SetCursorPosition(startColPrint - 2, i);
                Console.Write(" ");

                Console.SetCursorPosition(startColPrint + board.TotalCols * CHARACTERS_PER_COL_PER_BOARD_SQUARE + 1, i);
                Console.Write(" ");

                Console.SetCursorPosition(i, startRowPrint + board.TotalRows * CHARACTERS_PER_ROW_PER_BOARD_SQUARE + 1);
                Console.Write(" ");
            }
        }

        public void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleHelpers.SetCursorAtCenterInARow(message.Length, CONSOLE_ROW_FOR_COMMAND_AND_MESSAGES);
            Console.Write(message);
            Console.ResetColor();

            Thread.Sleep(2000);
        }

        private static void PrintFigure(IFigure figure, int left, int top, ConsoleColor backGroundColor)
        {
            Console.BackgroundColor = backGroundColor;

            if (figure == null)
            {
                PrintEmptySquare(left, top);
                return;
            }

            PrintFigure(left, top, backGroundColor, figure);
        }

        private static void PrintEmptySquare(int left, int top)
        {
            for (var i = 0; i < CHARACTERS_PER_ROW_PER_BOARD_SQUARE; i++)
            {
                for (var j = 0; j < CHARACTERS_PER_COL_PER_BOARD_SQUARE; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }
            }
        }

        private static void PrintFigure(int left, int top, ConsoleColor backgroundColor, IFigure figure )
        {
            var figureColor = figure.Color.ToConsoleColor();

            var figurePattern = Patterns[figure.GetType()];

            for (var i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (var j = 0; j < figurePattern.GetLength(1); j++)
                {
                    if (figurePattern[i, j])
                    {
                        Console.BackgroundColor = figureColor;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundColor;
                    }

                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}