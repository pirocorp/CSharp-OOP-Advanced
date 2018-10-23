namespace P07_InfernoInfinity.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Reviewers : AttributeCommand
    {
        public Reviewers(string[] data) 
            : base(data)
        {
        }

        public override void Execute()
        {
            this.writer.WriteLine($"Reviewers: {string.Join(", ", this.attribute.Reviewers)}");
        }
    }
}