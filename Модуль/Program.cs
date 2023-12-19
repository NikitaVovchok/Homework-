using System;

namespace SuvenyStore
{
    // Интерфейс продукта
    public interface IProduct
    {
        string Name { get; }
        string Type { get; }
        double Price { get; }
    }

    // Реализация интерфейса продукта
    public class Product : IProduct
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public double Price { get; private set; }

        // Конструктор с параметрами
        public Product(string name, string type, double price)
        {
            Name = name;
            Type = type;
            Price = price;
        }
    }

    // Интерфейс Builder'а
    public interface IBuilder
    {
        void BuildName(string name);
        void BuildType(string type);
        void BuildPrice(double price);
        IProduct GetProduct();
    }

    // Реализация интерфейса Builder'а
    public class ProductBuilder : IBuilder
    {
        private string _name;
        private string _type;
        private double _price;

        public void BuildName(string name)
        {
            _name = name;
        }

        public void BuildType(string type)
        {
            _type = type;
        }

        public void BuildPrice(double price)
        {
            _price = price;
        }

        public IProduct GetProduct()
        {
            return new Product(_name, _type, _price);
        }
    }

    // Директор
    public class Director
    {
        private IBuilder _builder;

        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public IProduct ConstructProduct(string name, string type, double price)
        {
            _builder.BuildName(name);
            _builder.BuildType(type);
            _builder.BuildPrice(price);

            return _builder.GetProduct();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Использование Builder'а
            var builder = new ProductBuilder();
            var director = new Director(builder);
            var product = director.ConstructProduct("Candle", "Home Decor", 5.99);

            Console.WriteLine($"Product: {product.Name}, Type: {product.Type}, Price: {product.Price}");
        }
    }
}