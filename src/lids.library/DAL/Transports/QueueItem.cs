using lids.library.Enums;

namespace lids.library.DAL.Transports
{
    public class QueueItem
    {
        public DAL_TRANSACTION_TYPES TransactionType { get; set; }

        public dynamic QueueObject { get; set; }
    }
}