using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DatingApp.Models.SqlRepository
{
    public struct PropertyItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public int CultureId { get; set; }
    }

    public struct CityItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public int CultureId { get; set; }
        public int CountryId { get; set; }
    }

    public static class UsersProperties
    {
        public static List<PropertyItem> Sex(int cultureId)
        {
            lock (Properties.Sex)
            {
                var x = from a in Properties.Sex where a.CultureId == cultureId select a;
                return x.ToList<PropertyItem>();
            }

        }

        public static List<PropertyItem> SeekSex(int cultureId)
        {
            var x = from a in Properties.SeekSex where a.CultureId == cultureId select a;
            return x.ToList<PropertyItem>();
        }

        public static List<PropertyItem> Sign(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Sign where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Countries(int cultureId, bool addDefault)
        {
            var x = from a in Properties.Countries where a.CultureId == cultureId select a;
            return x.ToList<PropertyItem>();
        }

        public static List<CityItem> Cities(int cultureId, int countryId, bool addDefault)
        {
            List<CityItem> r = new List<CityItem>();

            var x = from a in Properties.Cities where a.CultureId == cultureId && a.CountryId == countryId select a;
            r = x.ToList<CityItem>();

            if (addDefault)
            {
                CityItem defaultItem = new CityItem();

                defaultItem.Text = Resources.Labels.Labels.Select;
                defaultItem.Value = "0";

                r.Insert(0, defaultItem);
            }

            return r;
        }

        public static List<PropertyItem> Days()
        {
            List<PropertyItem> r = new List<PropertyItem>();
            PropertyItem defaultItem = new PropertyItem();

            var x = from a in Properties.Days select a;
            r = x.ToList<PropertyItem>();

            defaultItem.Text = Resources.Labels.Labels.Day;
            defaultItem.Value = "0";

            r.Insert(0, defaultItem);

            return r;
        }

        public static List<PropertyItem> Months(int cultureId)
        {
            List<PropertyItem> r = new List<PropertyItem>();
            PropertyItem defaultItem = new PropertyItem();

            var x = from a in Properties.Months where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();
            defaultItem.Text = Resources.Labels.Labels.Month;
            defaultItem.Value = "0";
            defaultItem.CultureId = cultureId;

            r.Insert(0, defaultItem);;

            return r;
        }

        public static List<PropertyItem> Year()
        {
            List<PropertyItem> r = new List<PropertyItem>();
            PropertyItem defaultItem = new PropertyItem();

            var x = from a in Properties.Year select a;
            r = x.ToList<PropertyItem>();

            defaultItem.Text = Resources.Labels.Labels.Year;
            defaultItem.Value = "0";
            //defaultItem.CultureId = cultureId;

            r.Insert(0, defaultItem);;

            return r;
        }

        public static List<PropertyItem> Height()
        {
            List<PropertyItem> r = new List<PropertyItem>();            

            var x = from a in Properties.Height select a;
            r = x.ToList<PropertyItem>();

            AddDefaultItem(r, true);            

            return r;
        }

        public static List<PropertyItem> Relationships(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Relationships where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> FashionStyles(int cultureId, bool addDefault)
        {

            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.FashionStyles where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Drinkings(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Drinkings where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Smokings(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Smokings where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Figures(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Figures where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Eyes(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Eyes where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Hair(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Hair where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Body(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Body where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Bodyart(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Bodyart where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Look(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Look where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Ethnicities(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Ethnicity where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Educations(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Educations where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Religions(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Religions where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Profession(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Profession where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Salary(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Salary where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Diets(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Diets where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> FreeTimeFavorites(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.FreeTimeFavorites where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Hobbies(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Hobbies where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Sports(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Sports where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Music(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Music where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Statuses(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Statuses where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> StatusesPartner(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.StatusesPartner where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Kids(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Kids where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> KidsHave(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.KidsHave where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> KidsWant(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.KidsWant where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();

            UsersProperties.AddDefaultItem(r, addDefault);

            return r;
        }

        public static List<PropertyItem> Excercise(int cultureId, bool addDefault)
        {
            List<PropertyItem> r = new List<PropertyItem>();

            var x = from a in Properties.Excercise where a.CultureId == cultureId select a;
            r = x.ToList<PropertyItem>();
            
            UsersProperties.AddDefaultItem(r, addDefault);          

            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// TODO: Preveri, če je ok, da se zgenerira instanca objekta v statični metodi
        /// <returns></returns>
        private static PropertyItem DefaultItem()
        {
            PropertyItem r = new PropertyItem
            {
                Text = Resources.Labels.Labels.Select,
                Value = "0"
            };

            return r;
        }

        private static List<PropertyItem> AddDefaultItem(List<PropertyItem> p, bool addDefault)
        {
            if (addDefault)
            {
                p.Insert(0, UsersProperties.DefaultItem());
            }

            return p;
        }
    }
}