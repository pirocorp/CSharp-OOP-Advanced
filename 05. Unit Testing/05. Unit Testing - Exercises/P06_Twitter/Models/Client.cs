namespace P06_Twitter.Models
{
    using System;
    using Interfaces;

    public class Client
    {
        private readonly IWriter consoleWriter;
        private readonly IWriter netWriter;

        public Client(IWriter consoleWriter, IWriter netWriter)
        {
            if (consoleWriter == null || netWriter == null)
            {
                throw new ArgumentNullException();
            }

            this.consoleWriter = consoleWriter;
            this.netWriter = netWriter;
        }

        public void Receive(ITweet tweet)
        {
            this.consoleWriter.WriteLine(tweet);
            this.netWriter.WriteLine(tweet);
        }
    }
}