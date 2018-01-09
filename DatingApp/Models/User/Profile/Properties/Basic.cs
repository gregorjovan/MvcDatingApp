using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DatingApp.Models.User.Profile.Properties
{
    public class Basic : UserInputCheckTool
    {
        #region Data members

        public List<int> Relationship { get; set; }
        public int Status { get; set; }
        public int StatusPartner { get; set; }
        public int KidsHave { get; set; }
        public int KidsWant { get; set; }
        public int Kids { get; set; }

        private int userId;
        #endregion

        #region Constructor

        public Basic()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
            this.Relationship = new List<int>();
        }

        public Basic(int userId)
        {
            this.userId = userId;
            this.Relationship = new List<int>();
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

            for (int i = 0; i < this.Relationship.Count; i++)
            {
                dtBasic.Rows.Add(Convert.ToInt16(this.Relationship[i]));
            }

            if (this.Status > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.Status));

            if (this.Kids > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.Kids));

            if (this.KidsHave > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.KidsHave));

            if (this.KidsWant > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.KidsWant));

            if (this.StatusPartner > 0)
                dtBasic.Rows.Add(Convert.ToInt16(this.StatusPartner));

            string sql = "dbo.User_Property_ChapterBasic_Set";
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

            string sql = "dbo.User_Property_ChapterBasic_Get";
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
                    case Categories.Relationship:
                        this.Relationship.Add(properties[i].PropertyId);
                        break;

                    case Categories.Kids:
                        this.Kids = properties[i].PropertyId;
                        break;

                    case Categories.KidsHave:
                        this.KidsHave = properties[i].PropertyId;
                        break;

                    case Categories.KidsWant:
                        this.KidsWant = properties[i].PropertyId;
                        break;

                    case Categories.Status:
                        this.Status = properties[i].PropertyId;
                        break;

                    case Categories.StatusPartner:
                        this.StatusPartner = properties[i].PropertyId;
                        break;
                }
            }
        }

        #endregion
    }
}