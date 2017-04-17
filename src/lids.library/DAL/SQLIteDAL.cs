using System.Collections.Generic;
using System.Linq;

using lids.library.DAL.Transports;
using lids.library.Enums;

using SQLite;

namespace lids.library.DAL
{
    public class SQLiteDAL : BaseDAL
    {
        private readonly Queue<QueueItem> _queueItems;

        public SQLiteDAL(string connectionString) : base(connectionString) { _queueItems = new Queue<QueueItem>(); }

        public override void Write<T>(T writeObject)
        {
            addToQueue<T>(DAL_TRANSACTION_TYPES.INSERT, writeObject);
        }

        public override T Get<T>(int id)
        {
            return default(T);
        }

        public override void Delete<T>(T writeObject)
        {
            addToQueue<T>(DAL_TRANSACTION_TYPES.DELETE, writeObject);
        }

        private void addToQueue<T>(DAL_TRANSACTION_TYPES transactionType, dynamic obj = null)
        {
            _queueItems.Enqueue(new QueueItem
            {
                QueueObject = obj,
                TransactionType = transactionType
            });
        }

        private void write(dynamic obj)
        {
            using (var sqlFactory = new SQLiteConnection(_connectionString))
            {
                sqlFactory.Insert(obj);
            }
        }

        private void delete(dynamic obj)
        {
            using (var sqlFactory = new SQLiteConnection(_connectionString))
            {
                sqlFactory.Delete(obj);
            }
        }

        private void processQueue()
        {
            while (_queueItems.Any()) {
                var item = _queueItems.Dequeue();

                switch (item.TransactionType)
                {
                    case DAL_TRANSACTION_TYPES.DELETE:
                        delete(item.QueueObject);
                        break;
                    case DAL_TRANSACTION_TYPES.INSERT:
                        write(item.QueueObject);
                        break;
                    case DAL_TRANSACTION_TYPES.UPDATE:
                        break;
                }
            }
        }
    }
}