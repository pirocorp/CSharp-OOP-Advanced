namespace JustChessEngine.Figures
{
    using System.Collections.Generic;

    using Common;
    using Contracts;
    using Movements.Contracts;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color) : base(color)
        {
        }

    }
}