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
            List<List<String>> colorized_input = Colorize_Text("test input to make sure everything is working as intended to avoid sudden problems", color_codex);
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
            int word_number = 0;
            foreach (var word in colorized_input){
                Generate_Rectangle_Codes_For_Word(image, word, color_dict, word_number);
                word_number++;
            }

                        
            // TODO: prompt for user to specify file save location, as part of an actual app or something idk
            image.Save("test.jpg");
        }

        static Image<Rgba32> Generate_Rectangle_Codes_For_Word(Image<Rgba32> canvas, List<String> word, Dictionary<String, SixLabors.ImageSharp.Color> color_dict, int word_number){
            
            foreach (var letter in word){
                canvas = Generate_Rectangle_Code_For_Letter(canvas, word, color_dict, word_number);
            }
            return canvas;
        }

        static Image<Rgba32> Generate_Rectangle_Code_For_Letter(Image<Rgba32> canvas, List<String> letter, Dictionary<String, SixLabors.ImageSharp.Color> color_dict, int word_number){

            // TODO: determine Y based on word number
            // TODO: determine X based on letter number

            String type = letter[0];

            switch (type){
                case "l:":            
                    // TODO: get next 3 sets of 2 characters
                    String block_one_color = letter[1];
                    String bar_presence = letter[2];
                    String block_two_color = letter[3];
                    canvas.Mutate(x => x.Fill(color_dict[block_one_color], new RectangularPolygon(50, 50, 20, 60)));
                    canvas.Mutate(x => x.Fill(color_dict[block_two_color], new RectangularPolygon(70, 50, 20, 60)));
                    if(bar_presence.Equals("||")){
                        canvas.Mutate(x => x.Fill(SixLabors.ImageSharp.Color.Grey, new RectangularPolygon(65, 50, 10, 60)));
                    }
                    break;
                case "n:":
                    break;
                case "p:":
                    break;                
                default:
                
                    // TODO: space?
                    break;

            }

            return canvas;
        }

        // TODO: generate letter code for each letter and pass back to Generate_Rectangle_Codes_For_Word?

    }
}