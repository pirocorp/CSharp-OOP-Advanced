namespace JustChessEngine.Figures
{
    using System.Collections.Generic;
    using Common;
    using Contracts;
    using Movements.Contracts;

    public class King : BaseFigure, IFigure
    {
        private bool _notMoved;

        public King(ChessColor color) 
            : base(color)
        {
            this._notMoved = true;
        }
    }
}