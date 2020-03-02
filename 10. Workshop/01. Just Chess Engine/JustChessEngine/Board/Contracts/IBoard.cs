namespace JustChessEngine.Board.Contracts
{
    using Common;
    using JustChessEngine.Figures.Contracts;

    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get; }

        void AddFigure(IFigure figure, Position position);

        IFigure GetFigureAtPosition(Position position);

        void RemoveFigure(Position position);

        void MoveFigureAtPosition(IFigure figure, Position from, Position to);

        void RemoveAllToBeRemovedFigures();

        void RestoreFigures();
    }
}