namespace JustChessEngine.Players.Contracts
{
    using Common;
    using JustChessEngine.Figures.Contracts;

    public interface IPlayer
    {
        string Name { get; }

        ChessColor Color { get; }

        void AddFigure(IFigure figure);

        void RemoveFigure(IFigure figure);
    }
}