using lids.library.DAL;

namespace lids.library
{
    public class lidsmain
    {
        private SQLiteDAL _sqlLie;

        public lidsmain(string connectionString)
        {
            _sqlLie = new SQLiteDAL(connectionString);
        }

        public void MainLoop()
        {
            while (true)
            {
                // Check for changes and process
            }
        }
    }
}