namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;
	    private readonly List<ISet> sets;

	    public Stage()
	    {
	        this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
            this.sets = new List<ISet>();
	    }

	    public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

	    public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

	    public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

	    public void AddSong(ISong song)
	    {
	        this.songs.Add(song);
	    }

	    public void AddPerformer(IPerformer performer)
	    {
	        this.performers.Add(performer);
	    }

        public void AddSet(ISet set)
	    {
	        this.sets.Add(set);
	    }

	    public ISong GetSong(string name)
	    {
	        var result = this.songs.FirstOrDefault(s => s.Name == name);

	        return result;
	    }

        public IPerformer GetPerformer(string name)
        {
            var result = this.performers.FirstOrDefault(p => p.Name == name);

            return result;
        }

	    public ISet GetSet(string name)
	    {
	        var result = this.sets.FirstOrDefault(s => s.Name == name);

            return result;
	    }

	    public bool HasSong(string name)
	    {
	        return this.songs.Any(s => s.Name == name);
	    }

	    public bool HasPerformer(string name)
	    {
	        return this.performers.Any(p => p.Name == name);
	    }

        public bool HasSet(string name)
        {
            return this.sets.Any(s => s.Name == name);
        }
	}
}