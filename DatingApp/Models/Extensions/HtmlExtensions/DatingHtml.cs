using DatingApp.Models.Infrastructure;
using DatingApp.Models.SqlRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.Models.Extensions.HtmlExtensions
{
    public static class DatingHtml
    {

        public static string RadioButtonList(string propertyName, int columns, int selectedValue, bool addDefault)
        {
            int cultureId = Convert.ToInt32(System.Web.HttpContext.Current.Session["___APPCU"].ToString());

            List<PropertyItem> l = currentList(propertyName, cultureId, addDefault);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table style=\"text-align:left\">");
            sb.Append("<tr>");
            for (int i = 0; i < l.Count; i++)
            {
                sb.Append("<td>");
                sb.Append("&nbsp;<input class=\"radio-inline\"  type=\"radio\" name=\"");
                sb.Append(propertyName);
                sb.Append("\" ");
                sb.Append("id=\"rb");
                sb.Append(propertyName);
                sb.Append("_");
                sb.Append(i.ToString());
                sb.Append("\" ");
                sb.Append("value=\"");
                sb.Append(l[i].Value);
                sb.Append("\"");
                if (l[i].Value == selectedValue.ToString())
                {
                    sb.Append(" checked=\"checked\" ");
                }
                sb.Append(" />");
                sb.Append("&nbsp;<label for=\"rb");
                sb.Append(propertyName);
                sb.Append("_");
                sb.Append(i.ToString());
                sb.Append("\">");
                sb.Append(l[i].Text);
                sb.Append("</label>");

                sb.Append("</td>");

                if (Math.IEEERemainder((i + 1), columns) == 0)
                {
                    sb.Append("</tr><tr>");
                }

            }
            sb.Append("</tr>");
            sb.Append("</table>");
            return sb.ToString();
        }

        public static string RadioButtonListBtstrp(string propertyName, int columns, int selectedValue, bool addDefault)
        {
            int cultureId = Convert.ToInt32(System.Web.HttpContext.Current.Session["___APPCU"].ToString());

            List<PropertyItem> l = currentList(propertyName, cultureId, addDefault);

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"container\">");
            for (int i = 0; i < l.Count; i++)
            {
                //sb.Append("<div class=\"radio radio-inline\">");
                sb.Append("<label class=\"radio-inline input-sm\">");
                sb.Append("&nbsp;<input type=\"radio\" name=\"");
                sb.Append(propertyName);
                sb.Append("\" ");
                sb.Append("id=\"rb");
                sb.Append(propertyName);
                sb.Append("_");
                sb.Append(i.ToString());
                sb.Append("\" ");
                sb.Append("value=\"");
                sb.Append(l[i].Value);
                sb.Append("\"");
                if (l[i].Value == selectedValue.ToString())
                {
                    sb.Append(" checked=\"checked\" ");
                }
                sb.Append(" />");
                sb.Append(l[i].Text);
                sb.Append("</label>");
                /*
                if (Math.IEEERemainder((i + 1), columns) == 0)
                {
                    sb.Append("<br />");
                }
                */
                //sb.Append("</div>");



            }
            sb.Append("</div>");
            return sb.ToString();
        }

        public static string CheckBoxList(string propertyName, int columns, List<int> selectedValues)
        {
            HiPerfTimer a = new HiPerfTimer();
            HiPerfTimer b = new HiPerfTimer();


            int cultureId = Convert.ToInt32(System.Web.HttpContext.Current.Session["___APPCU"].ToString());
            a.Start();
            b.Start();
            List<PropertyItem> l = currentList(propertyName, cultureId, false);
            b.Stop();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style=\"text-align:left\"><tr>");
            for (int i = 0; i < l.Count; i++)
            {
                sb.Append("<td><input type=\"checkbox\" name=\"");
                sb.Append(propertyName);
                sb.Append("\" id=\"cbl");
                sb.Append(propertyName);
                sb.Append("_");
                sb.Append(i.ToString());
                sb.Append("\" value=\"");
                sb.Append(l[i].Value);
                sb.Append("\"");
                for (int j = 0; j < selectedValues.Count; j++)
                {
                    if (l[i].Value == selectedValues[j].ToString())
                        sb.Append(" checked=\"checked\" ");
                }
                sb.Append(" />&nbsp;<label for=\"cbl");
                sb.Append(propertyName);
                sb.Append("_");
                sb.Append(i.ToString());
                sb.Append("\">");
                sb.Append(l[i].Text);
                sb.Append("</label></td>");

                if (Math.IEEERemainder((i + 1), columns) == 0)
                {
                    sb.Append("</tr><tr>");
                }

            }
            sb.Append("</tr>");
            sb.Append("</table>");

            a.Stop();

            string a1 = (a.Duration * 1000000).ToString();

            string b1 = (b.Duration * 1000000).ToString();


            return sb.ToString();
        }

        public static string CheckBoxListBtstsr(string propertyName, int columns, List<int> selectedValues)
        {
            HiPerfTimer a = new HiPerfTimer();
            HiPerfTimer b = new HiPerfTimer();


            int cultureId = Convert.ToInt32(System.Web.HttpContext.Current.Session["___APPCU"].ToString());
            a.Start();
            b.Start();
            List<PropertyItem> l = currentList(propertyName, cultureId, false);
            b.Stop();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style=\"text-align:left\"><tr>");
            for (int i = 0; i < l.Count; i++)
            {
                sb.Append("<td><input type=\"checkbox\" name=\"");
                sb.Append(propertyName);
                sb.Append("\" id=\"cbl");
                sb.Append(propertyName);
                sb.Append("_");
                sb.Append(i.ToString());
                sb.Append("\" value=\"");
                sb.Append(l[i].Value);
                sb.Append("\"");
                for (int j = 0; j < selectedValues.Count; j++)
                {
                    if (l[i].Value == selectedValues[j].ToString())
                        sb.Append(" checked=\"checked\" ");
                }
                sb.Append(" />&nbsp;<label class=\"input-sm\" for=\"cbl");
                sb.Append(propertyName);
                sb.Append("_");
                sb.Append(i.ToString());
                sb.Append("\">");
                sb.Append(l[i].Text);
                sb.Append("</label></td>");

                if (Math.IEEERemainder((i + 1), columns) == 0)
                {
                    sb.Append("</tr><tr>");
                }

            }
            sb.Append("</tr>");
            sb.Append("</table>");

            a.Stop();

            string a1 = (a.Duration * 1000000).ToString();

            string b1 = (b.Duration * 1000000).ToString();


            return sb.ToString();
        }

        private static string ddlNoValue(string ddlName, int selectedValue, string CssClass)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<select name=\"");
            sb.Append(ddlName);
            sb.Append("\" id=\"ddl");
            sb.Append(ddlName);
            sb.Append("\" class=\"form-control input-sm");
            //sb.Append(CssClass);
            sb.Append("\">");

            for (int i = 18; i < 100; i++)
            {
                sb.Append("<option");
                if (i == selectedValue)
                    sb.Append(" selected=\"selected\"");
                sb.Append(">");
                sb.Append(i);
                sb.Append("</option>");
            }
            sb.Append("</select>");

            return sb.ToString();
        }

        public static string ddlAgeMin = ddlNoValue("agemin", 18, "selectS");
        public static string ddlAgeMax = ddlNoValue("agemax", 99, "selectS");

        public static string DropDownList(string propertyName, int selectedValue, string CssClass, bool addDefault)
        {
            int cultureId = Convert.ToInt32(System.Web.HttpContext.Current.Session["___APPCU"].ToString());
            List<PropertyItem> l = currentList(propertyName, cultureId, addDefault);
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"form-group\">");
            sb.Append("<select name=\"");
            sb.Append(propertyName);
            sb.Append("\" id=\"ddl");
            sb.Append(propertyName);
            sb.Append("\" class=\"form-control input-sm");
            //sb.Append(CssClass);
            sb.Append("\">");

            for (int i = 0; i < l.Count; i++)
            {
                sb.Append("<option value=\"");
                sb.Append(l[i].Value);
                sb.Append("\" ");

                if (l[i].Value == selectedValue.ToString())
                    sb.Append("selected=\"selected\"");

                sb.Append(">");
                sb.Append(l[i].Text);
                sb.Append("</option>");
            }
            sb.Append("</select>");
            sb.Append("</div>");

            return sb.ToString();
        }

        public static string DropDownList(string propertyName, int selectedValue, string CssClass, bool addDefault, bool multiselect)
        {
            int cultureId = Convert.ToInt32(System.Web.HttpContext.Current.Session["___APPCU"].ToString());
            List<PropertyItem> l = currentList(propertyName, cultureId, addDefault);
            StringBuilder sb = new StringBuilder();

            sb.Append("<select name=\"");
            sb.Append(propertyName);
            sb.Append("\" id=\"ddl");
            sb.Append(propertyName);
            sb.Append("\" ");
            if (multiselect)
                sb.Append("multiple=\"multiple\" height=\"100\" ");
            sb.Append("class=\"form-control input-sm");
            //sb.Append(CssClass);
            sb.Append("\">");

            for (int i = 0; i < l.Count; i++)
            {
                sb.Append("<option value=\"");
                sb.Append(l[i].Value);
                sb.Append("\" ");

                if (l[i].Value == selectedValue.ToString())
                    sb.Append("selected=\"selected\"");

                sb.Append(">");
                sb.Append(l[i].Text);
                sb.Append("</option>");
            }
            sb.Append("</select>");

            return sb.ToString();
        }

        public static List<PropertyItem> currentList(string property, int cultureId, bool addDefaultItem)
        {
            List<PropertyItem> l = new List<PropertyItem>();

            switch (property)
            {
                case "sex":
                    l = UsersProperties.Sex(cultureId);
                    break;

                case "country":
                    l = UsersProperties.Countries(cultureId, addDefaultItem);
                    break;

                case "seeksex":
                    l = UsersProperties.SeekSex(cultureId);
                    break;

                case "month":
                    l = UsersProperties.Months(cultureId);
                    break;

                case "day":
                    l = UsersProperties.Days();
                    break;

                case "year":
                    l = UsersProperties.Year();
                    break;

                case "relationship":
                    l = UsersProperties.Relationships(cultureId, addDefaultItem);
                    break;

                case "height":
                    l = UsersProperties.Height();
                    break;

                case "fashionstyle":
                    l = UsersProperties.FashionStyles(cultureId, addDefaultItem);
                    break;

                case "drinking":
                    l = UsersProperties.Drinkings(cultureId, addDefaultItem);
                    break;

                case "smoking":
                    l = UsersProperties.Smokings(cultureId, addDefaultItem);
                    break;

                case "figure":
                    l = UsersProperties.Figures(cultureId, addDefaultItem);
                    break;

                case "eyes":
                    l = UsersProperties.Eyes(cultureId, addDefaultItem);
                    break;

                case "hair":
                    l = UsersProperties.Hair(cultureId, addDefaultItem);
                    break;

                case "body":
                    l = UsersProperties.Body(cultureId, addDefaultItem);
                    break;

                case "bodyart":
                    l = UsersProperties.Bodyart(cultureId, addDefaultItem);
                    break;

                case "look":
                    l = UsersProperties.Look(cultureId, addDefaultItem);
                    break;

                case "education":
                    l = UsersProperties.Educations(cultureId, addDefaultItem);
                    break;

                case "ethnicity":
                    l = UsersProperties.Ethnicities(cultureId, addDefaultItem);
                    break;

                case "religion":
                    l = UsersProperties.Religions(cultureId, addDefaultItem);
                    break;

                case "profession":
                    l = UsersProperties.Profession(cultureId, addDefaultItem);
                    break;

                case "salary":
                    l = UsersProperties.Salary(cultureId, addDefaultItem);
                    break;

                case "diet":
                    l = UsersProperties.Diets(cultureId, addDefaultItem);
                    break;

                case "freetimefavorite":
                    l = UsersProperties.FreeTimeFavorites(cultureId, addDefaultItem);
                    break;

                case "hobbies":
                    l = UsersProperties.Hobbies(cultureId, addDefaultItem);
                    break;

                case "status":
                    l = UsersProperties.Statuses(cultureId, addDefaultItem);
                    break;

                case "statuspartner":
                    l = UsersProperties.StatusesPartner(cultureId, addDefaultItem);
                    break;

                case "kids":
                    l = UsersProperties.Kids(cultureId, addDefaultItem);
                    break;

                case "kidshave":
                    l = UsersProperties.KidsHave(cultureId, addDefaultItem);
                    break;

                case "kidswant":
                    l = UsersProperties.KidsWant(cultureId, addDefaultItem);
                    break;

                case "exercise":
                    l = UsersProperties.Excercise(cultureId, addDefaultItem);
                    break;

                case "sport":
                    l = UsersProperties.Sports(cultureId, addDefaultItem);
                    break;

                case "music":
                    l = UsersProperties.Music(cultureId, addDefaultItem);
                    break;

                case "sign":
                    l = UsersProperties.Sign(cultureId, addDefaultItem);
                    break;
            }

            return l;
        }
    }
    }