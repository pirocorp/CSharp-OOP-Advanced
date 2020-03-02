namespace JustChessEngine.Figures.Contracts
{
    using System.Collections.Generic;

    using Common;
    using JustChessEngine.Movements.Contracts;
    

    public interface IFigure
    {
        ChessColor Color { get; }

        int Rank { get; }

        bool InPassing { get; }

        bool ToBeRemoved { get; set; }

        bool IsMoved { get; }

        ICollection<IMovement> Move(IMovementStrategy strategy);

        void IncreaseRank();

        void SetInPassing();

        void ClearInPassing();
    }
}