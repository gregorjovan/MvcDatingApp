using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using DatingApp.Models.Infrastructure.Settings;

namespace DatingApp.Models.Repository.Properties
{
    /// <summary>
    /// PropertyItem
    /// </summary>
    /// <remarks>
    /// Item loaded from database with id and value. Usign in loading dictionaries.
    /// </remarks>
    public struct PropertyItem
    {
        public int itemId { get; set; }
        public string itemDescription { get; set; }
    }


    public static class PropertiesDictionary
    {
        #region Data members

        private static string[][] properties = null;
        public static string[][] Properties
        {
            get
            {
                if (properties == null)
                    properties = GetProperties();

                return properties;

            }
        }

        private static string[][] sex = null;
        public static string[][] Sex
        {
            get
            {
                if (sex == null)
                    sex = GetSex();

                return sex;

            }
        }

        private static string[][] seekSex = null;
        public static string[][] SeekSex
        {
            get
            {
                if (seekSex == null)
                    seekSex = GetSeekSex();

                return seekSex;

            }
        }


        #endregion

        #region Function members

        #region SeekSex
        private static string[][] GetSeekSex()
        {
            int languageIndex = 0;
            int SeeksexSizeIndex = 0;

            languageIndex = LanguagesIndexSize() + 1;
            SeeksexSizeIndex = SeekSexIndexSize() + 1;

            string[][] languageArray = new string[languageIndex][];

            for (int i = 0; i < languageIndex; i++)
            {
                string[] seekSexArray = new string[SeeksexSizeIndex];

                string[] curr = GetSeekSexByLanguage(i, SeeksexSizeIndex);
                for (int j = 0; j < SeeksexSizeIndex; j++)
                {
                    seekSexArray[j] = curr[j];
                }

                languageArray[i] = seekSexArray;

            }
            return languageArray;
        }

        private static string[] GetSeekSexByLanguage(int languageId, int size)
        {
            string[] r = new string[size];

            string sql = "dbo.p_SeekSex_GetByLanguage";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LanguageId", Convert.ToByte(languageId)).SqlDbType = SqlDbType.TinyInt;

            try
            {
                cnn.Open();
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        int id = Convert.ToInt32(rdr.GetByte(0));
                        string itemDescription = rdr.GetString(1);

                        r[id] = itemDescription;
                    }
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
                if (rdr != null)
                {
                    rdr.Close();
                    rdr.Dispose();
                }

                cmd.Dispose();
                cnn.Close();
            }

            return r;
        }


        private static int SeekSexIndexSize()
        {
            int r = 0;

            string sql = "dbo.p_SeekSex_GetTopIndex";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@SeekSexMax", SqlDbType.TinyInt);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

                r = Convert.ToInt32(p.Value);
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
                cmd.Dispose();
                cnn.Close();
            }

