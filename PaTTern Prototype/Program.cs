using System;
using System.Collections.Generic;

namespace FunLibNamespace
{
    // Абстрактний клас для представлення криптобіржі
    abstract class ExchangePrototype
    {
        public abstract ExchangePrototype Clone();
        public abstract void Display();
    }

    // Конкретний клас для криптобіржі про біткоїн
    class BitcoinExchange : ExchangePrototype
    {
        private string name;

        public BitcoinExchange(string name)
        {
            this.name = name;
        }

        public override ExchangePrototype Clone()
        {
            return new BitcoinExchange(name);
        }

        public override void Display()
        {
            Console.WriteLine($"Bitcoin Exchange: {name}");
        }
    }

    // Конкретний клас для криптобіржі про етHEREUM
    class EthereumExchange : ExchangePrototype
    {
        private string name;

        public EthereumExchange(string name)
        {
            this.name = name;
        }

        public override ExchangePrototype Clone()
        {
            return new EthereumExchange(name);
        }

        public override void Display()
        {
            Console.WriteLine($"Ethereum Exchange: {name}");
        }
    }

    // Клас для керування прототипами криптобірж
    class ExchangePrototypeManager
    {
        private Dictionary<string, ExchangePrototype> prototypes = new Dictionary<string, ExchangePrototype>();

        public ExchangePrototype this[string key]
        {
            get { return prototypes[key].Clone(); }
            set { prototypes[key] = value; }
        }
    }

    // Клас бібліотеки, який використовує прототипи для створення криптобірж
    class FunLib
    {
        private List<ExchangePrototype> exchanges = new List<ExchangePrototype>();

        public void AddExchange(ExchangePrototype exchange)
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
            ExchangePrototypeManager prototypeManager = new ExchangePrototypeManager();

            prototypeManager["Bitcoin"] = new BitcoinExchange("Coinbase");
            prototypeManager["Ethereum"] = new EthereumExchange("Binance");

            FunLib library = new FunLib();

            // Додавання криптобірж до бібліотеки, використовуючи клонування прототипів
            library.AddExchange(prototypeManager["Bitcoin"].Clone());
            library.AddExchange(prototypeManager["Ethereum"].Clone());

            // Виведення всіх криптобірж в бібліотеці
            library.DisplayExchanges();
        }
    }
}