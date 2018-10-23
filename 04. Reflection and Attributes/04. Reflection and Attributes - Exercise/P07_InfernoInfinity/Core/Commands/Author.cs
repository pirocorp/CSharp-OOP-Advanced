﻿namespace P07_InfernoInfinity.Core.Commands
{
    public class Author : AttributeCommand
    {
        public Author(string[] data) 
            : base(data)
        {
        }

        public override void Execute()
        {
            this.writer.WriteLine($"Author: {this.attribute.Author}");
        }
    }
}