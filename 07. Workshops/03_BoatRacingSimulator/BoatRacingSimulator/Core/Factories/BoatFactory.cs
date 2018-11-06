namespace BoatRacingSimulator.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class BoatFactory : IBoatFactory
    {
        public IBoat CreateBoat(string boatModel, params object[] args)
        {
            //Create{boatModel}
            var assembly = Assembly.GetExecutingAssembly();

            boatModel = boatModel.Remove(0, "Create".Length);

            var boatModelType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == $"{boatModel}");

            if (boatModelType == null)
            {
                throw new InvalidOperationException($"{boatModel} not found!");
            }

            if (!typeof(IBoat).IsAssignableFrom(boatModelType))
            {
                throw new InvalidOperationException($"{boatModel} is not a {nameof(IBoat)}!");
            }

            var boat = (IBoat)Activator.CreateInstance(boatModelType, args);
            return boat;
        }
    }
}