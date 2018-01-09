namespace DatingApp.Models.Search
{

    public enum SortType
    {
        LastVisit = 0,
        NewestUsers = 1
    }

    public enum DisplayType
    {
        Gallery = 0,
        Details = 1
    }

    public enum FilterByPhoto
    {
        AllProfile = 2,
        OnlyImages = 1,
        NoImages = 0
    }

    public static class SearchHelper
    {
        public static string GetSearchTableBySex(int sex, int seeksex)
        {
            string r = string.Empty;

            if (sex == 1 && seeksex == 2)
                r = "MSF";
            else if (sex == 2 && seeksex == 1)
                r = "FSM";
            else if (sex == 1 && seeksex == 1)
                r = "MSM";
            else if (sex == 1 && seeksex == 3)
                r = "MSA";
            else if (sex == 2 && seeksex == 2)
                r = "FSF";
            else if (sex == 1 && seeksex == 3)
                r = "FSA";


            return r;
        }
    }
}