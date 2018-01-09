using DatingApp.Models.Repository.User.CompleteProfiles;
using System.Web;

namespace DatingApp.Models.Repository.User
{
    public struct SearchDetailItemView
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Introduction { get; set; }
        public string DescriptionLowRes { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public int SeekSex { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
    }

    public struct DatingUser
    {

    }

    public class SearchDetailItem
    {


        public static SearchDetailItemView Get(int userId)
        {
            UserProperties p;

            if (HttpContext.Current.Cache[userId.ToString()] == null)
            {
                p = new UserProperties();
                //p.Get();
                p.InsertIntoCache();
            }
            else
            {
                p = (UserProperties)HttpContext.Current.Cache[userId.ToString()];
            }

            SearchDetailItemView r = new SearchDetailItemView();
            //r.City=p.ci
            r.Username = p.Username;


            return r;
        }


        private static SearchDetailItemView GetFromCachePipeline(int userId)
        {
            SearchDetailItemView r = new SearchDetailItemView();

            if (HttpContext.Current.Cache[userId.ToString()] == null || (HttpContext.Current.Cache[userId.ToString()].GetType().ToString() != "Dating.Repository.DatingUser"))
            { }
            else
            {
                r = (SearchDetailItemView)HttpContext.Current.Cache[userId.ToString()];
            }

            return r;
        }
    }
}