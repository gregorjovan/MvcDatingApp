using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatingApp.Models.Search
{

    public struct SimpleSearchItem
    {
        public int userId;
        public int cityId;
        public int age;
        public List<int> relationship;
        public int sign;
        public int ethnicity;
        public bool photo;
    }

    public enum GenderTable
    {
        FSA = 0,
        FSF = 1,
        FSM = 2,
        MSA = 3,
        MSF = 4,
        MSM = 5
    }

    public class SearchListGenerator
    {
        #region Data members

        const int GENDERTABLESCOUNT = 6;

        private static int maxCountryId = 0;
        public static int MaxCountryId
        {
            get
            {
                if (maxCountryId == 0)
                    maxCountryId = MaxCountryId_Get();

                return maxCountryId;
            }
        }

        #endregion

        #region Function members

        public SimpleSearchItem[][][] SimpleSearchCache()
        {
            SimpleSearchItem[][][] r = new SimpleSearchItem[6][][];

            List<int> populatedCountries;
            this.GetPopulatedCountries(out populatedCountries);

            for (int i = 0; i < GENDERTABLESCOUNT; i++)
            {
                //SearchItem[][][] x = new SearchItem[i][][];

                for (int j = 1; j <= MaxCountryId; j++)
                {
                    if (populatedCountries.Contains(j))
                    {
                        r[i][j] = UsersByLastAction((GenderTable)i, j);
                    }
                }
            }
            return r;
        }

        private SimpleSearchItem[] UsersByLastAction(GenderTable x, int countryId)
        {
            string sql = "dbo.Users_GetByLastAction";
            List<SimpleSearchItem> tempResults = new List<SimpleSearchItem>();

            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlSearch);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.Parameters.AddWithValue("@GenderTable", Convert.ToInt32(x)).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Country_ID", Convert.ToByte(countryId)).SqlDbType = SqlDbType.TinyInt;
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {

                cnn.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        SimpleSearchItem it = new SimpleSearchItem();
                        it.relationship = new List<int>();

                        it.userId = rdr.GetInt32(0);
                        it.age = Convert.ToInt32(rdr.GetValue(2));
                        it.relationship.Add(rdr.GetInt16(6));
                        it.sign = Convert.ToInt32(rdr.GetByte(5));
                        it.ethnicity = Convert.ToInt32(rdr.GetInt16(3));
                        //it.eyes = Convert.ToInt32(rdr.GetInt16(6));

                        tempResults.Add(it);

                    }
                }

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
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

            SimpleSearchItem[] r = new SimpleSearchItem[tempResults.Count];
            r = tempResults.ToArray();

            return r;


        }

        private void GetPopulatedCountries(out List<int> populatedCountries)
        {
            string sql = "dbo.User_GetDistinctCountries";
            populatedCountries = new List<int>();
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlSearch);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cnn.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        populatedCountries.Add(Convert.ToInt32(rdr.GetByte(0)));
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
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
        }

        private static int MaxCountryId_Get()
        {
            int r = 0;

            string sql = "dbo.p_Country_GetTopIndex";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = new SqlParameter("@CountryMax", SqlDbType.TinyInt);
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
    }
}