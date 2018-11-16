namespace FestivalManager
{
    using Core;
    using Core.Controllers;
	using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
			IStage stage = new Stage();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISongFactory songFactory = new SongFactory();
			IFestivalController festivalController = new FestivalController(stage, instrumentFactory, performerFactory, songFactory);
			ISetController setController = new SetController(stage);

            var engine = new Engine(reader, writer, stage, festivalController, setController);
			engine.Run();
		}
	}
}