// Crypto Exchange
using System;

namespace CryptoExchange
{
    // Интерфейс продукта
    public interface IProduct
    {
        string Operation();
    }

    // Клас конкретного продукта
    public class CryptoProduct : IProduct
    {
        public string Operation()
        {
            return "Crypto Exchange Product";
        }
    }

    // Интерфейс створювача
    public abstract class Creator
    {
        // Абстрактный фабричный метод
        public abstract IProduct FactoryMethod();
    }

    // Конкретний створювач
    public class CryptoFactory : Creator
    {
        // Реализация фабричного метода для создания Crypto Exchange продукта
        public override IProduct FactoryMethod()
        {
            return new CryptoProduct();
        }
    }
}

// My App
namespace MyApp
{
    // Клас, который представляет биржу
    public class Exchange : CryptoExchange.IProduct
    {
        private string name;

        public Exchange(string name)
        {
            this.name = name;
        }

        public string Operation()
        {
            return $"Exchange: {name}";
        }
    }

    // Клас, который представляет створювач бирж
    public class ExchangeCreator : CryptoExchange.Creator
    {
        private string name;

        public ExchangeCreator(string name)
        {
            this.name = name;
        }

        // Реализация фабричного метода для создания биржи
        public override CryptoExchange.IProduct FactoryMethod()
        {
            return new Exchange(name);
        }
    }
}

class Program
{
    static void Main()
    {
        // Использование CryptoExchange.Factory и CryptoExchange.Product
        var cryptoFactory = new CryptoExchange.CryptoFactory();
        var cryptoProduct = cryptoFactory.FactoryMethod();
        Console.WriteLine(cryptoProduct.Operation());

        // Использование MyApp.ExchangeCreator
        var exchangeCreator = new MyApp.ExchangeCreator("Binance");
        var exchange = exchangeCreator.FactoryMethod();
        Console.WriteLine(exchange.Operation());
    }
}