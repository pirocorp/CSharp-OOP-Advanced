namespace JustChessEngine.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalKingMovement : BaseNormalMovement, IMovement
    {
        private const string ILLEGAL_KING_DESTINATION = "King destination {0}{1} is invalid";

        public NormalKingMovement()
            : base()
        {
        }

        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var from = move.From;
            var to = move.To;

            var dx = Math.Abs(from.Col - to.Col);
            var dy = Math.Abs(from.Row - to.Row);

            if (dx <= 1 && dy <= 1)
            {
                return;
            }

            this.CheckCastle();

            throw new InvalidOperationException(string.Format(ILLEGAL_KING_DESTINATION, move.To.Col, move.To.Row));
        }

        private void CheckCastle()
        {
            //throw new NotImplementedException();
        }
    }
}
