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
    public class RegistrationProfileVersionOne : UserInputCheckTool
    {
        #region Data members

        public int City;


        public int SeekSex { get; set; }
        public List<int> Relationship { get; set; }
        public int Height { get; set; }
        public List<int> FashionStyle { get; set; }
        public int Smoking { get; set; }
        public int Drinking { get; set; }

        private int userId;

        #endregion

        #region Constructor

        public RegistrationProfileVersionOne()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
            this.Relationship = new List<int>();
            this.FashionStyle = new List<int>();

            this.City = 4;
        }

        #endregion

        #region Function members

        public void Set()
        {
            this.Check(this, true);

            if (this.errors.Count > 0)
                throw new RuleException(errors);


            DataTable dtBasic = new DataTable();
            DataTable dtLifestyle = new DataTable();

            dtBasic.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));
            dtLifestyle.Columns.Add("PropertyId", System.Type.GetType("System.Int16"));

            for (int i = 0; i < this.Relationship.Count; i++)
            {
                dtBasic.Rows.Add(Convert.ToInt16(this.Relationship[i]));
            }

            for (int i = 0; i < this.FashionStyle.Count; i++)
            {
                dtLifestyle.Rows.Add(Convert.ToInt16(this.FashionStyle[i]));
            }

            dtLifestyle.Rows.Add(Convert.ToInt16(this.Smoking));
            dtLifestyle.Rows.Add(Convert.ToInt16(this.Drinking));


            string sql = "dbo.reg_FormVersionOne_Set";
            SqlConnection cnn = new SqlConnection(ConnectionStrings.sqlUsers);
            SqlCommand cmd = new SqlCommand(sql, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId_ID", this.userId).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@CityId", this.City).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@SeekSexId", this.SeekSex).SqlDbType = SqlDbType.TinyInt;
            cmd.Parameters.AddWithValue("@Height", this.Height).SqlDbType = SqlDbType.TinyInt;
            cmd.Parameters.AddWithValue("@Basic", dtBasic).SqlDbType = SqlDbType.Structured;
            cmd.Parameters.AddWithValue("@Lifestyle", dtLifestyle).SqlDbType = SqlDbType.Structured;

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

            string sql = "dbo.reg_FormVersionOne_Get";
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
                    this.SeekSex = Convert.ToInt32(rdr.GetByte(0));
                    this.Height = Convert.ToInt32(rdr.GetByte(1));
                    this.City = rdr.GetInt32(2);

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
                //this.error = true;
                //this.AddErrorMessage(e.Message);
            }

            catch (Exception ex)
            {
                //this.error = true;
                //this.AddErrorMessage(ex.Message);
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

                    case Categories.FashionStyle:
                        this.FashionStyle.Add(properties[i].PropertyId);
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