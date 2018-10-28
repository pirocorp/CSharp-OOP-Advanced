namespace P06_Twitter.Tests
{
    using Models;
    using NUnit.Framework;

    [TestFixture]
    public class TweetTests
    {
        [Test]
        public void Constructor_CreateInstance_Successful()
        {
            //Arrange
            var testTweetMessage = "Test tweet message!";

            //Act
            var testTweet = new Tweet(testTweetMessage);

            //Assert
            Assert.That(testTweet.Message, Is.EqualTo(testTweetMessage));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void Constructor_StringCantBeNullOrWhiteSpace_ThrowsArgumentException(string testString)
        {
            //Assert
            Assert.That(() => new Tweet(testString), Throws.ArgumentException);
        }

        [Test]
        public void ToString_InputString_InputAndOutputStringMustBeEqual()
        {
            //Arrange
            var inputString = "New test input string.";
            var tweet = new Tweet(inputString);

            //Act
            var outputString = tweet.ToString();

            //Assert
            Assert.That(inputString, Is.EqualTo(outputString));
        }
    }
}