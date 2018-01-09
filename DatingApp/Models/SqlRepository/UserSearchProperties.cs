using DatingApp.Models.User.Profile.Properties;

namespace DatingApp.Models.SqlRepository
{
    public class UserSearchProperties
    {
        #region Data members       

        public Basic BasicProperties { get; set; }
        public Appearance AppearanceProperties { get; set; }
        public Interests InterestsProperties { get; set; }
        public Lifestyle LifestyleProperties { get; set; }
        public Values ValuesProperties { get; set; }
        public Username UsernameValue { get; set; }
        public WelcomeMessage WelcomeMessageProperties { get; set; }
        public string DescriptionLowResolution { get; set; }

        private int userId;

        #endregion

        #region Constructor

        public UserSearchProperties(int userId)
        {
            this.userId = userId;

        }

        #endregion

        #region Function members

        public void Get()
        {
            Basic basicGet = new Basic(this.userId);
            Appearance appearanceGet = new Appearance(this.userId);
            Interests interestsGet = new Interests(this.userId);
            Lifestyle lifestyleGet = new Lifestyle(this.userId);
            Values valuesGet = new Values(this.userId);
            Username usernameGet = new Username(this.userId);
            WelcomeMessage welcomeGet = new WelcomeMessage(this.userId);
            PersonalDescription personalGet = new PersonalDescription(this.userId);

            basicGet.Get();
            this.BasicProperties = basicGet;


            appearanceGet.Get();
            this.AppearanceProperties = appearanceGet;


            interestsGet.Get();
            this.InterestsProperties = interestsGet;


            lifestyleGet.Get();
            this.LifestyleProperties = lifestyleGet;


            valuesGet.Get();
            this.ValuesProperties = valuesGet;


            usernameGet.Get();
            this.UsernameValue = usernameGet;


            welcomeGet.Get();
            this.WelcomeMessageProperties = welcomeGet;

            personalGet.Get();
            if (personalGet.About.Length < 246)
                this.DescriptionLowResolution = personalGet.About + "&nbsp;...";
            else
                this.DescriptionLowResolution = personalGet.About.Substring(0, 245) + "&nbsp;...";
        }

        #endregion
    }
}