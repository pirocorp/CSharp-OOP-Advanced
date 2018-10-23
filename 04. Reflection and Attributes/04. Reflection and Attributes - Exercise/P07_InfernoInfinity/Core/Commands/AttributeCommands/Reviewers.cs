namespace P07_InfernoInfinity.Core.Commands.AttributeCommands
{
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