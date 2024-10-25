namespace flaxseed {
    class Flaxseed{

        static void Main(string[] args){
            String[][] output = Colorize_Text("test input to make sure everything is working as intended");
            // TODO: convert text to color blocks like in New Order - Blue Monday (Official Lyric Video)
            // TODO: get input
            // TODO: somehow generate an actual image using the color arrays.
        }

        static String[][] Colorize_Text(String input){

            var color_codex = new Color_Arrays();
            Dictionary<Char, String[]> Letter_Colors = color_codex.Init_Letter_Colors_Dict();
            String[] split_input = input.Split(' ');
            // TODO: break individual words into character arrays

            // TODO: analyze character arrays, construct color array (as text, e.x. [['r', 'g'], ['b', 'r']])

            return null;
        }
    }
}