namespace JustChessEngine.Figures.Contracts
{
    using System.Collections.Generic;

    using Common;
    using JustChessEngine.Movements.Contracts;

    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
            this.ToBeRemoved = false;
        }

        public bool ToBeRemoved { get; set; }

        public virtual int Rank => -1;

        public virtual bool InPassing => false;

        public virtual bool IsMoved => true;

        public ChessColor Color { get; private set; }

        public virtual ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.GetMovements(this.GetType().Name);
        }

        public virtual void IncreaseRank() { }

        public virtual void SetInPassing() { }

        public virtual void ClearInPassing() { }
    }
}