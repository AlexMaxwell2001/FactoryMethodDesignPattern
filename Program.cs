using System;
using System.IO;
using System.Text.RegularExpressions;

//OS:Windows , IDE:VS Code 1.51.0

/*(i),(ii),(iii),(iv) were already implemented in the previous assignment,
 you can see comments in the code on how to add,save,display and undo redo//

/*Part 1: Factory Method Design Pattern
 I used this design pattern to implement the creation of shapes to the canvas.I chose
 this design pattern over the Abstract Factory for this assignment because 1. The implementation
 of this pattern was much more easier and the Abstract factory was hard to understand and implement.
 2. The factory method design pattern fit well to the specification of this assignment. A factory could be made
 per each shape making it ideal to implement this design pattern. 3. This design pattern scales well compared to the 
 Abstract factory for this assignment as a factory only needs to be created per each shape and I believe atleast an 
 extra class/interface needs to be created per shape in the Abstract Factory design pattern for this assignment*/

 /*Part 2: Factory Method Design Pattern
 I used this design pattern to implement the stlying of shapes and putting them on the canvas.I chose
 this design pattern over the Abstract Factory for this assignment because 1,2,3 reasons listed above.
 Also I chose this pattern to check the overall program's pattern consistent, it would be hard to 
 understand reading the code if there was both patterns implemented. Aswell, the implementation of 
 this functionality fit in well to the previous code as all I had to do was add it into the pre-made
 factory implementations of the shapes. It all fit in perfectly in regards to the specification for this 
 assignment. */

 /*Part 3: PUML Class diagram 
    You can preview classDiag.puml for this. */

    class Program{
        private static Canvas canvas = new Canvas();
        private static User user = new User();
        private static string filePath=@".\svg.svg";
        public static void Main()
        {
            string svg="</svg>";
            string nothing="";
            File.WriteAllText(filePath,nothing);
            Console.WriteLine(canvas);
            /*Create shapes using their dedicated factory, 
            to fully test the functionality switch each CreateShape to CreateStyleShape*/
            //Creates styled circle and displays the canvas 
            ClientCode(new CircleFactory().CreateStyledShape());
            Console.WriteLine(canvas);
            //creates unstyled rectangle and displays the canvas
            ClientCode(new RectangleFactory().CreateShape());
            Console.WriteLine(canvas);
            //Creates a styled Ellipse and displays the canvas
            ClientCode(new EllipseFactory().CreateStyledShape());
            Console.WriteLine(canvas);
            //Creates a unstyled Line and displays the canvas
            ClientCode(new LineFactory().CreateShape());
            Console.WriteLine(canvas);
            //Creates a styled Polyline and displays the canvas
            ClientCode(new PolyLineFactory().CreateStyledShape());
            Console.WriteLine(canvas);
            //Creates a unstyled Polygon and displays the canvas
            ClientCode(new PolygonFactory().CreateShape());
            Console.WriteLine(canvas);
            //Creates a styled Path and displays the canvas
            ClientCode(new PathFactory().CreateStyledShape());
            Console.WriteLine(canvas);
            //undoing
            user.Undo(canvas);
            //Displaying the canvas
            Console.WriteLine(canvas);
            //redoing
            user.Redo(canvas);
            Console.WriteLine(canvas);
            //Saving the canvas to .svg file
            if(canvas.ToString().Length>0){
                string var= canvas.ToString();
                File.WriteAllText(filePath,var);
                string [] tempar= File.ReadAllLines(filePath);
                string canvasstring = "<svg width="+@"""" +400+@""""+" height="+ @""""+400+@""""+ " version="+ @""""+1.1+@""""+ " xmlns="+@""""+ "http:"+ "//www.w3.org/2000/svg"+ @""""+">"+ Environment.NewLine +svg;
                File.WriteAllText(filePath,canvasstring);
                Save(tempar);
            }
            //Clearing the canvas
            clearing();  
            //Sign off       
            Console.WriteLine("Goodbye!");
        }
        public static string RemoveSpaces(string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
        public static void Save(string [] tempar){
            for(int i=1;i<tempar.Length;i++){
                if(tempar[i].Contains(":")){
                    string [] temp= tempar[i].Split(" (");string [] temp2= tempar[i].Split(":");
                    string shape=temp[0].Replace(">","");string shapes=RemoveSpaces(shape);
                    if(shapes.Equals(" Rectangle")){
                        string [] ar1=temp2[1].Split(",");string id=ar1[0].Replace(" ","");
                        string [] ar2=temp2[2].Split(",");string x=ar2[0].Replace(" ","");
                        string [] ar3=temp2[3].Split(",");string y=ar3[0].Replace(" ","");
                        string [] ar4=temp2[4].Split(",");string width=ar4[0].Replace(" ","");
                        string [] ar5=temp2[5].Split(",");string height=ar5[0].Replace(" ","").Replace(")","");
                        if(temp2.Length>=7){
                            string [] ar6=temp2[6].Split(")");string style=ar6[0].Replace(" ","");
                            Rectangle rect = new Rectangle(int.Parse(x) ,int.Parse(y),int.Parse(height),int.Parse(width),int.Parse(id),style);
                            rect.add();
                        }else{
                            Rectangle rect = new Rectangle(int.Parse(x) ,int.Parse(y),int.Parse(height),int.Parse(width),int.Parse(id),null);
                            rect.add();
                        }
                    }else if(shapes.Equals(" Circle")){
                        string [] ar1=temp2[1].Split(",");string id=ar1[0].Replace(" ","");
                        string [] ar2=temp2[2].Split(",");string cx=ar2[0].Replace(" ","");
                        string [] ar3=temp2[3].Split(",");string cy=ar3[0].Replace(" ","");
                        string [] ar4=temp2[4].Split(",");string r=ar4[0].Replace(" ","").Replace(")","");
                        if(temp2.Length>=6){
                            string [] ar5=temp2[5].Split(")");string style=ar5[0].Replace(" ","");
                            Circle c = new Circle(int.Parse(cx) ,int.Parse(cy),int.Parse(r),int.Parse(id),style);
                            c.add();
                        }else{
                            Circle c = new Circle(int.Parse(cx) ,int.Parse(cy),int.Parse(r),int.Parse(id),null);
                            c.add();
                        }
                    }else if(shapes.Equals(" Ellipse")){
                        string [] ar1=temp2[1].Split(",");string id=ar1[0].Replace(" ","");
                        string [] ar2=temp2[2].Split(",");string cx=ar2[0].Replace(" ","");
                        string [] ar3=temp2[3].Split(",");string cy=ar3[0].Replace(" ","");
                        string [] ar4=temp2[4].Split(",");string rx=ar4[0].Replace(" ","");
                        string [] ar5=temp2[5].Split(",");string ry=ar5[0].Replace(" ","").Replace(")","");
                        if(temp2.Length>=7){
                            string [] ar6=temp2[6].Split(")");string style=ar6[0].Replace(" ","");
                            Ellipse ee = new Ellipse(int.Parse(cx) ,int.Parse(cy),int.Parse(rx),int.Parse(ry),int.Parse(id),style);
                            ee.add();
                        }else{
                            Ellipse c = new Ellipse(int.Parse(cx) ,int.Parse(cy),int.Parse(rx),int.Parse(ry),int.Parse(id),null);
                            c.add();
                        }
                    }else if(shapes.Equals(" Line")){
                        string [] ar1=temp2[1].Split(",");string id=ar1[0].Replace(" ","");
                        string [] ar2=temp2[2].Split(",");string x1=ar2[0].Replace(" ","");
                        string [] ar3=temp2[3].Split(",");string x2=ar3[0].Replace(" ","");
                        string [] ar4=temp2[4].Split(",");string y1=ar4[0].Replace(" ","");
                        string [] ar5=temp2[5].Split(",");string y2=ar5[0].Replace(" ","").Replace(")","");
                        if(temp2.Length>=7){
                            string [] ar6=temp2[6].Split(")");string style=ar6[0].Replace(" ","");
                            Line ee = new Line(int.Parse(x1) ,int.Parse(x2),int.Parse(y1),int.Parse(y2),int.Parse(id),style);
                            ee.add();
                        }else{
                            Line c = new Line(int.Parse(x1) ,int.Parse(x2),int.Parse(y1),int.Parse(y2),int.Parse(id),null);
                            c.add();
                        }
                    }else if(shapes.Equals(" Polyline")){
                        string [] ar1=temp2[1].Split(":");string id=ar1[0].Replace(" ","").Replace(",points","");
                        string [] ar2=temp2[2].Split(":");string points=ar2[0].Replace("  style","").Replace(")","");
                        if(temp2.Length>=4){
                            string [] ar6=temp2[3].Split(")");string style=ar6[0].Replace(" ","");
                            Polyline ee = new Polyline(points,int.Parse(id),style);
                            ee.add();
                        }else{
                            Polyline c = new Polyline(points, int.Parse(id),null);
                            c.add();
                        }
                    }else if(shapes.Equals(" Polygon")){
                        string [] ar1=temp2[1].Split(":");string id=ar1[0].Replace(" ","").Replace(",points","");
                        string [] ar2=temp2[2].Split(":");string points=ar2[0].Replace(" style","").Replace(")","");
                        if(temp2.Length>=4){
                            string [] ar6=temp2[3].Split(")");string style=ar6[0].Replace(" ","");
                            Polygon ee = new Polygon(points,int.Parse(id),style);
                            ee.add();
                        }else{
                            Polygon c = new Polygon(points, int.Parse(id),null);
                            c.add();
                        }
                    }else if(shapes.Equals(" Path")){
                        string [] ar1=temp2[1].Split(":");string id=ar1[0].Replace(" ","").Replace(",d","");
                        string [] ar2=temp2[2].Split(":");string points=ar2[0].Replace(" style","").Replace(")","");
                        if(temp2.Length>=4){
                            string [] ar6=temp2[3].Split(")");string style=ar6[0].Replace(" ","");
                            Path ee = new Path(points,int.Parse(id),style);
                            ee.add();
                        }else{
                            Path c = new Path(points, int.Parse(id),null);
                            c.add();
                        }
                    }
                }     
            }
            string ans = File.ReadAllText(filePath);
            if(!ans.Contains("</svg>")){
                using (var writer = File.AppendText(filePath))  
                { 
                    writer.Write("</svg>"); 
                }
            }
        }
        public static void clearing(){
            Console.WriteLine("Clearing the canvas!!");
            canvas= new Canvas();
            Console.WriteLine(canvas);
        }

        
        public static void ClientCode(IShape shape)
        {
            user.Action(shape,canvas);
        }
}

