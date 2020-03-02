namespace JustChessEngine.Movements.Contracts
{
    using System;
    using Board.Contracts;
    using Common;
    using Figures.Contracts;

    public abstract class BaseNormalMovement : IMovement
    {
        private const string FIGURE_IN_THE_QUEEN_WAY = "Figure at {0}{1} is in the way";

        protected BaseNormalMovement()
        {
        }

        public abstract void ValidateMove(IFigure figure, IBoard board, Move move);

        protected void CheckForFigureInTheWay(IBoard board, Position from, Position to)
        {
            var directionX = this.GetDirectionOfMovement(from.Col, to.Col);
            var directionY = this.GetDirectionOfMovement(from.Row, to.Row);

            var rowIndex = from.Row;
            var colIndex = from.Col;

            rowIndex += directionY;
            colIndex = (char)(colIndex + directionX);

            while (rowIndex != to.Row || colIndex != to.Col)
            {
                var currentPosition = new Position(rowIndex, colIndex);
                var currentTarget = board.GetFigureAtPosition(currentPosition);

                if (currentTarget != null)
                {
                    throw new InvalidOperationException(string.Format(FIGURE_IN_THE_QUEEN_WAY, colIndex, rowIndex));
                }

                rowIndex += directionY;
                colIndex = (char)(colIndex + directionX);
            }
        }

        private int GetDirectionOfMovement(int from, int to)
        {
            if (from == to)
            {
                return 0;
            }

            var directionX = 1;

            if (from > to)
            {
                directionX = -1;
            }

            return directionX;
        }
    }
}
