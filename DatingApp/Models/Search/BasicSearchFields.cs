using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.Models.Search
{
    public abstract class BasicSearchFields
    {
        #region Data members

        public int Sex { get; set; }
        public int SeekSex { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int Relationship { get; set; }
        public int Sign { get; set; }
        public int Ethnicity { get; set; }
        public int Country { get; set; }
        public int City { get; set; }
        public SortType sortby { get; set; }
        public DisplayType display { get; set; }
        public FilterByPhoto photofilter { get; set; }
        public int Page { get; set; }
        public int Counter { get; set; }

        protected int userId;

        #endregion
    }
}