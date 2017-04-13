using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XCoin.API.Trade
{
    /// <summary>
    /// https://api.bithumb.com/
    /// </summary>
    public class XTradeApi
    {
        private string __connect_key;
        private string __secret_key;

        /// <summary>
        /// 
        /// </summary>
        public XTradeApi(string connect_key, string secret_key)
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
        /// bithumb 회원 판/구매 거래 주문 등록 및 체결
        /// </summary>
        /// <param name="units">주문 BTC 수량 (0.001 ~ 999.99999999)</param>
        /// <param name="price">1BTC당 거래금액</param>
        /// <param name="type">거래유형 (bid : 구매, ask : 판매)</param>
        /// <param name="currency">BTC (기본값)</param>
        /// <param name="misu">신용거래(Y : 사용, N : 일반) – 추후 제공</param>
        /// <returns></returns>
        public async Task<TradePlace> Place(decimal units, decimal price, string type, string currency = "BTC", string misu = "N")
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("order_currency", currency);
                _params.Add("units", units);
                _params.Add("price", price);
                _params.Add("type", type);
                _params.Add("misu", misu);
            }

            return await Api_Client.CallApiAsync<TradePlace>("/trade/place", _params);
        }

        /// <summary>
        /// bithumb 회원 판/구매 거래 취소
        /// </summary>
        /// <param name="orderId">판/구매 주문 등록된 주문번호</param>
        /// <param name="type">거래유형 (bid : 구매, ask : 판매)</param>
        /// <returns></returns>
        public async Task<TradeCancel> Cancel(string orderId, string type)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("order_id", orderId);
                _params.Add("type", type);
            }

            return await Api_Client.CallApiAsync<TradeCancel>("/trade/cancel", _params);
        }

        /// <summary>
        /// bithumb 회원 btc 출금(회원등급에 따른 BTC 출금)
        /// </summary>
        /// <param name="units">BTC 출금 하고자 하는 수량(0.01~ 회원등급수량)</param>
        /// <param name="address">BTC 출금 주소</param>
        /// <returns></returns>
        public async Task<TradeWithdrawal> BtcWithdrawal(decimal units, string address)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("units", units);
                _params.Add("address", address);
            }

            return await Api_Client.CallApiAsync<TradeWithdrawal>("/trade/btc_withdrawal", _params);
        }

        /// <summary>
        /// bithumb 회원 krw 입금 가상계좌 정보 요청
        /// </summary>
        /// <returns></returns>
        public async Task<TradeDeposit> KrwDeposit()
        {
            return await Api_Client.CallApiAsync<TradeDeposit>("/trade/krw_deposit");
        }

        /// <summary>
        /// bithumb 회원 krw 출금 신청 "088_신한은행"
        /// </summary>
        /// <param name="bank">은행코드_은행명</param>
        /// <param name="account">출금계좌번호</param>
        /// <param name="price">출금 금액</param>
        /// <returns></returns>
        public async Task<TradeWithdrawal> KrwWithdrawal(string bank, string account, decimal price)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("bank", bank);
                _params.Add("account", account);
                _params.Add("price", price);
            }

            return await Api_Client.CallApiAsync<TradeWithdrawal>("/trade/krw_withdrawal", _params);
        }

        /// <summary>
        /// 시장가 구매
        /// </summary>
        /// <param name="units">주문 BTC 수량(0.001~ 999.99999999)</param>
        /// <returns></returns>
        public async Task<TradeMarket> MarketBid(decimal units)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("units", units);
            }

            return await Api_Client.CallApiAsync<TradeMarket>("/trade/market_buy", _params);
        }

        /// <summary>
        /// 시장가 판매
        /// </summary>
        /// <param name="units">주문 BTC 수량(0.001 ~ 999.99999999)</param>
        /// <returns></returns>
        public async Task<TradeMarket> MarketAsk(decimal units)
        {
            var _params = new Dictionary<string, object>();
            {
                _params.Add("units", units);
            }

            return await Api_Client.CallApiAsync<TradeMarket>("/trade/market_sell", _params);
        }
    }
}