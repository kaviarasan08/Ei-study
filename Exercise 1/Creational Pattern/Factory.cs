using System;

// Step 1: Product interface
interface IShape
{
    void Draw();
}

// Step 2: Concrete Products
class Circle : IShape
{
    public void Draw() => Console.WriteLine("Drawing Circle");
}

class Square : IShape
{
    public void Draw() => Console.WriteLine("Drawing Square");
}

// Step 3: Factory
class ShapeFactory
{
    public static IShape GetShape(string type)
    {
        if (type.Equals("Circle")) return new Circle();
        if (type.Equals("Square")) return new Square();
        throw new Exception("Unknown Shape");
    }
}

// Step 4: Demo
class Program3
{
    static void Main()
    {
        IShape shape1 = ShapeFactory.GetShape("Circle");
        shape1.Draw();

        IShape shape2 = ShapeFactory.GetShape("Square");
        shape2.Draw();
    }
}
