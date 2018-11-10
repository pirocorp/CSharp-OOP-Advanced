namespace LambdaCore.Interfaces.Models
{
    using Enums;

    public interface IFragment
    {
        string Name { get; }

        FragmentType Type { get; }

        int PressureAffection { get; }
    }
}