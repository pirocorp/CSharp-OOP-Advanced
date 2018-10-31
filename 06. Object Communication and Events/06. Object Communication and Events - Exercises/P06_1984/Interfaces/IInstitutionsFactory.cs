namespace P06_1984.Interfaces
{
    public interface IInstitutionsFactory
    {
        IInstitution CreateInstitution(string[] institutionData);
    }
}