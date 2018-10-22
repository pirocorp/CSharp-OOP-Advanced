namespace P03_BarraksWars.Core
{
    using System;
    using Contracts;

    public class Engine : IRunnable
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
                    var data = input.Split();
                    var commandName = data[0];
                    var result = this.commandInterpreter.InterpretCommand(data, commandName);
                    Console.WriteLine(result.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
