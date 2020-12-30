using System;
class EllipseFactory : ShapeCreator
{
    Random rnd=new Random();
    public override IShape CreateShape()
    {
        return new Ellipse(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200),rnd.Next(1,200),rnd.Next(1, 10000),null);
    }
    public override IShape CreateStyledShape()
    {
        return new Ellipse(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200),rnd.Next(1,200),rnd.Next(1, 10000),"red,10,transparent,null");
    }
}
    