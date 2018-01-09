using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Caching;
using DatingApp.Models.Infrastructure;

namespace DatingApp.Models.Search
{
    public class SearchCacheEngine
    {

        #region Data members

        const int ReloadTimeInterval = 10;
        #endregion

        public static void InitializeSearchCache()
        {
            SearchCacheEngine.HandleSearchItems();
            //earchCacheEngine.HandleUsersByLastVisit();            
        }

        //public static void UsersByLastVisitRemoved(string key, object value, CacheItemRemovedReason reason)
        //{
        //    SearchCacheEngine.HandleUsersByLastVisit();
        //}

        private static void SearchItemsRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            SearchCacheEngine.HandleSearchItems();
        }

        //private static void HandleUsersByLastVisit()
        //{
        //    CacheItemRemovedCallback removalOrderByLastVisit;
        //    removalOrderByLastVisit = new CacheItemRemovedCallback(UsersByLastVisitRemoved);

        //    SearchListGenerator g = new SearchListGenerator();
        //    OrderItem[] o = g.UsersByLastVisit;


        //    HttpRuntime.Cache.Insert("ByLastVisit", o, null, DateTime.UtcNow.AddSeconds(OrderTimeInterval), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, removalOrderByLastVisit);
        //    HttpRuntime.Cache.Insert("ByLastVisitBackup", o, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);

        //    SearchItem[] elementi = (SearchItem[])HttpRuntime.Cache["SearchItems"];
        //    OrderItem[] ox = (OrderItem[])HttpRuntime.Cache["ByLastVisit"];
        //    OrderItem[] ox2 = (OrderItem[])HttpRuntime.Cache["ByLastVisitBackup"];

        //    var x = from a in elementi join ee in ox on a.userId equals ee.UserId where a.age > 18 && a.age < 99 & a.relationship.Contains(5) && (a.sign == 1) && a.ethnicity == 170 && (a.eyes == 70) orderby ee.Row ascending select a.userId;
        //    var x2 = from a in elementi join ee in ox2 on a.userId equals ee.UserId where a.age > 18 && a.age < 99 & a.relationship.Contains(5) && (a.sign == 1) && a.ethnicity == 170 && (a.eyes == 70) orderby ee.Row ascending select a.userId;

        //    SearchEngine.counter = SearchEngine.counter + 1;            
        //}

        private static void HandleSearchItems()
        {
            HiPerfTimer t = new HiPerfTimer();

            CacheItemRemovedCallback removalSearchItems;
            removalSearchItems = new CacheItemRemovedCallback(SearchItemsRemoved);

            t.Start();
            SearchListGenerator g = new SearchListGenerator();
            SimpleSearchItem[][][] o = g.SimpleSearchCache();
            t.Stop();

            timer = (t.Duration * 1000000).ToString();

            HttpRuntime.Cache.Insert("SearchItems", o, null, DateTime.Now.AddSeconds(ReloadTimeInterval), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, removalSearchItems);
            HttpRuntime.Cache.Insert("SearchItemsBackup", o, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
            SearchEngine.counter = SearchEngine.counter + 1;
        }

        public static int Counter = 0;

        public static string timer = string.Empty;
    }
}
