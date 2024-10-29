namespace flaxseed { 
    public class Color_Arrays{

        /*
        OVERALL SCHEMA

        l: = letter
        n: = number
        p: = punctuation
        spaces = grey octagons

        LETTER CODEC
        Rectangles
        2 colors per letter
        7 characters per letter 
        gr = green
        ye = yellow
        pu = pink
        or = orange
        cy = cyan
        pi = pink
        ma = magenta (dark purple)
        re = red
        bl = blue
        wh = white
        - = lack of bar
        | = thin white vertical bar separating two colors        

        NUMBER CODEC
        Triangles or hexagons
        Start with solid color
        Stretch goal: each 1/n-side segment (1/3 for triangle, 1/6 for hexagon) is a color, meaning 3 colors can be condensed into 1 triangle or 6 into 1 hexagon
        0 
        1
        2
        3
        4
        5
        6
        7
        8
        9


        PUNCTUATION CODEX
        Circles
        Solid color
        */

        private readonly Dictionary<Char, List<String>> Letter_Colors = [];
        private readonly Dictionary<Char, List<String>> Punctuation_Colors = [];
        private readonly Dictionary<Char, List<String>> Number_Colors = [];

        public Dictionary<Char, List<String>> Init_Letter_Colors_Dict(){
            Letter_Colors.Add('A', ["l:", "gr", "-" ,"gr"]);
            Letter_Colors.Add('B', ["l:", "ye", "-" ,"ye"]);
            Letter_Colors.Add('C', ["l:", "pu", "-" ,"pu"]);
            Letter_Colors.Add('D', ["l:", "or", "-" ,"or"]);
            Letter_Colors.Add('E', ["l:", "cy", "-" ,"cy"]);
            Letter_Colors.Add('F', ["l:", "pu", "-" ,"pu"]);
            Letter_Colors.Add('G', ["l:", "ma", "-" ,"ma"]);
            Letter_Colors.Add('H', ["l:", "re", "-" ,"re"]);
            Letter_Colors.Add('I', ["l:", "bl", "-" ,"bl"]);
            Letter_Colors.Add('J', ["l:", "gr", "|" ,"wh"]);
            Letter_Colors.Add('K', ["l:", "gr", "|" ,"gr"]);
            Letter_Colors.Add('L', ["l:", "gr", "|" ,"ye"]);
            Letter_Colors.Add('M', ["l:", "gr", "|" ,"pu"]);
            Letter_Colors.Add('N', ["l:", "gr", "|" ,"or"]);
            Letter_Colors.Add('O', ["l:", "gr", "|" ,"cy"]);
            Letter_Colors.Add('P', ["l:", "gr", "|" ,"pu"]);
            Letter_Colors.Add('Q', ["l:", "gr", "|" ,"ma"]);
            Letter_Colors.Add('R', ["l:", "gr", "|" ,"re"]);
            Letter_Colors.Add('S', ["l:", "gr", "|" ,"bl"]);
            Letter_Colors.Add('T', ["l:", "ye", "|" ,"wh"]);
            Letter_Colors.Add('U', ["l:", "ye", "|" ,"gr"]);
            Letter_Colors.Add('V', ["l:", "ye", "|" ,"ye"]);
            Letter_Colors.Add('W', ["l:", "ye", "|" ,"pu"]);
            Letter_Colors.Add('X', ["l:", "ye", "|" ,"or"]);
            Letter_Colors.Add('Y', ["l:", "ye", "|" ,"cy"]);
            Letter_Colors.Add('Z', ["l:", "ye", "|" ,"pu"]);

            return Letter_Colors;
        }

        // TODO: finish color codes
        public Dictionary<Char, List<String>> Init_Number_Colors_Dict(){
            Number_Colors.Add('0', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('1', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('2', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('3', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('4', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('5', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('6', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('7', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('8', ["n:", "gr", "-" ,"gr"]);
            Number_Colors.Add('9', ["n:", "gr", "-" ,"gr"]);
            return Number_Colors;
        }

        // TODO: finish color codes, add ' and "
        public Dictionary<Char, List<String>> Init_Punctuation_Colors_Dict(){
            Punctuation_Colors.Add('!', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('@', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('#', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('$', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('%', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('^', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('&', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('*', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('(', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add(')', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('-', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('_', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('+', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('=', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('[', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add(']', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('{', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('}', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('\\', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('|', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add(';', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add(':', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add(',', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('<', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('.', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('>', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('/', ["p:", "gr", "-" ,"gr"]);
            Punctuation_Colors.Add('?', ["p:", "gr", "-" ,"gr"]);
            return Punctuation_Colors;
        }
    }
}