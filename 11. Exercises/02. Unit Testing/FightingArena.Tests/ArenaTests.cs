namespace Tests
{
    using System;
    using NUnit.Framework;

    using FightingArena;

    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }

        [Test]
        public void ArenaConstructorWorksFine()
        {
            Assert.IsNotNull(this.arena.Warriors);
            Assert.AreEqual(0, this.arena.Count);
            Assert.AreEqual(this.arena.Warriors.Count, this.arena.Count);
        }

        [Test]
        public void ArenaEnrollWorksFine()
        {
            var warrior = new Warrior("Test", 100, 100);

            this.arena.Enroll(warrior);

            Assert.IsNotNull(this.arena.Warriors);
            Assert.AreEqual(1, this.arena.Count);
            Assert.AreEqual(this.arena.Warriors.Count, this.arena.Count);

            var warrior2 = new Warrior("Test2", 100, 100);

            this.arena.Enroll(warrior2);

            Assert.IsNotNull(this.arena.Warriors);
            Assert.AreEqual(2, this.arena.Count);
            Assert.AreEqual(this.arena.Warriors.Count, this.arena.Count);
        }

        [Test]
        public void ArenaEnrollThrowsWhenWarriorWithSameNameAlreadyExists()
        {
            var warrior = new Warrior("Test", 100, 100);

            this.arena.Enroll(warrior);

            var warrior2 = new Warrior("Test", 200, 200);
            var exception = Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior2));
            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightWorksCorrectly()
        {
            var warrior1 = new Warrior("Test1", 100, 100);
            var warrior2 = new Warrior("Test2", 50, 50);
            var warrior3 = new Warrior("Test3", 50, 50);
            var warrior4 = new Warrior("Test4", 50, 50);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);
            this.arena.Enroll(warrior3);
            this.arena.Enroll(warrior4);

            this.arena.Fight(warrior1.Name, warrior2.Name);

            Assert.AreEqual(50, warrior1.HP);
            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        public void ArenaFightWorksCorrectly2()
        {
            var warrior1 = new Warrior("Test1", 110, 80);
            var warrior2 = new Warrior("Test2", 50, 150);
            var warrior3 = new Warrior("Test3", 222, 11);
            var warrior4 = new Warrior("Test4", 22, 333);

            this.arena.Enroll(warrior3);
            this.arena.Enroll(warrior4);
            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            this.arena.Fight(warrior1.Name, warrior2.Name);

            Assert.AreEqual(30, warrior1.HP);
            Assert.AreEqual(40, warrior2.HP);
        }

        [Test]
        public void ArenaFightThrowsInvalidOperationExceptionWhenAttackerIsMissing()
        {
            var warrior1 = new Warrior("Test1", 110, 80);
            var warrior2 = new Warrior("Test2", 50, 150);
            var warrior3 = new Warrior("Test3", 222, 11);
            var warrior4 = new Warrior("Test4", 22, 333);

            this.arena.Enroll(warrior3);
            this.arena.Enroll(warrior4);
            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            var missingName = "Invalid Name";

            var exception = Assert.Throws<InvalidOperationException>(() => this.arena.Fight(missingName, warrior2.Name));
            Assert.AreEqual($"There is no fighter with name {missingName} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightThrowsInvalidOperationExceptionWhenVictimIsMissing()
        {
            var warrior1 = new Warrior("Test1", 110, 80);
            var warrior2 = new Warrior("Test2", 50, 150);
            var warrior3 = new Warrior("Test3", 222, 11);
            var warrior4 = new Warrior("Test4", 22, 333);

            this.arena.Enroll(warrior3);
            this.arena.Enroll(warrior4);
            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);

            var missingName = "Invalid Name 2";

            var exception = Assert.Throws<InvalidOperationException>(() => this.arena.Fight(warrior1.Name, missingName));
            Assert.AreEqual($"There is no fighter with name {missingName} enrolled for the fights!", exception.Message);
        }
    }
}
