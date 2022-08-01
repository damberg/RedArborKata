namespace RedArborKata.Data
{
    public interface IUnitOfWork
    {
        void Dispose();
        void SaveChanges();
    }
}
