namespace P06_Twitter.Models
{
    using System;
    using Interfaces;

    public class Tweet : ITweet
    {
        private string message;

        public Tweet(string message)
        {
            this.Message = message;
        }

        public string Message
        {
            get => this.message;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Message)} cannot be empty.");
                }

                this.message = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Message}";
        }
    }
}