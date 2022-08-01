namespace RedArbor.Data
{
    public interface IUnitOfWork
    {
        void Dispose();
        void SaveChanges();
    }
}
