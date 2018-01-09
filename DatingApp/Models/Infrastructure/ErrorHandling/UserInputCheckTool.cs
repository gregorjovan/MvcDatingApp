using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

namespace DatingApp.Models.Infrastructure.ErrorHandling
{
    public abstract class UserInputCheckTool : ErrorHandler
    {
        protected void Check(object data)
        {
            Type t = data.GetType();
            FieldInfo[] pi = t.GetFields();

            for (int i = 0; i < pi.Length; i++)
            {
                string fieldName = (pi[i].Name);

                switch (fieldName)
                {
                    case "Username":
                        this.CheckUsername((string)t.GetField("Username").GetValue(data));
                        break;

                    case "Password":
                        this.CheckPassword((string)t.GetField("Password").GetValue(data));
                        break;

                    case "Country":
                        this.CheckCountry((int)t.GetField("Country").GetValue(data));
                        break;

                    case "Sex":
                        this.CheckSex((int)t.GetField("Sex").GetValue(data));
                        break;

                    case "Email":
                        this.CheckEmail((string)t.GetField("Email").GetValue(data));
                        break;

                    case "City":
                        this.CheckCity((int)t.GetField("City").GetValue(data));
                        break;

                    case "SeekSex":
                        this.CheckSeekSex((int)t.GetField("SeekSex").GetValue(data));
                        break;

                    case "Relationship":
                        this.CheckRelationship((List<int>)t.GetField("Relationship").GetValue(data));
                        break;

                    case "Height":
                        this.CheckHeight((int)t.GetField("Height").GetValue(data));
                        break;

                    case "FashionStyle":
                        this.CheckFashionStyle((List<int>)t.GetField("FashionStyle").GetValue(data));
                        break;

                    case "Smoking":
                        this.CheckSmoking((int)t.GetField("Smoking").GetValue(data));
                        break;

                    case "Drinking":
                        this.CheckDrinking((int)t.GetField("Drinking").GetValue(data));
                        break;

                    case "Figure":
                        this.CheckFigure((int)t.GetField("Figure").GetValue(data));
                        break;

                    case "Diet":
                        this.CheckDiet((List<int>)t.GetField("Diet").GetValue(data));
                        break;

                    case "Education":
                        this.CheckEducation((int)t.GetField("Education").GetValue(data));
                        break;

                    case "Ethnicity":
                        this.CheckEthnicity((int)t.GetField("Ethnicity").GetValue(data));
                        break;

                    case "Religion":
                        this.CheckReligion((int)t.GetField("Religion").GetValue(data));
                        break;

                    case "FreeTimeFavorite":
                        this.CheckFreeTimeFavorite((List<int>)t.GetField("FreeTimeFavorite").GetValue(data));
                        break;

                    case "Hobbies":
                        this.CheckHobbies((List<int>)t.GetField("Hobbies").GetValue(data));
                        break;

                    case "Introduction":
                        this.CheckIntroduction((string)t.GetField("Introduction").GetValue(data));
                        break;
                }
            }
        }

