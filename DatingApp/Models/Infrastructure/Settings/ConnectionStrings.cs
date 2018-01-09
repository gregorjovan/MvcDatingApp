using System.Configuration;

namespace DatingApp.Models.Infrastructure.Settings
{
    public static class ConnectionStrings
    {
        public static string sqlUsers = ConfigurationManager.ConnectionStrings["sqlUsers"].ConnectionString;
        public static string sqlRegistrations = ConfigurationManager.ConnectionStrings["sqlRegistrations"].ConnectionString;
        public static string sqlSearch = ConfigurationManager.ConnectionStrings["sqlSearch"].ConnectionString;

    }
}