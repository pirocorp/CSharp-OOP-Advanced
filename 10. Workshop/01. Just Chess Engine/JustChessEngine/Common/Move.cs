namespace JustChessEngine.Common
{
    public struct Move
    {
        public static Move FromStringCommand(string command)
        {
            var positionAsStringParts = command
                .Trim()
                .Split(new[] { '-' });

            var from = positionAsStringParts[0];
            var to = positionAsStringParts[1];

            var fromPosition = Position.FromChessCoordinates(from[1] - '0', from[0]);
            var toPosition = Position.FromChessCoordinates(to[1] - '0', to[0]);

            return new Move(fromPosition, toPosition);
        }

        public Position From { get; private set; }

        public Position To { get; private set; }

        public Move(Position from, Position to)
            : this()
        {
            this.From = from;
            this.To = to;
        }
    }
}