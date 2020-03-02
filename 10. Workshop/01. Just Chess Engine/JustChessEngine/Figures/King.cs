namespace JustChessEngine.Figures
{
    using System.Collections.Generic;

    using Common;
    using Contracts;
    using Movements.Contracts;

    public class King : BaseFigure, IFigure
    {
        private bool _isMoved;

        private bool _isInCheck;

        public King(ChessColor color) 
            : base(color)
        {
            this._isMoved = false;
            this._isInCheck = false;
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            this._isMoved = true;
            return base.Move(strategy);
        }

        public override bool IsMoved => this._isMoved;

        public override bool IsInCheck => this._isInCheck;

        public override void SetCheck()
        {
            this._isInCheck = true;
        }

        public override void ClearCheck()
        {
            this._isInCheck = false;
        }
    }
}