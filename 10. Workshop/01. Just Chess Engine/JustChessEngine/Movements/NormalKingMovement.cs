namespace JustChessEngine.Movements
{
    using System;
    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalKingMovement : BaseNormalMovement, IMovement
    {
        private const string ILLEGAL_KING_DESTINATION = "King destination {0}{1} is invalid";

        public NormalKingMovement()
            : base()
        {
        }

        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var attackerColor = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;

            var from = move.From;
            var to = move.To;
            
            //if (this.CheckCastle(figure, board, move, attackerColor))
            //{
            //    return;
            //}

            //if (board.PositionIsAttacked(to, attackerColor))
            //{
            //    return;
            //}

            var dx = Math.Abs(from.Col - to.Col);
            var dy = Math.Abs(from.Row - to.Row);

            if (dx <= 1 && dy <= 1)
            {
                return;
            }

            throw new InvalidOperationException(string.Format(ILLEGAL_KING_DESTINATION, move.To.Col, move.To.Row));
        }

        private bool CheckCastle(IFigure figure, IBoard board, Move move, ChessColor attackerColor)
        {
            if (figure.IsInCheck || figure.IsMoved)
            {
                return false;
            }

            var from = move.From;
            var to = move.To;

            var dx = from.Col - to.Col;

            if (dx == -2)
            {
                //Queen Castle 
                var rookPosition = new Position(1, 'a');
                var leftRook = board.GetFigureAtPosition(rookPosition);

                if (leftRook == null || leftRook.IsMoved)
                {
                    return false;
                }

                var c1Pos = new Position(1, 'c');
                var d1Pos = new Position(1, 'd');

                var c1Fig = board.GetFigureAtPosition(c1Pos);
                var d1Fig = board.GetFigureAtPosition(d1Pos);

                if (c1Fig != null || d1Fig != null)
                {
                    return false;
                }

                //Check CHECK.
                if (board.PositionIsAttacked(c1Pos, attackerColor) || 
                    board.PositionIsAttacked(d1Pos, attackerColor))
                {
                    return false;
                }

                board.MoveFigureAtPosition(leftRook, rookPosition, d1Pos);
                return true;
            }
            else if (dx == 2)
            {
                //Right Castle
                var rookPosition = new Position(1, 'h');
                var rightRook = board.GetFigureAtPosition(rookPosition);

                if (rightRook == null || rightRook.IsMoved)
                {
                    return false;
                }

                var f1Pos = new Position(1, 'f');
                var g1Pos = new Position(1, 'g');

                var f1 = board.GetFigureAtPosition(f1Pos);
                var g1 = board.GetFigureAtPosition(g1Pos);

                if (f1 != null || g1 != null)
                {
                    return false;
                }

                //Check CHECK.
                if (board.PositionIsAttacked(f1Pos, attackerColor) ||
                    board.PositionIsAttacked(g1Pos, attackerColor))
                {
                    return false;
                }

                board.MoveFigureAtPosition(rightRook, rookPosition, f1Pos);
                return true;
            }

            return false;
        }
    }
}