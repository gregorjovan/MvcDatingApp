using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace DatingApp.Models.User.Profile.Properties
{
    public class Values : UserInputCheckTool
    {
        #region Data members

        public int Profession { get; set; }
        public int Salary { get; set; }
        public int Education { get; set; }
        public int Ethnicity { get; set; }
        public int Religion { get; set; }

        private int userId;
        #endregion

        #region Constructor

        public Values()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
        }

        public Values(int userId)
        {
            this.userId = userId;
        }

        #endregion


        #region Function members

        public void Set()
        {
            this.Check(this, true);

            if (this.errors.Count > 0)
                throw new RuleException(errors);

            DataTable dtBasic = new DataTable();
            dtBasic.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));


            if (this.Profession > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.Profession));

            if (this.Salary > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.Salary));

            if (this.Education > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.Education));

            if (this.Ethnicity > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.Ethnicity));

            if (this.Religion > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.Religion));

            string sql = "dbo.User_Property_ChapterValues_Set";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Properties", dtBasic).SqlDbType = SqlDbType.Structured;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }

        }

        public void Get()
        {

            List<PropertiesContainer> properties = new List<PropertiesContainer>();

            string sql = "dbo.User_Property_ChapterValues_Get";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataReader rdr = null;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;

            try
            {
                cnn.Open();
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        PropertiesContainer p = new PropertiesContainer();

                        p.PropertyId = Convert.ToInt32(rdr.GetInt16(0));
                        p.CategoryId = Convert.ToInt32(rdr.GetByte(1));

                        properties.Add(p);
                    }
                }
            }
            catch (SqlException e)
            {
            }

            catch (Exception ex)
            {

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
                cnn.Dispose();
            }

            for (int i = 0; i < properties.Count; i++)
            {
                switch ((Categories)properties[i].CategoryId)
                {
                    case Categories.Profession:
                        this.Profession = properties[i].PropertyId;
                        break;

                    case Categories.Salary:
                        this.Salary = properties[i].PropertyId;
                        break;

                    case Categories.Education:
                        this.Education = properties[i].PropertyId;
                        break;

                    case Categories.Ethnicity:
                        this.Ethnicity = properties[i].PropertyId;
                        break;

                    case Categories.Religion:
                        this.Religion = properties[i].PropertyId;
                        break;
                }
            }
        }


        #endregion
    }
}