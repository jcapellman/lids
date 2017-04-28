namespace lids.library.DAL
{
    public abstract class BaseDAL
    {
        protected string _connectionString;

        protected BaseDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public abstract void Write<T>(T writeObject);

        public abstract T Get<T>(int id);

        public abstract void Delete<T>(T writeObject);       
    }
}