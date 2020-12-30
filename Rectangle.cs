// Rectangle Shape class
using System;
using  System.IO;
public class Rectangle : IShape
{
    //Output file path
    string filePath=@".\svg.svg";
    public  int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Id { get; private set; }
    public string Style { get; private set; }
    public Rectangle(){
            X=10;
            Y=10;
            Width=30;
            Height=30;
            Id=1;
            Style="black,5,transparent,null";
    }
    public Rectangle(int x, int y, int width, int height,int id,string style)
    {
        X = x; Y = y; Width= width;Height= height;Id=id;Style=style;
    }

    //This function will take care of adding shapes with and without style, dimensions are mandatory for adding rectangles
        public void add()
        {
            //Closing tag
            string svg="</svg>";
            //File contents
            string lines=File.ReadAllText(filePath);
                //If the user indentified style to be null/didn't specify style, only create the rectangle with the specified dimensions
                if(Style==null){
                        //Take off the </svg> closing tag to add our shape on
                        readWrite();
                        //Add the shape and the closing tag after
                        using (var writer = File.AppendText(filePath))  
                        {  
                            writer.Write("\t"+"<rect id="+@""""+Id+@""""+" x="+@""""+X+@""""+" y="+@""""+Y+@""""+" width="+@""""+Width+@""""+" height="+@""""+Height+@""""+"/>" + Environment.NewLine);
                            writer.Write(svg);
                        } 
                }
                //Else the user wants to specify the style so we need to add it now
                else{
                    //Use the findStyle() function to format the user input into the style formt required
                    string manip=findStyle();
                    //Take off the </svg> closing tag to add our shape
                    readWrite();
                    //Add our shape with the style and the closing tag after
                    using (var writer = File.AppendText(filePath))  
                    {  
                        writer.Write("\t" +"<rect id="+@""""+Id+@""""+" x="+@""""+X+@""""+" y="+@""""+Y+@""""+" width="+@""""+Width+@""""+" height="+@""""+Height+@""""+" style="+@""""+manip+@""""+"/>" + Environment.NewLine);
                        writer.Write(svg);
                    }  
                }
            }
            //The findStyle() functions manipulates the user input to format the style string
        public string findStyle(){
            var individual= Style.Split(",");
            var stroke=individual[0];
            var strokewidth=individual[1];
            var fill=individual[2];
            var linestyle=individual[3];
            string  [] seperate;
            string styletype="";
            string dimensionsStyle="";
            string manip="";
            //if the 4th styling attribute is empty don't bother trying to manipulate it
            if(linestyle.Equals("null")){}
            //If not empty split it and get the information 
            else{
                seperate= linestyle.Split(":");
                styletype+=seperate[0];
                if(linestyle.Contains(".")){
                    dimensionsStyle=seperate[1].Replace(".",",");
                }
                else{
                        dimensionsStyle=seperate[1];
                }
            }
            //Make two data structures for manipulating the data  
            string [] ar={"stroke:", "stroke-width:","fill:", styletype+":" };
            string [] dim={stroke,strokewidth,fill,dimensionsStyle};
            if(stroke.Equals("null"))ar[0]="null";
            if(strokewidth.Equals("null"))ar[1]="null";
            if(fill.Equals("null"))ar[2]="null";
            if(linestyle.Equals("null"))ar[3]="null";
            //Depending if the values are null , format the style string
            for(int i=0;i<ar.Length;i++){
                if(i==ar.Length-1 && !ar[i].Equals("null"))manip+=ar[i]+dim[i];
                else if(!ar[i].Equals("null")){
                        manip+=ar[i]+dim[i] + ";";
                }
            }
            //Return the string that was manipulated
            return manip;
        }
        //This function will be used to remove the closing svg tag for adding shapes
        public static void readWrite(){
            //File path
            string filePath=@".\svg.svg";
            //Closing tag
            string svg="</svg>";
            string text;
            string value="";
            StreamReader sr = File.OpenText(filePath);
            while ((text = sr.ReadLine()) != null)
            {
                //Add it to the value string if it doesn't have the closing tag
                if (!text.Contains(svg))
                {
                    value += text + Environment.NewLine;
                }
            }
            //Close the reader
            sr.Close();
            //Write the string version without the closing tag
            File.WriteAllText(filePath, value);
        }
    public override string ToString()
    {
        if(Style == null){
            return "Rectangle (id: " + Id + ", x: " + X + ", y: " + Y + ", width: " + Width + ", height: " + Height +")";
        }else{
            return "Rectangle (id: " + Id + ", x: " + X + ", y: " + Y + ", width: " + Width + ", height: " + Height +", style: " + Style +")";
        }
    }
}

        