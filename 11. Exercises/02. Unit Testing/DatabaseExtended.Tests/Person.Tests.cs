namespace DatabaseExtended
{
    using ExtendedDatabase;
    using NUnit.Framework;

    public class PersonTests
    {
        [TestCase(1, "Pesho")]
        public void PersonIsCreatedCorrectly(int id, string name)
        {
            var person = new Person(id, name);

            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(name, person.UserName);
        }
    }
}
