namespace JustChessEngine.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalRookMovement : BaseNormalMovement, IMovement
    {
        private const string ILLEGAL_ROOK_DESTINATION = "Rook destination {0}{1} is invalid";
        private const string FIGURE_IN_THE_ROOK_WAY = "Figure at {0}{1} is in the way";

        public NormalRookMovement()
            : base()
        {
        }

        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            var from = move.From;
            var to = move.To;

            if (rowDistance != 0 && colDistance != 0)
            {
                throw new InvalidOperationException(string.Format(ILLEGAL_ROOK_DESTINATION, move.To.Col, move.To.Row));
            }

            this.CheckForFigureInTheWay(board, from, to, FIGURE_IN_THE_ROOK_WAY);
        }
    }
}