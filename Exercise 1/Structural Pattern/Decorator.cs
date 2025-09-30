//using System;

//// Component
//public interface ICoffee
//{
//    string GetDescription();
//    double GetCost();
//}

//// Concrete Component
//public class SimpleCoffee : ICoffee
//{
//    public string GetDescription() => "Simple Coffee";
//    public double GetCost() => 50;
//}

//// Decorator
//public abstract class CoffeeDecorator : ICoffee
//{
//    protected ICoffee _coffee;
//    public CoffeeDecorator(ICoffee coffee) { _coffee = coffee; }
//    public abstract string GetDescription();
//    public abstract double GetCost();
//}

//// Concrete Decorators
//public class MilkDecorator : CoffeeDecorator
//{
//    public MilkDecorator(ICoffee coffee) : base(coffee) { }
//    public override string GetDescription() => _coffee.GetDescription() + ", Milk";
//    public override double GetCost() => _coffee.GetCost() + 10;
//}

//public class SugarDecorator : CoffeeDecorator
//{
//    public SugarDecorator(ICoffee coffee) : base(coffee) { }
//    public override string GetDescription() => _coffee.GetDescription() + ", Sugar";
//    public override double GetCost() => _coffee.GetCost() + 5;
//}

//public class Program
//{
//    public static void Main()
//    {
//        ICoffee coffee = new SimpleCoffee();
//        Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}");

//        coffee = new MilkDecorator(coffee);
//        coffee = new SugarDecorator(coffee);
//        Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}");
//    }
//}
