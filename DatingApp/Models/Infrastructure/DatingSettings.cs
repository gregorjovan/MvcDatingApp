using System;
using System.Configuration;

namespace DatingApp.Models.Infrastructure
{
    public static class DatingSettings
    {
        public static int UsernameMinLenght = Convert.ToInt32(ConfigurationManager.AppSettings["UsernameMinLenght"]);
        public static int UsernameMaxLenght = Convert.ToInt32(ConfigurationManager.AppSettings["UsernameMaxLenght"]);
        public static int PasswordMinLenght = Convert.ToInt32(ConfigurationManager.AppSettings["PasswordMinLenght"]);
        public static int PasswordMaxLenght = Convert.ToInt32(ConfigurationManager.AppSettings["PasswordMaxLenght"]);
        public static int HeightMin = Convert.ToInt32(ConfigurationManager.AppSettings["HeightMin"]);
        public static int HeightMax = Convert.ToInt32(ConfigurationManager.AppSettings["HeightMax"]);
        public static int IntroductionMinLenght = Convert.ToInt32(ConfigurationManager.AppSettings["IntroductionMinLenght"]);
        public static int IntroductionMaxLenght = Convert.ToInt32(ConfigurationManager.AppSettings["IntroductionMaxLenght"]);

        public static string RegexUsername = "([a-zA-Z0-9]{" + UsernameMinLenght.ToString() + "," + UsernameMaxLenght.ToString() + "})$";

    }
}