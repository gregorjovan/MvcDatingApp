namespace DatingApp.Models.User.Profile.Properties
{
    public struct PropertiesContainer
    {
        public int PropertyId;
        public int CategoryId;
    }

    public struct PersonalContainer
    {
        public int DescriptionId;
        public string Description;
    }

    public enum Categories
    {
        Relationship = 4,
        Status = 5,
        StatusPartner = 7,
        KidsHave = 8,
        Kids = 10,
        KidsWant = 11,
        Excercise = 12,
        Diet = 13,
        FashionStyle = 14,
        Smoking = 15,
        Drinking = 16,
        Figure = 19,
        Eyes = 20,
        Hair = 21,
        BestBodyFeature = 22,
        Bodyart = 23,
        Look = 24,
        FreeTimeFavorite = 25,
        Hobbies = 26,
        Sport = 27,
        Music = 28,
        Profession = 29,
        Salary = 30,
        Education = 31,
        Ethnicity = 32,
        Religion = 34

    }

    public enum PersonalCategories
    {
        About = 1,
        Partner = 7
    }

    public enum TellMoreCategories
    {
        Books = 1,
        Pets = 2,
        Interests = 3,
        Movies = 4,
        Music = 5,
        Sports = 6,
        Fashion = 7,
        TVProgrammes = 8
    }
}