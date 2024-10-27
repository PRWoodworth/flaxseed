using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Drawing;

namespace flaxseed {
    
    
    
    class Flaxseed{

        static void Main(string[] args){
            List<List<String>> colorized_input = Colorize_Text("test input to make sure everything is working as intended");
            foreach (var d1 in colorized_input)
            {
                foreach (var d2 in d1)
                {
                    Console.Write(d2);
                }
            }
            Generate_Image(colorized_input);
            // TODO: convert text to color blocks like in New Order - Blue Monday (Official Lyric Video)

        }

        static List<List<String>> Colorize_Text(String input){
            // TODO: console prompt to get input from user 
            // TODO: make actual window to get input from user

            var color_codex = new Color_Arrays();
            Dictionary<Char, List<String>> Letter_Colors = color_codex.Init_Letter_Colors_Dict();
            String[] split_input = input.Split(' ');
            List<List<String>> input_colorization = [];

            //TODO: adjust to add a space between every word?
            foreach (var word in split_input){
                foreach (var letter in word){
                    input_colorization.Add(Letter_Colors[Char.ToUpper(letter)]);
                }
            }
            
            return input_colorization;
        }

        static void Generate_Image(List<List<String>> colorized_input){
            int width = 1900;
            int height = 1200;
            // TODO: somehow generate an actual image using the color arrays.
            // TODO: read https://docs.sixlabors.com/articles/imagesharp.drawing/gettingstarted.html
            using(Image<Rgba32> image = new(width, height)){
                RectangularPolygon test_rectangle = new(10, 10, 10, 10);
                // TODO: prompt for user to specify file save location, as part of an actual app or something idk
                image.Save("test.jpg");
            }
            
            
        }
    }
}