namespace P06_1984.Interfaces
{
    public interface IInstitution
    {
        int Id { get; }
        string Name { get; set; }

        void RegisterInterest(string interest, object entity);
        string ReportChanges();
    }
}