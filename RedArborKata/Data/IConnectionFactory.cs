using System.Data;

namespace RedArborKata.Data
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
