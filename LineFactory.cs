using System;
class LineFactory : ShapeCreator
{
    Random rnd = new Random();
    public override IShape CreateShape()
    {
        return new Line(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200),rnd.Next(1,200),rnd.Next(1, 10000),null);
    }
    public override IShape CreateStyledShape()
    {
        return new Line(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200),rnd.Next(1,200),rnd.Next(1, 10000),"orange,5,null,null");
    }
}