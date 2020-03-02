namespace JustChessEngine.Movements
{
    using System;

    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures.Contracts;

    public class NormalPawnMovement : BaseNormalMovement, IMovement
    {
        private const string ILLEGAL_PAWN_DIRECTION_MOVE = "Pawns cannot move backwards.";
        private const string ILLEGAL_PAWN_DESTINATION = "Pawn destination {0}{1} is invalid";

        public NormalPawnMovement()
            : base()
        {
        }

        public override void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var color = figure.Color;
            var from = move.From;
            var to = move.To;

            if (color == ChessColor.White &&
                to.Row < from.Row)
            {
                throw new InvalidOperationException(ILLEGAL_PAWN_DIRECTION_MOVE);
            }

            if (color == ChessColor.Black &&
                to.Row > from.Row)
            {
                throw new InvalidOperationException(ILLEGAL_PAWN_DIRECTION_MOVE);
            }

            if (CheckDiagonalMove(figure, board, from, to))
            {
                figure.IncreaseRank();
                return;
            }

            var other = board.GetFigureAtPosition(to);

            if (CheckAnPasseren(figure, other, from, to))
            {
                figure.SetInPassing();
                return;
            }

            if (CheckOneStepMove(figure, from, to, color, other))
            {
                figure.IncreaseRank();
                return;
            };

            if (CheckPassing(figure, board, to))
            {
                figure.IncreaseRank();
                return;
            }

            throw new InvalidOperationException(string.Format(ILLEGAL_PAWN_DESTINATION, to.Col, to.Row));
        }

        private static bool CheckPassing(IFigure figure, IBoard board, Position to)
        {
            var color = figure.Color;
            var direction = -1;

            if (color == ChessColor.Black)
            {
                direction = 1;
            }

            var position = new Position(to.Row + direction, to.Col);
            var passing = board.GetFigureAtPosition(position);

            if (passing != null && passing.Color != color)
            {
                passing.ToBeRemoved = true;
                return true;
            }

            return false;
        }

        private static bool CheckOneStepMove(IFigure figure, Position from, Position to, ChessColor color, IFigure other)
        {
            if (from.Row + 1 == to.Row && 
                from.Col == to.Col &&
                color == ChessColor.White)
            {
                if (other == null)
                {
                    return true;
                }
            }
            else if (from.Row - 1 == to.Row &&
                     from.Col == to.Col &&
                     color == ChessColor.Black)
            {
                return true;
            }

            return false;
        }

        private static bool CheckAnPasseren(IFigure figure, IFigure other, Position from, Position to)
        {
            var color = figure.Color;

            if (other == null)
            {
                if (figure.Rank == 2 && color == ChessColor.White)
                {
                    if (from.Row + 2 == to.Row)
                    {
                        return true;
                    }
                }
                else if (figure.Rank == 2 && color == ChessColor.Black)
                {
                    if (from.Row - 2 == to.Row)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CheckDiagonalMove(IFigure figure, IBoard board, Position from, Position to)
        {
            var direction = 1;
            var otherFigureColor = ChessColor.Black;

            if (figure.Color == ChessColor.Black)
            {
                direction = -1;
                otherFigureColor = ChessColor.White;
            }

            if (from.Row + direction == to.Row &&
                (from.Col + 1 == to.Col || from.Col - 1 == to.Col))
            {
                if (CheckValidOtherFigure(board, to, otherFigureColor))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckValidOtherFigure(IBoard board, Position to, ChessColor otherFigureColor)
        {
            var otherFigure = board.GetFigureAtPosition(to);

            if (otherFigure != null &&
                otherFigure.Color == otherFigureColor)
            {
                return true;
            }

            return false;
        }
    }
}
