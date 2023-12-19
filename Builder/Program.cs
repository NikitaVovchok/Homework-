using System;

namespace CryptoExchange
{
    // Crypto exchange
    public class Exchange
    {
        public string Name { get; set; }
        public Currency[] Currencies { get; set; }

        public void Display()
        {
            Console.WriteLine($"Назва: {Name}");
            foreach (var currency in Currencies)
            {
                Console.WriteLine($" Валюта: {currency.Name}, course: {currency.Course}");
            }
        }
    }

    // Currency
    public class Currency
    {
        public string Name { get; set; }
        public decimal Course { get; set; }
    }

    // Builder for Exchange
    public class ExchangeBuilder
    {
        private Exchange _exchange = new Exchange();

        public ExchangeBuilder SetName(string name)
        {
            _exchange.Name = name;
            return this;
        }

        public ExchangeBuilder SetCurrencies(Currency[] currencies)
        {
            _exchange.Currencies = currencies;
            return this;
        }

        public Exchange Build()
        {
            return _exchange;
        }
    }

    // Builder for Currency
    public class CurrencyBuilder
    {
        private Currency _currency = new Currency();

        public CurrencyBuilder SetName(string name)
        {
            _currency.Name = name;
            return this;
        }

        public CurrencyBuilder SetCourse(decimal course)
        {
            _currency.Course = course;
            return this;
        }

        public Currency Build()
        {
            return _currency;
        }
    }

    class Program
    {
        static void Main()
        {
            // Creating Exchange with Currencies
            Exchange exchange = new ExchangeBuilder()
                .SetName("Crypto Exchange")
                .SetCurrencies(new Currency[] {
                    new CurrencyBuilder().SetName("Bitcoin").SetCourse(60000).Build(),
                    new CurrencyBuilder().SetName("Ethereum").SetCourse(2500).Build()
                })
                .Build();

            // Displaying the result
            exchange.Display();
        }
    }
}