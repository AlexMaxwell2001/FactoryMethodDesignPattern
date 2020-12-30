using System;
class PolygonFactory : ShapeCreator
{
    Random rnd =new Random();
    public override IShape CreateShape()
    {
        return new Polygon(rnd.Next(1, 200)+", "+ rnd.Next(1, 200)+" "+ rnd.Next(1, 200)+", " +rnd.Next(1,200)+ " "+ rnd.Next(1,200)+ ", " + rnd.Next(1,200),rnd.Next(1, 10000),null);
    }
    public override IShape CreateStyledShape()
    {
        return new Polygon(rnd.Next(1, 200)+", "+ rnd.Next(1, 200)+" "+ rnd.Next(1, 200)+", " +rnd.Next(1,200)+ " "+ rnd.Next(1,200)+ ", " + rnd.Next(1,200),rnd.Next(1, 10000),"green,5,transparent,null");
    }
}