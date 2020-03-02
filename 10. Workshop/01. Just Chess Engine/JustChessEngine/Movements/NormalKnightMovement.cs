namespace JustChessEngine.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalKnightMovement : BaseNormalMovement, IMovement
    {
        private const string ILLEGAL_KNIGHT_DESTINATION = "Knight destination {0}{1} is invalid";

        public NormalKnightMovement()
            :base()
        {
        }

        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var from = move.From;
            var to = move.To;

            var dx = Math.Abs(from.Col - to.Col);
            var dy = Math.Abs(from.Row - to.Row);

            var validMoves = (dx == 1 && dy == 2) || (dx == 2 && dy == 1);

            if (!validMoves)
            {
                throw new InvalidOperationException(string.Format(ILLEGAL_KNIGHT_DESTINATION, move.To.Col, move.To.Row));
            }
        }
    }
}
