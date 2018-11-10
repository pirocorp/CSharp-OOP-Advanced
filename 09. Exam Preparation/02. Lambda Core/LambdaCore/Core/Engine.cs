namespace LambdaCore.Core
{
    using System;
    using Interfaces;
    using Interfaces.Controllers;
    using Interfaces.IO;

    public class Engine : IEngine
    {
        private readonly ILambdaCoreController lambdaCoreController;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILambdaCoreController lambdaCoreController, IReader reader, IWriter writer)
        {
            this.lambdaCoreController = lambdaCoreController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = this.reader.ReadLine()) != "System Shutdown!")
            {
                var inputTokens = inputLine.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);
                var command = inputTokens[0];
                string[] args = null;

                if (inputTokens.Length == 2)
                {
                    args = inputTokens[1].Split(new[] {"@"}, StringSplitOptions.RemoveEmptyEntries);
                }

                switch (command)
                {
                    case "CreateCore":
                        this.writer.WriteLine(this.lambdaCoreController.CreateCore(args));
                        break;
                    case "RemoveCore":
                        this.writer.WriteLine(this.lambdaCoreController.RemoveCore(args));
                        break;
                    case "SelectCore":
                        this.writer.WriteLine(this.lambdaCoreController.SelectCore(args));
                        break;
                    case "AttachFragment":
                        this.writer.WriteLine(this.lambdaCoreController.AttachFragment(args));
                        break;
                    case "DetachFragment":
                        this.writer.WriteLine(this.lambdaCoreController.DetachFragment(args));
                        break;
                    case "Status":
                        this.writer.WriteLine(this.lambdaCoreController.Status(args));
                        break;
                }
            }
        }
    }
}