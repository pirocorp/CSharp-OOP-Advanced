namespace P01_Logger.Files
{
    using System.IO;
    using System.Text;
    using System.Linq;

    public class LogFile
    {
        private readonly StringBuilder log;
        private readonly StreamWriter fileWriter;

        public LogFile()
        {
            this.log = new StringBuilder();
            this.fileWriter = new StreamWriter("log.txt", true);
        }

        public void Write(string content)
        {
            this.log.AppendLine(content);
            this.fileWriter.WriteLine(content);
            this.fileWriter.AutoFlush = true;
        }

        public int Size => this.log.ToString()
            .Where(char.IsLetter)
            .Select(x => (int) x)
            .Sum();

        //public char[] Chars => this.log.ToString()
        //    .Where(char.IsLetter)
        //    .ToArray();

        public void Close()
        {
            this.fileWriter.Close();
        }
    }
}