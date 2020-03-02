namespace JustChessEngine.Board
{
    using System;

    using Common;
    using Figures.Contracts;
    using Contracts;

    public class Board : IBoard
    {
        private readonly IFigure[,] _board;

        public Board(
            int rows = GlobalConstants.StandardGameTotalBoardRows, 
            int cols = GlobalConstants.StandardGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this._board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }

        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, ErrorMessages.NullFigureErrorMessage);
            Position.ValidatePositionWithException(position);

            var arrayRow = this.GetArrayRow(position.Row);
            var arrayCol = this.GetArrayCol(position.Col);

            this._board[arrayRow, arrayCol] = figure;
        }

        public IFigure GetFigureAtPosition(Position position)
        {
            var arrayRow = this.GetArrayRow(position.Row);
            var arrayCol = this.GetArrayCol(position.Col);

            return this._board[arrayRow, arrayCol];
        }

        public void RemoveFigure(Position position)
        {
            Position.ValidatePositionWithException(position);

            var arrayRow = this.GetArrayRow(position.Row);
            var arrayCol = this.GetArrayCol(position.Col);

            this._board[arrayRow, arrayCol] = null;
        }

        public void MoveFigureAtPosition(IFigure figure, Position from, Position to)
        {
            this.RemoveFigure(from);
            this.AddFigure(figure, to);
        }

        public void RemoveAllToBeRemovedFigures()
        {
            for (var i = 0; i < this._board.GetLength(0); i++)
            {
                for (var j = 0; j < this._board.GetLength(1); j++)
                {
                    if (this._board[i, j] != null && 
                        this._board[i, j].ToBeRemoved)
                    {
                        this._board[i, j] = null;
                    }
                }
            }
        }

        public void RestoreFigures()
        {
            for (var i = 0; i < this._board.GetLength(0); i++)
            {
                for (var j = 0; j < this._board.GetLength(1); j++)
                {
                    if (this._board[i, j] != null &&
                        this._board[i, j].ToBeRemoved)
                    {
                        this._board[i, j].ToBeRemoved = false;
                    }
                }
            }
        }

        private int GetArrayRow(int chessRow)
        {
            return this.TotalRows - chessRow;
        }

        private int GetArrayCol(int chessCol)
        {
            return chessCol - GlobalConstants.MinColValueOnBoard;
        }
    }
}