using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DatingApp.Models.Repository.User.CompleteProfiles
{
    public enum Categories
    {
        Relationship = 4,
        Status = 5,
        StatusPartner = 7,
        KidsHave = 8,
        Kids = 10,
        KidsWant = 11,
        Excercise = 12,
        Diet = 13,
        FashionStyle = 14,
        Smoking = 15,
        Drinking = 16,
        Figure = 19,
        Eyes = 20,
        Hair = 21,
        BestBodyFeature = 22,
        Bodyart = 23,
        Look = 24,
        FreeTimeFavorite = 25,
        Hobbies = 26,
        Sport = 27,
        Music = 28,
        Profession = 29,
        Salary = 30,
        Education = 31,
        Ethnicity = 32,
        Religion = 34

    }

    public struct PropertiesContainer
    {
        public int PropertyId;
        public int CategoryId;
    }

    public class UserProperties
    {
        #region Data members

        public string Username { get; set; }
        public int UserId { get; set; }
        public int Sex { get; set; }
        public int SeekSex { get; set; }
        public int City { get; set; }
        public int Country { get; set; }

        public int Sign { get; set; }
        public int Age { get; set; }

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

        public string Introduction { get; set; }
        public string DescriptionLowResolution { get; set; }

        private int userId;

        #endregion

        #region Constructor
        public UserProperties()
        {
            this.Relationship = new List<int>();
            this.Bodyart = new List<int>();
            this.FreeTimeFavorite = new List<int>();
            this.Hobbies = new List<int>();
            this.Sport = new List<int>();
            this.Music = new List<int>();
            this.Diet = new List<int>();
            this.FashionStyle = new List<int>();
        }
        #endregion

        #region Function members

        public void Get(int userId)
        {
            this.userId = userId;
            List<PropertiesContainer> properties = new List<PropertiesContainer>();

            string sql = "dbo.User_GetAll";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId_ID", userId).SqlDbType = SqlDbType.Int;

            try
            {
                cnn.Open();
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        PropertiesContainer p = new PropertiesContainer
                        {
                            PropertyId = Convert.ToInt32(rdr.GetInt16(0)),
                            CategoryId = Convert.ToInt32(rdr.GetByte(1))
                        };

                        properties.Add(p);
                    }

                    rdr.NextResult();
                    rdr.Read();

                    this.Username = rdr.GetString(0);
                    this.Introduction = rdr.GetString(1);
                    this.Sex = Convert.ToInt32(rdr.GetByte(2));
                    this.SeekSex = Convert.ToInt32(rdr.GetByte(3));
                    this.Height = Convert.ToInt32(rdr.GetByte(4));
                    this.Sign = Convert.ToInt32(rdr.GetByte(5));
                    this.City = rdr.GetInt32(6);
                    this.Country = Convert.ToInt32(rdr.GetByte(7));
                    this.DescriptionLowResolution = rdr.GetString(8);
                    this.Age = Convert.ToInt32(rdr.GetValue(9));

                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (!(rdr == null))
                {
                    rdr.Close();
                    rdr.Dispose();
                }
                cnn.Close();
                cmd.Dispose();
            }

            for (int i = 0; i < properties.Count; i++)
            {
                switch ((Categories)properties[i].CategoryId)
                {
                    case Categories.Bodyart:
                        this.Bodyart.Add(properties[i].PropertyId);
                        break;

                    case Categories.Diet:
                        this.Diet.Add(properties[i].PropertyId);
                        break;

                    case Categories.BestBodyFeature:
                        this.Body = properties[i].PropertyId;
                        break;

                    case Categories.FashionStyle:
                        this.FashionStyle.Add(properties[i].PropertyId);
                        break;

                    case Categories.FreeTimeFavorite:
                        this.FreeTimeFavorite.Add(properties[i].PropertyId);
                        break;

                    case Categories.Hobbies:
                        this.Hobbies.Add(properties[i].PropertyId);
                        break;

                    case Categories.Music:
                        this.Music.Add(properties[i].PropertyId);
                        break;

                    case Categories.Relationship:
                        this.Relationship.Add(properties[i].PropertyId);
                        break;

                    case Categories.Sport:
                        this.Sport.Add(properties[i].PropertyId);
                        break;

                    case Categories.Drinking:
                        this.Drinking = properties[i].PropertyId;
                        break;

                    case Categories.Education:
                        this.Education = properties[i].PropertyId;
                        break;

                    case Categories.Ethnicity:
                        this.Ethnicity = properties[i].PropertyId;
                        break;

                    case Categories.Excercise:
                        this.Exercise = properties[i].PropertyId;
                        break;

                    case Categories.Eyes:
                        this.Eyes = properties[i].PropertyId;
                        break;

                    case Categories.Figure:
                        this.Figure = properties[i].PropertyId;
                        break;

                    case Categories.Hair:
                        this.Hair = properties[i].PropertyId;
                        break;

                    case Categories.KidsHave:
                        this.KidsHave = properties[i].PropertyId;
                        break;

                    case Categories.KidsWant:
                        this.KidsWant = properties[i].PropertyId;
                        break;

                    case Categories.Look:
                        this.Look = properties[i].PropertyId;
                        break;

                    case Categories.Profession:
                        this.Profession = properties[i].PropertyId;
                        break;

                    case Categories.Religion:
                        this.Religion = properties[i].PropertyId;
                        break;

                    case Categories.Salary:
                        this.Salary = properties[i].PropertyId;
                        break;

                    case Categories.Smoking:
                        this.Smoking = properties[i].PropertyId;
                        break;

                    case Categories.Status:
                        this.Status = properties[i].PropertyId;
                        break;

                    case Categories.StatusPartner:
                        this.StatusPartner = properties[i].PropertyId;
                        break;
                }
            }
        }

        public void InsertIntoCache()
        {
            HttpContext.Current.Cache.Insert(this.userId.ToString(), this, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(30));
        }

        #endregion
    }
}