        protected void Check(object data, bool checkProperties)
        {
            Type t = data.GetType();
            PropertyInfo[] pi = t.GetProperties();

            for (int i = 0; i < pi.Length; i++)
            {
                switch (pi[i].Name)
                {
                    case "Username":
                        this.CheckUsername((string)pi[i].GetValue(data, null));
                        break;

                    case "Password":
                        this.CheckPassword((string)pi[i].GetValue(data, null));
                        break;

                    case "Country":
                        this.CheckCountry((int)pi[i].GetValue(data, null));
                        break;

                    case "Sex":
                        this.CheckSex((int)pi[i].GetValue(data, null));
                        break;

                    case "Email":
                        this.CheckEmail((string)pi[i].GetValue(data, null));
                        break;

                    case "City":
                        this.CheckCity((int)pi[i].GetValue(data, null));
                        break;

                    case "SeekSex":
                        this.CheckSeekSex((int)pi[i].GetValue(data, null));
                        break;

                    case "Relationship":
                        this.CheckRelationship((List<int>)pi[i].GetValue(data, null));
                        break;

                    case "Height":
                        this.CheckHeight((int)pi[i].GetValue(data, null));
                        break;

                    case "FashionStyle":
                        this.CheckFashionStyle((List<int>)pi[i].GetValue(data, null));
                        break;

                    case "Smoking":
                        this.CheckSmoking((int)pi[i].GetValue(data, null));
                        break;

                    case "Drinking":
                        this.CheckDrinking((int)pi[i].GetValue(data, null));
                        break;

                    case "Figure":
                        this.CheckFigure((int)pi[i].GetValue(data, null));
                        break;

                    case "Diet":
                        this.CheckDiet((List<int>)pi[i].GetValue(data, null));
                        break;

                    case "Education":
                        this.CheckEducation((int)pi[i].GetValue(data, null));
                        break;

                    case "Ethnicity":
                        this.CheckEthnicity((int)pi[i].GetValue(data, null));
                        break;

                    case "Religion":
                        this.CheckReligion((int)pi[i].GetValue(data, null));
                        break;

                    case "FreeTimeFavorite":
                        this.CheckFreeTimeFavorite((List<int>)pi[i].GetValue(data, null));
                        break;

                    case "Hobbies":
                        this.CheckHobbies((List<int>)pi[i].GetValue(data, null));
                        break;

                    case "Introduction":
                        this.CheckIntroduction((string)pi[i].GetValue(data, null));
                        break;
                }

            }
        }

        protected void CheckBirthday(int day, int month, int year)
        {
            try
            {
                DateTime dt = new DateTime(year, month, day);
            }
            catch (Exception e)
            {
                this.errors.Add("birthday", Resources.ErrorMessages.ErrorMessages.BirthdayNotSet);
            }
        }

        /// <summary>
        /// Check email user input
        /// </summary>
        /// <param name="email">email</param>
        protected void CheckEmail(string email)
        {
            if (email.Length == 0)
            {
                this.errors.Add("email", Resources.ErrorMessages.ErrorMessages.EmailNotSet);
            }
            else if (EmailHelper.EmailIsValid(email) == false)
            {
                this.errors.Add("email", Resources.ErrorMessages.ErrorMessages.EmailNotValid);
            }
            else if (UserHelper.EmailExists(email) == true)
            {
                this.errors.Add("email", Resources.ErrorMessages.ErrorMessages.EmailExists);
            }
        }

        /// <summary>
        /// Check email user input
        /// </summary>
        /// <param name="email">email</param>
        protected void CheckUsername(string username)
        {
            if (username.Length == 0)
            {
                this.errors.Add("username", Resources.ErrorMessages.ErrorMessages.UsernameNotSet);
            }
            else if (username.Length < DatingSettings.UsernameMinLenght)
            {
                this.errors.Add("username", Resources.ErrorMessages.ErrorMessages.UsernameTooShort);
            }
            else if (username.Length > DatingSettings.UsernameMaxLenght)
            {
                this.errors.Add("username", Resources.ErrorMessages.ErrorMessages.UsernameTooLong);
            }
            else if (UserHelper.UsernameIsValid(username) == false)
            {
                this.errors.Add("username", Resources.ErrorMessages.ErrorMessages.UsernameNotValid);
            }
            else if (UserHelper.UsernameExists(username) == true)
            {
                this.errors.Add("username", Resources.ErrorMessages.ErrorMessages.UsernameExists);
            }
        }

        protected void CheckPassword(string password)
        {
            if (password.Length == 0)
            {
                this.errors.Add("password", Resources.ErrorMessages.ErrorMessages.PasswordNotSet);
            }
            else if (password.Length < DatingSettings.PasswordMinLenght)
            {
                this.errors.Add("password", Resources.ErrorMessages.ErrorMessages.PasswordTooShort);
            }
            else if (password.Length > DatingSettings.PasswordMaxLenght)
            {
                this.errors.Add("password", Resources.ErrorMessages.ErrorMessages.PasswordTooLong);
            }
        }

