using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lids.library.Enums;
using lids.library.Transports;

namespace lids.library.Managers
{
    public class QueueManager
    {
        private readonly Queue<QueueTransportItem> _transportItems;

        public QueueManager()
        {
            _transportItems = new Queue<QueueTransportItem>();
        }

        public async Task<bool> AddToQueue(QUEUE_TYPE queueType, dynamic dataObject = null)
        {
            await Task.Run(() =>
            {
                _transportItems.Enqueue(new QueueTransportItem
                {
                    Data = dataObject,
                    QueueType = queueType
                });
            });

            return true;
        }

        public void ProcessQueue()
        {
            while (_transportItems.Any())
            {
                var item = _transportItems.Dequeue();

                switch (item.QueueType)
                {
                    case QUEUE_TYPE.LISTEN_FOR_CHANGES:
                        break;
                }
            }
        }
    }
}