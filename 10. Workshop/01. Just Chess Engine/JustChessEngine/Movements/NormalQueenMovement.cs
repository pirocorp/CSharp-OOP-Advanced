namespace JustChessEngine.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalQueenMovement : BaseNormalMovement, IMovement
    {
        private const string ILLEGAL_QUEEN_DESTINATION = "Queen destination {0}{1} is invalid";

        public NormalQueenMovement()
            : base()
        {
        }

        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            var from = move.From;
            var to = move.To;

            if (rowDistance != colDistance && rowDistance != 0 && colDistance != 0)
            {
                throw new InvalidOperationException(string.Format(ILLEGAL_QUEEN_DESTINATION, move.To.Col, move.To.Row));
            }

            this.CheckForFigureInTheWay(board, from, to);
        }
    }
}
