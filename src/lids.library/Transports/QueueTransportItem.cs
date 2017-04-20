using lids.library.Enums;

namespace lids.library.Transports
{
    public class QueueTransportItem
    {
        public QUEUE_TYPE QueueType { get; set; }

        public dynamic Data { get; set; }
    }
}