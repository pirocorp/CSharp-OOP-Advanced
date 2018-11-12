namespace RecyclingStation.Interfaces.Models
{
    using System;

    public interface IManagementRequirement
    {
        double CapitalBalance { get; }

        double EnergyBalance { get; }

        Type WasteType { get; }
    }
}