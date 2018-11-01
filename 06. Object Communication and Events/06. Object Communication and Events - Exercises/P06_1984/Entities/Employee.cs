namespace P06_1984.Entities
{
    using Delegates;
    using EventArgs;
    using Interfaces;

    public class Employee : IEntity
    {
        private string name;
        private int income;

        public event NameChangeEventHandler NameChange;
        public event IncomeChangeEventHandler IncomeChange;

        public Employee(int id, string name, params int[] personData)
        {
            this.Id = id;
            this.Name = name;
            this.Income = personData[0];
        }

        public int Id { get; }

        public string Name
        {
            get => this.name;
            set
            {
                this.OnNameChange(value);
                this.name = value;
            }
        }

        public int Income
        {
            get => this.income;
            set
            {
                this.OnIncomeChange(value);
                this.income = value;
            }
        }

        protected void OnNameChange(string value)
        {
            if (this.NameChange != null)
            {
                var eventArgs = new ChangeEventArgs(this.Id.ToString(), nameof(Employee),
                    typeof(string).Name, nameof(this.Name), this.Name, value);

                this.NameChange(this, eventArgs);
            }
        }

        protected void OnIncomeChange(int value)
        {
            if (this.IncomeChange != null)
            {
                var eventArgs = new ChangeEventArgs(this.Id.ToString(), nameof(Employee),
                    typeof(int).Name, nameof(this.Income), this.Income.ToString(), value.ToString());

                this.IncomeChange(this, eventArgs);
            }
        }
    }
}