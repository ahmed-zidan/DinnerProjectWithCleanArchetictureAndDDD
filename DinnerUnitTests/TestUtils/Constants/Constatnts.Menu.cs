

namespace DinnerUnitTests.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Menu
        {
            //public const string HostId =
            public const string Name = "menuName";
            public const string Description = "menuDescription";
            public const string SectionName = "SectionName";
            public const string SectionDescription = "SectionDescription";

            public const string ItemName = "ItemName";
            public const string ItemDescription = "ItemDescription";

            public static string SectionNameFromIndex(int index) => $"{SectionName}{index}";
            public static string SectionDescriptionFromIndex(int index) => $"{SectionDescription}{index}";


            public static string ItemNameFromIndex(int index) => $"{ItemName}{index}";
            public static string ItemDescriptionFromIndex(int index) => $"{ItemDescription}{index}";


        }
    }
}
