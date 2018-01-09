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
    public class RegistrationProfileVersionThree : UserInputCheckTool
    {

        #region Data members

        public List<int> FreeTimeFavorite { get; set; }
        public List<int> Hobbies { get; set; }
        public string Introduction { get; set; }

        private int userId;

        #endregion

        #region Constructor

        public RegistrationProfileVersionThree()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
            this.FreeTimeFavorite = new List<int>();
            this.Hobbies = new List<int>();
        }

        #endregion

        #region Function members

        public void Set()
        {
            this.Check(this, true);

            if (this.errors.Count > 0)
                throw new RuleException(errors);

            DataTable dtInterests = new DataTable();

            dtInterests.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));

            for (int i = 0; i < this.FreeTimeFavorite.Count; i++)
            {
                dtInterests.Rows.Add(Convert.ToInt16(this.FreeTimeFavorite[i]));
            }

            for (int i = 0; i < this.Hobbies.Count; i++)
            {
                dtInterests.Rows.Add(Convert.ToInt16(this.Hobbies[i]));
            }

            string sql = "dbo.reg_FormVersionThree_Set";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Interests", dtInterests).SqlDbType = SqlDbType.Structured;
            cmd.Parameters.AddWithValue("@Introduction", this.Introduction).SqlDbType = SqlDbType.NVarChar;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {

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

            string sql = "dbo.reg_FormVersionThree_Get";
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
                    rdr.Read();
                    this.Introduction = rdr.GetString(0);
                }

                rdr.NextResult();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        PropertiesContainer p = new PropertiesContainer();

                        p.PropertyId = Convert.ToInt32(rdr.GetInt16(0));
                        p.CategoryId = Convert.ToInt32(rdr.GetSqlByte(1));

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
                    case Categories.FreeTimeFavorite:
                        this.FreeTimeFavorite.Add(properties[i].PropertyId);
                        break;

                    case Categories.Hobbies:
                        this.Hobbies.Add(properties[i].PropertyId);
                        break;
                }
            }
        }

        #endregion
    }
}