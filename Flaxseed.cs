using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Drawing;

namespace flaxseed {
    
    
    
    class Flaxseed{

        static void Main(string[] args){
            List<List<String>> colorized_input = Colorize_Text("test input to make sure everything is working as intended");
            foreach (var d1 in colorized_input)
            {
                Console.WriteLine(d1);
                foreach (var d2 in d1)
                {
                    Console.WriteLine(d2);
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

            // TODO: refactor to leave whitespace intact
            List<List<String>> input_colorization = [];


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
            using Image<Rgba32> image = new(width, height);
            

            // TODO: iterate through entire input array
            // TODO: get each word
            // TODO: get each letter

                        
            // TODO: prompt for user to specify file save location, as part of an actual app or something idk
            image.Save("test.jpg");
        }

        static RectangularPolygon Generate_Rectangle_Code(Image<Rgba32> canvas, String letter_code){
            RectangularPolygon test_rectangle = new(5, 5, 20, 60);
            canvas.Mutate(x => x.Fill(Color.Red, test_rectangle));
            return new RectangularPolygon(0,0,0,0);
        }

    }
}