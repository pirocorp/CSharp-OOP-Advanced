namespace Travel.Core.IO
{
    using System;
    using Contracts;

	public class ConsoleWriter : IWriter
	{
		public void WriteLine(string contents)
		{
		    //Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(contents);
		    //Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void Write(string contents)
		{
			Console.Write(contents);
		}
	}
}