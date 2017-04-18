using SQLite;

namespace lids.library.DAL.Tables
{
    public class Devices
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string IPAddress { get; set; }
    }
}