using lids.library.Enums;
using lids.library.Wrappers;

namespace lids.library.QueueTasks
{
    public class HostInformationTask : BaseQueueTask
    {
        public HostInformationTask(TaskWrapper wrapper) : base(wrapper)
        {
        }

        public override QUEUE_TYPE GetQueueType() => QUEUE_TYPE.RECORD_HOST_INFORMATION;

        public override TASK_PROCESS_RESPONSE ProcessTask()
        {

            return TASK_PROCESS_RESPONSE.SUCCESS;
        }
    }
}