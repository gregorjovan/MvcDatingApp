using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using DatingApp.Models.Infrastructure.Tools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DatingApp.Models.User.Profile.Registration
{
    public class UserRegistration : UserInputCheckTool
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; this.CheckUsername(username); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; this.CheckPassword(password); }
        }

        private int sex;
        public int Sex
        {
            get { return sex; }
            set { sex = value; this.CheckSex(sex); }
        }

        public int Day;
        public int Month;
        public int Year;

        private int country;
        public int Country
        {
            get { return country; }
            set { country = value; this.CheckCountry(country); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; this.CheckEmail(email); }
        }

        #region Data Members

        private string iP;
        private long iPNumeric;
        private string verificationCode;

        private string emailUsername;
        private string emailHost;
        private string emailDisplayName;
        private string addressToLower;
        private string usernameUrlEncoded;
        private DateTime birthday;

        #endregion

        #region Constructor

        public UserRegistration()
        {
            this.iP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            this.iPNumeric = Converter.IPAddressToInt(this.iP);
            this.verificationCode = HttpContext.Current.Session.SessionID;
        }

        #endregion

        #region Function Members

        public void Create()
        {
            this.InitializeData();

            if (this.errors.Count > 0)
                throw new RuleException(errors);

            if (this.errors.Count == 0)
            {
                this.usernameUrlEncoded = HttpUtility.UrlEncode(this.Username, System.Text.Encoding.UTF8);
                this.addressToLower = this.emailUsername + "@" + emailHost;

                try
                {
                    this.birthday = new DateTime(Convert.ToInt32(this.Year), Convert.ToInt32(this.Month), Convert.ToInt32(this.Day));
                }
                catch (Exception e)
                {

                }

                string sql = "dbo.Registration_Insert";
                SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlRegistrations);
                SqlCommand cmd = new SqlCommand(sql, cnn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", this.username).SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.AddWithValue("@UsernameUrlEncoded", this.usernameUrlEncoded).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@Sex_Id", this.sex).SqlDbType = SqlDbType.TinyInt;
                cmd.Parameters.AddWithValue("@RawEmail", this.email).SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.AddWithValue("@AddressToLower", this.addressToLower).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@EmailUsername", this.emailUsername).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@EmailHost", this.emailHost).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@EmailDisplayname", this.emailDisplayName).SqlDbType = SqlDbType.NVarChar;
                cmd.Parameters.AddWithValue("@Birthday", this.birthday).SqlDbType = SqlDbType.SmallDateTime;
                cmd.Parameters.AddWithValue("@Country_ID", this.country).SqlDbType = SqlDbType.TinyInt;
                cmd.Parameters.AddWithValue("@Password", this.password).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@VerificationCode", this.verificationCode).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@IP", this.iPNumeric).SqlDbType = SqlDbType.BigInt;

                cmd.Parameters.Add("@Registration_ID", SqlDbType.Int);
                cmd.Parameters["@Registration_ID"].Direction = ParameterDirection.Output;

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
        }

        private void InitializeData()
        {
            this.CheckData();

            if (this.errors.Count == 0)
            {
                this.ExtractEmail();
            }
        }

        private void CheckData()
        {
            this.CheckBirthday(this.Day, this.Month, this.Year);
        }

        private void ExtractEmail()
        {
            EmailHelper.ExtractEmail(this.Email, out this.emailUsername, out this.emailHost, out this.emailDisplayName);
        }

        #endregion

    }
}