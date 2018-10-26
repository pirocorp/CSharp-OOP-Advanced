namespace P03_IteratorTest
{
    using System;
    using System.Linq;

    public class Controller
    {
        private ListIterator listIterator;

        public void Run()
        {
            try
            {
                this.CommandInterpreter();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void CommandInterpreter()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {
                    case "Create":
                        this.Create(tokens);
                        break;
                    case "Print":
                        this.Print();
                        break;
                    case "Move":
                        this.Move();
                        break;
                    case "HasNext":
                        this.HasNext();
                        break;
                }
            }
        }

        private void HasNext()
        {
            Console.WriteLine(this.listIterator.HasNext());
        }


        private void Move()
        {
            Console.WriteLine(this.listIterator.Move());
        }

        private void Print()
        {
            Console.WriteLine(this.listIterator.Print());
        }

        private void Create(string[] inputStrings)
        {
            var input = inputStrings.Skip(1).ToArray();
            this.listIterator = new ListIterator(input);
        }
    }
}