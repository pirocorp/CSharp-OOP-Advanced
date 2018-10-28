namespace P06_Twitter.Tests
{
    using System.Reflection;
    using Interfaces;
    using Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ClientTests
    {
        private Mock<IWriter> consoleWriter;
        private Mock<IWriter> netWriter;

        [SetUp]
        public void Initialize()
        {
            //Arrange
            this.consoleWriter = new Mock<IWriter>();
            this.netWriter = new Mock<IWriter>();
        }

        [Test]
        public void Constructor_CreateInstance_Successful()
        {
            //Act
            var client = new Client(this.consoleWriter.Object, this.netWriter.Object);
            var clientConsoleWriter = typeof(Client).GetField("consoleWriter", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(client);
            var clientNetWriter = typeof(Client).GetField("netWriter", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(client);

            //Assert
            Assert.That(clientConsoleWriter, Is.SameAs(this.consoleWriter.Object));
            Assert.That(clientNetWriter, Is.SameAs(this.netWriter.Object));
        }

        [Test]
        public void Constructor_NullParameters_ThrowsArgumentNullException()
        {
            //Assert
            Assert.That(() => new Client(null, null), Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_LeftNullParameter_ThrowsArgumentNullException()
        {
            //Assert
            Assert.That(() => new Client(null, this.netWriter.Object), Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_RightNullParameter_ThrowsArgumentNullException()
        {
            //Assert
            Assert.That(() => new Client(this.consoleWriter.Object, null), Throws.ArgumentNullException);
        }

        [Test]
        public void Receive_Tweet_CallsBothConsoleAndNetWriter_Successful()
        {
            //Arrange
            var tweet = new Tweet("New test tweet.");
            this.consoleWriter.Setup(c => c.WriteLine(It.IsAny<object>()));
            this.netWriter.Setup(n => n.WriteLine(It.IsAny<object>()));
            var client = new Client(this.consoleWriter.Object, this.netWriter.Object);

            //Act
            client.Receive(tweet);

            //Assert
            this.consoleWriter.Verify(c => c.WriteLine(It.IsAny<object>()), Times.Once);
            this.netWriter.Verify(c => c.WriteLine(It.IsAny<object>()), Times.Once);
        }
    }
}