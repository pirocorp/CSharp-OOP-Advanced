namespace BashSoft.Tests
{
    using System;
    using System.Collections.Generic;
    using Contracts.DataStructures;
    using DataStructures;
    using NUnit.Framework;

    [TestFixture]
    public class SimpleSortedListTests
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.That(this.names.Capacity, Is.EqualTo(16));
            Assert.That(this.names.Size, Is.EqualTo(0));
        }

        [Test]
        public void TestConstructorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(30);
            Assert.That(this.names.Capacity, Is.EqualTo(30));
            Assert.That(this.names.Size, Is.EqualTo(0));
        }

        [Test]
        public void TestConstructorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.That(this.names.Capacity, Is.EqualTo(16));
            Assert.That(this.names.Size, Is.EqualTo(0));
        }

        [Test]
        public void TestConstructorWithAllParameters()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 20);
            Assert.That(this.names.Capacity, Is.EqualTo(20));
            Assert.That(this.names.Size, Is.EqualTo(0));
        }

        [Test]
        public void AddMethodIncreaseSize()
        {
            this.names.Add("Nasko");
            Assert.That(this.names.Size, Is.EqualTo(1));
        }

        [Test]
        public void AddMethodThrowsExceptionWhenNullIsAdded()
        {
            Assert.That(() => this.names.Add(null), Throws.Exception);
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            var strings = new string[] {"Rosen", "Georgi", "Balkan",};
            this.names.AddAll(strings);
            Assert.That(this.names.JoinWith(", "), Is.EqualTo("Balkan, Georgi, Rosen"));
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (var i = 0; i < 17; i++)
            {
                this.names.Add($"Element{i + 1}");
            }

            Assert.That(this.names.Size, Is.EqualTo(17));
            Assert.That(this.names.Capacity, Is.EqualTo(32));
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            var strings = new List<string>();

            for (var i = 0; i < 1000; i++)
            {
                strings.Add($"Element{i + 1}");
            }

            this.names.AddAll(strings);
            Assert.That(this.names.Size, Is.EqualTo(1000));
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            var strings = new List<string> {null, "eerere"};

            Assert.That(() => this.names.AddAll(strings), Throws.Exception);
        }

        [Test]
        public void TestAddKeepsSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            Assert.That(this.names.JoinWith(", "), Is.EqualTo("Balkan, Georgi, Rosen"));
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            this.names.Remove("Georgi");
            Assert.That(this.names.Size, Is.EqualTo(2));
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            this.names.Remove("Georgi");
            Assert.That(this.names.JoinWith(", "), Is.EqualTo("Balkan, Rosen"));
        }

        [Test]
        public void TestRemoveNullThrowsException()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            Assert.That(() => this.names.Remove(null), Throws.Exception);
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            Assert.That(() => this.names.JoinWith(null), Throws.Exception);
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            Assert.That(this.names.JoinWith("|||||||"), Is.EqualTo("Balkan|||||||Georgi|||||||Rosen"));
        }
    }
}