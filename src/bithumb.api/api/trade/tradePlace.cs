using System;
using System.Collections.Generic;
using System.Linq;

namespace XCoin.API.Trade
{
    /// <summary>
    /// 
    /// </summary>
    public class TradePlaceData
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
        /// 체결 수량
        /// </summary>
        public decimal units
        {
            get;
            set;
        }

        /// <summary>
        /// 1BTC당 체결가
        /// </summary>
        public decimal price
        {
            get;
            set;
        }

        /// <summary>
        /// KRW 체결가
        /// </summary>
        public decimal total
        {
            get;
            set;
        }

        /// <summary>
        /// 수수료
        /// </summary>
        public decimal fee
        {
            get;
            set;
        }
    }

    /// <summary>
    /// bithumb 회원 판/구매 거래 주문 등록 및 체결
    /// </summary>
    public class TradePlace : ApiResult<List<TradePlaceData>>
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