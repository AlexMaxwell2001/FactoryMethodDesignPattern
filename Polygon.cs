// Polygon Shape class
using System;
using System.IO;
public class Polygon : IShape
{
    public string filePath=@".\svg.svg";
    public string Points { get; private set; }
    public int Id { get; private set; }
    public string Style { get; private set; }
    public Polygon(string points,int id,string style)
    {
        Points = points;Id=id;Style=style;
    }

    public Polygon(){
        Points="50,160,55,180,70,180,60,190,65,205,50,195,35,205,40,190,30,180,45,180";
        Id=6;
        Style="green,5,transparent,null";
    }
    
    public void add()
        {
            string svg="</svg>";
            string lines=File.ReadAllText(filePath);
            string [] values = Points.Split(",");
                if(Style==null){
                    readWrite();
                    using (var writer = File.AppendText(filePath))  
                    {  
                        writer.Write("\t" +"<polygon id="+@"""" +Id+@""""+" points="+@""""+Points+@""""+ "/>" +Environment.NewLine);
                        writer.Write(svg);
                    } 
                }else{
                    string manip=findStyle();
                    readWrite();
                    using (var writer = File.AppendText(filePath))  
                    {  
                        writer.Write("\t" +"<polygon id="+@"""" +Id+@""""+" points="+@""""+Points+@""""+" style="+@""""+manip+@""""+ "/>" +Environment.NewLine);
                        writer.Write(svg);
                    }                     
                }
        }

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
            if(linestyle.Equals("null")){}
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
            string [] ar={"stroke:", "stroke-width:","fill:", styletype+":" };
            string [] dim={stroke,strokewidth,fill,dimensionsStyle};
            if(stroke.Equals("null"))ar[0]="null";
            if(strokewidth.Equals("null"))ar[1]="null";
            if(fill.Equals("null"))ar[2]="null";
            if(linestyle.Equals("null"))ar[3]="null";
            for(int i=0;i<ar.Length;i++){
            if(i==ar.Length-1 && !ar[i].Equals("null"))manip+=ar[i]+dim[i];
                else if(!ar[i].Equals("null")){
                    manip+=ar[i]+dim[i] + ";";
                }
            }
            return manip;
        }
         public static void readWrite(){
            string filePath=@".\svg.svg";
            string svg="</svg>";
            string text;
            string value="";
            StreamReader sr = File.OpenText(filePath);
            while ((text = sr.ReadLine()) != null)
            {
                if (!text.Contains(svg))
                {
                    value += text + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(filePath, value);
        }

    public override string ToString()
    {
        if(Style == null){
            return "Polygon (id: " + Id+", points: " + Points+ ")";
        }else{
            return "Polygon (id: " + Id+", points: " + Points + " style: " + Style + ")";
        }
    }
}