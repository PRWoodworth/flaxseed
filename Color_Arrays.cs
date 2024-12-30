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

        private static Dictionary<string, SixLabors.ImageSharp.Color> Overall_Codec = [];
        private static Dictionary<char, List<string>> Letter_Colors = [];
        private static Dictionary<char, List<string>> Punctuation_Colors = [];
        private static Dictionary<char, List<string>> Number_Colors = [];
        private static Dictionary<string, SixLabors.ImageSharp.Color> Color_Codes = [];
        

        public Dictionary<char, List<string>> Init_Letter_Colors_Dict(){
            Letter_Colors.Add('A', ["l:", "gr", "--" ,"gr"]);
            Letter_Colors.Add('B', ["l:", "ye", "--" ,"ye"]);
            Letter_Colors.Add('C', ["l:", "pu", "--" ,"pu"]);
            Letter_Colors.Add('D', ["l:", "or", "--" ,"or"]);
            Letter_Colors.Add('E', ["l:", "cy", "--" ,"cy"]);
            Letter_Colors.Add('F', ["l:", "pu", "--" ,"pu"]);
            Letter_Colors.Add('G', ["l:", "ma", "--" ,"ma"]);
            Letter_Colors.Add('H', ["l:", "re", "--" ,"re"]);
            Letter_Colors.Add('I', ["l:", "bl", "--" ,"bl"]);
            Letter_Colors.Add('J', ["l:", "gr", "||" ,"wh"]);
            Letter_Colors.Add('K', ["l:", "gr", "||" ,"gr"]);
            Letter_Colors.Add('L', ["l:", "gr", "||" ,"ye"]);
            Letter_Colors.Add('M', ["l:", "gr", "||" ,"pu"]);
            Letter_Colors.Add('N', ["l:", "gr", "||" ,"or"]);
            Letter_Colors.Add('O', ["l:", "gr", "||" ,"cy"]);
            Letter_Colors.Add('P', ["l:", "gr", "||" ,"pu"]);
            Letter_Colors.Add('Q', ["l:", "gr", "||" ,"ma"]);
            Letter_Colors.Add('R', ["l:", "gr", "||" ,"re"]);
            Letter_Colors.Add('S', ["l:", "gr", "||" ,"bl"]);
            Letter_Colors.Add('T', ["l:", "ye", "||" ,"wh"]);
            Letter_Colors.Add('U', ["l:", "ye", "||" ,"gr"]);
            Letter_Colors.Add('V', ["l:", "ye", "||" ,"ye"]);
            Letter_Colors.Add('W', ["l:", "ye", "||" ,"pu"]);
            Letter_Colors.Add('X', ["l:", "ye", "||" ,"or"]);
            Letter_Colors.Add('Y', ["l:", "ye", "||" ,"cy"]);
            Letter_Colors.Add('Z', ["l:", "ye", "||" ,"pu"]);

            return Letter_Colors;
        }

        public Dictionary<char, List<string>> Init_Number_Colors_Dict(){
            Number_Colors.Add('0', ["n:", "gr", "--" ,"gr"]);
            Number_Colors.Add('1', ["n:", "bl", "--" ,"bl"]);
            Number_Colors.Add('2', ["n:", "ye", "--" ,"ye"]);
            Number_Colors.Add('3', ["n:", "wh", "--" ,"wh"]);
            Number_Colors.Add('4', ["n:", "ma", "--" ,"ma"]);
            Number_Colors.Add('5', ["n:", "or", "--" ,"or"]);
            Number_Colors.Add('6', ["n:", "cy", "--" ,"cy"]);
            Number_Colors.Add('7', ["n:", "pi", "--" ,"pi"]);
            Number_Colors.Add('8', ["n:", "re", "--" ,"re"]);
            Number_Colors.Add('9', ["n:", "pu", "--" ,"pu"]);
            return Number_Colors;
        }

        public Dictionary<char, List<string>> Init_Punctuation_Colors_Dict(){
            Punctuation_Colors.Add('!', ["p:", "gr", "--" ,"gr"]);
            Punctuation_Colors.Add('@', ["p:", "bl", "--" ,"bl"]);
            Punctuation_Colors.Add('#', ["p:", "ye", "--" ,"ye"]);
            Punctuation_Colors.Add('$', ["p:", "wh", "--" ,"wh"]);
            Punctuation_Colors.Add('%', ["p:", "ma", "--" ,"ma"]);
            Punctuation_Colors.Add('^', ["p:", "or", "--" ,"or"]);
            Punctuation_Colors.Add('&', ["p:", "cy", "--" ,"cy"]);
            Punctuation_Colors.Add('*', ["p:", "pi", "--" ,"pi"]);
            Punctuation_Colors.Add('(', ["p:", "re", "--" ,"re"]);
            Punctuation_Colors.Add(')', ["p:", "pu", "--" ,"pu"]);
            Punctuation_Colors.Add('-', ["p:", "gr", "--" ,"bl"]);
            Punctuation_Colors.Add('_', ["p:", "gr", "--" ,"ye"]);
            Punctuation_Colors.Add('+', ["p:", "gr", "--" ,"wh"]);
            Punctuation_Colors.Add('=', ["p:", "gr", "--" ,"ma"]);
            Punctuation_Colors.Add('`', ["p:", "gr", "--" ,"re"]);
            Punctuation_Colors.Add('~', ["p:", "gr", "--" ,"cy"]);
            Punctuation_Colors.Add('[', ["p:", "gr", "--" ,"pu"]);
            Punctuation_Colors.Add(']', ["p:", "bl", "--" ,"gr"]);
            Punctuation_Colors.Add('{', ["p:", "bl", "--" ,"wh"]);
            Punctuation_Colors.Add('}', ["p:", "bl", "--" ,"re"]);
            Punctuation_Colors.Add('\\', ["p:", "bl", "--" ,"pu"]);
            Punctuation_Colors.Add('|', ["p:", "bl", "--" ,"ye"]);
            Punctuation_Colors.Add(';', ["p:", "bl", "--" ,"pi"]);
            Punctuation_Colors.Add(':', ["p:", "bl", "--" ,"cy"]);
            Punctuation_Colors.Add('\'', ["p:", "bl", "--" ,"ma"]);
            Punctuation_Colors.Add('\"', ["p:", "ye", "--" ,"gr"]);
            Punctuation_Colors.Add(',', ["p:", "ye", "--" ,"bl"]);
            Punctuation_Colors.Add('<', ["p:", "ye", "--" ,"ma"]);
            Punctuation_Colors.Add('.', ["p:", "ye", "--" ,"wh"]);
            Punctuation_Colors.Add('>', ["p:", "ye", "--" ,"re"]);
            Punctuation_Colors.Add('/', ["p:", "ye", "--" ,"pi"]);
            Punctuation_Colors.Add('?', ["p:", "ye", "--" ,"cy"]);
            return Punctuation_Colors;
        }

        public Dictionary<string, SixLabors.ImageSharp.Color> Init_Color_Codes_Dict(){
            Color_Codes.Add("gr", SixLabors.ImageSharp.Color.Green);
            Color_Codes.Add("ga", SixLabors.ImageSharp.Color.Gray);
            Color_Codes.Add("ye", SixLabors.ImageSharp.Color.Yellow);
            Color_Codes.Add("pu", SixLabors.ImageSharp.Color.Purple);
            Color_Codes.Add("or", SixLabors.ImageSharp.Color.Orange);
            Color_Codes.Add("cy", SixLabors.ImageSharp.Color.Cyan);
            Color_Codes.Add("pi", SixLabors.ImageSharp.Color.Pink);
            Color_Codes.Add("ma", SixLabors.ImageSharp.Color.Magenta);
            Color_Codes.Add("re", SixLabors.ImageSharp.Color.Red);
            Color_Codes.Add("bl", SixLabors.ImageSharp.Color.Blue);
            Color_Codes.Add("wh", SixLabors.ImageSharp.Color.White);
            Color_Codes.Add("bk", SixLabors.ImageSharp.Color.Black);
            Color_Codes.Add("br", SixLabors.ImageSharp.Color.Brown);
            return Color_Codes;
        }
    }
}