using System;
using System.Collections.Generic;

namespace CryptoExchange
{
    // Абстрактний клас для представлення котирування криптовалюти
    abstract class CurrencyQuotation
    {
        public abstract CurrencyQuotation Clone();
        public abstract void Display();
    }

    // Конкретний клас для котирування криптовалюти 
    class CryptoCurrencyQuotation : CurrencyQuotation
    {
        private string currency;
        private double price;

        public CryptoCurrencyQuotation(string currency, double price)
        {
            this.currency = currency;
            this.price = price;
        }

        public override CurrencyQuotation Clone()
        {
            return new CryptoCurrencyQuotation(currency, price);
        }

        public override void Display()
        {
            Console.WriteLine($"{currency}: {price}");
        }
    }

    // Клас для керування прототипами котирування криптовалюти
    class CurrencyQuotationPrototypeManager
    {
        private Dictionary<string, CurrencyQuotation> prototypes = new Dictionary<string, CurrencyQuotation>();

        public CurrencyQuotation this[string key]
        {
            get { return prototypes[key].Clone(); }
            set { prototypes[key] = value; }
        }
    }

    // Клас обміну криптовалюти, який використовує прототипи для створення котирування
    class CryptoExchange
    {
        private List<CurrencyQuotation> quotations = new List<CurrencyQuotation>();

        public void AddQuotation(CurrencyQuotation quotation)
        {
            quotations.Add(quotation);
        }

        public void DisplayQuotations()
        {
            foreach (var quotation in quotations)
            {
                quotation.Display();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання прототипів для створення котирування криптовалюти та додавання їх до обміну
            CurrencyQuotationPrototypeManager prototypeManager = new CurrencyQuotationPrototypeManager();

            prototypeManager["BTC"] = new CryptoCurrencyQuotation("BTC", 10000);
            prototypeManager["ETH"] = new CryptoCurrencyQuotation("ETH", 2000);

            // Використання Singleton для отримання єдиного екземпляра обміну
            CryptoExchange exchange = new CryptoExchange();

            // Додавання котирування криптовалюти до обміну, використовуючи клонування прототипів
            exchange.AddQuotation(new CryptoCurrencyQuotation("BTC", 10000));
            exchange.AddQuotation(new CryptoCurrencyQuotation("ETH", 2000));

            // Виведення всіх котирувань криптовалюти в обміні
            exchange.DisplayQuotations();
        }
    }
}