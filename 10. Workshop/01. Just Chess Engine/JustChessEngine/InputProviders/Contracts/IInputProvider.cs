namespace JustChessEngine.InputProviders.Contracts
{
    using System.Collections.Generic;

    using JustChessEngine.Players.Contracts;
    using JustChessEngine.Common;

    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);

        Move GetNextPlayerMove(IPlayer player);
    }
}