using System;


namespace DatingApp.Models.Infrastructure.Tools
{
    public static class Converter
    {
        public static Int64 IPAddressToInt(string IPAddress)
        {
            if (IPAddress.Length < 6)
                IPAddress = "127.0.0.1";
            uint r = 0;
            foreach (string s in IPAddress.Split('.'))
                r = (r << 8) ^ (uint)UInt32.Parse(s);
            return Convert.ToInt32(r);
        }
    }
}