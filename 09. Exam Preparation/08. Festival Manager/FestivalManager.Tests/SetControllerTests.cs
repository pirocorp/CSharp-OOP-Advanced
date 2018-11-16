// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    //using Core.Controllers;
    //using Entities;
    //using Entities.Instruments;
    //using Entities.Sets;

    using System;
    using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void Test()
		{
		    var stage = new Stage();
            var performer1 = new Performer("Gosho", 21);
            performer1.AddInstrument(new Guitar());
            performer1.AddInstrument(new Microphone());
            var performer2 = new Performer("Pesho", 23);
            performer2.AddInstrument(new Drums());
            var performer3 = new Performer("Ivan", 20);
            performer3.AddInstrument(new Microphone());
		    var set = new Long("TestSet");
            set.AddPerformer(performer1);
            set.AddPerformer(performer2);
            set.AddPerformer(performer3);
            var song1 = new Song("song1", new TimeSpan(0,20,0));
            var song2 = new Song("song2", new TimeSpan(0,20,0));
            var song3 = new Song("song3", new TimeSpan(0,19,0));
            var song4 = new Song("song4", new TimeSpan(0,0,1));
            set.AddSong(song1);
            set.AddSong(song2);
            set.AddSong(song3);
            set.AddSong(song4);
		    stage.AddSet(set);

		    var controller = new SetController(stage);
		    var result = controller.PerformSets();

            Assert.That(result, Is.EqualTo("1. TestSet:\r\n-- 1. song1 (20:00)\r\n-- 2. song2 (20:00)\r\n-- 3. song3 (19:00)\r\n-- 4. song4 (00:01)\r\n-- Set Successful"));
		}

        [Test]
        public void Test2()
        {
            var stage = new Stage();
            var performer1 = new Performer("Gosho", 21);
            var guitar = new Guitar();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            performer1.AddInstrument(new Guitar());
            performer1.AddInstrument(new Microphone());
            var performer2 = new Performer("Pesho", 23);
            performer2.AddInstrument(new Drums());
            var performer3 = new Performer("Ivan", 20);
            performer3.AddInstrument(guitar);
            var set = new Long("TestSet");
            set.AddPerformer(performer1);
            set.AddPerformer(performer2);
            set.AddPerformer(performer3);
            var song1 = new Song("song1", new TimeSpan(0, 20, 0));
            var song2 = new Song("song2", new TimeSpan(0, 20, 0));
            var song3 = new Song("song3", new TimeSpan(0, 19, 0));
            var song4 = new Song("song4", new TimeSpan(0, 0, 1));
            set.AddSong(song1);
            set.AddSong(song2);
            set.AddSong(song3);
            set.AddSong(song4);
            stage.AddSet(set);

            var controller = new SetController(stage);
            var result = controller.PerformSets();

            Assert.That(result, Is.EqualTo("1. TestSet:\r\n-- Did not perform"));
        }

        [Test]
        public void Test3()
        {
            var stage = new Stage();

            var guitar = new Guitar();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();
            guitar.WearDown();

            var performer3 = new Performer("Ivan", 20);
            performer3.AddInstrument(guitar);

            var set2 = new Short("ShortTest");
            set2.AddPerformer(performer3);
            stage.AddSet(set2);


            var controller = new SetController(stage);
            var result = controller.PerformSets();

            Assert.That(result, Is.EqualTo("1. ShortTest:\r\n-- Did not perform"));
        }

        [Test]
        public void Test4()
        {
            var stage = new Stage();

            var guitar = new Guitar();


            var performer3 = new Performer("Ivan", 20);
            performer3.AddInstrument(guitar);

            var set2 = new Short("ShortTest");
            set2.AddPerformer(performer3);
            var song4 = new Song("song4", new TimeSpan(0, 0, 1));
            set2.AddSong(song4);
            stage.AddSet(set2);

            var controller = new SetController(stage);
            var result = controller.PerformSets();
            
            Assert.That(guitar.Wear < 100);
        }
    }
}