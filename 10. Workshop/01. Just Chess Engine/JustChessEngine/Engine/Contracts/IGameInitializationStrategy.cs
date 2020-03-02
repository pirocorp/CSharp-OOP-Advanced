namespace JustChessEngine.Engine.Contracts
{
    using System.Collections.Generic;
    using JustChessEngine.Board.Contracts;
    using JustChessEngine.Players.Contracts;

    public interface IGameInitializationStrategy
    {
        int NumberOfPlayers { get; }

        void Initialize(IList<IPlayer> players, IBoard board);
    }
}