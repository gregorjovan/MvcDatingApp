using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Diagnostics;

namespace DatingApp.Models.Search
{
    public class AdvancedSearch : BasicSearchFields
    {
        #region Data members

        public int Height { get; set; }
        public int Religion { get; set; }
        public int Smoking { get; set; }
        public int Alcohol { get; set; }
        public int Hobbies { get; set; }
        public int Education { get; set; }
        #endregion
    }
}