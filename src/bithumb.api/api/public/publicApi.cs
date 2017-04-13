using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCoin.API.Public
{
    /// <summary>
    /// https://api.bithumb.com/
    /// </summary>
    public class XPublicApi
    {
        private string __connect_key;
        private string __secret_key;

        /// <summary>
        /// 
        /// </summary>
        public XPublicApi()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public XPublicApi(string connect_key, string secret_key)
        {
            __connect_key = connect_key;
            __secret_key = secret_key;
        }

        private ApiClient __api_client = null;

        private ApiClient ApiClient
        {
            get
            {
                if (__api_client == null)
                    __api_client = new ApiClient(__connect_key, __secret_key);
                return __api_client;
            }
        }

        /// <summary>
        /// bithumb 거래소 마지막 거래 정보
        /// </summary>
        /// <param name="currency">BTC, ETH (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<PublicTicker> GetPublicTicker(string currency = "BTC")
        {
            var _result = await ApiClient.CallApiGetAsync<PublicTicker>($"/public/ticker/{currency}");
            _result.result = (_result.status == 0);

            return _result;
        }

        /// <summary>
        /// bithumb 거래소 판/구매 등록 대기 또는 거래 중 내역 정보
        /// </summary>
        /// <param name="currency">BTC, ETH (기본값: BTC)</param>
        /// <param name="group_orders">Value : 0 또는 1 (Default : 1)</param>
        /// <param name="count">Value : 1 ~ 50 (Default : 20)</param>
        /// <returns></returns>
        public async Task<PublicOrderBook> GetOrderBook(string currency = "BTC", int group_orders = 1, int count = 20)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("group_orders", group_orders);
                _params.Add("count", count);
            }

            var _result = await ApiClient.CallApiGetAsync<PublicOrderBook>($"/public/orderbook/{currency}", _params);
            _result.result = (_result.status == 0);

            return _result;
        }

        /// <summary>
        /// bithumb 거래소 거래 체결 완료 내역
        /// </summary>
        /// <param name="currency">BTC, ETH (기본값: BTC)</param>
        /// <param name="offset">Value : 0 ~ (Default : 0)</param>
        /// <param name="count">Value : 1 ~ 100 (Default : 20)</param>
        /// <returns></returns>
        public async Task<PublicTransactions> GetTransactions(string currency = "BTC", int offset = 0, int count = 50)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("offset", offset);
                _params.Add("count", count);
            }

            var _result = await ApiClient.CallApiGetAsync<PublicTransactions>($"/public/recent_transactions/{currency}", _params);
            _result.result = (_result.status == 0);

            return _result;
        }
    }
}