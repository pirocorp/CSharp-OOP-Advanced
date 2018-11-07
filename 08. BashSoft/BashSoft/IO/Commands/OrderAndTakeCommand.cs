namespace BashSoft.IO.Commands
{
    using Attributes;
    using Contracts.Repository;
    using Exceptions;

    [Alias("order")]
    public class OrderAndTakeCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public OrderAndTakeCommand(string input, string[] data)
            : base(input, data)
        {
        }

        private void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.OrderAndTake(courseName, comparison, null);
                }
                else
                {
                    var hasParsed = int.TryParse(takeQuantity, out var studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        throw new InvalidTakeQueryParameterException();
                    }
                }
            }
            else
            {
                throw new InvalidTakeQueryParameterException();
            }
        }

        public override void Execute()
        {
            if (this.Data.Length != 5)
            {
                throw new InvalidCommandException(this.Input);
            }

            var courseName = this.Data[1];
            var comparison = this.Data[2].ToLower();
            var takeCommand = this.Data[3].ToLower();
            var takeQuantity = this.Data[4].ToLower();

            this.TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
        }
    }
}