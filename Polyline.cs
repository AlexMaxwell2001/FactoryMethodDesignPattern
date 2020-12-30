// Polyline Shape class
using System;
using System.IO;

public class Polyline : IShape
{
    public string filePath=@".\svg.svg";
    public string Points { get; private set; }
    public int Id { get; private set; }
    public string Style { get; private set; }
    public Polyline(string points,int id,string style)
    {
        Points = points;Id=id;Style=style;
    }

    public Polyline(){
        Points="60,110,65,120,70,115,75,130,80,125,85,140,90,135,95,150,100,145";
        Id=5;
        Style="orange,5,transparent,null";
    }

     public void add()
        {
            string svg="</svg>";
            string pointsString="";
            int count=0;
            string lines=File.ReadAllText(filePath);
            string [] values = Points.Split(",");
            //Format the points string
            for(int i=0;i<values.Length;i++)
            {
                if(count%2==0){
                    pointsString+=values[i] + ", ";
                }else if(i==values.Length-1){
                    pointsString+=values[i];
                }else{
                    pointsString+=values[i] + " ";
                }
                count++;
            }
                if(Style==null){
                    readWrite();
                    using (var writer = File.AppendText(filePath))  
                    {  
                        writer.Write("\t" +"<polyline id="+@""""+Id+@""""+" points="+@""""+Points+@""""+ "/>" +Environment.NewLine);
                        writer.Write(svg);
                    } 
                }else{
                    string manip=findStyle();
                    readWrite();
                    using (var writer = File.AppendText(filePath))  
                    {  
                        writer.Write("\t" +"<polyline id="+@""""+Id+@""""+" points="+@""""+Points+@""""+" style="+@""""+manip+@""""+ "/>" +Environment.NewLine);
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
            return "Polyline (id: " + Id+", points: " + Points + ")";
        }else{
            return "Polyline (id: " + Id+", points: " + Points +  "  style: " +Style + ")";
        }
    }
}