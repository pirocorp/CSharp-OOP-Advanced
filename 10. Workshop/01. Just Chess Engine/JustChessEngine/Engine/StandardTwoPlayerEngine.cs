namespace JustChessEngine.Engine
{
    using System;
    using System.Collections.Generic;

    using Common;
    using JustChessEngine.Figures.Contracts;
    using JustChessEngine.Players.Contracts;
    using JustChessEngine.InputProviders.Contracts;
    using JustChessEngine.Renderers.Contracts;
    using JustChessEngine.Board.Contracts;
    using Contracts;
    using Movements.Contracts;
    using Movements.Strategies;

    public class StandardTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> _players;
        private readonly IRenderer _renderer;
        private readonly IInputProvider _inputProvider;
        private readonly IBoard _board;
        private readonly IMovementStrategy _movementStrategies;

        private int _currentPlayerIndex;
        private IList<IFigure> _inPassing;

        public StandardTwoPlayerEngine( 
            IRenderer renderer, IInputProvider inputProvider)
        {
            this._renderer = renderer;
            this._inputProvider = inputProvider;
            this._board = new Board.Board();
            this._movementStrategies = new NormalMovementStrategy();
            this._inPassing = new List<IFigure>();
        }

        public IEnumerable<IPlayer> Players => new List<IPlayer>(this._players);

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            this._players = this._inputProvider.GetPlayers(gameInitializationStrategy.NumberOfPlayers);
            gameInitializationStrategy.Initialize(this._players, this._board);
            this._renderer.RenderBoard(this._board);
            this.SetFirstPlayerIndex();
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this._inputProvider.GetNextPlayerMove(player);
                    this.ProcessPlayerMove(player, move);
                }
                catch (Exception e)
                {
                    this._renderer.PrintErrorMessage(e.Message);
                    this.SetCurrentPlayerIndexToPreviousPlayer();
                }
            }
        }

        public void WinningCondition()
        {
            throw new System.NotImplementedException();
        }

        private void SetFirstPlayerIndex()
        {
            for (var i = 0; i < this._players.Count; i++)
            {
                if (this._players[i].Color == ChessColor.White)
                {
                    this._currentPlayerIndex = i;
                    return;
                }
            }
        }

        private IPlayer GetNextPlayer()
        {
            var player = this._players[this._currentPlayerIndex++];
            this._currentPlayerIndex %= this._players.Count;
            return player;
        }

        private void ProcessPlayerMove(IPlayer player, Move move)
        {
            var from = move.From;
            var to = move.To;
            var figure = this._board.GetFigureAtPosition(from);

            this.CheckIfPlayerOwnsFigure(player, figure, from);
            this.CheckIfNotOurPosition(player, to);

            var movements = figure.Move(this._movementStrategies);

            foreach (var movement in movements)
            {
                movement.ValidateMove(figure, this._board, move);
            }

            this._board.MoveFigureAtPosition(figure, from, to);

            //TODO: On every move check if move is legal
            //TODO: Check castle

            //TODO: Move figure
            //TODO: Check check
            //TODO: If in check - check checkmate
            //TODO: else - check draw

            //TODO: Convert all pawns with rank 8 to Queens or ask user
            this.ClearInPassing();
            this.AddToInPassing(figure);
            this.RemoveAllFigures();
            this._renderer.RenderBoard(this._board);
        }

        private void RemoveAllFigures()
        {
            this._board.RemoveAllToBeRemovedFigures();
        }

        private void ClearInPassing()
        {
            foreach (var figure in this._inPassing)
            {
                figure.ClearInPassing();
            }

            this._inPassing = new List<IFigure>();
        }

        private void AddToInPassing(IFigure figure)
        {
            if (figure.InPassing)
            {
                this._inPassing.Add(figure);
            }
        }

        private void CheckIfNotOurPosition(IPlayer player, Position to)
        {
            var figure = this._board.GetFigureAtPosition(to);

            if (figure != null && figure.Color == player.Color)
            {
                throw new InvalidOperationException($"You already have figure at {to.Col}{to.Row} !");
            }
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position position)
        {
            if (figure == null)
            {
                throw new InvalidOperationException($"Invalid position: {position.Col}{position.Row}");
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException($"Figure at {position.Col}{position.Row} is not yours!");
            }
        }

        private void SetCurrentPlayerIndexToPreviousPlayer()
        {
            this._currentPlayerIndex--;

            if (this._currentPlayerIndex < 0)
            {
                this._currentPlayerIndex = this._players.Count - 1;
            }
        }
    }
}