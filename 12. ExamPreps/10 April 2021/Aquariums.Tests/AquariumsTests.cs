namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void AquariumIsCreatedCorrectly()
        {
            var aquariumName = "Test";
            var aquariumCapacity = 10;

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);

            Assert.AreEqual(aquariumName, aquarium.Name);
            Assert.AreEqual(aquariumCapacity, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [TestCase(null, 10)]
        [TestCase("", 10)]
        public void ThrowsWithInvalidName(string aquariumName, int capacity)
        {
            Assert.Throws<ArgumentNullException>(
                () => new Aquarium(aquariumName, capacity),
                "Invalid aquarium name!");
        }

        [TestCase("Valid name", -5)]
        public void ThrowsWithInvalidCapacity(string aquariumName, int capacity)
        {
            Assert.Throws<ArgumentException>(
                () => new Aquarium(aquariumName, capacity),
                "Invalid aquarium capacity!");
        }

        [Test]
        public void AddFishWorksCorrectly()
        {
            var aquariumName = "Test";
            var aquariumCapacity = 10;

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);

            for (var i = 0; i < aquariumCapacity; i++)
            {
                var fish = new Fish($"Fish {i}");

                aquarium.Add(fish);
            }

            Assert.AreEqual(aquariumCapacity, aquarium.Count);
        }

        [Test]
        public void AddFishThrowsWhenExceedCapacity()
        {
            var aquariumName = "Test";
            var aquariumCapacity = 5;

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);

            for (var i = 0; i < aquariumCapacity; i++)
            {
                var fish = new Fish($"Fish {i}");

                aquarium.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(
                () => aquarium.Add(new Fish("Valid fish")),
                "Aquarium is full!");
        }

        [Test]
        public void RemoveFishWorksCorrectly()
        {
            var aquariumName = "Test";
            var aquariumCapacity = 5;

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);

            var fishes = new List<Fish>();

            for (var i = 0; i < aquariumCapacity; i++)
            {
                var fish = new Fish($"Fish {i}");

                aquarium.Add(fish);
                fishes.Add(fish);
            }

            fishes.ForEach(f => aquarium.RemoveFish(f.Name));

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void RemoveFishThrowsWhenFishIsNotFound()
        {
            var aquariumName = "Test";
            var aquariumCapacity = 5;

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);

            for (var i = 0; i < aquariumCapacity; i++)
            {
                var fish = new Fish($"Fish {i}");

                aquarium.Add(fish);
            }

            var missingFish = "Missing Fish";

            Assert.Throws<InvalidOperationException>(
                () => aquarium.RemoveFish(missingFish),
                $"Fish with the name {missingFish} doesn't exist!");
        }

        [Test]
        public void SellFishWorksCorrectly()
        {
            var aquariumName = "Test";
            var aquariumCapacity = 5;

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);
            var fishes = new List<Fish>();

            for (var i = 0; i < aquariumCapacity; i++)
            {
                var fish = new Fish($"Fish {i}");

                aquarium.Add(fish);
                fishes.Add(fish);
            }

            var selledFishes = new List<Fish>();
            fishes.ForEach(f => selledFishes.Add(aquarium.SellFish(f.Name)));

            foreach (var fish in selledFishes)
            {
                Assert.AreEqual(false, fish.Available);
            }

            Assert.AreEqual(selledFishes.Count, aquarium.Count);
        }

        [Test]
        public void SellFishThrowsWhenFishIsMissing()
        {
            var aquariumName = "Test";
            var aquariumCapacity = 5;

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);

            for (var i = 0; i < aquariumCapacity; i++)
            {
                var fish = new Fish($"Fish {i}");

                aquarium.Add(fish);
            }

            var missingFish = "Missing Fish";

            Assert.Throws<InvalidOperationException>(
                () => aquarium.SellFish(missingFish),
                $"Fish with the name {missingFish} doesn't exist!");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ReportWorksCorrectly(int aquariumCapacity)
        {
            var aquariumName = "Test";

            var aquarium = new Aquarium(aquariumName, aquariumCapacity);
            var fishes = new List<Fish>();

            for (var i = 0; i < aquariumCapacity; i++)
            {
                var fish = new Fish($"Fish {i}");

                aquarium.Add(fish);
                fishes.Add(fish);
            }

            var expected = $"Fish available at {aquariumName}: {string.Join(", ", fishes.Select(f => f.Name))}";

            Assert.AreEqual(expected, aquarium.Report());
        }
    }
}
