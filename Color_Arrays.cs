using System.Drawing;

namespace flaxseed { 
    public class Color_Arrays{


        /*
        OVERALL SCHEMA
        2 colors per character
        7 characters in code for each original letter in input 
        gr = green
        ye = yellow
        pu = purple
        or = orange
        cy = cyan
        pi = pink
        ma = magenta
        re = red
        bl = blue
        wh = white
        -- = lack of bar
        || = thin white vertical bar separating two colors    

        l: = letter
        n: = number
        p: = punctuation

        Letters = rectangle entire height of row
        Numbers = rectangle on upper half of row
        Special characters = rectangle on lower half of row
        */

        private readonly Dictionary<char, List<string>> Letter_Colors = [];
        private readonly Dictionary<char, List<string>> Punctuation_Colors = [];
        private readonly Dictionary<char, List<string>> Number_Colors = [];
        private readonly Dictionary<string, SixLabors.ImageSharp.Color> Color_Codes = [];
        

        public Dictionary<char, List<string>> Init_Letter_Colors_Dict(){
            Letter_Colors.Add('A', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_GREEN]);
            Letter_Colors.Add('B', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_YELLOW]);
            Letter_Colors.Add('C', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_PURPLE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Letter_Colors.Add('D', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_ORANGE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_ORANGE]);
            Letter_Colors.Add('E', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_CYAN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            Letter_Colors.Add('F', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_PURPLE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Letter_Colors.Add('G', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_MAGENTA, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_MAGENTA]);
            Letter_Colors.Add('H', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_RED, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_RED]);
            Letter_Colors.Add('I', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_BLUE]);
            Letter_Colors.Add('J', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_WHITE]);
            Letter_Colors.Add('K', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_GREEN]);
            Letter_Colors.Add('L', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_YELLOW]);
            Letter_Colors.Add('M', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Letter_Colors.Add('N', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_ORANGE]);
            Letter_Colors.Add('O', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            Letter_Colors.Add('P', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Letter_Colors.Add('Q', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_MAGENTA]);
            Letter_Colors.Add('R', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_RED]);
            Letter_Colors.Add('S', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_BLUE]);
            Letter_Colors.Add('T', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_WHITE]);
            Letter_Colors.Add('U', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_GREEN]);
            Letter_Colors.Add('V', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_YELLOW]);
            Letter_Colors.Add('W', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Letter_Colors.Add('X', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_ORANGE]);
            Letter_Colors.Add('Y', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            Letter_Colors.Add('Z', [HelperVariables.PUBLIC_CONST_LETTER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            return Letter_Colors;
        }

        public Dictionary<char, List<string>> Init_Number_Colors_Dict(){
            Number_Colors.Add('0', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_GREEN]);
            Number_Colors.Add('1', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_BLUE]);
            Number_Colors.Add('2', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_YELLOW]);
            Number_Colors.Add('3', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_WHITE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_WHITE]);
            Number_Colors.Add('4', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_MAGENTA, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_MAGENTA]);
            Number_Colors.Add('5', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_ORANGE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_ORANGE]);
            Number_Colors.Add('6', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_CYAN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            Number_Colors.Add('7', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_PINK, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PINK]);
            Number_Colors.Add('8', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_RED, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_RED]);
            Number_Colors.Add('9', [HelperVariables.PUBLIC_CONST_NUMBER, HelperVariables.PUBLIC_CONST_PURPLE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            return Number_Colors;
        }

        public Dictionary<char, List<string>> Init_Punctuation_Colors_Dict(){
            Punctuation_Colors.Add(' ', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLACK, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_BLACK]);
            Punctuation_Colors.Add('!', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_GREEN]);
            Punctuation_Colors.Add('@', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_BLUE]);
            Punctuation_Colors.Add('#', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_YELLOW]);
            Punctuation_Colors.Add('$', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_WHITE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_WHITE]);
            Punctuation_Colors.Add('%', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_MAGENTA, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_MAGENTA]);
            Punctuation_Colors.Add('^', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_ORANGE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_ORANGE]);
            Punctuation_Colors.Add('&', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_CYAN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            Punctuation_Colors.Add('*', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_PINK, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PINK]);
            Punctuation_Colors.Add('(', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_RED, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_RED]);
            Punctuation_Colors.Add(')', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_PURPLE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Punctuation_Colors.Add('-', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_BLUE]);
            Punctuation_Colors.Add('_', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_YELLOW]);
            Punctuation_Colors.Add('+', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_WHITE]);
            Punctuation_Colors.Add('=', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_MAGENTA]);
            Punctuation_Colors.Add('`', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_RED]);
            Punctuation_Colors.Add('~', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            Punctuation_Colors.Add('[', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_GREEN, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Punctuation_Colors.Add(']', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_GREEN]);
            Punctuation_Colors.Add('{', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_WHITE]);
            Punctuation_Colors.Add('}', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_RED]);
            Punctuation_Colors.Add('\\', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PURPLE]);
            Punctuation_Colors.Add('|', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_YELLOW]);
            Punctuation_Colors.Add(';', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PINK]);
            Punctuation_Colors.Add(':', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            Punctuation_Colors.Add('\'', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_BLUE, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_MAGENTA]);
            Punctuation_Colors.Add('\"', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_GREEN]);
            Punctuation_Colors.Add(',', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_BLUE]);
            Punctuation_Colors.Add('<', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_MAGENTA]);
            Punctuation_Colors.Add('.', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_WHITE]);
            Punctuation_Colors.Add('>', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_RED]);
            Punctuation_Colors.Add('/', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_PINK]);
            Punctuation_Colors.Add('?', [HelperVariables.PUBLIC_CONST_PUNCTUATION, HelperVariables.PUBLIC_CONST_YELLOW, HelperVariables.PUBLIC_CONST_NO_BAR, HelperVariables.PUBLIC_CONST_CYAN]);
            return Punctuation_Colors;
        }

        public Dictionary<string, SixLabors.ImageSharp.Color> Init_Color_Codes_Dict(){
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_GREEN, SixLabors.ImageSharp.Color.Green);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_GRAY, SixLabors.ImageSharp.Color.Gray);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_YELLOW, SixLabors.ImageSharp.Color.Yellow);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_PURPLE, SixLabors.ImageSharp.Color.Purple);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_ORANGE, SixLabors.ImageSharp.Color.Orange);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_CYAN, SixLabors.ImageSharp.Color.Cyan);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_PINK, SixLabors.ImageSharp.Color.Pink);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_MAGENTA, SixLabors.ImageSharp.Color.Magenta);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_RED, SixLabors.ImageSharp.Color.Red);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_BLUE, SixLabors.ImageSharp.Color.Blue);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_WHITE, SixLabors.ImageSharp.Color.White);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_BLACK, SixLabors.ImageSharp.Color.Black);
            Color_Codes.Add(HelperVariables.PUBLIC_CONST_BROWN, SixLabors.ImageSharp.Color.Brown);
            return Color_Codes;
        }
    }
}