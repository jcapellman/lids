using SQLite;

namespace lids.library.DAL.Tables
{
    public class HostInformation
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        public string MACAddress { get; set; }
    }
}