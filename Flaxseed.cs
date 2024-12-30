// https://docs.sixlabors.com/articles/imagesharp/gettingstarted.html
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace flaxseed{
    class Flaxseed{

        const int height_basis = 40;
        const int width_basis = 40;

        static void Main(string[] args){
            var color_codex = new Color_Arrays();
            StreamReader reader = new StreamReader("text_input.txt");
            var line = reader.ReadLine();
            var total_input = "";
            while (line != null){
                total_input += line;
                line = reader.ReadLine();
            }
            List<List<List<string>>> colorized_input = Colorize_Text(total_input, color_codex);
            Generate_Image(colorized_input, color_codex);
            // TODO: convert text to color blocks like in New Order - Blue Monday (Official Lyric Video)

        }

        static List<List<List<string>>> Colorize_Text(string input, Color_Arrays color_codex){
            // TODO: make actual window to get input from user. might need to be a web UI rather than local app. 
            
            Dictionary<char, List<string>> Letter_Colors = color_codex.Init_Letter_Colors_Dict();
            Dictionary<char, List<string>> Punctuation_Colors = color_codex.Init_Punctuation_Colors_Dict();
            Dictionary<char, List<string>> Number_Colors = color_codex.Init_Number_Colors_Dict();
            string[] split_input = input.Split(' ');

            // TODO: refactor to leave whitespace intact
            List<List<List<string>>> input_colorization = [];


            foreach (var word in split_input){
                List<List<string>> word_colorization = [];
                foreach (var letter in word){
                    if(char.IsLetterOrDigit(letter)){
                        if(char.IsLetter(letter)){
                            word_colorization.Add(Letter_Colors[char.ToUpper(letter)]);
                        } else {
                            word_colorization.Add(Number_Colors[letter]);
                        }
                    } else {
                        word_colorization.Add(Punctuation_Colors[letter]);
                    }
                }
                input_colorization.Add(word_colorization);
            }
            
            return input_colorization;
        }

        static void Generate_Image(List<List<List<string>>> colorized_input, Color_Arrays color_codex){
            int longest_word = 0;
            foreach (var word in colorized_input){
                if(word.Count >= longest_word){
                    longest_word = word.Count;
                }
            }
            int width = width_basis  * longest_word;
            int height = height_basis * colorized_input.Count;
            Dictionary<string, SixLabors.ImageSharp.Color> color_dict = color_codex.Init_Color_Codes_Dict();
            using Image<Rgba32> image = new(width, height);
            int word_number = 0;
            foreach (var word in colorized_input){
                Generate_Rectangle_Codes_For_Word(image, word, color_dict, word_number);
                word_number++;
            }

                        
            // TODO: prompt for user to specify file save location, as part of an actual app or something idk
            image.Save("test.png");
        }

        static Image<Rgba32> Generate_Rectangle_Codes_For_Word(Image<Rgba32> canvas, List<List<string>> word, Dictionary<string, SixLabors.ImageSharp.Color> color_dict, int word_number){
            // TODO: implement word wrap.
            // TODO: generate a list of rectangles (entire word) instead of generating each rectangle iteratively and appending? 
            int letter_number = 0;
            foreach (var letter in word){
                canvas = Generate_Rectangle_Code_For_Letter(canvas, letter, color_dict, word_number, letter_number);
                letter_number++;
            }
            return canvas;
            
        }

        static Image<Rgba32> Generate_Rectangle_Code_For_Letter(Image<Rgba32> canvas, List<string> letter, Dictionary<string, SixLabors.ImageSharp.Color> color_dict, int word_number, int letter_number){
            float y_dim = height_basis * word_number;
            float x_dim = width_basis * letter_number;

            int width = width_basis/2;
            int height = height_basis;

            RectangularPolygon color_segment_one = new(0, 0, 0, 0);
            RectangularPolygon color_segment_two = new(0, 0, 0, 0);
            RectangularPolygon color_segment_three = new(0, 0, 0, 0);

            // TODO: improve code formatting for readability here. lot of repeated stuff. 
            // TODO: make each character type its own function, return a composite rectangle?
            // TODO: improve paramaterization. none of this should be using straight integers!

            switch (letter[0]){
                case "l:":
                    color_segment_one = new RectangularPolygon(x_dim, y_dim, width, height);
                    color_segment_two = new RectangularPolygon(x_dim + width, y_dim, width, height);
                    if(letter[2].Equals("||")){
                        color_segment_three = new RectangularPolygon(x_dim + 18, y_dim, width/4, height);
                    }
                    break;
                case "n:":
                    color_segment_one = new RectangularPolygon(x_dim, y_dim, width, height/2);
                    color_segment_two = new RectangularPolygon(x_dim + width, y_dim, width, height/2);
                    if(letter[2].Equals("||")){
                        color_segment_three = new RectangularPolygon(x_dim, y_dim, width*2, 5);
                    }
                    break;
                case "p:":
                    color_segment_one = new RectangularPolygon(x_dim, y_dim+(height/2), width, height/2);
                    color_segment_two = new RectangularPolygon(x_dim + width, y_dim+(height/2), width, height/2);
                    if(letter[2].Equals("||")){
                        color_segment_three = new RectangularPolygon(x_dim, y_dim + height-5, width*2, 5);
                    }
                    break;             
                default:
                    
                    break;

            }
            canvas.Mutate(x => x.Fill(color_dict[letter[1]], color_segment_one));
            canvas.Mutate(x => x.Fill(color_dict[letter[3]], color_segment_two));
            if(letter[2].Equals("||")){
                canvas.Mutate(x => x.Fill(SixLabors.ImageSharp.Color.Grey, color_segment_three));
            }
            return canvas;
        }
    }
}