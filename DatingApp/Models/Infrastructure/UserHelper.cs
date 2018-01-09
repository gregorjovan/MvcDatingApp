using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;


namespace DatingApp.Models.Infrastructure
{
    public static class UserHelper
    {

        public static bool UsernameExists(string username)
        {
            bool r = false;
            string usernameUrlEncoded = HttpUtility.UrlEncode(username, System.Text.Encoding.UTF8);

            String sql = "dbo.Registration_UsernameExists";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlRegistrations);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsernameUrlEncoded", usernameUrlEncoded).SqlDbType = SqlDbType.VarChar;

            SqlParameter p = new SqlParameter("@Exists", SqlDbType.Bit);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                r = (bool)cmd.Parameters["@Exists"].Value;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex.InnerException); }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }

            return r;
        }

        internal static bool EmailExists(string email)
        {
            bool r = true;
            bool error = false;

            string emailUsername, emailHost, emailToLower = string.Empty;

            try
            {
                MailAddress m = new MailAddress(email);

                emailUsername = m.User;
                emailHost = m.Host;
                emailToLower = emailUsername + "@" + emailHost;
            }
            catch (Exception e)
            {
                error = true;
            }

            if (error == false)
            {
                String sql = "dbo.Registration_EmailExists";
                SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlRegistrations);
                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailToLower", emailToLower).SqlDbType = SqlDbType.VarChar;

                SqlParameter p = new SqlParameter("@Exists", SqlDbType.Bit);
                p.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p);

                try
                {
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    r = (bool)cmd.Parameters["@Exists"].Value;
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message, e.InnerException);
                }
                catch (Exception ex)
                { throw new Exception(ex.Message, ex.InnerException); }
                finally
                {
                    cnn.Close();
                    cmd.Dispose();
                    cnn.Dispose();
                }
            }
            return r;
        }

        public static bool UsernameIsValid(string username)
        {
            bool r = true;

            Regex re = new Regex(DatingSettings.RegexUsername, RegexOptions.Compiled);
            r = re.IsMatch(username);
            return r;
        }

        public static int Culture_GetFromLCID()
        {
            int r = 0;

            //String sql = "dbo.LCID_Language_GetLanguageFromLCID";

            String sql = "LCID_Culture_GetCultureFromLCID";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LCID", HttpContext.Current.Session.LCID).SqlDbType = SqlDbType.VarChar;

            SqlParameter p = new SqlParameter("@CultureId", SqlDbType.TinyInt);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                r = Convert.ToInt32(cmd.Parameters["@CultureId"].Value);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex.InnerException); }
            finally
            {
                cnn.Close();
                cmd.Dispose();
                cnn.Dispose();
            }
            return r;
        }
    }
}