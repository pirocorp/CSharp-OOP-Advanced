namespace JustChessEngine.Players
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Figures.Contracts;
    using Contracts;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> _figures;
        
        public Player(string name, ChessColor color)
        {
            this._figures = new List<IFigure>();
            this.Color = color;
            this.Name = name;
        }

        public string Name { get; private set; }

        public ChessColor Color { get; private set;  }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, ErrorMessages.NullFigureErrorMessage);
            //TODO: Check figure and player color
            this.CheckIfFigureExists(figure);
            
            this._figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, ErrorMessages.NullFigureErrorMessage);
            //TODO: Check figure and player color
            this.CheckIfFigureDoesNotExists(figure);
            
            this._figures.Remove(figure);
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this._figures.Contains(figure))
            {
                throw new InvalidOperationException(ErrorMessages.FigureAlreadyOwned);
            }
        }

        private void CheckIfFigureDoesNotExists(IFigure figure)
        {
            if (!this._figures.Contains(figure))
            {
                throw new InvalidOperationException(ErrorMessages.FigureNotOwned);
            }
        }
    }
}