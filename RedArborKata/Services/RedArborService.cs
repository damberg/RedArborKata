using RedArborKata.Data;

namespace RedArborKata.Services
{
    public class RedArborService<T>
    {
        private Repo<T> _repo;
        private IConnectionFactory _connectionFactory;
        private DbContext _context;

        public RedArborService()
        {            
            _connectionFactory = ConnectionHelperService.GetConnection();
            _context = new DbContext(_connectionFactory);
            _repo = new Repo<T>(_context);
        }

        public object get() => _repo.GetAll().ToList();

        public object GetByID(int id) => _repo.GetByID(id);

        public object Create(T model) => _repo.Create(model);

        public void Update(int id, T model) => _repo.Update(id, model);

        public void Delete(int id) => _repo.Delete(id);
    }
}
