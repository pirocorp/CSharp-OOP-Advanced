namespace RecyclingStation.Models
{
    using System;
    using Interfaces.Models;

    public class ManagementRequirement : IManagementRequirement
    {
        public ManagementRequirement(double energyBalance, double capitalBalance, Type wasteType)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
            this.WasteType = wasteType;
        }

        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }

        public Type WasteType { get; private set; }
    }
}