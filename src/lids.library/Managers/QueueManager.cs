using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using lids.library.DAL;
using lids.library.Enums;
using lids.library.QueueTasks;
using lids.library.Transports;
using lids.library.Wrappers;

namespace lids.library.Managers
{
    public class QueueManager
    {
        private readonly Queue<QueueTransportItem> _transportItems;

        private readonly BaseDAL _dalObject;
        private bool _isRunning = true;

        private TaskWrapper Wrapper => new TaskWrapper
        {
            DAL = _dalObject
        };

        public QueueManager(BaseDAL dalObject)
        {
            _dalObject = dalObject;
            _transportItems = new Queue<QueueTransportItem>();
        }

        public bool AddToQueue(QUEUE_TYPE queueType, dynamic dataObject = null)
        {
            _transportItems.Enqueue(new QueueTransportItem
            {
                Data = dataObject,
                QueueType = queueType
            });

            return true;
        }

        public bool IsRunning() => _isRunning;

        private BaseQueueTask getQueueTask(QUEUE_TYPE queueType) => (from task in Assembly.GetEntryAssembly().GetTypes()
                                                                     where task == typeof(BaseQueueTask)
                                                                     select (BaseQueueTask) Activator.CreateInstance(task, Wrapper)).FirstOrDefault(obj => 
                                                                     obj.GetQueueType() == queueType);

        public void ProcessQueue()
        {
            while (_transportItems.Any())
            {
                var item = _transportItems.Dequeue();

                switch (item.QueueType)
                {
                    case QUEUE_TYPE.END_PROCESSING:
                        _isRunning = false;
                        break;
                    default:
                        var task = getQueueTask(item.QueueType);

                        if (task == null)
                        {
                            continue;
                        }

                        task.ProcessTask();

                        break;
                }
            }
        }
    }
}