namespace Skeleton.Tests
{
    using Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void AttackMethod_Experience_GainsExperienceAfterTargetDies()
        {
            //Arrange
            var fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(p => p.Health).Returns(0);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
            fakeTarget.Setup(p => p.IsDead()).Returns(true);

            var fakeWeapon = new Mock<IWeapon>();

            var hero = new Hero("Pesho", fakeWeapon.Object);

            //Act
            hero.Attack(fakeTarget.Object);

            //Assert
            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }
}