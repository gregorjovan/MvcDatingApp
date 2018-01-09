using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace DatingApp.Models.User.Profile.Properties
{
    public class Lifestyle : UserInputCheckTool
    {
        #region Data members

        public int Exercise { get; set; }
        public List<int> Diet { get; set; }
        public List<int> FashionStyle { get; set; }
        public int Smoking { get; set; }
        public int Drinking { get; set; }

        private int userId;
        #endregion

        #region Constructor

        public Lifestyle()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
            this.Diet = new List<int>();
            this.FashionStyle = new List<int>();
        }

        public Lifestyle(int userId)
        {
            this.userId = userId;
            this.Diet = new List<int>();
            this.FashionStyle = new List<int>();
        }

        #endregion

        #region Function members

        public void Set()
        {
            this.Check(this, true);

            if (this.errors.Count > 0)
                throw new RuleException(errors);

            DataTable dtLifestyle = new DataTable();
            dtLifestyle.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));

            for (int i = 0; i < this.Diet.Count; i++)
            {
                dtLifestyle.Rows.Add(Convert.ToInt16(this.Diet[i]));
            }

            for (int i = 0; i < this.FashionStyle.Count; i++)
            {
                dtLifestyle.Rows.Add(Convert.ToInt16(this.FashionStyle[i]));
            }

            if (this.Exercise > 0)
                dtLifestyle.Rows.Add(Convert.ToInt16(this.Exercise));

            if (this.Smoking > 0)
                dtLifestyle.Rows.Add(Convert.ToInt16(this.Smoking));

            if (this.Drinking > 0)
                dtLifestyle.Rows.Add(Convert.ToInt16(this.Drinking));

            string sql = "dbo.User_Property_ChapterLifestyle_Set";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@Properties", dtLifestyle).SqlDbType = SqlDbType.Structured;

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

            string sql = "dbo.User_Property_ChapterLifestyle_Get";
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
                    case Categories.Diet:
                        this.Diet.Add(properties[i].PropertyId);
                        break;

                    case Categories.FashionStyle:
                        this.FashionStyle.Add(properties[i].PropertyId);
                        break;

                    case Categories.Excercise:
                        this.Exercise = properties[i].PropertyId;
                        break;

                    case Categories.Drinking:
                        this.Drinking = properties[i].PropertyId;
                        break;

                    case Categories.Smoking:
                        this.Smoking = properties[i].PropertyId;
                        break;
                }
            }
        }

        #endregion

    }
}