using System;

namespace CryptoExchangeLib
{
    public abstract class CryptoCurrency
    {
        public abstract void Display();
    }

    public abstract class Exchange
    {
        public abstract void Display();
    }

    public class Bitcoin : CryptoCurrency
    {
        public override void Display()
        {
            Console.WriteLine("Це Bitcoin");
        }
    }

    public class Ethereum : CryptoCurrency
    {
        public override void Display()
        {
            Console.WriteLine("Це Ethereum");
        }
    }

    public class Binance : Exchange
    {
        public override void Display()
        {
            Console.WriteLine("Це Binance");
        }
    }

    public class Coinbase : Exchange
    {
        public override void Display()
        {
            Console.WriteLine("Це Coinbase");
        }
    }

    public abstract class CryptoExchangeFactory
    {
        public abstract CryptoCurrency CreateCryptoCurrency();
        public abstract Exchange CreateExchange();
    }

    public class BitcoinExchangeFactory : CryptoExchangeFactory
    {
        public override CryptoCurrency CreateCryptoCurrency()
        {
            return new Bitcoin();
        }

        public override Exchange CreateExchange()
        {
            return new Binance();
        }
    }

    public class EthereumExchangeFactory : CryptoExchangeFactory
    {
        public override CryptoCurrency CreateCryptoCurrency()
        {
            return new Ethereum();
        }

        public override Exchange CreateExchange()
        {
            return new Coinbase();
        }
    }

    public class Client
    {
        private CryptoCurrency _cryptoCurrency;
        private Exchange _exchange;

        public Client(CryptoExchangeFactory factory)
        {
            _cryptoCurrency = factory.CreateCryptoCurrency();
            _exchange = factory.CreateExchange();
        }

        public void Display()
        {
            _cryptoCurrency.Display();
            _exchange.Display();
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання конкретної фабрики
            CryptoExchangeFactory bitcoinFactory = new BitcoinExchangeFactory();
            Client bitcoinClient = new Client(bitcoinFactory);
            bitcoinClient.Display();

            CryptoExchangeFactory ethereumFactory = new EthereumExchangeFactory();
            Client ethereumClient = new Client(ethereumFactory);
            ethereumClient.Display();
        }
    }
}