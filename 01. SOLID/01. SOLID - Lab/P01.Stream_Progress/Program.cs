namespace P01.Stream_Progress
{
    public class Program
    {
        public static void Main()
        {   
            IStreamable file = new File("Filename", 100, 50);
            IStreamable music = new Music("T3", "T4", 100, 30);
            Music music2 = new Music("Second Artist", "Second Song", 500, 145);
            File file2 = new File("filename2", 500, 150);

            var streamProgress = new StreamProgressInfo(file);
            streamProgress = new StreamProgressInfo(music);
            streamProgress = new StreamProgressInfo(music2);
            streamProgress = new StreamProgressInfo(file2);
        }
    }
}
