// Line Shape class
using System;
using System.IO;
public class Line : IShape
{
    public string filePath=@".\svg.svg";
    public int X1 { get; private set; }
    public int X2 { get; private set; }
    public int Y1 { get; private set; }
    public int Y2 { get; private set; }
    public int Id { get; private set; }
    public string Style { get; private set; }
    public Line(int x1, int x2, int y1,int y2,int id,string style)
    {
        X1 = x1; X2 = x2; Y1 = y1;Y2=y2;Id=id;Style=style;
    }

    public Line(){
        X1=10;
        X2=50;
        Y1=110;
        Y2=150;
        Id=4;
        Style="orange,5,null,null";
    }

    public void add()
    {
            string svg="</svg>";
            string lines=File.ReadAllText(filePath);
                if(Style==null){
                    readWrite();
                    using (var writer = File.AppendText(filePath))  
                    {  
                        writer.Write("\t" +"<line id="+@"""" +Id+@""""+" x1="+@""""+X1+@""""+" x2="+@""""+X2+@""""+" y1="+@""""+Y1+@""""+ " y2="+@""""+Y2+@""""+"/>" + Environment.NewLine);
                        writer.Write(svg);
                    } 
                }
                else{
                    string manip=findStyle();
                    readWrite();
                    using (var writer = File.AppendText(filePath))  
                    {  
                        writer.Write("\t" +"<line id="+@"""" +Id+@""""+" x1="+@""""+X1+@""""+" x2="+@""""+X2+@""""+" y1="+@""""+Y1+@""""+ " y2="+@""""+Y2+@""""+ " style="+@""""+manip+@""""+"/>" + Environment.NewLine);
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
            return "Line (id: "+Id+", x1: " + X1 + ", x2: " + X2 + ", y1: " + Y1 + ", y2: " + Y2 + ")";
        }else{
            return "Line (id: "+Id+", x1: " + X1 + ", x2: " + X2 + ", y1: " + Y1 + ", y2: " + Y2 + ", style: " +Style+ ")";
        }
    }
}