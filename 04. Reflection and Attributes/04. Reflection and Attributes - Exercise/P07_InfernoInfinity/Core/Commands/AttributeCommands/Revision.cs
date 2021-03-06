﻿namespace P07_InfernoInfinity.Core.Commands.AttributeCommands
{
    public class Revision : AttributeCommand
    {
        public Revision(string[] data) 
            : base(data)
        {
        }

        public override void Execute()
        {
            this.writer.WriteLine($"Revision: {this.attribute.Revision}");
        }
    }
}