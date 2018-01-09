using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Caching;
using System.Diagnostics;
using DatingApp.Models.User.Profile.Properties;
using DatingApp.Models.Infrastructure;

namespace DatingApp.Models.SqlRepository
{
    public static class Users
    {
        public static string Username(int userId)
        {
            string r = "";

            return r;
        }
        public static Dictionary<int, Interests> vsix()
        {
            Dictionary<int, Interests> vsi = new Dictionary<int, DatingApp.Models.User.Profile.Properties.Interests>();

            return vsi;
        }

        public static Dictionary<int, DatingApp.Models.User.Profile.Properties.Interests> vsi = vsix();

        public static PropertyItem[][] ia3()
        {
            PropertyItem p = new PropertyItem();
            p.CultureId = 1;
            p.Value = "678iuohiuo  uo z uoz ";
            p.Text = "ijpnobn";

            PropertyItem[][] ia2 = new PropertyItem[4][];

            for (int ii = 0; ii < 4; ii++)
            {
                ia2[ii] = new PropertyItem[10];

                for (int z = 0; z < 10; z++)
                {

                    ia2[ii][z] = p;

                }

            }
            return ia2;
        }

        public static PropertyItem[][] ia = ia3();

        public static void test()
        {
            string[] vx = new string[1000];
            List<string> vy = new List<string>();

            for (int i = 0; i < vx.Length; i++)
            {
                vx[i] = "2";
                vy.Add("2");
            }

            HiPerfTimer o1 = new HiPerfTimer();
            HiPerfTimer o2 = new HiPerfTimer();

            o2.Start();
            for (int i = 0; i < vy.Count; i++)
            {
                string s = vy[i];
            }
            o2.Stop();
            o1.Start();
            for (int i = 0; i < vx.Length; i++)
            {
                string s = vx[i];
            }
            o1.Stop();




            string h1 = (o1.Duration * 1000000).ToString();
            string h2 = (o2.Duration * 1000000).ToString();







            HiPerfTimer o = new HiPerfTimer();
            PropertyItem bb = new PropertyItem();
            o.Start();
            PropertyItem[] hs = new PropertyItem[10]; ;
            //= new PropertyItem[10];
            //List<PropertyItem> ea = new List<PropertyItem>();

            hs = ia[3];

            o.Stop();
            //            ia = null;
            for (int i = 0; i < hs.Length; i++)
            { }
            string h = (o.Duration * 1000000).ToString();

            DatingApp.Models.User.Profile.Properties.Interests a = new DatingApp.Models.User.Profile.Properties.Interests();

            a.FreeTimeFavorite = new List<int> { 1, 4, 5, 7 };
            a.Hobbies = new List<int> { 11, 14, 15, 17 };
            a.Music = new List<int> { 11, 14, 15, 17 };
            a.Sport = new List<int> { 11, 14, 15, 17 };


            Dictionary<int, DatingApp.Models.User.Profile.Properties.Interests> aaa = new Dictionary<int, DatingApp.Models.User.Profile.Properties.Interests>();
            for (int i = 0; i < 500000; i++)
            {

                //HttpContext.Current.Cache.Insert(i.ToString(), a, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(30));
                //DatingEngine.InProcessCache.vsid.Add(i, "mucuc je šla na morje in je srečala starga mačkaa mucuc je šla na morje in je srečala starga mačkaa");
            }
            //HttpContext.Current.Cache.Insert("1s", aaa, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(3));


        }

        public static void Fetch()
        {

            Dictionary<int, string> a;// = new Dictionary<int, string>();
            DatingApp.Models.User.Profile.Properties.Interests n;
            DatingApp.Models.User.Profile.Properties.Interests n2;
            Dictionary<int, DatingApp.Models.User.Profile.Properties.Interests> b;

            Stopwatch s1 = new Stopwatch();
            Stopwatch s2 = new Stopwatch();

            s1.Start();
            b = (Dictionary<int, DatingApp.Models.User.Profile.Properties.Interests>)HttpContext.Current.Cache["1"];
            n = b[490000];
            b.TryGetValue(480000, out n);

            s1.Stop();
            s2.Start();


            vsi.TryGetValue(480000, out n2);

            s2.Stop();

            long s1sec = s1.ElapsedMilliseconds;
            long s1ti = s1.ElapsedTicks;
            long s2sec = s2.ElapsedMilliseconds;
            long s2ti = s2.ElapsedTicks;


            s1.Reset();
        }
    }
}