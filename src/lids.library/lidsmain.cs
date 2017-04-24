using System.Net;

using lids.library.DAL;
using lids.library.Managers;

namespace lids.library
{
    public class lidsmain
    {
        private SQLiteDAL _sqlLie;
        public static LogManager _logManager;

        public lidsmain(string connectionString)
        {
            _logManager = new LogManager();

            _sqlLie = new SQLiteDAL(connectionString);
        }

        public void MainLoop()
        {
            var hostName = Dns.GetHostName();
            
            _logManager.WriteMessage($"Grabbing hostname...{hostName}");
            
            while (true)
            {
                // Check for changes and process
                   
            }

            _logManager.FlushLog();
        }
    }
}