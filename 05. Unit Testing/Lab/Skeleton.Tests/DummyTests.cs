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
            var dummy = new Target(dummyHealth, dummyExperience);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(10), "Target health doesn't change after attack.");
        }

        [Test]
        public void TakeAttack_IsDead_TrowsException()
        {
            //Arrange
            var axeAttack = 100;
            var axeDurability = 100;

            var dummyHealth = 0;
            var dummyExperience = 5;

            
            var axe = new Axe(axeAttack, axeDurability);
            var dummy = new Target(dummyHealth, dummyExperience);

            //Assert
            Assert.That(() => axe.Attack(dummy), Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("Target is dead."));
        }

        [Test]
        public void GiveExperienceMethod_IsDead_GiveExperience()
        {
            //Arrange
            var dummyHealth = 0;
            var dummyExperience = 5;

            var dummy = new Target(dummyHealth, dummyExperience);

            //Act
            var experience = dummy.GiveExperience();

            //Assert
            Assert.That(experience, Is.EqualTo(dummyExperience), "Target doesn't give experience.");
        }

        [Test]
        public void GiveExperienceMethod_NotDead_NotGiveExperience()
        {
            //Arrange
            var dummyHealth = 10;
            var dummyExperience = 5;

            var dummy = new Target(dummyHealth, dummyExperience);

            //Assert
            Assert.That(() => dummy.GiveExperience(), Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("Target is not dead."));
        }
    }
}