using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCoin.API.Info
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
        /// <param name="currency">BTC, ETH (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<UserAccount> GetAccount(string currency = "BTC")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
            }

            var _result = await Api_Client.CallApiAsync<UserAccount>("/info/account", _params);
            _result.result = (_result.status == 0);

            return _result;
        }

        /// <summary>
        /// bithumb 거래소 회원 지갑 정보
        /// </summary>
        /// <param name="currency">BTC, ETH (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<UserBalance> GetUserBalance(string currency = "BTC")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
            }

            var _result = await Api_Client.CallApiAsync<UserBalance>("/info/balance", _params);
            _result.result = (_result.status == 0);

            return _result;
        }

        /// <summary>
        /// bithumb 거래소 회원 입금 주소
        /// </summary>
        /// <param name="currency">BTC, ETH (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<UserWalletAddress> GetWalletAddress(string currency = "BTC")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
            }

            var _result = await Api_Client.CallApiAsync<UserWalletAddress>("/info/wallet_address", _params);
            _result.result = (_result.status == 0);

            return _result;
        }

        /// <summary>
        /// 회원 마지막 거래 정보
        /// </summary>
        /// <param name="currency">BTC, ETH (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<UserTicker> GetUserTicker(string currency = "BTC")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
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