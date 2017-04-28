using lids.library.DAL.Tables;
using lids.library.Enums;

namespace lids.library.QueueTasks
{
    public class HostInformationTask : BaseQueueTask
    {
        public override QUEUE_TYPE GetQueueType() => QUEUE_TYPE.RECORD_HOST_INFORMATION;

        public override dynamic ProcessTask()
        {
            return new HostInformation();
        }
    }
}