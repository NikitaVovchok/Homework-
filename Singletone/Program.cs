using System;
using System.Collections.Generic;

namespace CryptoExchangeNamespace
{
    // Абстрактний клас для представлення криптобіржі
    abstract class CryptoExchangePrototype
    {
        public abstract CryptoExchangePrototype Clone();
        public abstract void Display();
    }

    // Конкретний клас для криптобіржі Binance
    class BinanceExchange : CryptoExchangePrototype
    {
        private string name;

        public BinanceExchange(string name)
        {
            this.name = name;
        }

        public override CryptoExchangePrototype Clone()
        {
            return new BinanceExchange(name);
        }

        public override void Display()
        {
            Console.WriteLine($"Binance Exchange: {name}");
        }
    }

    // Конкретний клас для криптобіржі Coinbase
    class CoinbaseExchange : CryptoExchangePrototype
    {
        private string name;

        public CoinbaseExchange(string name)
        {
            this.name = name;
        }

        public override CryptoExchangePrototype Clone()
        {
            return new CoinbaseExchange(name);
        }

        public override void Display()
        {
            Console.WriteLine($"Coinbase Exchange: {name}");
        }
    }

    // Клас для керування прототипами криптобірж
    class CryptoExchangePrototypeManager
    {
        private Dictionary<string, CryptoExchangePrototype> prototypes = new Dictionary<string, CryptoExchangePrototype>();

        public CryptoExchangePrototype this[string key]
        {
            get { return prototypes[key].Clone(); }
            set { prototypes[key] = value; }
        }
    }

    // Клас бібліотеки, який використовує прототипи для створення криптобірж
    class CryptoExchangeLibrary
    {
        private List<CryptoExchangePrototype> exchanges = new List<CryptoExchangePrototype>();

        public void AddExchange(CryptoExchangePrototype exchange)
        {
            exchanges.Add(exchange);
        }

        public void DisplayExchanges()
        {
            foreach (var exchange in exchanges)
            {
                exchange.Display();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання прототипів для створення криптобірж та додавання їх до бібліотеки
            CryptoExchangePrototypeManager prototypeManager = new CryptoExchangePrototypeManager();

            prototypeManager["Binance"] = new BinanceExchange("Binance Exchange");
            prototypeManager["Coinbase"] = new CoinbaseExchange("Coinbase Exchange");

            // Використання єдиного екземпляра бібліотеки за допомогою Singleton
            CryptoExchangeLibrary library = new CryptoExchangeLibrary();

            // Додавання криптобірж до бібліотеки, використовуючи клонування прототипів
            library.AddExchange(prototypeManager["Binance"].Clone());
            library.AddExchange(prototypeManager["Coinbase"].Clone());

            // Виведення всіх криптобірж в бібліотеці
            library.DisplayExchanges();
        }
    }
}