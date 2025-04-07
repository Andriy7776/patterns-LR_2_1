using System;

namespace CreationalPatterns
{
    // Одинак (Singleton)
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton() { }

        public static Singleton Instance => _instance ??= new Singleton();

        public void ShowMessage()
        {
            Console.WriteLine("Екземпляр Singleton");
        }
    }

    // Фабричний метод (Factory Method)
    public interface IProduct
    {
        void Use();
    }

    public class ConcreteProductA : IProduct
    {
        public void Use() => Console.WriteLine("Використання продукту A");
    }

    public class ConcreteProductB : IProduct
    {
        public void Use() => Console.WriteLine("Використання продукту B");
    }

    public class Creator
    {
        public IProduct FactoryMethod(string type)
        {
            return type switch
            {
                "A" => new ConcreteProductA(),
                _ => new ConcreteProductB(),
            };
        }
    }

    // Абстрактна фабрика (Abstract Factory)
    public interface IAbstractProduct
    {
        void Create();
    }

    public class ProductA : IAbstractProduct
    {
        public void Create() => Console.WriteLine("Створено продукт A");
    }

    public class ProductB : IAbstractProduct
    {
        public void Create() => Console.WriteLine("Створено продукт B");
    }

    public interface IAbstractFactory
    {
        IAbstractProduct CreateProduct();
    }

    public class FactoryA : IAbstractFactory
    {
        public IAbstractProduct CreateProduct() => new ProductA();
    }

    public class FactoryB : IAbstractFactory
    {
        public IAbstractProduct CreateProduct() => new ProductB();
    }

    // Будівельник (Builder)
    public class Product
    {
        public string PartA { get; set; }
        public string PartB { get; set; }

        public void Show() => Console.WriteLine($"Продукт створено з {PartA} та {PartB}");
    }

    public class ProductBuilder
    {
        private readonly Product _product = new Product();

        public ProductBuilder SetPartA(string partA)
        {
            _product.PartA = partA;
            return this;
        }

        public ProductBuilder SetPartB(string partB)
        {
            _product.PartB = partB;
            return this;
        }

        public Product Build() => _product;
    }

    // Прототип (Prototype)
    public class Prototype : ICloneable
    {
        public string Data { get; set; }

        public Prototype(string data)
        {
            Data = data;
        }

        public object Clone() => new Prototype(Data);

        public void ShowData() => Console.WriteLine($"Дані прототипу: {Data}");
    }

    public class Program
    {
        public static void Main()
        {
            // Singleton
            Console.WriteLine("Singleton:");
            var singleton = Singleton.Instance;
            singleton.ShowMessage();

            // Factory Method
            Console.WriteLine("\nFactory Method:");
            var creator = new Creator();
            var product = creator.FactoryMethod("A");
            product.Use();

            // Abstract Factory
            Console.WriteLine("\nAbstract Factory:");
            IAbstractFactory factoryA = new FactoryA();
            var productA = factoryA.CreateProduct();
            productA.Create();

            // Builder
            Console.WriteLine("\nBuilder:");
            var builder = new ProductBuilder();
            var builtProduct = builder.SetPartA("Двигун").SetPartB("Колеса").Build();
            builtProduct.Show();

            // Prototype
            Console.WriteLine("\nPrototype:");
            var original = new Prototype("Оригінальні дані");
            var clone = (Prototype)original.Clone();
            clone.ShowData();
        }
    }
}
