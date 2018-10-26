namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;
    
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AttackMethod_AxeDurability_AxeLoosesDurabilityAfterAttack()
        {
            //Arrange
            var axeAttack = 10;
            var axeDurability = 10;

            var dummyHealth = 20;
            var dummyExperience = 5;

            var axe = new Axe(axeAttack, axeDurability);
            var dummy = new Dummy(dummyHealth, dummyExperience);

            //Act
            axe.Attack(dummy);

            //Arrange
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack.");
        }

        [Test]
        public void AttackMethod_BrokenAxe_ThrowsException()
        {
            //Arrange
            var axeAttack = 10;
            var axeDurability = 0;

            var dummyHealth = 20;
            var dummyExperience = 5;

            var axe = new Axe(axeAttack, axeDurability);
            var dummy = new Dummy(dummyHealth, dummyExperience);

            //Arrange
            Assert.That(() => axe.Attack(dummy), Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}