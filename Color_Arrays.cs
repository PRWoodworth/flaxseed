namespace flaxseed { 
    public class Color_Arrays{
        private Dictionary<Char, List<String>> Letter_Colors = new Dictionary<Char, List<String>>();

            /*
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
            | = thin white vertical bar separating the two colors

            spaces = grey octagons
            all punctuation = blank space
            // TODO: create codec for punctuation
            */

        public Dictionary<Char, List<String>> Init_Letter_Colors_Dict(){
            Letter_Colors.Add('A', ["gr", "" ,"gr"]);
            Letter_Colors.Add('B', ["ye", "" ,"ye"]);
            Letter_Colors.Add('C', ["pu", "" ,"pu"]);
            Letter_Colors.Add('D', ["or", "" ,"or"]);
            Letter_Colors.Add('E', ["cy", "" ,"cy"]);
            Letter_Colors.Add('F', ["pu", "" ,"pu"]);
            Letter_Colors.Add('G', ["ma", "" ,"ma"]);
            Letter_Colors.Add('H', ["re", "" ,"re"]);
            Letter_Colors.Add('I', ["bl", "" ,"bl"]);
            Letter_Colors.Add('J', ["gr", "|" ,"wh"]);
            Letter_Colors.Add('K', ["gr", "|" ,"gr"]);
            Letter_Colors.Add('L', ["gr", "|" ,"ye"]);
            Letter_Colors.Add('M', ["gr", "|" ,"pu"]);
            Letter_Colors.Add('N', ["gr", "|" ,"or"]);
            Letter_Colors.Add('O', ["gr", "|" ,"cy"]);
            Letter_Colors.Add('P', ["gr", "|" ,"pu"]);
            Letter_Colors.Add('Q', ["gr", "|" ,"ma"]);
            Letter_Colors.Add('R', ["gr", "|" ,"re"]);
            Letter_Colors.Add('S', ["gr", "|" ,"bl"]);
            Letter_Colors.Add('T', ["ye", "|" ,"wh"]);
            Letter_Colors.Add('U', ["ye", "|" ,"gr"]);
            Letter_Colors.Add('V', ["ye", "|" ,"ye"]);
            Letter_Colors.Add('W', ["ye", "|" ,"pu"]);
            Letter_Colors.Add('X', ["ye", "|" ,"or"]);
            Letter_Colors.Add('Y', ["ye", "|" ,"cy"]);
            Letter_Colors.Add('Z', ["ye", "|" ,"pu"]);

            return Letter_Colors;
        }

        public Dictionary<Char, List<String>> get_letter_colors(){
            return Letter_Colors;
        }
    }
}