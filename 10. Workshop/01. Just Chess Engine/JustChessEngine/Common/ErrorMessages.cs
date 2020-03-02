namespace JustChessEngine.Common
{
    public class ErrorMessages
    {
        public const string NullFigureErrorMessage = "Figure cannot be null!";

        public const string InvalidRowPosition = "Selected row position is not valid!";

        public const string InvalidColPosition = "Selected column position is not valid!";

        public const string FigureAlreadyOwned = "This player already owns this figure!";

        public const string FigureNotOwned = "This player do not owns this figure!";

        public const string StandardGameInitializationPlayersMismatch = "Standard start game initialization strategy needs two players";

        public const string StandardGameInitializationBoardMismatch = "Standard start game initialization strategy needs 8x8 board";

    }
}