using System;
using XCoin.API.Info;
using XCoin.API.Public;

namespace XCoin.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var _debug_step = 2;

            // 1. Public API
            if (_debug_step == 1)
            {
                var _public_api = new XPublicApi();

                var _ticker = _public_api.GetPublicTicker("ETH").GetAwaiter().GetResult();
                Console.WriteLine(_ticker.data.closing_price);

                var _orderbook = _public_api.GetOrderBook("ETH", 1, 50).GetAwaiter().GetResult();
                Console.WriteLine(_orderbook.data.timestamp);

                var _transactions = _public_api.GetTransactions("ETH", 0, 100).GetAwaiter().GetResult();
                Console.WriteLine(_transactions.status);
            }

            // 2. Private API
            if (_debug_step == 2)
            {
                var __info_api = new XInfoApi("b93991a223d91303b01584546d486f5f", "409c4b86bc33978695fe64d963a21b2a");

                var _account = __info_api.GetAccount("ETH").GetAwaiter().GetResult();
                Console.WriteLine(_account.data.account_id);

                var _balance = __info_api.GetUserBalance("ETH").GetAwaiter().GetResult();
                Console.WriteLine(_balance.data.available_btc);

                var _wallet_address = __info_api.GetWalletAddress("ETH").GetAwaiter().GetResult();
                Console.WriteLine(_wallet_address.data.wallet_address);
            }

            Console.WriteLine("hit any key to quit...");
            Console.ReadKey();
        }
    }
}
