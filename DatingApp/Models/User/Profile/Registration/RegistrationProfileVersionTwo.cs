using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using DatingApp.Models.Repository.User.CompleteProfiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DatingApp.Models.User.Profile.Registration
{
    public class RegistrationProfileVersionTwo : UserInputCheckTool
    {
        #region Data members

        public int Figure { get; set; }
        public List<int> Diet { get; set; }
        public int Education { get; set; }
        public int Ethnicity { get; set; }
        public int Religion { get; set; }

        private int userId;

        #endregion

        #region Constructor

        public RegistrationProfileVersionTwo()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
            this.Diet = new List<int>();
        }

        #endregion

        #region Function members

        public void Set()
        {
            this.Check(this, true);

            if (this.errors.Count > 0)
                throw new RuleException(errors);


            DataTable dtAppearance = new DataTable();
            DataTable dtLifestyle = new DataTable();
            DataTable dtValues = new DataTable();

            dtAppearance.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));
            dtLifestyle.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));
            dtValues.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));

            dtAppearance.Rows.Add(Convert.ToInt16(this.Figure));

            for (int i = 0; i < this.Diet.Count; i++)
            {
                dtLifestyle.Rows.Add(Convert.ToInt16(this.Diet[i]));
            }

            dtValues.Rows.Add(Convert.ToInt16(this.Education));
            dtValues.Rows.Add(Convert.ToInt16(this.Ethnicity));
            dtValues.Rows.Add(Convert.ToInt16(this.Religion));

            string sql = "dbo.reg_FormVersionTwo_Set";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Appearance", dtAppearance).SqlDbType = SqlDbType.Structured;
            cmd.Parameters.AddWithValue("@Lifestyle", dtLifestyle).SqlDbType = SqlDbType.Structured;
            cmd.Parameters.AddWithValue("@Values", dtValues).SqlDbType = SqlDbType.Structured;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception();
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

            string sql = "dbo.reg_FormVersionTwo_Get";
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
                    case Categories.Figure:
                        this.Figure = properties[i].PropertyId;
                        break;

                    case Categories.Diet:
                        this.Diet.Add(properties[i].PropertyId);
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