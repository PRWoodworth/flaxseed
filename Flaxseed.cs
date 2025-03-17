// https://docs.sixlabors.com/articles/imagesharp/gettingstarted.html
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Text.RegularExpressions;

namespace flaxseed{
	class Flaxseed{
        public static void Main(){
			StreamReader reader = new("text_input.txt");
			var line = reader.ReadLine();
			var total_input = "";
			while (line != null){
				total_input += line;
				line = reader.ReadLine();
			}
			List<List<List<string>>> colorized_input = Colorize_Text(total_input);
			Generate_Image(colorized_input);

		}

		static List<List<List<string>>> Colorize_Text(string input){
			// TODO: make actual window to get input from user. might need to be a web UI rather than local app. 

			String pattern = " ";
			string[] split_input = Regex.Split(input, pattern);

			List<List<List<string>>> input_colorization = [];


			foreach (var word in split_input){
				List<List<string>> word_colorization = [];
				foreach (var letter in word){
					if(char.IsLetterOrDigit(letter)){
						if(char.IsLetter(letter)){
							word_colorization.Add(HelperVariables.Letter_Colors_Public[char.ToUpper(letter)]);
						} else {
							word_colorization.Add(HelperVariables.Number_Colors_Public[letter]);
						}
					} else {
						word_colorization.Add(HelperVariables.Punctuation_Colors_Public[letter]);
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
			int width = 1980;
			int height = 1020;
			Image<Rgba32> image = new(width, height);
			int word_number = 0;
			foreach (var word in colorized_input){
				int word_height = HelperVariables.Height_basis_public * word_number;
                int letter_number = 0;
                foreach (var letter in word){
                    float x_coordinate = letter_number * HelperVariables.Width_basis_public;
                    image = Generate_Rectangle_Code_For_Letter(image, letter, word_height, x_coordinate);
                    letter_number++;
                }
                word_number++;
			}

						
			// TODO: prompt for user to specify file save location, as part of an actual app or something idk
			image.Save("test.png");
		}

		// TODO: calculate correct location, height, width, etc. BEFORE hand and then pass to this function. 
		static Image<Rgba32> Generate_Rectangle_Code_For_Letter(Image<Rgba32> canvas,
                                                          List<string> letter,
                                                          float y_dim,
                                                          float x_dim)
        {
            int width = HelperVariables.Width_basis_public / 2;
			int height = HelperVariables.Height_basis_public;

			// TODO: improve code formatting for readability here. lot of repeated stuff. 

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