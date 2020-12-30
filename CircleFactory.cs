using System;
class CircleFactory : ShapeCreator
{
    Random rnd= new Random();
    public override IShape CreateShape()
    {
        return new Circle(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200),rnd.Next(1, 10000),null);
    }
    public override IShape CreateStyledShape()
    {
        return new Circle(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200),rnd.Next(1, 10000),"red,5,transparent,null");
    }
}
    