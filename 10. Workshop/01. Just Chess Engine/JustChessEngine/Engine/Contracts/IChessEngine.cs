namespace JustChessEngine.Engine.Contracts
{
    using System.Collections.Generic;
    using JustChessEngine.Players.Contracts;

    public interface IChessEngine
    {
        IEnumerable<IPlayer> Players { get; }

        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        void WinningCondition();
    }
}