namespace JustChessEngine.Renderers.Contracts
{
    using JustChessEngine.Board.Contracts;

    public interface IRenderer
    {
        void RenderMainMenu();

        void RenderBoard(IBoard board);

        void PrintErrorMessage(string message);
    }
}