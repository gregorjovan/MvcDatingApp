using DatingApp.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DatingApp.Models.Search
{
    public class SearchEngine
    {
        private static Object thisLock = new Object();

        public static int counter;

        public static int[] results(int agemin, int agemax, int relationship, int sign, int ethnicity, int eyes, int page, out string speed)
        {

            HiPerfTimer t = new HiPerfTimer();
            int startRecord = ((page - 1) * 15);
            int stopRecord = 15;


            IEnumerable<int> x = null;
            int[] xx = new int[16];

            SimpleSearchItem[][][] elementi;

            if (HttpContext.Current.Cache["SearchItems"] == null)
            {
                elementi = (SimpleSearchItem[][][])HttpContext.Current.Cache["SearchItemsBackup"];
            }
            else
            {
                elementi = (SimpleSearchItem[][][])HttpContext.Current.Cache["SearchItems"];
            }

            t.Start();


            //lock (thisLock)
            //{
            //xx = ((from a in elementi where a.age > agemin && a.age < agemax & a.relationship.Contains(relationship) && (sign == 0 || a.sign == sign) && a.ethnicity == ethnicity && (eyes == 0 || a.eyes == eyes) select a.userId).Skip(startRecord).Take(stopRecord)).ToArray();

            int foundrecords = 0;
            int counter = 0;
            int z = elementi.Count();
            int ss = startRecord + stopRecord;
            for (int i = 0; i < z; i++)
            {
                SimpleSearchItem s = elementi[0][1][i];
                if (s.age > agemin && s.age < agemax)
                {
                    if (s.relationship.Contains(relationship) && (sign == 0 || s.sign == sign) && s.ethnicity == ethnicity)
                    {
                        if (foundrecords >= startRecord)
                        {
                            xx[counter] = s.userId;
                            counter = counter + 1;


                        }
                        foundrecords = foundrecords + 1;

                        if (foundrecords > ss)
                        {
                            break;
                        }
                    }
                }
            }
            //}
            t.Stop();


            speed = ((t.Duration) * 1000000).ToString();

            return xx;
        }
    }
}