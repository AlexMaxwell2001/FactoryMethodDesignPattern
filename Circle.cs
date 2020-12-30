using System.IO;
using System;
// Circle Shape class
public class Circle : IShape
{
    string filePath=@".\svg.svg";
    public int CX { get; private set; }
    public int CY { get; private set; }
    public int R { get; private set; }
    public int Id { get; private set; }
    public string Style { get; private set; }

    public Circle(){
            CX=25;
            CY=75;
            R=20;
            Id=2;
            Style="red,5,transparent,null";
    }

    public Circle(int cx, int cy, int r,int id, string style)
    {
        CX = cx; CY = cy; R = r;Id=id;Style=style;
    }
    public void add(){
        string lines=File.ReadAllText(filePath);
        if(Style==null){
            readWrite();
            using (var writer = File.AppendText(filePath))  
            {  
                writer.Write("\t" +"<circle id="+@""""  +Id+@""""+" cx="+@""""+CX+@""""+" cy="+@""""+CY+@""""+" r="+@""""+R+@""""+"/>" + Environment.NewLine);
            } 
        }else{
            string manip=findStyle();
            readWrite();
            using (var writer = File.AppendText(filePath))  
            {  
                writer.Write("\t" +"<circle id="+@"""" +Id+@""""+" cx="+@""""+CX+@""""+" cy="+@""""+CY+@""""+" r="+@""""+R+@""""+ " style="+@""""+manip+@""""+"/>" + Environment.NewLine);
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
        public void edit(string action){
            string filePath=@".\svg.svg", text,value="",manip="",theline="";
            string [] ar=Style.Split(",");
            for(int i=0;i<ar.Length;i++){
                if(i==ar.Length-1)manip+=ar[i];
                else manip+=ar[i] + " ";
            }
            StreamReader sr = File.OpenText(filePath);
            while ((text = sr.ReadLine()) != null)
            {
                if (text.Contains(Id.ToString()))theline=text;
            }
            sr.Close();
            string [] results= theline.Split("/");string now=results[0];
            string add=" transform="+ @"""" + action+ "(" + manip+ ")"+@""""+"/>";string theEnd= now +add;
            StreamReader sr2 = File.OpenText(filePath);
            while ((text = sr2.ReadLine()) != null)
            {
                if (text.Contains(Id.ToString())) value += theEnd + Environment.NewLine;
                else value += text + Environment.NewLine; 
            }
            sr2.Close();File.WriteAllText(filePath, value);
        }
    public override string ToString()
    {
        if(Style == null){
            return "Circle (id: " + Id +", cx: " + CX + ", cy: " + CY + ", r: " + R + ")";
        }else{
            return "Circle (id: " + Id +", cx: " + CX + ", cy: " + CY + ", r: " + R +", style: " + Style+ ")";
        }
    }
}

    