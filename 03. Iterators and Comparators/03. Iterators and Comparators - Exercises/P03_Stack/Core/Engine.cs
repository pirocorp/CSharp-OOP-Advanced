namespace P03_Stack.Core
{
    using System;
    using System.Linq;
    using IO.Interfaces;

    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly CustomStack<int> stack;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.stack = new CustomStack<int>();
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
                    this.writer.WriteLine(nse.Message);
                }
            }

            this.ProcessEnd();
        }

        private void InterpretCommand(string input)
        {
            var inputTokens = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var commandTokens = inputTokens[0].Split();
            var command = commandTokens[0];

            switch (command)
            {
                case "Push":
                    this.ProcessPush(inputTokens);
                    break;
                case "Pop":
                    this.stack.Pop();
                    break;
                default:
                    throw new NotSupportedException("Command is not supported.");
            }
        }

        private void ProcessEnd()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in this.stack)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private void ProcessPush(string[] inputTokens)
        {
            if (inputTokens.Length == 1)
            {
                var tokens = inputTokens[0].Split(" ");
                var element = int.Parse(tokens[1]);
                this.stack.Push(element);
                return;
            }

            var firstElementTokens = inputTokens[0].Split(" ");
            var firstElement = int.Parse(firstElementTokens[1]);
            var restElements = inputTokens.Skip(1).Select(int.Parse).ToArray();
            this.stack.Push(firstElement);
            this.stack.Push(restElements);
        }
    }
}