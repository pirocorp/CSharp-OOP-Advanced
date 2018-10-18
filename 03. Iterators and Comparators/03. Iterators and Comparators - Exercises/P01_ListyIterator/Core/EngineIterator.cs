namespace P01_Library.Core
{
    using System;
    using System.Collections.Generic;
    using IO.Interfaces;
    using P01_ListyIterator;

    public class EngineIterator<T>
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ListyIterator<T> iterator;

        public EngineIterator(IReader reader, IWriter writer, ICollection<T> inputCollection)
        {
            this.reader = reader;
            this.writer = writer;
            
            this.iterator = new ListyIterator<T>(inputCollection);
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "END")
            {
                try
                {
                    this.InterpretCommand(input);
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine(ioe.Message);
                }
                catch (NotSupportedException nse)
                {
                    //this.writer.WriteLine(nse.Message);
                }
            }
        }

        private void InterpretCommand(string input)
        {
            var inputTokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var command = inputTokens[0];

            switch (command)
            {
                case "Move":
                    this.writer.WriteLine(this.iterator.Move());
                    break;
                case "Print":
                    this.writer.WriteLine(this.iterator.Print());
                    break;
                case "HasNext":
                    this.writer.WriteLine(this.iterator.HasNext());
                    break;
                case "PrintAll":
                    this.writer.WriteLine(this.iterator.PrintAll());
                    break;
                case "END":
                    return;
                default:
                    throw new NotSupportedException("Command is not supported.");
            }
        }
    }
}