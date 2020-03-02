namespace JustChessEngine.InputProviders
{
    using System;
    using System.Threading;
    using System.Collections.Generic;

    using Players;
    using Common;
    using Contracts;
    using Common.Console;
    using JustChessEngine.Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PLAYER_NAME_TEXT = "Enter {0} Player name: ";
        private const string NEXT_PLAYER_TEXT = "{0} is next: ";
        private const string INVALID_COMMAND = "Move command {0} is invalid.";

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();

            for (var i = 0; i < numberOfPlayers; i++)
            {
                var message = string.Format(PLAYER_NAME_TEXT, (ChessColor)i);

                MessageAtCenterOfTheScreen(message);
                var name = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(name))
                {
                    MessageAtCenterOfTheScreen(message);
                    name = Console.ReadLine();
                }

                var player =  new Player(name, (ChessColor)i);
                players.Add(player);
            }

            return players;
        }

        /// <summary>
        /// Command is in format a5-c5
        /// </summary>
        public Move GetNextPlayerMove(IPlayer player)
        {
            MessageOnTopCenter(string.Format(NEXT_PLAYER_TEXT, player.Name));

            var command = Console.ReadLine();

            while (!this.ValidateCommand(command))
            {
                MessageOnTopCenter(string.Format(INVALID_COMMAND, command));
                Thread.Sleep(1000);
                MessageOnTopCenter(string.Format(NEXT_PLAYER_TEXT, player.Name));

                command = Console.ReadLine();
            }

            return Move.FromStringCommand(command.Trim().ToLower());
        }

        private bool ValidateCommand(string command)
        {
            command = command.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(command) ||
                command.Trim().Split(new[] {'-'}).Length != 2 ||
                command.Length != 5 ||
                command[1] - '0' < 1 ||
                command[1] - '0' > 8 ||
                command[4] - '0' < 1 ||
                command[4] - '0' > 8 ||
                command[0] - 'a' < 0 ||
                command[0] - 'a' > 7 ||
                command[3] - 'a' < 0 ||
                command[3] - 'a' > 7)
            {
                return false;
            }

            return true;
        }

        private static void MessageOnTopCenter(string message)
        {
            ConsoleHelpers.SetCursorAtCenterInARow(message.Length);
            Console.Write(message);
        }

        private static void MessageAtCenterOfTheScreen(string message, bool clear = true)
        {
            if (clear)
            {
                Console.Clear();
            }

            ConsoleHelpers.SetCursorAtCenter(message.Length);
            Console.Write(message);
        }
    }
}