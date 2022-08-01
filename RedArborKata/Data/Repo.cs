using System.Data;

namespace RedArborKata.Data
{
    public class Repo<T>
    {        
        private DbContext _context;

        public Repo(DbContext context) 
        {
            _context = context;
        }

		public IEnumerable<T> GetAll()
        {
           
            using (var command = _context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {typeof(T).Name}";

                return this.Execute(command);
            }
        }

        public IEnumerable<T> GetByID(int id)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE id = {id}";

                return this.Execute(command);
            }
        }

        public IEnumerable<T> GetLast()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = $"SELECT TOP (1) * FROM {typeof(T).Name} order by id desc";

                return this.Execute(command);
            }
        }

        public IEnumerable<T> Create(T model)
        {           
            using (var command = _context.CreateCommand())
            {
                var sql = $"INSERT INTO {model.GetType().Name}" +
                    " values " + "(";


                Type t = model.GetType();

                 var myPropertyInfo = t.GetProperties();

                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    if (myPropertyInfo[i].PropertyType.Name.Equals("String"))
                        sql += "'" + myPropertyInfo[i].GetValue(model).ToString() + "',";
                    else
                        sql += myPropertyInfo[i].GetValue(model).ToString() + ",";
                }

                command.CommandText = sql.Substring(0, sql.Length -1) + ")";

                this.Execute(command);

                return GetLast();
            }
        }

        public void Update(int id, T model)
        {
            using (var command = _context.CreateCommand())
            {


                var sql = $"Update {typeof(T).Name} SET "; 
                 Type tipe = model.GetType();

                var myPropertyInfo = tipe.GetProperties();

                for (int i = 0; i < myPropertyInfo.Length; i++)
                {
                    sql += myPropertyInfo[i].Name + " = ";
                    
                    if (myPropertyInfo[i].PropertyType.Name.Equals("String"))
                        sql += "'" + myPropertyInfo[i].GetValue(model).ToString() + "',";
                    else
                        sql += myPropertyInfo[i].GetValue(model).ToString() + ",";
                }

                sql = sql.Substring(0, sql.Length -1);

                sql += $" where id = {id}";

                command.CommandText = sql;
                
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE id = {id}";

                command.ExecuteNonQuery();
            }
        }

        protected IEnumerable<T> Execute(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<T> items = new List<T>();
                while (record.Read())
                {
                    items.Add(Map<T>(record));
                }
                return items;
            }
        }

        protected T Map<T>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (!record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);
            }
            return objT;
        }
    }
}