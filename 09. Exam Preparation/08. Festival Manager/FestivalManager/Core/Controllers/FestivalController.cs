namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using Contracts;
	using Entities;
	using Entities.Contracts;
	using Entities.Factories.Contracts;
	using Entities.Sets;

    public class FestivalController : IFestivalController
    {
        private const string TIME_FORMAT = "mm\\:ss";
        private const string TIME_FORMAT_LONG = "{0:2D}:{1:2D}";

        private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISongFactory songFactory;

        public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISongFactory songFactory)
        {
            this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
        }

	    public string ProduceReport()
	    {
	        var result = new StringBuilder();

	        var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

	        result.AppendLine($"Festival length: {FormatTimeSpan(totalFestivalLength)}");

	        foreach (var set in this.stage.Sets)
	        {
	            result.AppendLine($"--{set.Name} ({FormatTimeSpan(set.ActualDuration)}):");

	            var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
	            foreach (var performer in performersOrderedDescendingByAge)
	            {
	                var instruments = string.Join(", ", performer.Instruments
	                    .OrderByDescending(i => i.Wear));

	                result.AppendLine($"---{performer.Name} ({instruments})");
	            }

	            if (!set.Songs.Any())
	                result.AppendLine("--No songs played");
	            else
	            {
	                result.AppendLine("--Songs played:");
	                foreach (var song in set.Songs)
	                {
	                    result.AppendLine($"----{song.Name} ({song.Duration.ToString(TIME_FORMAT)})");
	                }
	            }
	        }

	        return result.ToString();
        }

	    public string RegisterSet(string[] args)
	    {
	        var setName = args[0];
	        var setTypeString = args[1];

	        var setType = Assembly.GetCallingAssembly()
	            .GetTypes()
	            .FirstOrDefault(t => t.Name == setTypeString);

	        var setInstance = (ISet)Activator.CreateInstance(setType, setName);
            this.stage.AddSet(setInstance);

	        return $"Registered {setTypeString} set";
	    }

	    public string SignUpPerformer(string[] args)
	    {
	        var name = args[0];
	        var age = int.Parse(args[1]);

	        var instruments = args
	            .Skip(2)
	            .Select(i => this.instrumentFactory.CreateInstrument(i))
	            .ToArray();

	        var performer = this.performerFactory.CreatePerformer(name, age);

	        foreach (var instrument in instruments)
	        {
	            performer.AddInstrument(instrument);
	        }

	        this.stage.AddPerformer(performer);

	        return $"Registered performer {performer.Name}";
        }

	    public string RegisterSong(string[] args)
	    {
	        var songName = args[0];
	        var durationString = args[1];
	        var duration = TimeSpan.ParseExact(durationString, TIME_FORMAT, CultureInfo.InvariantCulture);
	        var song = this.songFactory.CreateSong(songName, duration);

            this.stage.AddSong(song);
	        return $"Registered song {song}";
	    }

	    public string AddSongToSet(string[] args)
	    {
	        var songName = args[0];
	        var setName = args[1];

	        if (!this.stage.HasSet(setName))
	        {
	            throw new InvalidOperationException("Invalid set provided");
	        }

	        if (!this.stage.HasSong(songName))
	        {
	            throw new InvalidOperationException("Invalid song provided");
	        }

	        var set = this.stage.GetSet(setName);
	        var song = this.stage.GetSong(songName);

	        set.AddSong(song);

	        return $"Added {song} to {set.Name}";
        }

	    public string AddPerformerToSet(string[] args)
	    {
	        var performerName = args[0];
	        var setName = args[1];

	        var performer = this.stage.GetPerformer(performerName);

	        if (performer == null)
	        {
	            throw new InvalidOperationException("Invalid performer provided");

	        }

	        var set = this.stage.GetSet(setName);

	        if (set == null)
	        {
	            throw new InvalidOperationException("Invalid set provided");
            }

            set.AddPerformer(performer);
	        return $"Added {performerName} to {setName}";
	    }

	    public string RepairInstruments(string[] args)
	    {
	        var instrumentsToRepair = this.stage.Performers
	            .SelectMany(p => p.Instruments)
	            .Where(i => i.Wear < 100)
	            .ToArray();

	        foreach (var instrument in instrumentsToRepair)
	        {
	            instrument.Repair();
	        }

	        return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        private static string FormatTimeSpan(TimeSpan timeSpan)
        {
            var formatted = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
            return formatted;
        }
    }
}