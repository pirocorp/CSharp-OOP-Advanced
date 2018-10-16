namespace P07_CustomList.Core
{
    using Factories;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine
    {
        private readonly GenericFactory commandFactory;

        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly CustomList<string> list;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.list = new CustomList<string>();
            this.commandFactory = new GenericFactory();
        }

        public void Run()
        {
            string inputTokens;

            while ((inputTokens = this.reader.ReadLine()) != "END")
            {
                var tokens = inputTokens.Split();

                var command = tokens[0];

                var currentCommand = this.commandFactory.Create<ICommand>(command, new object[]{this.writer});
                currentCommand.Execute(tokens, this.list);
            }
        }
    }
}