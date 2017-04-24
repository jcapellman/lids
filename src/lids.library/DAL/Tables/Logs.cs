using System;

using SQLite;

namespace lids.library.DAL.Tables
{
    public class Logs
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime Timestamp { get; set; }
    }
}