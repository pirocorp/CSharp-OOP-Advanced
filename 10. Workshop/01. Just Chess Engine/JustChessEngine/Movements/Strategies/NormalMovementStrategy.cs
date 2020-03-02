namespace JustChessEngine.Movements.Strategies
{
    using System.Collections.Generic;

    using Contracts;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private IDictionary<string, IList<IMovement>> _strategies;

        public NormalMovementStrategy()
        {
            this._strategies = new Dictionary<string, IList<IMovement>>();
            this.Initialize();
        }

        public IList<IMovement> GetMovements(string figure)
        {
            return this._strategies[figure];
        }

        private void Initialize()
        {
            var pawnStrategies = new List<IMovement>()
            {
                new NormalPawnMovement(),
            };

            this._strategies.Add("Pawn", pawnStrategies);

            var bishopStrategies = new List<IMovement>()
            {
                new NormalBishopMovement(),
            };

            this._strategies.Add("Bishop", bishopStrategies);

            var rookStrategies = new List<IMovement>()
            {
                new NormalRookMovement(),
            };

            this._strategies.Add("Rook", rookStrategies);

            var queenStrategies = new List<IMovement>()
            {
                new NormalQueenMovement(),
            };

            this._strategies.Add("Queen", queenStrategies);

            var knightStrategies = new List<IMovement>()
            {
                new NormalKnightMovement(),
            };

            this._strategies.Add("Knight", knightStrategies);

            var kingStrategies = new List<IMovement>()
            {
                new NormalKingMovement(),
            };

            this._strategies.Add("King", kingStrategies);
        }
    }
}