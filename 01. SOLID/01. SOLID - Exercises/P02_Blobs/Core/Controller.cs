namespace _02.Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using Entities;
    using Factories;

    public class Controller
    {
        private BlobFactory blobFactory;
        private Dictionary<string, Blob> blobs;

        public Controller()
        {
            this.blobFactory = new BlobFactory();
            this.blobs = new Dictionary<string, Blob>();
        }

        public void Run()
        {
            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == null)
                {
                    throw new InvalidOperationException("Command is not in correct format or missing.");
                }

                var inputTokens = inputLine.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries);

                var command = inputTokens[0];

                switch (command)
                {
                    case "create":
                        this.Create(inputTokens);
                        break;
                    case "attack":
                        this.Attack(inputTokens);
                        break;
                    case "pass":
                        continue;
                    case "status":
                        this.Status(inputTokens);
                        break;
                    case "drop":
                        return;
                    default:
                        throw new InvalidOperationException("Not supported command.");
                }

                this.EndTurn();
            }
        }

        private void Status(string[] inputTokens)
        {
            foreach (var blob in this.blobs)
            {
                Console.WriteLine(blob.Value);
            }
        }

        private void Attack(string[] inputTokens)
        {
            var attackerString = inputTokens[1];
            var targetString = inputTokens[2];

            var attacker = this.blobs[attackerString];
            var target = this.blobs[targetString];

            attacker.Attack(target);
        }

        private void EndTurn()
        {
            foreach (var blob in this.blobs)
            {
                blob.Value.Update();
            }
        }

        private void Create(string[] inputTokens)
        {
            var currentBlob = this.blobFactory.Create(inputTokens);
            var currentBlobName = currentBlob.Name;
            this.blobs.Add(currentBlobName, currentBlob);
        }
    }
}