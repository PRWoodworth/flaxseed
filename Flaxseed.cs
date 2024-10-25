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
            Dictionary<Char, List<String>> Letter_Colors = color_codex.Init_Letter_Colors_Dict();
            String[] split_input = input.Split(' ');
            List<List<String>> input_colorization = new List<List<String>>();
            foreach (var word in split_input){
                foreach (var letter in word){
                    input_colorization.Add(Letter_Colors[Char.ToUpper(letter)]);
                }
                // TODO:construct color array (as text, e.x. [['r', 'g'], ['b', 'r']])
            }

            foreach (var d1 in input_colorization)
            {
                foreach (var d2 in d1)
                {
                    Console.Write(d2);
                }
            }

            return null;
        }
    }
}