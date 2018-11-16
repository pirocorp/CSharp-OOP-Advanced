namespace FestivalManager.Entities.Sets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public abstract class Set : ISet
    {
        private readonly List<IPerformer> performers;
        private readonly List<ISong> songs;

        protected Set(string name, TimeSpan maxDuration)
        {
            this.Name = name;
            this.MaxDuration = maxDuration;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; private set; }

        public TimeSpan MaxDuration { get; private set; }

        public TimeSpan ActualDuration => new TimeSpan(this.songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public bool CanPerform()
        {
            var atLeastOnePerformer = this.performers.Count > 0;
            var atLeastOneSong = this.songs.Count > 0;
            var allPerformersHasAtLeastOneUnbrokenInstrument =
                this.Performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (atLeastOnePerformer && atLeastOneSong && allPerformersHasAtLeastOneUnbrokenInstrument)
            {
                return true;
            }

            return false;
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            var currentActualDuration = this.ActualDuration;
            var resultDuration = currentActualDuration + song.Duration;

            if (resultDuration > this.MaxDuration)
            {
                throw new InvalidOperationException("Song is over the set limit!");
            }

            this.songs.Add(song);
        }
    }
}