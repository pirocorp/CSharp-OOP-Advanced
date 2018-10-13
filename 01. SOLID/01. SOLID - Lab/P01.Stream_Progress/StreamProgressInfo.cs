namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private readonly IStreamable stream;

        // If we want to stream a music stream, we can't
        public StreamProgressInfo(IStreamable stream)
        {
            this.stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.stream.BytesSent * 100) / this.stream.Length;
        }
    }
}
