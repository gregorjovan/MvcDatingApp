using System.Collections.Generic;

namespace DatingApp.Models.Repository.User
{
    public class UserProperties
    {
        public UserProperties()
        { }

        public List<int> Bodyart { get; set; }
        public int Look { get; set; }
        public List<int> FreeTimeFavorite { get; set; }
        public List<int> Hobbies { get; set; }
        public List<int> Sport { get; set; }
        public List<int> Music { get; set; }
        public int Exercise { get; set; }
        public int Body { get; set; }
        public List<int> Diet { get; set; }
        public int Smoking { get; set; }
        public int Drinking { get; set; }
        public int Profession { get; set; }
        public int Salary { get; set; }
        public int Education { get; set; }
        public int Ethnicity { get; set; }
        public int Religion { get; set; }
        public List<int> FashionStyle { get; set; }
        public int Hair { get; set; }
        public int Eyes { get; set; }
        public int Figure { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public int Sex { get; set; }
        public int SeekSex { get; set; }
        public int City { get; set; }
        public int Country { get; set; }
        public string Introduction { get; set; }
        public int Sign { get; set; }
        public List<int> Relationship { get; set; }
        public int Status { get; set; }
        public int StatusPartner { get; set; }
        public int KidsHave { get; set; }
        public int KidsWant { get; set; }
        public int Kids { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public string DescriptionLowResolution { get; set; }

        public void Get(int userId) { }
        public void InsertIntoCache() { }
    }
}