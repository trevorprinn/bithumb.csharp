using System;
using XCoin.API.Trader.XCoin.Info;

namespace XCoin.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var __info_api = new XInfoApi("connect-key", "secret-key");

            var _balance = __info_api
                                .GetUserBalance("BTC", "KRW")
                                .GetAwaiter()
                                .GetResult();

            Console.WriteLine(_balance.data.available_btc);
        }
    }
}
