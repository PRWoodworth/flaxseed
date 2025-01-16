namespace flaxseed{
    class Shape_Generators{
        public static Image<Rgba32> Generate_For_Letter(Image<Rgba32> canvas, List<string> letter, float x_dim, float y_dim, int width, int height){
            RectangularPolygon color_segment_one = new(x_dim, y_dim, width, height);
            RectangularPolygon color_segment_two = new(x_dim + width, y_dim, width, height);
            RectangularPolygon color_segment_three = new (0,0,0,0);
            if(letter[2].Equals("||")){
                color_segment_three = new (x_dim + 18, y_dim, width/4, height);
            }
            canvas = Mutate_Rectangle(canvas, letter, color_segment_one, color_segment_two, color_segment_three);
            return canvas;
        }

        public static Image<Rgba32> Generate_For_Number(Image<Rgba32> canvas, List<string> letter, float x_dim, float y_dim, int width, int height){
            RectangularPolygon color_segment_one = new (x_dim, y_dim, width, height/2);
            RectangularPolygon color_segment_two = new (x_dim + width, y_dim, width, height/2);
            RectangularPolygon color_segment_three = new (0,0,0,0);
            if(letter[2].Equals("||")){
                color_segment_three = new RectangularPolygon(x_dim, y_dim, width*2, height/8);
            }
            canvas = Mutate_Rectangle(canvas, letter, color_segment_one, color_segment_two, color_segment_three);
            return canvas;
        }
        public static Image<Rgba32> Generate_For_Special_Character(Image<Rgba32> canvas, List<string> letter, float x_dim, float y_dim, int width, int height){
            RectangularPolygon color_segment_one = new (x_dim, y_dim+(height/2), width, height/2);
            RectangularPolygon color_segment_two = new (x_dim + width, y_dim+(height/2), width, height/2);
            RectangularPolygon color_segment_three = new (0,0,0,0);
            if(letter[2].Equals("||")){
                color_segment_three = new RectangularPolygon(x_dim, y_dim + height-5, width*2, height/8);
            }
            canvas = Mutate_Rectangle(canvas, letter, color_segment_one, color_segment_two, color_segment_three);
            return canvas;
        }

        public static Image<Rgba32> Mutate_Rectangle(Image<Rgba32> canvas, List<string> letter, RectangularPolygon color_segment_one, RectangularPolygon color_segment_two, RectangularPolygon color_segment_three){
            canvas.Mutate(x => x.Fill(color_dict[letter[1]], color_segment_one));
            canvas.Mutate(x => x.Fill(color_dict[letter[3]], color_segment_two));
            if(letter[2].Equals("||")){
                canvas.Mutate(x => x.Fill(Color.Grey, color_segment_three));
            }
            return canvas;
        }
    }
}