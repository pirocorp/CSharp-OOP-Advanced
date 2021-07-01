namespace Tests
{
    using System;
    using System.Reflection;
    using FightingArena;
    using NUnit.Framework;

    public class WarriorTests
    {
        [TestCase("Zelda", 100, 100)]
        [TestCase("Blue eye dragon", 500, 5000)]
        [TestCase("Mario", 10, 10)]
        public void WarriorConstructorWorksFine(string name, int damage, int hp)
        {
            var warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null, 100, 100)]
        [TestCase("", 100, 100)]
        [TestCase("    ", 100, 100)]
        public void WarriorConstructorThrowsWhenNameIsNullOrWhiteSpace(string name, int damage, int hp)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));

            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase("Mario", -100, 100)]
        [TestCase("Mario", -50, 100)]
        [TestCase("Mario", 0, 100)]
        public void WarriorConstructorThrowsWhenDamageIsZeroOrNegative(string name, int damage, int hp)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));

            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase("Mario", 100, -10)]
        [TestCase("Mario", 100, -50)]
        [TestCase("Mario", 100, -100)]
        public void WarriorConstructorThrowsWhenHPIsNegative(string name, int damage, int hp)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));

            Assert.AreEqual("HP should not be negative!", exception.Message);
        }

        [TestCase("Zelda", 100, 100)]
        [TestCase("Zelda", 50, 100)]
        [TestCase("Zelda", 10, 100)]
        public void WarriorAttackWarriorHpIsCorrect(string name, int damage, int hp)
        {
            var warrior = new Warrior("Attacker", 100, 100);
            var victim = new Warrior(name, damage, hp);

            var expectedHp = warrior.HP - victim.Damage;
            warrior.Attack(victim);

            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [TestCase("Zelda", 100, 100)]
        [TestCase("Zelda", 100, 70)]
        [TestCase("Zelda", 100, 40)]
        public void WarriorAttackVictimHpIsCorrect(string name, int damage, int hp)
        {
            var warrior = new Warrior("Attacker", 100, 100);
            var victim = new Warrior(name, damage, hp);

            var expectedHp = Math.Max(0, victim.HP - warrior.Damage);
            warrior.Attack(victim);

            Assert.AreEqual(expectedHp, victim.HP);
        }

        [Test]
        public void WarriorAttackThrowsInvalidOperationExceptionWhenHpBellowThreshold()
        {
            var minAttackHp = (int) typeof(Warrior)
                    .GetField("MIN_ATTACK_HP", BindingFlags.NonPublic | BindingFlags.Static)
                    .GetValue(null);

            var warrior = new Warrior("Test", 100, minAttackHp);

            var exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior));
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [Test]
        public void WarriorAttackThrowsInvalidOperationExceptionWhenVictimHpBellowThreshold()
        {
            var minAttackHp = (int)typeof(Warrior)
                .GetField("MIN_ATTACK_HP", BindingFlags.NonPublic | BindingFlags.Static)
                .GetValue(null);

            var warrior = new Warrior("Test", 100, minAttackHp + 50);
            var victim = new Warrior("Test", 100, minAttackHp);

            var exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(victim));
            Assert.AreEqual($"Enemy HP must be greater than {minAttackHp} in order to attack him!", exception.Message);
        }

        [Test]
        public void WarriorAttackThrowsInvalidOperationExceptionWhenVictimHasMoreAttackThenWarriorHp()
        {
            var warrior = new Warrior("Test", 100, 100);
            var victim = new Warrior("Test", 200, 100);

            var exception = Assert.Throws<InvalidOperationException>(() => warrior.Attack(victim));
            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }
    }
}