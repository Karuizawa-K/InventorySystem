using System.Configuration;

namespace InventorySystem
{
    public static class DB
    {
        public static string conStr = ConfigurationManager
            .ConnectionStrings["InventoryDB"].ConnectionString;
    }
}