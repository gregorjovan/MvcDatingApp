using DatingApp.Models.Infrastructure.ErrorHandling;
using DatingApp.Models.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DatingApp.Models.User.Profile.Properties
{
    public class TellMore : UserInputCheckTool
    {
        #region Data members

        public string BooksDescriptive { get; set; }
        public string PetsDescriptive { get; set; }
        public string InterestsDescriptive { get; set; }
        public string MoviesDescriptive { get; set; }
        public string TvProgrammesDescriptive { get; set; }
        public string MusicDescriptive { get; set; }
        public string FashionDescriptive { get; set; }
        public string SportDescriptive { get; set; }

        private int userId;

        #endregion

        #region Constructor

        public TellMore()
        {
            this.userId = Convert.ToInt32(HttpContext.Current.Session["_u__USERID"].ToString());
        }

        public TellMore(int userId)
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

            if (this.BooksDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.Books, this.BooksDescriptive);

            if (this.PetsDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.Pets, this.PetsDescriptive);

            if (this.MoviesDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.Movies, this.MoviesDescriptive);

            if (this.InterestsDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.Interests, this.InterestsDescriptive);

            if (this.TvProgrammesDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.TVProgrammes, this.TvProgrammesDescriptive);

            if (this.MusicDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.Music, this.MusicDescriptive);

            if (this.FashionDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.Fashion, this.FashionDescriptive);

            if (this.SportDescriptive.Length > 0)
                dtDescriptions.Rows.Add(TellMoreCategories.Sports, this.SportDescriptive);

            string sql = "dbo.User_SayMore_Set";
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
            string sql = "dbo.User_SayMore_Get";
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
                switch ((TellMoreCategories)all[i].DescriptionId)
                {
                    case TellMoreCategories.Books:
                        this.BooksDescriptive = all[i].Description;
                        break;

                    case TellMoreCategories.Fashion:
                        this.FashionDescriptive = all[i].Description;
                        break;

                    case TellMoreCategories.Interests:
                        this.InterestsDescriptive = all[i].Description;
                        break;

                    case TellMoreCategories.Movies:
                        this.MoviesDescriptive = all[i].Description;
                        break;

                    case TellMoreCategories.Music:
                        this.MusicDescriptive = all[i].Description;
                        break;

                    case TellMoreCategories.Pets:
                        this.PetsDescriptive = all[i].Description;
                        break;

                    case TellMoreCategories.Sports:
                        this.SportDescriptive = all[i].Description;
                        break;

                    case TellMoreCategories.TVProgrammes:
                        this.TvProgrammesDescriptive = all[i].Description;
                        break;
                }
            }
        }

        #endregion
    }
}