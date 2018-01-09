using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace DatingApp.Models.User.Profile.Properties
{
    public class Appearance : UserInputCheckTool
    {
        #region Data members

        public int Height { get; set; }
        public int Figure { get; set; }
        public int Eyes { get; set; }
        public int Hair { get; set; }
        public int Body { get; set; }
        public List<int> Bodyart { get; set; }
        public int Look { get; set; }

        private int userId;

        #endregion

        #region Constructor

        public Appearance()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
            this.Bodyart = new List<int>();
        }

        public Appearance(int userId)
        {
            this.userId = userId;
            this.Bodyart = new List<int>();
        }

        #endregion

        #region Function members


        public void Set()
        {
            this.Check(this, true);

            if (this.errors.Count > 0)
                throw new RuleException(errors);

            DataTable dtAppearance = new DataTable();
            dtAppearance.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));

            for (int i = 0; i < this.Bodyart.Count; i++)
            {
                dtAppearance.Rows.Add(Convert.ToInt16(this.Bodyart[i]));
            }

            if (this.Figure > 0)
                dtAppearance.Rows.Add(Convert.ToInt16(this.Figure));

            if (this.Eyes > 0)
                dtAppearance.Rows.Add(Convert.ToInt16(this.Eyes));

            if (this.Hair > 0)
                dtAppearance.Rows.Add(Convert.ToInt16(this.Hair));

            if (this.Look > 0)
                dtAppearance.Rows.Add(Convert.ToInt16(this.Look));

            if (this.Body > 0)
                dtAppearance.Rows.Add(Convert.ToInt16(this.Body));

            string sql = "dbo.User_Property_ChapterAppearance_Set";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Height", this.Height).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Properties", dtAppearance).SqlDbType = SqlDbType.Structured;

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

            string sql = "dbo.User_Property_ChapterAppearance_Get";
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

                    this.Height = Convert.ToInt32(rdr.GetByte(0));

                    rdr.NextResult();

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
                throw new Exception(e.Message);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    case Categories.Eyes:
                        this.Eyes = properties[i].PropertyId;
                        break;

                    case Categories.Hair:
                        this.Hair = properties[i].PropertyId;
                        break;

                    case Categories.Bodyart:
                        this.Bodyart.Add(properties[i].PropertyId);
                        break;

                    case Categories.BestBodyFeature:
                        this.Body = properties[i].PropertyId;
                        break;

                    case Categories.Figure:
                        this.Figure = properties[i].PropertyId;
                        break;

                    case Categories.Look:
                        this.Look = properties[i].PropertyId;
                        break;
                }
            }
        }

        #endregion


    }
}