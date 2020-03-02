namespace JustChessEngine.Engine.Initializations
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Common;
    using Figures;
    using JustChessEngine.Board.Contracts;
    using JustChessEngine.Players.Contracts;
    using JustChessEngine.Figures.Contracts;

    public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int NUMBER_OF_PLAYERS = 2;
        private const int BOARD_TOTAL_ROWS_AND_COLS = 8;

        private readonly IList<Type> _figureTypes;

        public StandardStartGameInitializationStrategy()
        {
            this._figureTypes = new List<Type>
            {
                typeof(Rook),
                typeof(Knight),
                typeof(Bishop),
                typeof(Queen),
                typeof(King),
                typeof(Bishop),
                typeof(Knight),
                typeof(Rook)
            };
        }

        public int NumberOfPlayers => NUMBER_OF_PLAYERS;

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddArmyToBoardRow(firstPlayer, board, 8);
            this.AddPawnsToBoardRow(firstPlayer, board, 7);

            this.AddPawnsToBoardRow(secondPlayer, board, 2);
            this.AddArmyToBoardRow(secondPlayer, board, 1);
        }

        private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != NUMBER_OF_PLAYERS)
            {
                throw new InvalidOperationException(ErrorMessages.StandardGameInitializationPlayersMismatch);
            }

            if (board.TotalRows != BOARD_TOTAL_ROWS_AND_COLS ||
                board.TotalCols != BOARD_TOTAL_ROWS_AND_COLS)
            {
                throw new InvalidOperationException(ErrorMessages.StandardGameInitializationBoardMismatch);
            }
        }

        private void AddPawnsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (var i = 0; i < BOARD_TOTAL_ROWS_AND_COLS; i++)
            {
                var chessCol = (char)(i + 'a');

                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Position(chessRow, chessCol);
                board.AddFigure(pawn, position);
            }
        }

        private void AddArmyToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (var i = 0; i < BOARD_TOTAL_ROWS_AND_COLS; i++)
            {
                var figureType = this._figureTypes[i];
                var figureInstance = (IFigure)Activator.CreateInstance(figureType, player.Color);
                player.AddFigure(figureInstance);
                var chessCol = (char)(i + 'a');
                var position = new Position(chessRow, chessCol);
                board.AddFigure(figureInstance, position);
            }
        }
    }
}