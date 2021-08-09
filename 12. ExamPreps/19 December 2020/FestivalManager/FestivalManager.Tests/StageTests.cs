// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using Entities;

    [TestFixture]
	public class StageTests
    {
        private Stage stage = null;

        [SetUp]
        public void InitTest()
        {
            this.stage = new Stage();
        }

		[Test]
	    public void PerformerCannotBeNullInAddPerformer()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.stage.AddPerformer(null), 
                "Can not be null!");
        }

        [Test]
        public void PerformerIsLessThan18YearsOld()
        {
            var performer = new Performer("AAA", "BBB", 17);

            Assert.Throws<ArgumentException>(
                () => this.stage.AddPerformer(performer),
                "You can only add performers that are at least 18.");
        }

        [Test]
        public void SuccessfullyAddPerformer()
        {
            var performer = new Performer("AAA", "BBB", 18);

            this.stage.AddPerformer(performer);

            Assert.AreEqual(1, this.stage.Performers.Count);
        }

        [Test]
        public void SongCannotBeNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.stage.AddSong(null),
                "Can not be null!");
        }

        [Test]
        public void SongCannotBeLessThan1Minute()
        {
            var song = new Song("AAA", TimeSpan.FromSeconds(59));

            Assert.Throws<ArgumentException>(
                () => this.stage.AddSong(song),
                "You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void SuccessfullyAddSong()
        {
            var song = new Song("AAA", TimeSpan.FromMinutes(2));
            Assert.DoesNotThrow(() => this.stage.AddSong(song));
        }

        [Test]

        public void ThrowsIfSongIsNull()
        {
            var song = new Song("AAA", TimeSpan.FromMinutes(2));
            var performer = new Performer("AAA", "BBB", 18);

            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            Assert.Throws<ArgumentNullException>(
                () => this.stage.AddSongToPerformer(null, performer.FullName),
                "Can not be null!");
        }

        [Test]

        public void ThrowsIfPerformerIsNull()
        {
            var song = new Song("AAA", TimeSpan.FromMinutes(2));
            var performer = new Performer("AAA", "BBB", 18);

            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            Assert.Throws<ArgumentNullException>(
                () => this.stage.AddSongToPerformer(song.Name, null),
                "Can not be null!");
        }

        [Test]
        public void ThrowsIfSongIsNotFound()
        {
            var song = new Song("AAA", TimeSpan.FromMinutes(2));
            var performer = new Performer("AAA", "BBB", 18);

            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(
                () => this.stage.AddSongToPerformer("CCC", performer.FullName),
                "There is no song with this name.");
        }

        [Test]

        public void ThrowsIfPerformerIsNotFound()
        {
            var song = new Song("AAA", TimeSpan.FromMinutes(2));
            var performer = new Performer("AAA", "BBB", 18);

            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            Assert.Throws<ArgumentException>(
                () => this.stage.AddSongToPerformer(song.Name, "CCC"),
                "There is no performer with this name.");
        }

        [Test]
        public void SuccessfullyAddSongToPerformer()
        {
            var song = new Song("AAA", TimeSpan.FromMinutes(2));
            var performer = new Performer("AAA", "BBB", 18);

            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);

            var actual = this.stage.AddSongToPerformer(song.Name, performer.FullName);
            var expected = $"{song} will be performed by {performer}";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PlayWorksCorrectly()
        {
            var song1 = new Song("AAA", TimeSpan.FromMinutes(2));
            var song2 = new Song("BBB", TimeSpan.FromMinutes(2));
            var song3 = new Song("CCC", TimeSpan.FromMinutes(2));
            var song4 = new Song("DDD", TimeSpan.FromMinutes(2));
            var song5 = new Song("EEE", TimeSpan.FromMinutes(2));

            this.stage.AddSong(song1);
            this.stage.AddSong(song2);
            this.stage.AddSong(song3);
            this.stage.AddSong(song4);
            this.stage.AddSong(song5);

            var performer1 = new Performer("AAA", "AAA", 18);
            var performer2 = new Performer("BBB", "BBB", 18);

            this.stage.AddPerformer(performer1);
            this.stage.AddPerformer(performer2);

            this.stage.AddSongToPerformer(song1.Name, performer1.FullName);
            this.stage.AddSongToPerformer(song2.Name, performer1.FullName);
            this.stage.AddSongToPerformer(song3.Name, performer1.FullName);

            this.stage.AddSongToPerformer(song2.Name, performer2.FullName);
            this.stage.AddSongToPerformer(song3.Name, performer2.FullName);
            this.stage.AddSongToPerformer(song4.Name, performer2.FullName);
            this.stage.AddSongToPerformer(song5.Name, performer2.FullName);

            Assert.AreEqual(2, this.stage.Performers.Count);

            var expected = "2 performers played 7 songs";
            var actual = this.stage.Play();

            Assert.AreEqual(expected, actual);
        }
    }
}
