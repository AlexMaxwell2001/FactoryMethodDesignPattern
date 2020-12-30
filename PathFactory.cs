using System;
class PathFactory : ShapeCreator
{
    Random rnd = new Random();
    public override IShape CreateShape()
    {
        return new Path("M"+rnd.Next(1, 200)+","+ rnd.Next(1, 200)+" "+ "Q"+rnd.Next(1, 200)+"," +rnd.Next(1,200)+" "+rnd.Next(1,200)+ ","+rnd.Next(1,200)+" T"+rnd.Next(1,200),rnd.Next(1, 10000),null);
    }
    public override IShape CreateStyledShape()
    {
        return new Path("M"+rnd.Next(1, 200)+","+ rnd.Next(1, 200)+" "+ "Q"+rnd.Next(1, 200)+"," +rnd.Next(1,200)+" "+rnd.Next(1,200)+ ","+rnd.Next(1,200)+" T"+rnd.Next(1,200),rnd.Next(1, 10000),"blue,5,none,null");
    }
}