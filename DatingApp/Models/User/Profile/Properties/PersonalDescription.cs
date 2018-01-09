using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DatingApp.Models.User.Profile.Properties
{
    public class PersonalDescription : UserInputCheckTool
    {
        #region Data members

        public string About { get; set; }
        public string AboutPartner { get; set; }

        private int userId;

        #endregion

        #region Constructor

        public PersonalDescription()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
        }

        public PersonalDescription(int userId)
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

            DataTable dtDescriptions = new DataTable();
            dtDescriptions.Columns.Add("PropertyId", System.Type.GetType("System.Byte"));
            dtDescriptions.Columns.Add("PersonalProperty", System.Type.GetType("System.String"));

            if (this.About.Length > 0)
                dtDescriptions.Rows.Add(PersonalCategories.About, this.About);

            if (this.AboutPartner.Length > 0)
                dtDescriptions.Rows.Add(PersonalCategories.Partner, this.AboutPartner);

            string sql = "dbo.User_Personal_Set";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Descriptions", dtDescriptions).SqlDbType = SqlDbType.Structured;

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
            List<PersonalContainer> all = new List<PersonalContainer>();
            string sql = "dbo.User_Personal_Get";
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
                        PersonalContainer pc = new PersonalContainer();
                        pc.DescriptionId = Convert.ToInt32(rdr.GetByte(0));
                        pc.Description = rdr.GetString(1);

                        all.Add(pc);
                    }
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

            for (int i = 0; i < all.Count; i++)
            {
                switch ((PersonalCategories)all[i].DescriptionId)
                {
                    case PersonalCategories.About:
                        this.About = all[i].Description;
                        break;

                    case PersonalCategories.Partner:
                        this.AboutPartner = all[i].Description;
                        break;
                }
            }
        }

        #endregion

    }
}