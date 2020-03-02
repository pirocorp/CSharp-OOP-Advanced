namespace JustChessEngine.Figures
{
    using System.Collections.Generic;
    using Common;
    using Contracts;
    using Movements.Contracts;

    public class Rook : BaseFigure, IFigure
    {
        private bool _isMoved;

        public Rook(ChessColor color) 
            : base(color)
        {
            this._isMoved = false;
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            this._isMoved = true;
            return base.Move(strategy);
        }

        public override bool IsMoved => this._isMoved;
    }
}
