namespace P06_1984.Entities
{
    using Delegates;
    using EventArgs;
    using Interfaces;

    public class Company : IEntity
    {
        private string name;
        private int turnover;
        private int revenue;

        public event NameChangeEventHandler NameChange;
        public event TurnoverChangeEventHandler TurnoverChange;
        public event RevenueChangeEventHandler RevenueChange;

        public Company(int id, string name, params int[] companyData)
        {
            this.Id = id;
            this.Name = name;
            this.Turnover = companyData[0];
            this.Revenue = companyData[1];
        }

        public int Id { get; }

        public string Name
        {
            get => this.name;
            set
            {
                if (this.NameChange != null)
                {
                    var eventArgs = new ChangeEventArgs(this.Id.ToString(), nameof(Company),
                        typeof(string).Name, nameof(this.Name), this.Name, value);

                    this.NameChange(this, eventArgs);
                }

                this.name = value;
            }
        }

        public int Turnover
        {
            get => this.turnover;
            set
            {
                if (this.TurnoverChange != null)
                {
                    var eventArgs = new ChangeEventArgs(this.Id.ToString(), nameof(Company),
                        typeof(int).Name, nameof(this.Turnover), this.Turnover.ToString(), value.ToString());

                    this.TurnoverChange(this, eventArgs);
                }

                this.turnover = value;
            }
        }

        public int Revenue
        {
            get => this.revenue;
            set
            {
                if (this.RevenueChange != null)
                {
                    var eventArgs = new ChangeEventArgs(this.Id.ToString(), nameof(Company),
                        typeof(int).Name, nameof(this.Revenue), this.Revenue.ToString(), value.ToString());

                    this.RevenueChange(this, eventArgs);
                }

                this.revenue = value;
            }
        }
    }
}