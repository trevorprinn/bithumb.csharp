using System;
using XCT.BaseLib.API.Bithumb.Public;
using XCT.BaseLib.API.Bithumb.Trade;
using XCT.BaseLib.API.Bithumb.User;

namespace Bithumb.Sample.Core
{
    class Program
    {
        /// <summary>
        /// 1. Public API
        /// </summary>
        public static async void XPublicApi()
        {
            var _public_api = new BPublicApi();

            var _ticker = await _public_api.Ticker("ETH");
            if (_ticker.status == 0)
                Console.WriteLine(_ticker.data.closing_price);

            var _orderbook = await _public_api.OrderBook("ETH", 1, 50);
            if (_orderbook.status == 0)
                Console.WriteLine(_orderbook.data.timestamp);

            var _recent_transactions = await _public_api.RecentTransactions("ETH", 0, 100);
            if (_recent_transactions.status == 0)
                Console.WriteLine(_recent_transactions.status);
        }

        /// <summary>
        /// 2. User API
        /// </summary>
        public static async void XInfoApi()
        {
            var __info_api = new BUserApi("connect-key", "secret-key");

            var _account = await __info_api.Account("ETH");
            if (_account.status == 0)
                Console.WriteLine(_account.data.account_id);

            var _balance = await __info_api.Balance("ETH");
            if (_balance.status == 0)
                Console.WriteLine(_balance.data.available_btc);

            var _wallet_address = await __info_api.WalletAddress("ETH");
            if (_wallet_address.status == 0)
                Console.WriteLine(_wallet_address.data.wallet_address);

            var _ticker = await __info_api.Ticker(order_currency: "ETH");
            if (_ticker.status == 0)
                Console.WriteLine(_ticker.data.units_traded);

            var _orders = await __info_api.Orders("ETH");
            if (_orders.status == 0)
                Console.WriteLine(_orders.data.Count);

            var _order_detail = await __info_api.OrderDetail("ETH", "order_id", "ask");
            if (_order_detail.status == 0)
                Console.WriteLine(_order_detail.data.Count);

            var _user_transactions = await __info_api.UserTransactions("ETH");
            if (_user_transactions.status == 0)
                Console.WriteLine(_user_transactions.data.Count);
        }

        /// <summary>
        /// 3. Trade API
        /// </summary>
        public static async void XTradeApi()
        {
            var __trade_api = new BTradeApi("connect-key", "secret-key");

            var _place = await __trade_api.Place(0.1m, 60000, "ask", "ETH");
            if (_place.status == 0)
                Console.WriteLine(_place.data.Count);

            var _cancel = await __trade_api.Cancel("ETH", "order_id", "bid");
            if (_cancel.status == 0)
                Console.WriteLine(_cancel.status);

            var _btc_withdrawal = await __trade_api.BtcWithdrawal("ETH", 0.1m, "address");
            if (_btc_withdrawal.status == 0)
                Console.WriteLine(_btc_withdrawal.status);

            var _krw_deposit = await __trade_api.KrwDeposit();
            if (_krw_deposit.status == 0)
                Console.WriteLine(_krw_deposit.status);

            var _krw_withdrawal = await __trade_api.KrwWithdrawal("003_기업은행", "111-2222-33333", 10000m);
            if (_krw_withdrawal.status == 0)
                Console.WriteLine(_krw_withdrawal.status);

            var _market_buy = await __trade_api.MarketBuy("ETH", 0.1m);
            if (_market_buy.status == 0)
                Console.WriteLine(_market_buy.order_id);

            var _market_sell = await __trade_api.MarketSell("ETH", 0.1m);
            if (_market_sell.status == 0)
                Console.WriteLine(_market_sell.order_id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var _debug_step = 1;

            // 1. Public API
            if (_debug_step == 1)
                XPublicApi();

            // 2. Private API
            if (_debug_step == 2)
                XInfoApi();

            // 3. Trade API
            if (_debug_step == 3)
                XTradeApi();

            Console.WriteLine("hit any key to quit...");
            Console.ReadKey();
        }
    }
}