namespace CommandPattern
{
    using System;
    using CommandPattern.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var result = this.commandInterpreter.Read(input);
                    Console.WriteLine(result);
                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
        }
    }
}
