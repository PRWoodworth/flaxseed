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
            List<List<List<String>>> colorized_input = Colorize_Text("test input to make sure everything is working as intended to avoid sudden problems", color_codex);
            Generate_Image(colorized_input, color_codex);
            // TODO: convert text to color blocks like in New Order - Blue Monday (Official Lyric Video)

        }

        static List<List<List<String>>> Colorize_Text(String input, Color_Arrays color_codex){
            // TODO: console prompt to get input from user 
            // TODO: make actual window to get input from user
            
            Dictionary<Char, List<String>> Letter_Colors = color_codex.Init_Letter_Colors_Dict();
            String[] split_input = input.Split(' ');

            // TODO: refactor to leave whitespace intact
            List<List<List<String>>> input_colorization = [];


            foreach (var word in split_input){
                List<List<String>> word_colorization = [];
                foreach (var letter in word){
                    word_colorization.Add(Letter_Colors[char.ToUpper(letter)]);
                }
                input_colorization.Add(word_colorization);
            }
            
            return input_colorization;
        }

        static void Generate_Image(List<List<List<String>>> colorized_input, Color_Arrays color_codex){
            int width = 1900;
            int height = 1200;
            Dictionary<String, SixLabors.ImageSharp.Color> color_dict = color_codex.Init_Color_Codes_Dict();
            using Image<Rgba32> image = new(width, height);
            int word_number = 0;
            foreach (var word in colorized_input){
                Generate_Rectangle_Codes_For_Word(image, word, color_dict, word_number);
                word_number++;
            }

                        
            // TODO: prompt for user to specify file save location, as part of an actual app or something idk
            image.Save("test.jpg");
        }

        static Image<Rgba32> Generate_Rectangle_Codes_For_Word(Image<Rgba32> canvas, List<List<String>> word, Dictionary<String, SixLabors.ImageSharp.Color> color_dict, int word_number){
            int letter_number = 0;
            foreach (var letter in word){
                canvas = Generate_Rectangle_Code_For_Letter(canvas, letter, color_dict, word_number, letter_number);
                letter_number++;
            }
            return canvas;
        }

        static Image<Rgba32> Generate_Rectangle_Code_For_Letter(Image<Rgba32> canvas, List<String> letter, Dictionary<String, SixLabors.ImageSharp.Color> color_dict, int word_number, int letter_number){
            float y = 50 * word_number;
            float starting_x = 50 * letter_number;
            switch (letter[0]){
                case "l:":
                    // TODO: remove the awkard space between letters  
                    canvas.Mutate(x => x.Fill(color_dict[letter[1]], new RectangularPolygon(starting_x, y, 20, 60)));
                    canvas.Mutate(x => x.Fill(color_dict[letter[3]], new RectangularPolygon(starting_x + 20, y, 20, 60)));
                    if(letter[2].Equals("||")){
                        // TODO: get the bar placed properly
                        canvas.Mutate(x => x.Fill(SixLabors.ImageSharp.Color.Grey, new RectangularPolygon(Math.Max(65, 65 * letter_number), y, 10, 60)));
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
    }
}