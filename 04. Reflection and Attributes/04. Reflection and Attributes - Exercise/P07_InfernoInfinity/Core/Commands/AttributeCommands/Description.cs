namespace P07_InfernoInfinity.Core.Commands.AttributeCommands
{
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