            return r;
        }
        #endregion

        #region Sex

        private static string[][] GetSex()
        {
            int languageIndex = 0;
            int sexSizeIndex = 0;

            languageIndex = LanguagesIndexSize() + 1;
            sexSizeIndex = SexIndexSize() + 1;

            string[][] languageArray = new string[languageIndex][];

            for (int i = 0; i < languageIndex; i++)
            {
                string[] sexArray = new string[sexSizeIndex];

                string[] curr = GetSexByLanguage(i, sexSizeIndex);
                for (int j = 0; j < sexSizeIndex; j++)
                {
                    sexArray[j] = curr[j];
                }

                languageArray[i] = sexArray;

            }
            return languageArray;
        }

        private static string[] GetSexByLanguage(int languageId, int size)
        {
            string[] r = new string[size];

            string sql = "dbo.p_Sex_GetByLanguage";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LanguageId", Convert.ToByte(languageId)).SqlDbType = SqlDbType.TinyInt;

            try
            {
                cnn.Open();
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        int id = Convert.ToInt32(rdr.GetByte(0));
                        string itemDescription = rdr.GetString(1);

                        r[id] = itemDescription;
                    }
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
                if (rdr != null)
                {
                    rdr.Close();
                    rdr.Dispose();
                }

                cmd.Dispose();
                cnn.Close();
            }

            return r;
        }


        private static int SexIndexSize()
        {
            int r = 0;

            string sql = "dbo.p_Sex_GetTopIndex";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@SexMax", SqlDbType.TinyInt);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

                r = Convert.ToInt32(p.Value);
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
                cmd.Dispose();
                cnn.Close();
            }

            return r;
        }

        #endregion

        #region Properties

        private static string[][] GetProperties()
        {
            int languageIndex = 0;
            int propertyIndex = 0;

            languageIndex = LanguagesIndexSize() + 1;
            propertyIndex = PropertyIndexSize() + 1;

            string[][] languageArray = new string[languageIndex][];

            for (int i = 0; i < languageIndex; i++)
            {
                string[] propertyArray = new string[propertyIndex];

                string[] curr = GetPropertiesByLanguage(i, propertyIndex);
                for (int j = 0; j < propertyIndex; j++)
                {
                    propertyArray[j] = curr[j];
                }

                languageArray[i] = propertyArray;

            }
            return languageArray;
        }

        private static string[] GetPropertiesByLanguage(int languageId, int size)
        {
            string[] r = new string[size];

            string sql = "dbo.p_Property_GetByLanguage";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LanguageId", Convert.ToByte(languageId)).SqlDbType = SqlDbType.TinyInt;

            try
            {
                cnn.Open();
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        int id = Convert.ToInt32(rdr.GetInt16(0));
                        string itemDescription = rdr.GetString(1);

                        r[id] = itemDescription;
                    }
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
                if (rdr != null)
                {
                    rdr.Close();
                    rdr.Dispose();
                }

                cmd.Dispose();
                cnn.Close();
            }

            return r;
        }

        private static int PropertyIndexSize()
        {
            int r = 0;

            string sql = "dbo.p_Property_GetTopIndex";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@PropertyMax", SqlDbType.TinyInt);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

                r = Convert.ToInt32(p.Value);
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
                cmd.Dispose();
                cnn.Close();
            }

            return r;
        }

        #endregion

        private static int LanguagesIndexSize()
        {
            int r = 0;

            string sql = "dbo.p_Language_GetTopIndex";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@LanguageMax", SqlDbType.TinyInt);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();

                r = Convert.ToInt32(p.Value);
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
                cmd.Dispose();
                cnn.Close();
            }

            return r;
        }

        #endregion

        //private static List<PropertyItem> GetRepository(int categoryId)
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    String sql = "dbo.p_Property_GetByCategory";
        //    SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
        //    SqlCommand cmd = new SqlCommand(sql, cnn);

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Category_ID", categoryId).SqlDbType = SqlDbType.TinyInt;

        //    cnn.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    if (rdr.HasRows)
        //    {
        //        while (rdr.Read())
        //        {
        //            PropertyItem x = new PropertyItem();

        //            x.Value = rdr.GetSqlInt16(0).ToString();
        //            x.Text = rdr.GetString(1);
        //            x.CultureId = rdr.GetByte(2);

        //            all.Add(x);
        //        }
        //    }

        //    rdr.Close();
        //    rdr.Dispose();
        //    cnn.Close();
        //    cnn.Dispose();
        //    cmd.Dispose();

        //    return all;
        //}


        //private static List<PropertyItem> SeekSexRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    String sql = "dbo.p_SeekSex_Get";
        //    SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
        //    SqlCommand cmd = new SqlCommand(sql, cnn);
        //    SqlDataReader rdr = null;

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        cnn.Open();
        //        rdr = cmd.ExecuteReader();

        //        if (rdr.HasRows)
        //        {
        //            while (rdr.Read())
        //            {
        //                PropertyItem x = new PropertyItem();

        //                x.Value = rdr.GetByte(0).ToString();
        //                x.Text = rdr.GetString(1);
        //                x.CultureId = rdr.GetByte(2);

        //                all.Add(x);
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    { }
        //    catch (Exception ex)
        //    { }
        //    finally
        //    {
        //        if (!(rdr == null))
        //        {
        //            rdr.Close();
        //            rdr.Dispose();
        //        }

        //        cnn.Close();
        //        cnn.Dispose();
        //        cmd.Dispose();
        //    }
        //    return all;
        //}
        //public static List<PropertyItem> SeekSex = SeekSexRepository();

        //private static List<PropertyItem> SexRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    String sql = "dbo.p_Sex_Get";
        //    SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
        //    SqlCommand cmd = new SqlCommand(sql, cnn);
        //    SqlDataReader rdr = null;

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        cnn.Open();
        //        rdr = cmd.ExecuteReader();

        //        if (rdr.HasRows)
        //        {
        //            while (rdr.Read())
        //            {
        //                PropertyItem x = new PropertyItem();

        //                x.Value = rdr.GetByte(0).ToString();
        //                x.Text = rdr.GetString(1);
        //                x.CultureId = rdr.GetByte(2);

        //                all.Add(x);
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    { throw new Exception(e.Message, e.InnerException); }
        //    catch (Exception ex)
        //    { throw new Exception(ex.Message, ex.InnerException); }
        //    finally
        //    {
        //        if (rdr != null)
        //        {
        //            rdr.Close();
        //            rdr.Dispose();
        //        }

        //        cnn.Close();
        //        cnn.Dispose();
        //        cmd.Dispose();
        //    }
        //    return all;
        //}
        //private static List<PropertyItem> Sex__ = null;
        //public static List<PropertyItem> Sex
        //{
        //    get
        //    {

        //        if (Sex__ == null)
        //            Sex__ = SexRepository();

        //        return Sex__;
        //    }
        //}//  = SexRepository();

        //private static void Add()
        //{

        //    PropertyItem x = new PropertyItem();
        //    lock (Sex)
        //    {
        //        Sex.Add(x);
        //    }
        //}

        //private static List<PropertyItem> SignRepository()
        //{
        //    Properties.Sex.Add(new PropertyItem());

        //    List<PropertyItem> all = new List<PropertyItem>();

        //    String sql = "dbo.p_Sign_Get";
        //    SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
        //    SqlCommand cmd = new SqlCommand(sql, cnn);
        //    SqlDataReader rdr = null;

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        cnn.Open();
        //        rdr = cmd.ExecuteReader();

        //        if (rdr.HasRows)
        //        {
        //            while (rdr.Read())
        //            {
        //                PropertyItem x = new PropertyItem();

        //                x.Value = rdr.GetByte(0).ToString();
        //                x.Text = rdr.GetString(1);
        //                x.CultureId = rdr.GetByte(2);

        //                all.Add(x);
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    { }
        //    catch (Exception ex)
        //    { }
        //    finally
        //    {
        //        if (!(rdr == null))
        //        {
        //            rdr.Close();
        //            rdr.Dispose();
        //        }

        //        cnn.Close();
        //        cnn.Dispose();
        //        cmd.Dispose();
        //    }
        //    return all;
        //}
        //public static List<PropertyItem> Sign = SignRepository();

        //private static List<PropertyItem> CountriesRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    String sql = "dbo.p_Country_Get";
        //    SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
        //    SqlCommand cmd = new SqlCommand(sql, cnn);
        //    SqlDataReader rdr = null;

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        cnn.Open();
        //        rdr = cmd.ExecuteReader();

        //        if (rdr.HasRows)
        //        {
        //            while (rdr.Read())
        //            {
        //                PropertyItem x = new PropertyItem();

        //                x.Value = rdr.GetByte(0).ToString();
        //                x.Text = rdr.GetString(1);
        //                x.CultureId = rdr.GetByte(2);

        //                all.Add(x);
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    { }
        //    catch (Exception ex)
        //    { }
        //    finally
        //    {
        //        if (!(rdr == null))
        //        {
        //            rdr.Close();
        //            rdr.Dispose();
        //        }

        //        cnn.Close();
        //        cnn.Dispose();
        //        cmd.Dispose();
        //    }
        //    return all;
        //}
        //public static List<PropertyItem> Countries = CountriesRepository();

        //private static List<CityItem> CitiesRepository()
        //{
        //    List<CityItem> all = new List<CityItem>();

        //    String sql = "dbo.p_City_Get";
        //    SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
        //    SqlCommand cmd = new SqlCommand(sql, cnn);
        //    SqlDataReader rdr = null;

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        cnn.Open();
        //        rdr = cmd.ExecuteReader();

        //        if (rdr.HasRows)
        //        {
        //            while (rdr.Read())
        //            {
        //                CityItem x = new CityItem();

        //                x.Value = rdr.GetByte(0).ToString();
        //                x.Text = rdr.GetString(1);
        //                x.CultureId = rdr.GetByte(2);
        //                x.CountryId = rdr.GetByte(3);

        //                all.Add(x);
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    { }
        //    catch (Exception ex)
        //    { }
        //    finally
        //    {
        //        if (!(rdr == null))
        //        {
        //            rdr.Close();
        //            rdr.Dispose();
        //        }

        //        cnn.Close();
        //        cnn.Dispose();
        //        cmd.Dispose();
        //    }
        //    return all;
        //}
        //public static List<CityItem> Cities = CitiesRepository();

        //private static List<PropertyItem> DaysRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    for (int i = 1; i <= 31; i++)
        //    {
        //        PropertyItem x = new PropertyItem();

        //        x.Text = i.ToString();
        //        x.Value = i.ToString();

        //        all.Add(x);
        //    }

        //    return all;
        //}
        //public static List<PropertyItem> Days = DaysRepository();

        //private static List<PropertyItem> YearRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    for (int i = (DateTime.Now.Year - 100); i <= (DateTime.Now.Year - 16); i++)
        //    {
        //        PropertyItem x = new PropertyItem();

        //        x.Text = i.ToString();
        //        x.Value = i.ToString();

        //        all.Add(x);
        //    }

        //    return all;
        //}
        //public static List<PropertyItem> Year = YearRepository();

        //private static List<PropertyItem> MonthsRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    String sql = "dbo.p_Month_Get";
        //    SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
        //    SqlCommand cmd = new SqlCommand(sql, cnn);

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cnn.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    if (rdr.HasRows)
        //    {
        //        while (rdr.Read())
        //        {
        //            PropertyItem x = new PropertyItem();

        //            x.Value = rdr.GetByte(0).ToString();
        //            x.Text = rdr.GetString(1);
        //            x.CultureId = rdr.GetByte(2);

        //            all.Add(x);
        //        }
        //    }

        //    rdr.Close();
        //    rdr.Dispose();
        //    cnn.Close();
        //    cnn.Dispose();
        //    cmd.Dispose();

        //    return all;
        //}
        //public static List<PropertyItem> Months = MonthsRepository();

        //private static List<PropertyItem> HeightRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();

        //    for (int i = 130; i <= 230; i++)
        //    {
        //        PropertyItem x = new PropertyItem();

        //        x.Text = i.ToString();
        //        x.Value = i.ToString();

        //        all.Add(x);
        //    }

        //    return all;
        //}
        //public static List<PropertyItem> Height = HeightRepository();

        //private static List<PropertyItem> RelationshipRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Relationship);

        //    return all;
        //}
        //public static List<PropertyItem> Relationships = RelationshipRepository();

        //private static List<PropertyItem> FashionStyleRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.FashionStyle);

        //    return all;
        //}
        //public static List<PropertyItem> FashionStyles = FashionStyleRepository();

        //private static List<PropertyItem> DrinkingRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Drinking);

        //    return all;
        //}
        //public static List<PropertyItem> Drinkings = DrinkingRepository();

        //private static List<PropertyItem> SmokingRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Smoking);

        //    return all;
        //}
        //public static List<PropertyItem> Smokings = SmokingRepository();

        //private static List<PropertyItem> FigureRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Figure);

        //    return all;
        //}
        //public static List<PropertyItem> Figures = FigureRepository();

        //private static List<PropertyItem> EyesRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Eyes);

        //    return all;
        //}
        //public static List<PropertyItem> Eyes = EyesRepository();

        //private static List<PropertyItem> HairRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Hair);

        //    return all;
        //}
        //public static List<PropertyItem> Hair = HairRepository();

        //private static List<PropertyItem> BodyRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.BestBodyFeature);

        //    return all;
        //}
        //public static List<PropertyItem> Body = BodyRepository();

        //private static List<PropertyItem> BodyartRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Bodyart);

        //    return all;
        //}
        //public static List<PropertyItem> Bodyart = BodyartRepository();

        //private static List<PropertyItem> LookRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Look);

        //    return all;
        //}
        //public static List<PropertyItem> Look = LookRepository();

        //private static List<PropertyItem> EducationRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Education);

        //    return all;
        //}
        //public static List<PropertyItem> Educations = EducationRepository();

        //private static List<PropertyItem> EthnicityRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Ethnicity);

        //    return all;
        //}
        //public static List<PropertyItem> Ethnicity = EthnicityRepository();

        //private static List<PropertyItem> ProfessionRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Profession);

        //    return all;
        //}
        //public static List<PropertyItem> Profession = ProfessionRepository();

        //private static List<PropertyItem> SalaryRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Salary);

        //    return all;
        //}
        //public static List<PropertyItem> Salary = SalaryRepository();

        //private static List<PropertyItem> ReligionRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Religion);

        //    return all;
        //}
        //public static List<PropertyItem> Religions = ReligionRepository();

        //private static List<PropertyItem> DietRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Diet);

        //    return all;
        //}
        //public static List<PropertyItem> Diets = DietRepository();

        //private static List<PropertyItem> FreeTimeFavoritesRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.FreeTimeFavorite);

        //    return all;
        //}
        //public static List<PropertyItem> FreeTimeFavorites = FreeTimeFavoritesRepository();

        //private static List<PropertyItem> HobbiesRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Hobbies);

        //    return all;
        //}
        //public static List<PropertyItem> Hobbies = HobbiesRepository();

        //private static List<PropertyItem> SportsRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Sport);

        //    return all;
        //}
        //public static List<PropertyItem> Sports = SportsRepository();

        //private static List<PropertyItem> MusicRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Music);

        //    return all;
        //}
        //public static List<PropertyItem> Music = MusicRepository();

        //private static List<PropertyItem> StatusRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Status);

        //    return all;
        //}
        //public static List<PropertyItem> Statuses = StatusRepository();

        //private static List<PropertyItem> StatusPartnerRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.StatusPartner);

        //    return all;
        //}
        //public static List<PropertyItem> StatusesPartner = StatusPartnerRepository();

        //private static List<PropertyItem> KidsRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Kids);

        //    return all;
        //}
        //public static List<PropertyItem> Kids = KidsRepository();

        //private static List<PropertyItem> KidsHaveRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.KidsHave);

        //    return all;
        //}
        //public static List<PropertyItem> KidsHave = KidsHaveRepository();

        //private static List<PropertyItem> KidsWantRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.KidsWant);

        //    return all;
        //}
        //public static List<PropertyItem> KidsWant = KidsWantRepository();

        //private static List<PropertyItem> ExcerciseRepository()
        //{
        //    List<PropertyItem> all = new List<PropertyItem>();
        //    all = GetRepository((int)Categories.Excercise);

        //    return all;
        //}
        //public static List<PropertyItem> Excercise = ExcerciseRepository();
    }

}