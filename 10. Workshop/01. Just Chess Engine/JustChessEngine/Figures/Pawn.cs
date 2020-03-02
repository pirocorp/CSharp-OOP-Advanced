namespace JustChessEngine.Figures
{
    using Common;
    using Contracts;

    public class Pawn : BaseFigure, IFigure
    {
        private byte _rank;
        private bool _inPassing;

        public Pawn(ChessColor color)
            : base(color)
        {
            this._rank = 2;
            this._inPassing = false;
        }

        public override int Rank => this._rank;

        public override bool InPassing => this._inPassing;

        public override void IncreaseRank()
        {
            this._rank++;
        }

        public override void SetInPassing()
        {
            this._rank += 2;
            this._inPassing = true;
        }

        public override void ClearInPassing()
        {
            this._inPassing = false;
        }
    }
}