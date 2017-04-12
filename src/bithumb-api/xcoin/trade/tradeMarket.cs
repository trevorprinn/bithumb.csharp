using System;
using System.Collections.Generic;
using System.Linq;

namespace XCoin.ApiCall.Trader.XCoin.Trade
{
    /// <summary>
    /// 
    /// </summary>
    public class TradeMarketData
    {
        /// <summary>
        /// 체결 번호
        /// </summary>
        public long cont_id
        {
            get;
            set;
        }

        /// <summary>
        /// 총 매도/매수 수량(수수료 포함)
        /// </summary>
        public decimal units
        {
            get;
            set;
        }

        /// <summary>
        /// 1BTC당 KRW 시세
        /// </summary>
        public decimal price
        {
            get;
            set;
        }

        /// <summary>
        /// 매도/매수 금액(KRW) 수수료 포함
        /// </summary>
        public decimal total
        {
            get;
            set;
        }

        /// <summary>
        /// 구매 수수료
        /// </summary>
        public decimal fee
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 시장가 구매
    /// </summary>
    public class TradeMarket : ApiResult<List<TradeMarketData>>
    {
        /// <summary>
        /// 주문 ID
        /// </summary>
        public string order_id
        {
            get;
            set;
        }
    }
}