namespace P02_KingsGambit.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using IO;

    public class CommandInterpreter
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IKing king;
        private IDictionary<string, IUnit> military;

        public CommandInterpreter(IKing king, IDictionary<string, IUnit> military)
            :this(new ConsoleReader(), new ConsoleWriter(), king, military)
        {

        }

        public CommandInterpreter(IReader reader, IWriter writer, IKing king, IDictionary<string, IUnit> military)
        {
            this.reader = reader;
            this.writer = writer;
            this.king = king;
            this.military = military;
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = this.reader.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                switch (command)
                {
                    case "Attack":
                        this.king.OnKingUnderAttack();
                        break;
                    case "Kill":
                        var name = tokens[1];
                        this.military[name].Kill();
                        break;
                    default:
                        this.writer.WriteLine($"{command} is not supported!");
                        break;
                }

                this.military = this.military
                    .Where(x => x.Value.IsAlive)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}