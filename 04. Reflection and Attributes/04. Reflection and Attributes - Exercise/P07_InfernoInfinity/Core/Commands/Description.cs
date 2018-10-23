namespace P07_InfernoInfinity.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Description : AttributeCommand
    {
        public Description(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            this.writer.WriteLine($"Class description: {this.attribute.Description}");
        }
    }
}