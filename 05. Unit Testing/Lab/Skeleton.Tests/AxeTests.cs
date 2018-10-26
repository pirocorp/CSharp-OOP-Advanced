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
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Arrange
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack.");
        }

        [Test]
        public void AttackMethod_BrokenAxe_ThrowsException()
        {
            //Arrange
            var axe = new Axe(10, 0);
            var dummy = new Dummy(10, 10);

            //Arrange
            Assert.That(() => axe.Attack(dummy), Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}