using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace DatingApp.Models.User.Profile.Properties
{
    public class Username : UserInputCheckTool
    {
        #region Data members

        public string UserUsername { get; set; }
        private int userId;

        #endregion

        #region Constructor

        public Username()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
        }

        public Username(int userId)
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
            cmd.Parameters.AddWithValue("@Username", UserUsername).SqlDbType = SqlDbType.NVarChar;

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

                    this.UserUsername = rdr.GetString(0);
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
                cnn.Dispose();
            }
        }

        #endregion

    }
}