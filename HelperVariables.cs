

namespace flaxseed
{
    internal static class HelperVariables
    {

        const int height_basis = 40;
        const int width_basis = 40;
        const string CONST_GREEN = "gr";
        const string CONST_YELLOW = "ye";
        const string CONST_PURPLE = "pu";
        const string CONST_ORANGE = "or";
        const string CONST_CYAN = "cy";
        const string CONST_MAGENTA = "ma";
        const string CONST_RED = "re";
        const string CONST_BLUE = "bl";
        const string CONST_WHITE = "wh";
        const string CONST_PINK = "pi";
        const string CONST_BLACK = "bk";
        const string CONST_GRAY = "ga";
        const string CONST_BROWN = "br";
        const string CONST_NO_BAR = "--";
        const string CONST_BAR = "||";
        const string CONST_LETTER = "l:";
        const string CONST_NUMBER = "n:";
        const string CONST_PUNCTUATION = "p:";
        static readonly Dictionary<char, List<string>> Letter_Colors = new Color_Arrays().Init_Letter_Colors_Dict();
		static readonly Dictionary<char, List<string>> Punctuation_Colors = new Color_Arrays().Init_Punctuation_Colors_Dict();
		static readonly Dictionary<char, List<string>> Number_Colors = new Color_Arrays().Init_Number_Colors_Dict();

        public static Dictionary<char, List<string>> Letter_Colors_Public => Letter_Colors;

        public static Dictionary<char, List<string>> Punctuation_Colors_Public => Punctuation_Colors;

        public static Dictionary<char, List<string>> Number_Colors_Public => Number_Colors;

        public static int Height_basis_public => height_basis;

        public static int Width_basis_public => width_basis;

        public static string PUBLIC_CONST_GREEN=> CONST_GREEN;

        public static string PUBLIC_CONST_YELLOW => CONST_YELLOW;

        public static string PUBLIC_CONST_PURPLE => CONST_PURPLE;

        public static string PUBLIC_CONST_ORANGE => CONST_ORANGE;

        public static string PUBLIC_CONST_CYAN => CONST_CYAN;

        public static string PUBLIC_CONST_MAGENTA => CONST_MAGENTA;

        public static string PUBLIC_CONST_RED => CONST_RED;

        public static string PUBLIC_CONST_BLUE => CONST_BLUE;

        public static string PUBLIC_CONST_WHITE => CONST_WHITE;

        public static string PUBLIC_CONST_PINK => CONST_PINK;

        public static string PUBLIC_CONST_BLACK => CONST_BLACK;

        public static string PUBLIC_CONST_GRAY => CONST_GRAY;

        public static string PUBLIC_CONST_BROWN => CONST_BROWN;

        public static string PUBLIC_CONST_NO_BAR => CONST_NO_BAR;

        public static string PUBLIC_CONST_BAR => CONST_BAR;

        public static string PUBLIC_CONST_LETTER => CONST_LETTER;

        public static string PUBLIC_CONST_NUMBER => CONST_NUMBER;

        public static string PUBLIC_CONST_PUNCTUATION => CONST_PUNCTUATION;
    }
}