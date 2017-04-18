using lids.library;

namespace lids.app
{
    class Program
    {
        static void Main(string[] args)
        {
            var lm = new lidsmain("lids.db");

            lm.MainLoop();
        }
    }
}