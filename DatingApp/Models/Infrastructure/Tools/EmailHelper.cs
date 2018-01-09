using System;
using System.Net.Mail;

namespace DatingApp
{
    public static class EmailHelper
    {
        public static bool EmailIsValid(string email)
        {
            bool r = true;

            try
            {
                MailAddress adr = new MailAddress(email);
            }
            catch (Exception e)
            {
                r = false;
            }

            return r;
        }

        public static void ExtractEmail(string EmailAddress, out string User, out string Host, out string DisplayName)
        {
            MailAddress adr = new MailAddress(EmailAddress);

            User = adr.User;
            Host = adr.Host;
            DisplayName = adr.DisplayName;
        }


    }
}
