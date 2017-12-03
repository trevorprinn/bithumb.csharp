﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCT.BaseLib.API.Bithumb.User
{
    /// <summary>
    /// https://api.bithumb.com/
    /// </summary>
    public class BUserApi
    {
        private string __connect_key;
        private string __secret_key;

        /// <summary>
        /// 
        /// </summary>
        public BUserApi(string connect_key, string secret_key)
        {
            __connect_key = connect_key;
            __secret_key = secret_key;
        }

        private BithumbClient __user_client = null;

        private BithumbClient UserClient
        {
            get
            {
                if (__user_client == null)
                    __user_client = new BithumbClient(__connect_key, __secret_key);
                return __user_client;
            }
        }

        /// <summary>
        /// bithumb 거래소 회원 정보
        /// </summary>
        /// <param name="currency">BTC, ETH, DASH, LTC, ETC, XRP (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<UserAccount> Account(string currency)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
            }

            return await UserClient.CallApiPostAsync<UserAccount>("/info/account", _params);
        }

        /// <summary>
        /// bithumb 거래소 회원 지갑 정보
        /// </summary>
        /// <param name="currency">BTC, ETH, DASH, LTC, ETC, XRP (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<UserBalance> Balance(string currency = "ALL")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
            }

            return await UserClient.CallApiPostAsync<UserBalance>("/info/balance", _params);
        }

        // For testing in LinqPad, returns the raw JSON
        internal async Task<string> BalanceRaw(string currency = "ALL") {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
            }

            return await UserClient.CallApiPostRawAsync("/info/balance", _params);
        }

        /// <summary>
        /// bithumb 거래소 회원 입금 주소
        /// </summary>
        /// <param name="currency">BTC, ETH, DASH, LTC, ETC, XRP (기본값: BTC)</param>
        /// <returns></returns>
        public async Task<UserWalletAddress> WalletAddress(string currency)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
            }

            return await UserClient.CallApiPostAsync<UserWalletAddress>("/info/wallet_address", _params);
        }

        /// <summary>
        /// 회원 마지막 거래 정보
        /// </summary>
        /// <param name="order_currency">BTC, ETH, DASH, LTC, ETC, XRP (기본값: BTC)</param>
        /// <param name="payment_currency">KRW (현재 bithumb에서 제공하는 통화 KRW)</param>
        /// <returns></returns>
        public async Task<UserTicker> Ticker(string order_currency, string payment_currency = "KRW")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("order_currency", order_currency);
                _params.Add("payment_currency", payment_currency);
            }

            return await UserClient.CallApiPostAsync<UserTicker>("/info/ticker", _params);
        }

        /// <summary>
        /// 판/구매 거래 주문 등록 또는 진행 중인 거래
        /// </summary>
        /// <param name="currency">BTC, ETH, DASH, LTC, ETC, XRP (기본값: BTC)</param>
        /// <param name="order_id">판/구매 주문 등록된 주문번호</param>
        /// <param name="type">거래유형(bid : 구매, ask : 판매)</param>
        /// <param name="count">Value : 1 ~1000 (default : 100)</param>
        /// <param name="after">YYYY-MM-DD hh:mm:ss 의 UNIX Timestamp (2014-11-28 16:40:01 = 1417160401000)</param>
        /// <returns></returns>
        public async Task<UserOrders> Orders(string currency, string order_id = "", string type = "", int count = 100, long after = 0)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
                _params.Add("order_id", order_id);
                _params.Add("type", type);
                _params.Add("count", count);
                _params.Add("after", after);
            }

            return await UserClient.CallApiPostAsync<UserOrders>("/info/orders", _params);
        }

        /// <summary>
        /// 회원 거래 내역
        /// </summary>
        /// <param name="currency">BTC, ETH, DASH, LTC, ETC, XRP (기본값: BTC)</param>
        /// <param name="offset">Value : 0 ~ (default : 0)</param>
        /// <param name="count">Value : 1 ~ 50 (default : 20)</param>
        /// <param name="searchGb">	0 : 전체, 1 : 구매완료, 2 : 판매완료, 3 : 출금중, 4 : 입금, 5 : 출금, 9 : KRW입금중</param>
        /// <returns></returns>
        public async Task<UserTransactions> UserTransactions(string currency, int offset = 0, int count = 20, int searchGb = 0)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
                _params.Add("offset", offset);
                _params.Add("count", count);
                _params.Add("searchGb", searchGb);
            }

            return await UserClient.CallApiPostAsync<UserTransactions>("/info/user_transactions", _params);
        }

        /// <summary>
        /// bithumb 회원 판/구매 체결 내역
        /// </summary>
        /// <param name="currency">BTC, ETH, DASH, LTC, ETC, XRP (기본값: BTC)</param>
        /// <param name="order_id">판/구매 주문 등록된 주문번호</param>
        /// <param name="type">거래유형 (bid : 구매, ask : 판매)</param>
        /// <returns></returns>
        public async Task<UserOrderDetail> OrderDetail(string currency, string order_id, string type)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("currency", currency);
                _params.Add("order_id", order_id);
                _params.Add("type", type);
            }

            return await UserClient.CallApiPostAsync<UserOrderDetail>("/info/order_detail", _params);
        }
    }
}