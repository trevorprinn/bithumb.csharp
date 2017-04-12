using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCoin.ApiCall.Trader.XCoin.Public
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
        /// <returns></returns>
        public async Task<PublicTicker> GetPublicTicker()
        {
            return await ApiClient.CallApiGetAsync<PublicTicker>("/public/ticker");
        }

        /// <summary>
        /// bithumb 거래소 판/구매 등록 대기 또는 거래 중 내역 정보
        /// </summary>
        /// <returns></returns>
        public async Task<PublicOrderBook> GetOrderBook()
        {
            return await ApiClient.CallApiAsync<PublicOrderBook>("/public/orderbook");
        }

        /// <summary>
        /// bithumb 거래소 거래 체결 완료 내역
        /// </summary>
        /// <returns></returns>
        public async Task<PublicTransactions> GetTransactions(int offset = 0, int count = 50)
        {
            return await ApiClient.CallApiAsync<PublicTransactions>(String.Format("/public/recent_transactions?offset={0}&count={1}", offset, count));
        }
    }
}