        protected void CheckSex(int sex)
        {
            if (!(sex == 1 || sex == 2))
            {
                this.errors.Add("sex", Resources.ErrorMessages.ErrorMessages.SexNotSet);
            }
        }

        protected void CheckCountry(int country)
        {
            if (country == 0)
            {
                this.errors.Add("country", Resources.ErrorMessages.ErrorMessages.CountryNotSet);
            }
        }

        protected void CheckCity(int city)
        {
            if (city == 0)
            {
                this.errors.Add("city", Resources.ErrorMessages.ErrorMessages.CityNotSet);
            }
        }

        protected void CheckSeekSex(int seekSex)
        {
            if (!(seekSex == 1 || seekSex == 2 || seekSex == 3))
            {
                this.errors.Add("seeksex", Resources.ErrorMessages.ErrorMessages.SeekSexNotSet);
            }
        }

        protected void CheckRelationship(List<int> relationship)
        {
            if (relationship.Count == 0)
            {
                this.errors.Add("relationship", Resources.ErrorMessages.ErrorMessages.RelationshipNotSet);
            }
        }

        protected void CheckHeight(int height)
        {
            if (height == 0 || height < DatingSettings.HeightMin || height > DatingSettings.HeightMax)
            {
                this.errors.Add("height", Resources.ErrorMessages.ErrorMessages.HeightNotSet);
            }
        }

        protected void CheckFashionStyle(List<int> fashionStyle)
        {
            if (fashionStyle.Count == 0)
            {
                if (this.errors.Get("fashionstyle") == null)
                    this.errors.Add("fashionstyle", Resources.ErrorMessages.ErrorMessages.FashionStyleNotSet);
            }
        }

        protected void CheckSmoking(int smoking)
        {
            if (smoking == 0)
            {
                this.errors.Add("smoking", Resources.ErrorMessages.ErrorMessages.SmokingNotSet);
            }
        }

        protected void CheckDrinking(int drinking)
        {
            if (drinking == 0)
            {
                this.errors.Add("drinking", Resources.ErrorMessages.ErrorMessages.DrinkingNotSet);
            }
        }

        protected void CheckFigure(int figure)
        {
            if (figure == 0)
            {
                this.errors.Add("figure", Resources.ErrorMessages.ErrorMessages.FigureNotSet);
            }
        }

        protected void CheckDiet(List<int> diet)
        {
            if (diet.Count == 0)
            {
                this.errors.Add("diet", Resources.ErrorMessages.ErrorMessages.DietNotSet);
            }
        }

        protected void CheckEducation(int education)
        {
            if (education == 0)
            {
                this.errors.Add("education", Resources.ErrorMessages.ErrorMessages.EducationNotSet);
            }
        }

        protected void CheckEthnicity(int ethnicity)
        {
            if (ethnicity == 0)
            {
                this.errors.Add("ethnicity", Resources.ErrorMessages.ErrorMessages.EthnicityNotSet);
            }
        }

        protected void CheckReligion(int religion)
        {
            if (religion == 0)
            {
                this.errors.Add("religion", Resources.ErrorMessages.ErrorMessages.ReligionNotSet);
            }
        }

        protected void CheckFreeTimeFavorite(List<int> freeTimeFavorite)
        {
            if (freeTimeFavorite.Count == 0)
            {
                this.errors.Add("freetimefavorite", Resources.ErrorMessages.ErrorMessages.FreeTimeNotSet);
            }
        }

        protected void CheckHobbies(List<int> hobbies)
        {
            if (hobbies.Count == 0)
            {
                this.errors.Add("hobbies", Resources.ErrorMessages.ErrorMessages.HobbiesNotSet);
            }
        }

        protected void CheckIntroduction(string introduction)
        {
            if (introduction.Length < DatingSettings.IntroductionMinLenght || introduction.Length > DatingSettings.IntroductionMaxLenght)
            {
                this.errors.Add("introduction", Resources.ErrorMessages.ErrorMessages.IntroductionNotSet);
            }
        }



    }
}