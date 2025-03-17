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
            Letter_Colors.Add('A', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.GREEN_PUBLIC]);
            Letter_Colors.Add('B', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.YELLOW_PUBLIC]);
            Letter_Colors.Add('C', [HelperVariables.LETTER_PUBLIC, HelperVariables.PURPLE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Letter_Colors.Add('D', [HelperVariables.LETTER_PUBLIC, HelperVariables.ORANGE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.ORANGE_PUBLIC]);
            Letter_Colors.Add('E', [HelperVariables.LETTER_PUBLIC, HelperVariables.CYAN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            Letter_Colors.Add('F', [HelperVariables.LETTER_PUBLIC, HelperVariables.PURPLE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Letter_Colors.Add('G', [HelperVariables.LETTER_PUBLIC, HelperVariables.MAGENTA_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.MAGENTA_PUBLIC]);
            Letter_Colors.Add('H', [HelperVariables.LETTER_PUBLIC, HelperVariables.RED_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.RED_PUBLIC]);
            Letter_Colors.Add('I', [HelperVariables.LETTER_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.BLUE_PUBLIC]);
            Letter_Colors.Add('J', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.WHITE_PUBLIC]);
            Letter_Colors.Add('K', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.GREEN_PUBLIC]);
            Letter_Colors.Add('L', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.YELLOW_PUBLIC]);
            Letter_Colors.Add('M', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Letter_Colors.Add('N', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.ORANGE_PUBLIC]);
            Letter_Colors.Add('O', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            Letter_Colors.Add('P', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Letter_Colors.Add('Q', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.MAGENTA_PUBLIC]);
            Letter_Colors.Add('R', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.RED_PUBLIC]);
            Letter_Colors.Add('S', [HelperVariables.LETTER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.BLUE_PUBLIC]);
            Letter_Colors.Add('T', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.WHITE_PUBLIC]);
            Letter_Colors.Add('U', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.GREEN_PUBLIC]);
            Letter_Colors.Add('V', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.YELLOW_PUBLIC]);
            Letter_Colors.Add('W', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Letter_Colors.Add('X', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.ORANGE_PUBLIC]);
            Letter_Colors.Add('Y', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            Letter_Colors.Add('Z', [HelperVariables.LETTER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            return Letter_Colors;
        }

        public Dictionary<char, List<string>> Init_Number_Colors_Dict(){
            Number_Colors.Add('0', [HelperVariables.NUMBER_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.GREEN_PUBLIC]);
            Number_Colors.Add('1', [HelperVariables.NUMBER_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.BLUE_PUBLIC]);
            Number_Colors.Add('2', [HelperVariables.NUMBER_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.YELLOW_PUBLIC]);
            Number_Colors.Add('3', [HelperVariables.NUMBER_PUBLIC, HelperVariables.WHITE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.WHITE_PUBLIC]);
            Number_Colors.Add('4', [HelperVariables.NUMBER_PUBLIC, HelperVariables.MAGENTA_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.MAGENTA_PUBLIC]);
            Number_Colors.Add('5', [HelperVariables.NUMBER_PUBLIC, HelperVariables.ORANGE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.ORANGE_PUBLIC]);
            Number_Colors.Add('6', [HelperVariables.NUMBER_PUBLIC, HelperVariables.CYAN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            Number_Colors.Add('7', [HelperVariables.NUMBER_PUBLIC, HelperVariables.PINK_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PINK_PUBLIC]);
            Number_Colors.Add('8', [HelperVariables.NUMBER_PUBLIC, HelperVariables.RED_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.RED_PUBLIC]);
            Number_Colors.Add('9', [HelperVariables.NUMBER_PUBLIC, HelperVariables.PURPLE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            return Number_Colors;
        }

        public Dictionary<char, List<string>> Init_Punctuation_Colors_Dict(){
            Punctuation_Colors.Add(' ', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLACK_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.BLACK_PUBLIC]);
            Punctuation_Colors.Add('!', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.GREEN_PUBLIC]);
            Punctuation_Colors.Add('@', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.BLUE_PUBLIC]);
            Punctuation_Colors.Add('#', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.YELLOW_PUBLIC]);
            Punctuation_Colors.Add('$', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.WHITE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.WHITE_PUBLIC]);
            Punctuation_Colors.Add('%', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.MAGENTA_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.MAGENTA_PUBLIC]);
            Punctuation_Colors.Add('^', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.ORANGE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.ORANGE_PUBLIC]);
            Punctuation_Colors.Add('&', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.CYAN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            Punctuation_Colors.Add('*', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.PINK_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PINK_PUBLIC]);
            Punctuation_Colors.Add('(', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.RED_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.RED_PUBLIC]);
            Punctuation_Colors.Add(')', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.PURPLE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Punctuation_Colors.Add('-', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.BLUE_PUBLIC]);
            Punctuation_Colors.Add('_', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.YELLOW_PUBLIC]);
            Punctuation_Colors.Add('+', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.WHITE_PUBLIC]);
            Punctuation_Colors.Add('=', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.MAGENTA_PUBLIC]);
            Punctuation_Colors.Add('`', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.RED_PUBLIC]);
            Punctuation_Colors.Add('~', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            Punctuation_Colors.Add('[', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.GREEN_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Punctuation_Colors.Add(']', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.GREEN_PUBLIC]);
            Punctuation_Colors.Add('{', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.WHITE_PUBLIC]);
            Punctuation_Colors.Add('}', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.RED_PUBLIC]);
            Punctuation_Colors.Add('\\', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PURPLE_PUBLIC]);
            Punctuation_Colors.Add('|', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.YELLOW_PUBLIC]);
            Punctuation_Colors.Add(';', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PINK_PUBLIC]);
            Punctuation_Colors.Add(':', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            Punctuation_Colors.Add('\'', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.BLUE_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.MAGENTA_PUBLIC]);
            Punctuation_Colors.Add('\"', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.GREEN_PUBLIC]);
            Punctuation_Colors.Add(',', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.BLUE_PUBLIC]);
            Punctuation_Colors.Add('<', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.MAGENTA_PUBLIC]);
            Punctuation_Colors.Add('.', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.WHITE_PUBLIC]);
            Punctuation_Colors.Add('>', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.RED_PUBLIC]);
            Punctuation_Colors.Add('/', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.PINK_PUBLIC]);
            Punctuation_Colors.Add('?', [HelperVariables.PUNCTUATION_PUBLIC, HelperVariables.YELLOW_PUBLIC, HelperVariables.NO_BAR_PUBLIC, HelperVariables.CYAN_PUBLIC]);
            return Punctuation_Colors;
        }

        public Dictionary<string, SixLabors.ImageSharp.Color> Init_Color_Codes_Dict(){
            Color_Codes.Add(HelperVariables.GREEN_PUBLIC, SixLabors.ImageSharp.Color.Green);
            Color_Codes.Add(HelperVariables.GRAY_PUBLIC, SixLabors.ImageSharp.Color.Gray);
            Color_Codes.Add(HelperVariables.YELLOW_PUBLIC, SixLabors.ImageSharp.Color.Yellow);
            Color_Codes.Add(HelperVariables.PURPLE_PUBLIC, SixLabors.ImageSharp.Color.Purple);
            Color_Codes.Add(HelperVariables.ORANGE_PUBLIC, SixLabors.ImageSharp.Color.Orange);
            Color_Codes.Add(HelperVariables.CYAN_PUBLIC, SixLabors.ImageSharp.Color.Cyan);
            Color_Codes.Add(HelperVariables.PINK_PUBLIC, SixLabors.ImageSharp.Color.Pink);
            Color_Codes.Add(HelperVariables.MAGENTA_PUBLIC, SixLabors.ImageSharp.Color.Magenta);
            Color_Codes.Add(HelperVariables.RED_PUBLIC, SixLabors.ImageSharp.Color.Red);
            Color_Codes.Add(HelperVariables.BLUE_PUBLIC, SixLabors.ImageSharp.Color.Blue);
            Color_Codes.Add(HelperVariables.WHITE_PUBLIC, SixLabors.ImageSharp.Color.White);
            Color_Codes.Add(HelperVariables.BLACK_PUBLIC, SixLabors.ImageSharp.Color.Black);
            Color_Codes.Add(HelperVariables.BROWN_PUBLIC, SixLabors.ImageSharp.Color.Brown);
            return Color_Codes;
        }
    }
}