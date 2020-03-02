namespace JustChessEngine.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures;
    using Figures.Contracts;

    public class NormalBishopMovement : BaseNormalMovement, IMovement
    {
        private const string ILLEGAL_BISHOP_DESTINATION = "Bishop destination {0}{1} is invalid";

        public NormalBishopMovement()
            : base()
        {
        }

        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            var from = move.From;
            var to = move.To;
            
            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(string.Format(ILLEGAL_BISHOP_DESTINATION, move.To.Col, move.To.Row));
            }

            this.CheckForFigureInTheWay(board, from, to);
        }
    }
}
