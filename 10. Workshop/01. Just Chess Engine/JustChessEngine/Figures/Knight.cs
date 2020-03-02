namespace JustChessEngine.Figures
{
    using System.Collections.Generic;

    using Contracts;
    using Common;
    using Movements.Contracts;

    public class Knight : BaseFigure, IFigure
    {
        public Knight(ChessColor color)
            : base(color)
        {
        }
    }
}