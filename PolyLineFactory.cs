using System;
class PolyLineFactory : ShapeCreator
{
    Random rnd= new Random();
    public override IShape CreateShape()
    {
        return new Polyline(rnd.Next(1, 200)+", "+ rnd.Next(1, 200)+" "+ rnd.Next(1, 200)+", " +rnd.Next(1,200),rnd.Next(1, 10000),null);
    }
    public override IShape CreateStyledShape()
    {
        return new Polyline(rnd.Next(1, 200)+", "+ rnd.Next(1, 200)+" "+ rnd.Next(1, 200)+", " +rnd.Next(1,200),rnd.Next(1, 10000),"orange,5,transparent,null");
    }
}