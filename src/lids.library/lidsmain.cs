using System.Net;
using System.Threading;

using lids.library.DAL;
using lids.library.Enums;
using lids.library.Managers;

namespace lids.library
{
    public class lidsmain
    {
        private SQLiteDAL _sqlLie;
        public static LogManager _logManager;
        private readonly QueueManager _queueManager;

        public lidsmain(string connectionString)
        {
            _logManager =new LogManager();
            _queueManager = new QueueManager();

            _sqlLie = new SQLiteDAL(connectionString);
        }

        public async void MainLoop()
        {
            var hostName = Dns.GetHostName();

            _logManager.WriteMessage($"Grabbing hostname...{hostName}");

            await _queueManager.AddToQueue(QUEUE_TYPE.RECORD_HOST_INFORMATION, hostName);

            while (_queueManager.IsRunning())
            {
                await _queueManager.AddToQueue(QUEUE_TYPE.LISTEN_FOR_CHANGES);

                _queueManager.ProcessQueue(); 
                
                Thread.Sleep(1000);
            }

            _logManager.FlushLog();
        }
    }
}