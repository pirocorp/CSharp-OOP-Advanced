namespace RecyclingStation.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Interfaces.Core;
    using Interfaces.Models;
    using Interfaces.Models.GarbageDisposalStrategies;
    using Interfaces.Models.Wastes;
    using Interfaces.WasteDisposal;
    using Models;
    using Models.GarbageDisposalStrategies;
    using WasteDisposal;

    public class CommandHandler : ICommandHandler
    {
        private IManagementRequirement managementRequirement;

        public CommandHandler()
            :this(new RecyclingStation(), new GarbageProcessor())
        {
        }

        public CommandHandler(IRecyclingStation recyclingStation, IGarbageProcessor garbageProcessor)
        {
            this.RecyclingStation = recyclingStation;
            this.GarbageProcessor = garbageProcessor;
            this.managementRequirement = null;
            this.InitializeStrategies();
        }

        public IRecyclingStation RecyclingStation { get; private set; }

        public IGarbageProcessor GarbageProcessor { get; private set; }
        
        public string ProcessGarbage(params string[] argsStrings)
        {
            //ProcessGarbage {name}|{weight}|{volumePerKg}|{type}
            var waste = this.InstantiateWaste(argsStrings);

            if (this.managementRequirement != null && (
                this.managementRequirement.CapitalBalance > this.RecyclingStation.CapitalBalance ||
                this.managementRequirement.EnergyBalance > this.RecyclingStation.EnergyBalance ) && 
                this.managementRequirement.WasteType == waste.GetType())
            {
                return $"Processing Denied!";
            }

            var result = this.GarbageProcessor.ProcessWaste(waste);
            this.RecyclingStation.ApplyProcessingResult(result);

            return $"{waste.Weight:F2} kg of {waste.Name} successfully processed!";
        }

        public string Status()
        {
            return
                $"Energy: {this.RecyclingStation.EnergyBalance:F2} Capital: {this.RecyclingStation.CapitalBalance:F2}";
        }

        public string ChangeManagementRequirement(params string[] argsStrings)
        {
            //ChangeManagementRequirement {energyBalance}|{capitalBalance}|{garbageType}
            var energyBalance = double.Parse(argsStrings[0]);
            var capitalBalance = double.Parse(argsStrings[1]);

            var typeString = argsStrings[2];
            var wasteType = GetWasteType(typeString);

            var newManagementRequirement = new ManagementRequirement(energyBalance, capitalBalance, wasteType);
            this.managementRequirement = newManagementRequirement;

            return $"Management requirement changed!";
        }

        private IWaste InstantiateWaste(string[] argsStrings)
        {
            var name = argsStrings[0];
            var weight = double.Parse(argsStrings[1]);
            var volumePerKg = double.Parse(argsStrings[2]);
            var wasteType = GetWasteType(argsStrings[3]);

            var wasteObject = (IWaste)Activator.CreateInstance(wasteType, name, volumePerKg, weight);
            return wasteObject;
        }

        private static Type GetWasteType(string typeString)
        {
            var wasteType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == $"{typeString}Waste");

            if (wasteType == null)
            {
                throw new ArgumentException("Unsupported garbage type passed!");
            }

            return wasteType;
        }

        private void InitializeStrategies()
        {
            var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

            var disposableAttributeTypes = assemblyTypes
                .Where(a => a.Name.EndsWith("Attribute"))
                .Where(a => a.IsSubclassOf(typeof(DisposableAttribute)))
                .Select(a => new {Key = a.Name.Replace("Attribute", string.Empty), Attribute = a})
                .ToDictionary(a => a.Key, a => a.Attribute);

            var garbageDisposableStrategies = assemblyTypes
                .Where(g => g.Name.EndsWith("GarbageDisposalStrategy"))
                .Where(g => g.IsSubclassOf(typeof(GarbageDisposalStrategy)))
                .Select(g => new { Key = g.Name.Replace("GarbageDisposalStrategy", string.Empty), Strategy = g })
                .ToDictionary(a => a.Key, a => a.Strategy);

            foreach (var attribute in disposableAttributeTypes)
            {
                var attributeName = attribute.Key;
                var attributeType = attribute.Value;
                var strategyType = garbageDisposableStrategies[attributeName];
                var strategyInstance = (IGarbageDisposalStrategy)Activator.CreateInstance(strategyType);

                this.GarbageProcessor.StrategyHolder.AddStrategy(attributeType, strategyInstance);
            }
        }
    }
}