namespace JustChessEngine
{
    using Engine;
    using Engine.Contracts;
    using Engine.Initializations;
    using InputProviders;
    using InputProviders.Contracts;
    using Renderers;
    using Renderers.Contracts;

    public static class ChessFacade
    {
        public static void Start()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputProvider inputProvider = new ConsoleInputProvider();

            renderer.RenderMainMenu();

            IChessEngine chessEngine = new StandardTwoPlayerEngine(renderer, inputProvider);
            IGameInitializationStrategy strategy = new StandardStartGameInitializationStrategy();

            chessEngine.Initialize(strategy);
            chessEngine.Start();
        }
    }
}