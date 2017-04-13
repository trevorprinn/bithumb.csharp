using System;
using System.Collections.Generic;
using System.Linq;

namespace XCoin.API.Trader.XCoin.Public
{
    /// <summary>
    /// 
    /// </summary>
    public class PublicOrderBookData
    {
        /// <summary>
        /// 개당 단가 (btc1krw)
        /// </summary>
        public decimal price
        {
            get;
            set;
        }

        /// <summary>
        /// btc 수량
        /// </summary>
        public decimal quantity
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class OrderBookData
    {
        /// <summary>
        /// 
        /// </summary>
        public long timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string order_currency
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string payment_currency
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<PublicOrderBookData> bids
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<PublicOrderBookData> asks
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal quantity
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal price
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PublicOrderBook : ApiResult<OrderBookData>
    {
        public PublicOrderBook()
        {
            this.data = new OrderBookData();
        }
    }
}