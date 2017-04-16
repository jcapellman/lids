using System.Collections.Generic;
using System.Linq;

using lids.library.DAL.Transports;
using lids.library.Enums;

using SQLite;

namespace lids.library.DAL
{
    public class SQLiteDAL : BaseDAL
    {
        private Queue<QueueItem> _queueItems;

        public SQLiteDAL(string connectionString) : base(connectionString) { _queueItems = new List<QueueItem>(); }

        public override void Write<T>(T writeObject)
        {
            using (var sqlFactory = new SQLiteConnection(_connectionString))
            {
                sqlFactory.Insert(writeObject);                
            }
        }

        public override T Get<T>(int id)
        {
            return default(T);
        }

        public override void Delete<T>(T writeObject)
        {
            using (var sqlFactory = new SQLiteConnection(_connectionString))
            {
                sqlFactory.Delete(writeObject);
            }
        }

        private void processQueue()
        {
            while (_queueItems.Any()) {
                var item = _queueItems.Dequeue();

                switch (item.TransactionType)
                {
                    case DAL_TRANSACTION_TYPES.DELETE:
                        Delete(item.QueueObject);
                        break;
                    case DAL_TRANSACTION_TYPES.INSERT:
                        Write(item.QueueObject);
                        break;
                    case DAL_TRANSACTION_TYPES.UPDATE:
                        break;
                }
            }
        }
    }
}