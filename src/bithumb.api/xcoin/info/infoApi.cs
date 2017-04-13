using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCoin.API.Trader.XCoin.Info
{
    /// <summary>
    /// https://api.bithumb.com/
    /// </summary>
    public class XInfoApi
    {
        private string __connect_key;
        private string __secret_key;

        /// <summary>
        /// 
        /// </summary>
        public XInfoApi(string connect_key, string secret_key)
        {
            __connect_key = connect_key;
            __secret_key = secret_key;
        }

        private ApiClient __api_client = null;

        private ApiClient Api_Client
        {
            get
            {
                if (__api_client == null)
                    __api_client = new ApiClient(__connect_key, __secret_key);
                return __api_client;
            }
        }

        /// <summary>
        /// bithumb 거래소 회원 정보
        /// </summary>
        /// <returns></returns>
        public async Task<UserAccount> GetAccount()
        {
            return await Api_Client.CallApiAsync<UserAccount>("/info/account");
        }

        /// <summary>
        /// bithumb 거래소 회원 지갑 정보
        /// </summary>
        /// <param name="coin_name">BTC, ETH</param>
        /// <param name="currency_name">KRW</param>
        /// <returns></returns>
        public async Task<UserBalance> GetUserBalance(string coin_name = "BTC", string currency_name = "KRW")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("order_currency", coin_name);
                _params.Add("payment_currency", currency_name);
            }

            return await Api_Client.CallApiAsync<UserBalance>("/info/balance", _params);
        }

        /// <summary>
        /// bithumb 거래소 회원 입금 주소
        /// </summary>
        /// <param name="coin_name">BTC, ETH</param>
        /// <returns></returns>
        public async Task<UserWalletAddress> GetWalletAddress(string coin_name = "BTC")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", coin_name);
            }

            return await Api_Client.CallApiAsync<UserWalletAddress>("/info/wallet_address", _params);
        }

        /// <summary>
        /// 회원 마지막 거래 정보
        /// </summary>
        /// <param name="coin_name">BTC, ETH</param>
        /// <param name="currency_name">KRW</param>
        /// <returns></returns>
        public async Task<UserTicker> GetUserTicker(string coin_name = "BTC", string currency_name = "KRW")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("order_currency", coin_name);
                _params.Add("payment_currency", currency_name);
            }

            return await Api_Client.CallApiAsync<UserTicker>("/info/ticker", _params);
        }

        /// <summary>
        /// 판/구매 거래 주문 등록 또는 진행 중인 거래
        /// </summary>
        /// <returns></returns>
        public async Task<UserOrders> GetOrders()
        {
            var _params = new Dictionary<string, object>();
            {
                //_params.Add("order_id", "");
                //_params.Add("type", "bid");
                _params.Add("count", 100);
                _params.Add("after", 0);
            }

            return await Api_Client.CallApiAsync<UserOrders>("/info/orders", _params);
        }

        /// <summary>
        /// 회원 거래 내역
        /// </summary>
        /// <returns></returns>
        public async Task<UserTransactions> GetUserTransactions(int offset = 0, int count = 50, int searchGb = 0)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("offset", offset);
                _params.Add("count", count);
                _params.Add("searchGb", searchGb);
            }

            return await Api_Client.CallApiAsync<UserTransactions>("/info/user_transactions", _params);
        }

        /// <summary>
        /// bithumb 회원 판/구매 체결 내역
        /// </summary>
        /// <returns></returns>
        public async Task<UserOrderDetail> GetOrderDetail(string orderId, string type)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("order_id", orderId);
                _params.Add("type", type);
            }

            return await Api_Client.CallApiAsync<UserOrderDetail>("/info/order_detail", _params);
        }
    }
}