﻿// https://docs.sixlabors.com/articles/imagesharp/gettingstarted.html
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace flaxseed{
    class Flaxseed{

        const int height_basis = 40;
        const int width_basis = 40;
        static readonly Dictionary<char, List<string>> Letter_Colors = new Color_Arrays().Init_Letter_Colors_Dict();
        static readonly Dictionary<char, List<string>> Punctuation_Colors = new Color_Arrays().Init_Punctuation_Colors_Dict();
        static readonly Dictionary<char, List<string>> Number_Colors = new Color_Arrays().Init_Number_Colors_Dict();
        public static void Main(string[] args){
            StreamReader reader = new("text_input.txt");
            var line = reader.ReadLine();
            var total_input = "";
            while (line != null){
                total_input += line;
                line = reader.ReadLine();
            }
            List<List<List<string>>> colorized_input = Colorize_Text(total_input);
            Generate_Image(colorized_input);
            // TODO: convert text to color blocks like in New Order - Blue Monday (Official Lyric Video)

        }

        static List<List<List<string>>> Colorize_Text(string input){
            // TODO: make actual window to get input from user. might need to be a web UI rather than local app. 
            
            
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

        static void Generate_Image(List<List<List<string>>> colorized_input){
            int longest_word = 0;
            foreach (var word in colorized_input){
                if(word.Count >= longest_word){
                    longest_word = word.Count;
                }
            }
            int width = width_basis  * longest_word;
            int height = height_basis * colorized_input.Count;
            using Image<Rgba32> image = new(width, height);
            int word_number = 0;
            foreach (var word in colorized_input){
                Generate_Rectangle_Codes_For_Word(image, word, word_number);
                word_number++;
            }

                        
            // TODO: prompt for user to specify file save location, as part of an actual app or something idk
            image.Save("test.png");
        }

        // TODO: word wrap
        /*
            Break input into individual words, preserving whitespace.
            Convert to color codes, get back 2D list of rectangles (list of list of rectangles) 
            Iterate through colorized input, mutating canvas as we go.
                Determine upper bound on canas width.
                Multiple words on same line unless width of word would extend beyond canvas width. 
                If so, move to new line.
        */

        static Image<Rgba32> Generate_Rectangle_Codes_For_Word(Image<Rgba32> canvas, List<List<string>> word, int word_number){
            // TODO: implement word wrap.
            // TODO: generate a list of rectangles (entire word) instead of generating each rectangle iteratively and appending? 
            int letter_number = 0;
            foreach (var letter in word){
                canvas = Generate_Rectangle_Code_For_Letter(canvas, letter, word_number, letter_number);
                letter_number++;
            }
            return canvas;
            
        }

        static Image<Rgba32> Generate_Rectangle_Code_For_Letter(Image<Rgba32> canvas, List<string> letter, int word_number, int letter_number){
            float y_dim = height_basis * word_number;
            float x_dim = width_basis * letter_number;

            int width = width_basis/2;
            int height = height_basis;

            // TODO: improve code formatting for readability here. lot of repeated stuff. 
            // TODO: make each character type its own function, return a composite rectangle?
            // TODO: improve paramaterization. none of this should be using straight integers!

            switch (letter[0]){
                case "l:":
                    canvas = Shape_Generators.Generate_For_Letter(canvas, letter, x_dim, y_dim, width, height);
                    break;
                case "n:":
                    canvas = Shape_Generators.Generate_For_Number(canvas, letter, x_dim, y_dim, width, height);
                    break;
                case "p:":
                    canvas = Shape_Generators.Generate_For_Special_Character(canvas, letter, x_dim, y_dim, width, height);
                    break;             
                default:
                    
                    break;

            }
            return canvas;
        }
    }
}