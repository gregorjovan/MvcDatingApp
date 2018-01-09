using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace DatingApp.Models.Search
{
    public sealed class BasicSearch : BasicSearchFields
    {
        #region Constructor

        public BasicSearch()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
        }
        #endregion

        #region Function members

        public int[] GetResults(bool countTotal)
        {
            List<int> z = new List<int>();
            int[] results = new int[3];

            DateTime from = DateTime.Now.AddYears(-this.AgeMin);
            DateTime to = DateTime.Now.AddYears(-this.AgeMax);

            //string sql = SearchHelper.GetSearchTableBySex(this.Sex, this.SeekSex) + "_GetBasic";
            string sql = "dbo.FSA_GetBasic";

            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlSearch);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@BirthdayMin", from).SqlDbType = SqlDbType.Date;
            cmd.Parameters.AddWithValue("@BirthdayMax", to).SqlDbType = SqlDbType.Date;
            cmd.Parameters.AddWithValue("@CountryId", this.Country).SqlDbType = SqlDbType.Int;

            if (this.Sign > 0)
                cmd.Parameters.AddWithValue("@Sign", this.Sign).SqlDbType = SqlDbType.TinyInt;
            if (this.Ethnicity > 0)
                cmd.Parameters.AddWithValue("@Ethnicity", this.Ethnicity).SqlDbType = SqlDbType.SmallInt;
            if (this.City > 0)
                cmd.Parameters.AddWithValue("@City", this.City).SqlDbType = SqlDbType.Int;
            if (this.photofilter != FilterByPhoto.AllProfile)
                cmd.Parameters.AddWithValue("@Photo", Convert.ToBoolean(this.photofilter)).SqlDbType = SqlDbType.Bit;
            cmd.Parameters.AddWithValue("@OrderBy", (byte)this.sortby).SqlDbType = SqlDbType.TinyInt;
            cmd.Parameters.AddWithValue("@Page", (byte)this.Page).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@CountTotal", countTotal).SqlDbType = SqlDbType.Bit;

            try
            {
                cnn.Open();

                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        z.Add(rdr.GetInt32(0));
                    }

                    if (countTotal)
                    {
                        rdr.NextResult();

                        rdr.Read();
                        this.Counter = rdr.GetInt32(0);
                    }
                }

            }
            catch (SqlException e)
            { throw e; }
            catch (Exception e)
            { throw e; }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                    rdr.Dispose();
                }
                cnn.Close();
                cmd.Dispose();
            }
            
            results = z.ToArray();


            return results;
        }
        #endregion
    }
}