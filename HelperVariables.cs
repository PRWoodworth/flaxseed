namespace flaxseed
{
    internal static class HelperVariables
    {

        const int height_basis = 40;
        const int width_basis = 40;
        static readonly Dictionary<char, List<string>> Letter_Colors = new Color_Arrays().Init_Letter_Colors_Dict();
		static readonly Dictionary<char, List<string>> Punctuation_Colors = new Color_Arrays().Init_Punctuation_Colors_Dict();
		static readonly Dictionary<char, List<string>> Number_Colors = new Color_Arrays().Init_Number_Colors_Dict();

        public static int Height_basis => height_basis;

        public static int Width_basis => width_basis;

        public static Dictionary<char, List<string>> Letter_Colors_Public => Letter_Colors;

        public static Dictionary<char, List<string>> Punctuation_Colors_Public => Punctuation_Colors;

        public static Dictionary<char, List<string>> Number_Colors_Public => Number_Colors;
    }
}