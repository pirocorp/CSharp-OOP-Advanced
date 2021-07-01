namespace ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string userName;

        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string UserName
        {
            get => this.userName;
            private set => this.userName = value;
        }

        public long Id
        {
            get => this.id;
            private set => this.id = value;
        }
    }
}
