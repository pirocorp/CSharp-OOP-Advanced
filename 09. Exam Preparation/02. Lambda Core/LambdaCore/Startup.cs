namespace LambdaCore
{
    using System;
    using Core;
    using Core.Controllers;
    using Core.Factories;
    using Core.FactoryHandlers;
    using Interfaces;
    using Interfaces.Controllers;
    using Interfaces.Core.Factories;
    using Interfaces.Core.FactoryHandlers;
    using Interfaces.IO;
    using IO;
    using Microsoft.Extensions.DependencyInjection;
    using Models.Fragments;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var lambdaController = serviceProvider.GetService<ILambdaCoreController>();
            var reader = serviceProvider.GetService<IReader>();
            var writer = serviceProvider.GetService<IWriter>();

            IEngine engine = new Engine(lambdaController, reader, writer);
            engine.Run();

        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<ICoreFactory, CoreFactory>();
            services.AddTransient<ICoreFactoryHandler, CoreFactoryHandler>();
            services.AddTransient<IFragmentsFactory, FragmentsFactory>();
            services.AddTransient<IFragmentsFactoryHandler, FragmentsFactoryHandler>();
            services.AddTransient<IReader, ConsoleReader>();
            services.AddTransient<IWriter, ConsoleWriter>();
            services.AddTransient<IEngine, Engine>();

            services.AddSingleton<ILambdaCoreController, LambdaCoreController>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}