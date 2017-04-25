using System;

using lids.library.Enums;

using SQLite;

namespace lids.library.DAL.Tables
{
    public class Logs
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime Timestamp { get; set; }

        public QUEUE_TYPE QueueType { get; set; }

        public string Content { get; set; }
    }
}