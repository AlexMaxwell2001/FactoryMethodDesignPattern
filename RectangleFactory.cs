using System;
class RectangleFactory : ShapeCreator
{
    Random rnd = new Random();
    public override IShape CreateShape()
    {
        return new Rectangle(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1,200),rnd.Next(1, 10000),null);
    }
    public override IShape CreateStyledShape()
    {
        return new Rectangle(rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1, 200), rnd.Next(1,200),rnd.Next(1, 10000),"black,5,transparent,null");
    }
}
    