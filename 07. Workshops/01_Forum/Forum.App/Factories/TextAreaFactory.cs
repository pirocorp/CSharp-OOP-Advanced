namespace Forum.App.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;

	using Contracts;

	public class TextAreaFactory : ITextAreaFactory
	{
		public ITextInputArea CreateTextArea(IForumReader reader, int x, int y, bool isPost = true)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var commandType = assembly.GetTypes().FirstOrDefault(t => typeof(ITextInputArea).IsAssignableFrom(t));

			if (commandType == null)
			{
				throw new InvalidOperationException("TextArea not found!");
			}

			var args = new object[] { reader, x, y, isPost};

			var commandInstance = (ITextInputArea)Activator.CreateInstance(commandType, args);

			return commandInstance;
		}
	}
}
