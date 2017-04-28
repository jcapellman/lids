using lids.library.Enums;
using lids.library.Wrappers;

namespace lids.library.QueueTasks
{
    public abstract class BaseQueueTask
    {
        protected TaskWrapper Wrapper;
        
        protected BaseQueueTask(TaskWrapper wrapper)
        {
            Wrapper = wrapper;
        }

        public abstract QUEUE_TYPE GetQueueType();

        public abstract TASK_PROCESS_RESPONSE ProcessTask();
    }
}