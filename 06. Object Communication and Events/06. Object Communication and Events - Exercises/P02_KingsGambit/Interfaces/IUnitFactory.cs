namespace P02_KingsGambit.Interfaces
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType, string name);
    }
}