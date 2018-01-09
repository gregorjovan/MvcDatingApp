using DatingApp.Models.SqlRepository;
using System.Collections.Generic;


namespace DatingApp.Models.Repository.User
{
    public class UserPropertiesCacheItem
    {
        #region Data members

        public string Username { get; set; }
        public int UserId { get; set; }
        public List<int> Relationship { get; set; }
        public int Status { get; set; }
        public int StatusPartner { get; set; }
        public int KidsHave { get; set; }
        public int KidsWant { get; set; }
        public int Kids { get; set; }

        public int Height { get; set; }
        public int Figure { get; set; }
        public int Eyes { get; set; }
        public int Hair { get; set; }
        public int Body { get; set; }
        public List<int> Bodyart { get; set; }
        public int Look { get; set; }

        public List<int> FreeTimeFavorite { get; set; }
        public List<int> Hobbies { get; set; }
        public List<int> Sport { get; set; }
        public List<int> Music { get; set; }

        public int Exercise { get; set; }
        public List<int> Diet { get; set; }
        public List<int> FashionStyle { get; set; }
        public int Smoking { get; set; }
        public int Drinking { get; set; }

        public int Profession { get; set; }
        public int Salary { get; set; }
        public int Education { get; set; }
        public int Ethnicity { get; set; }
        public int Religion { get; set; }

        public string UserUsername { get; set; }
        public string DescriptionLowResolution { get; set; }

        #endregion

        #region Constructor
        public UserPropertiesCacheItem()
        { }

        public UserPropertiesCacheItem(int userId)
        { }

        #endregion

        public void Get()
        {
            UserSearchProperties user = new UserSearchProperties(this.UserId);

            user.Get();

            this.Relationship = user.BasicProperties.Relationship;
            this.Status = user.BasicProperties.Status;

        }



    }
}