

namespace flaxseed
{
    internal static class HelperVariables
    {

        const int height_basis = 40;
        const int width_basis = 40;
        private const string GREEN = "gr";
        private const string YELLOW = "ye";
        private const string PURPLE = "pu";
        private const string ORANGE = "or";
        private const string CYAN = "cy";
        private const string MAGENTA = "ma";
        private const string RED = "re";
        private const string BLUE = "bl";
        private const string WHITE = "wh";
        private const string PINK = "pi";
        private const string BLACK = "bk";
        private const string GRAY = "ga";
        private const string BROWN = "br";
        private const string NO_BAR = "--";
        private const string BAR = "||";
        private const string LETTER = "l:";
        private const string NUMBER = "n:";
        private const string PUNCTUATION = "p:";
        static readonly Dictionary<char, List<string>> Letter_Colors = new Color_Arrays().Init_Letter_Colors_Dict();
		static readonly Dictionary<char, List<string>> Punctuation_Colors = new Color_Arrays().Init_Punctuation_Colors_Dict();
		static readonly Dictionary<char, List<string>> Number_Colors = new Color_Arrays().Init_Number_Colors_Dict();

        public static Dictionary<char, List<string>> Letter_Colors_Public => Letter_Colors;

        public static Dictionary<char, List<string>> Punctuation_Colors_Public => Punctuation_Colors;

        public static Dictionary<char, List<string>> Number_Colors_Public => Number_Colors;

        public static int Height_basis_public => height_basis;

        public static int Width_basis_public => width_basis;

        public static string GREEN_PUBLIC => GREEN;

        public static string YELLOW_PUBLIC => YELLOW;

        public static string PURPLE_PUBLIC => PURPLE;

        public static string ORANGE_PUBLIC => ORANGE;

        public static string CYAN_PUBLIC => CYAN;

        public static string MAGENTA_PUBLIC => MAGENTA;

        public static string RED_PUBLIC => RED;

        public static string BLUE_PUBLIC => BLUE;

        public static string WHITE_PUBLIC => WHITE;

        public static string PINK_PUBLIC => PINK;

        public static string BLACK_PUBLIC => BLACK;

        public static string GRAY_PUBLIC => GRAY;

        public static string BROWN_PUBLIC => BROWN;

        public static string NO_BAR_PUBLIC => NO_BAR;

        public static string BAR_PUBLIC => BAR;

        public static string LETTER_PUBLIC => LETTER;

        public static string NUMBER_PUBLIC => NUMBER;

        public static string PUNCTUATION_PUBLIC => PUNCTUATION;
    }
}