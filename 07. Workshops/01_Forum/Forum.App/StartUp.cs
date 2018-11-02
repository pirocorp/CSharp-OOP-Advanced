namespace Forum.App
{
	using System;
	using Microsoft.Extensions.DependencyInjection;
	using Contracts;
	using Data;
	using Factories;
	using Models;
	using Services;

    public class StartUp
	{
		public static void Main(string[] args)
		{
		    var serviceProvider = ConfigureServices();
			var menu = serviceProvider.GetService<IMainController>();

			var engine = new Engine(menu);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices()
		{
			IServiceCollection services = new ServiceCollection();

            //Adding all of Factories as singletons
		    services.AddSingleton<ITextAreaFactory, TextAreaFactory>();
		    services.AddSingleton<ILabelFactory, LabelFactory>();
		    services.AddSingleton<IMenuFactory, MenuFactory>();
            services.AddSingleton<ICommandFactory, CommandFactory>();

            //Adding ForumData as singleton
		    services.AddSingleton<ForumData>();

            //Adding Services as transients
		    services.AddTransient<IPostService, PostService>();
		    services.AddTransient<IUserService, UserService>();

            //Adding Session, ForumViewEngine and MenuController as singleton
		    services.AddSingleton<ISession, Session>();
		    services.AddSingleton<IForumViewEngine, ForumViewEngine>();
		    services.AddSingleton<IMainController, MenuController>();

            //Adding ForumConsoleReader as transient
		    services.AddTransient<IForumReader, ForumConsoleReader>();

		    var serviceProvider = services.BuildServiceProvider();
		    return serviceProvider;
		}
	}
}