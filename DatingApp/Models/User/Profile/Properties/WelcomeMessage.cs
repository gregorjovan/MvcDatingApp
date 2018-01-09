using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DatingApp.Models.User.Profile.Properties
{
    public class WelcomeMessage : UserInputCheckTool
    {
        #region Data members

        public string Introduction { get; set; }
        private int userId;

        #endregion


        #region Constructor

        public WelcomeMessage()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
        }

        public WelcomeMessage(int userId)
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

            string sql = "dbo.UserUsernameAndIntroduction_Update";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Introduction", Introduction).SqlDbType = SqlDbType.NVarChar;

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
            string sql = "dbo.UserUsernameAndIntroduction_Get";
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

                    this.Introduction = rdr.GetString(1);
                }
            }
            catch (SqlException e)
            {
                throw new Exception();
            }

            catch (Exception ex)
            {
                throw new Exception();
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
        }

        #endregion



    }
}