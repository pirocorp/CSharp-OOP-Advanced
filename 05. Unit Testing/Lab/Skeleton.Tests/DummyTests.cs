namespace Skeleton.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void TakeAttack_DummyHealth_LosesHealthIfAttacked()
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

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(10));
        }

        [Test]
        public void TakeAttack_IsDead_TrowsException()
        {
            //Arrange
            var axeAttack = 10;
            var axeDurability = 10;

            var dummyHealth = 0;
            var dummyExperience = 5;

            
            var axe = new Axe(axeAttack, axeDurability);
            var dummy = new Dummy(dummyHealth, dummyExperience);

            //Assert
            Assert.That(() => axe.Attack(dummy), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void GiveExperienceMethod_IsDead_GiveExperience()
        {
            //Arrange
            var dummyHealth = 0;
            var dummyExperience = 5;

            var dummy = new Dummy(dummyHealth, dummyExperience);

            //Act
            var experience = dummy.GiveExperience();

            //Assert
            Assert.That(experience, Is.EqualTo(dummyExperience));
        }

        [Test]
        public void GiveExperienceMethod_NotDead_NotGiveExperience()
        {
            //Arrange
            var dummyHealth = 10;
            var dummyExperience = 5;

            var dummy = new Dummy(dummyHealth, dummyExperience);

            //Assert
            Assert.That(() => dummy.GiveExperience(), Throws.InstanceOf<InvalidOperationException>());
        }
    }
}