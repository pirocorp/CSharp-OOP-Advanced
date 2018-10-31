namespace P06_1984.Interfaces
{
    public interface IEntityFactory
    {
        IEntity CreateEntity(params string[] entityData);
    }
}