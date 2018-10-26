namespace Skeleton
{
    public class Hero
    {
        private string name;
        private int experience;
        private Axe weapon;

        public Hero(string name)
        {
            this.name = name;
            this.experience = 0;
            this.weapon = new Axe(10, 10);
        }

        public string Name => this.name;

        public int Experience => this.experience;

        public Axe Weapon => this.weapon;

        public void Attack(Dummy target)
        {
            this.weapon.Attack(target);

            if (target.IsDead())
            {
                this.experience += target.GiveExperience();
            }
        }
    }
}
