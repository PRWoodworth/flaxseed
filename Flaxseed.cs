using Microsoft.VisualBasic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Drawing;

namespace flaxseed {
    
    
    
    class Flaxseed{

        static void Main(string[] args){
            var color_codex = new Color_Arrays();
            List<List<String>> colorized_input = Colorize_Text("test input to make sure everything is working as intended", color_codex);
            Generate_Image(colorized_input, color_codex);
            // TODO: convert text to color blocks like in New Order - Blue Monday (Official Lyric Video)

        }

        static List<List<String>> Colorize_Text(String input, Color_Arrays color_codex){
            // TODO: console prompt to get input from user 
            // TODO: make actual window to get input from user

            
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

        static void Generate_Image(List<List<String>> colorized_input, Color_Arrays color_codex){
            int width = 1900;
            int height = 1200;
            // TODO: somehow generate an actual image using the color arrays.
            // TODO: read https://docs.sixlabors.com/articles/imagesharp.drawing/gettingstarted.html
            Dictionary<String, SixLabors.ImageSharp.Color> color_dict = color_codex.Init_Color_Codes_Dict();
            using Image<Rgba32> image = new(width, height);
            // TODO: iterate through entire input array
            foreach (var word in colorized_input){
                Generate_Rectangle_Code(image, word, color_dict);
            }

                        
            // TODO: prompt for user to specify file save location, as part of an actual app or something idk
            image.Save("test.jpg");
        }

        static Image<Rgba32> Generate_Rectangle_Code(Image<Rgba32> canvas, List<String> word, Dictionary<String, SixLabors.ImageSharp.Color> color_dict){
            // TODO: get first 2 characters from input
            RectangularPolygon block_one = new(50, 50, 20, 60);
            RectangularPolygon block_two = new(50, 60, 20, 60);
            
            // TODO: get characters from 0-1
            String type = word[0];
            Console.WriteLine(type);

            switch (type){
                case "l:":            
                    // TODO: get next 3 sets of 2 characters
                    String block_one_color = "gr";
                    String block_two_color = "bl";
                    canvas.Mutate(x => x.Fill(color_dict[block_one_color], block_one));
                    canvas.Mutate(x => x.Fill(color_dict[block_two_color], block_two));
                    break;
                case "n:":
                    // TODO: get next 3 sets of 2 characters
                    break;
                case "p:":
                    // TODO: get next 3 sets of 2 characters
                    break;                
                default:
                    break;
                    // TODO: space?

            }
            
            
            
            return canvas;
        }

    }
}