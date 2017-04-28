using lids.library.Enums;

namespace lids.library.QueueTasks
{
    public abstract class BaseQueueTask
    {
        public abstract QUEUE_TYPE GetQueueType();

        public abstract dynamic ProcessTask();
    }
}