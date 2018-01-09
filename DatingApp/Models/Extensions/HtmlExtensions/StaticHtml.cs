using System.Text;


namespace DatingApp.Models.Extensions.HtmlExtensions
{
    public static class StaticHtml
    {
        public static string DisplayTypeDropDownList(string listName, int selectedValue, string CssClass)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<select name=\"");
            sb.Append(listName);
            sb.Append("\" id=\"id_");
            sb.Append(listName);
            sb.Append("\" class=\"form-control input-sm");
            //sb.Append(CssClass);
            sb.Append("\">");

            sb.Append("<option value=\"0\"");

            if (selectedValue == 0)
                sb.Append(" selected=\"selected\"");

            sb.Append(">");
            sb.Append(Resources.Helpers.Helpers.DisplayTypeGallery);
            sb.Append("</option>");

            sb.Append("<option value=\"1\"");

            if (selectedValue == 1)
                sb.Append(" selected=\"selected\"");

            sb.Append(">");
            sb.Append(Resources.Helpers.Helpers.DisplayTypeDetails);
            sb.Append("</option>");

            sb.Append("</select>");

            return sb.ToString();
        }

        public static string SortByDropDownList(string listName, int selectedValue, string CssClass)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<select name=\"");
            sb.Append(listName);
            sb.Append("\" id=\"id_");
            sb.Append(listName);
            sb.Append("\" class=\"form-control input-sm");
            //sb.Append(CssClass);
            sb.Append("\">");

            sb.Append("<option value=\"0\"");

            if (selectedValue == 0)
                sb.Append(" selected=\"selected\"");

            sb.Append(">");
            sb.Append(Resources.Helpers.Helpers.SortTypeLastVisit);
            sb.Append("</option>");

            sb.Append("<option value=\"1\"");

            if (selectedValue == 1)
                sb.Append(" selected=\"selected\"");

            sb.Append(">");
            sb.Append(Resources.Helpers.Helpers.SortTypeNewestUsers);
            sb.Append("</option>");

            sb.Append("</select>");

            return sb.ToString();
        }

        public static string FilterByDropDownList(string listName, int selectedValue, string CssClass)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<select name=\"");
            sb.Append(listName);
            sb.Append("\" id=\"id_");
            sb.Append(listName);
            sb.Append("\" class=\"form-control input-sm");
            //sb.Append(CssClass);
            sb.Append("\">");

            sb.Append("<option value=\"0\"");

            if (selectedValue == 0)
                sb.Append(" selected=\"selected\"");

            sb.Append(">");
            sb.Append(Resources.Helpers.Helpers.FilterAll);
            sb.Append("</option>");

            sb.Append("<option value=\"1\"");

            if (selectedValue == 1)
                sb.Append(" selected=\"selected\"");

            sb.Append(">");
            sb.Append(Resources.Helpers.Helpers.FilterPhotoOnly);
            sb.Append("</option>");

            sb.Append("<option value=\"2\"");

            if (selectedValue == 1)
                sb.Append(" selected=\"selected\"");

            sb.Append(">");
            sb.Append(Resources.Helpers.Helpers.FilterNoPhoto);
            sb.Append("</option>");

            sb.Append("</select>");

            return sb.ToString();
        }
    }
}