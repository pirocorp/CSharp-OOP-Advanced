namespace JustChessEngine.Common
{
    using System;

    public struct Position
    {
        public static Position FromArrayCoordinates(int arrRow, int arrCol, int total)
        {
            return new Position(total - arrRow, (char)(arrCol + 'a'));
        }

        public static Position FromChessCoordinates(int chessRow, char chessCol)
        {
            var  newPosition = new Position(chessRow, chessCol);
            ValidatePositionWithException(newPosition);
            return newPosition;
        }

        public static void ValidatePositionWithException(Position position)
        {
            if (position.Row < GlobalConstants.MinRowValueOnBoard ||
                position.Row > GlobalConstants.MaxRowValueOnBoard)
            {
                throw new IndexOutOfRangeException(ErrorMessages.InvalidRowPosition);
            }

            if (position.Col < GlobalConstants.MinColValueOnBoard ||
                position.Col > GlobalConstants.MaxColValueOnBoard)
            {
                throw new IndexOutOfRangeException(ErrorMessages.InvalidColPosition);
            }
        }

        public Position(int row, char col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public char Col { get; private set; }
    }
}
