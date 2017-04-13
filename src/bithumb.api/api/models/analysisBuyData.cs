using System;
using System.Collections.Generic;
using System.Linq;

namespace XCoin.API.Models
{
    /// <summary>
    /// 매수 분석 데이터 형식
    /// </summary>
    public class AnalysisBuyData
    {
        /// <summary>
        /// 거래 일시 Timestamp
        /// </summary>
        public long booking_time
        {
            get;
            set;
        }

        /// <summary>
        /// 판매단가
        /// </summary>
        public decimal sold_price
        {
            get;
            set;
        }

        /// <summary>
        /// 거래 BTC 수량
        /// </summary>
        public decimal sold_qty
        {
            get;
            set;
        }

        /// <summary>
        /// 거래갯수
        /// </summary>
        public decimal sold_count
        {
            get;
            set;
        }

        /// <summary>
        /// 거래금액
        /// </summary>
        public decimal sold_amt
        {
            get;
            set;
        }

        /// <summary>
        /// 거래수수료
        /// </summary>
        public decimal sold_fee
        {
            get;
            set;
        }

        /// <summary>
        /// 수령단가
        /// </summary>
        public decimal received_price
        {
            get;
            set;
        }

        /// <summary>
        /// 수령금액
        /// </summary>
        public decimal received_amt
        {
            get;
            set;
        }

        /// <summary>
        /// 구매예정량
        /// </summary>
        public decimal buying_qty
        {
            get;
            set;
        }

        /// <summary>
        /// 구매예정단가
        /// </summary>
        public decimal buying_price
        {
            get;
            set;
        }

        /// <summary>
        /// 수령예정량
        /// </summary>
        public decimal receiving_qty
        {
            get;
            set;
        }

        /// <summary>
        /// 단타 일수 
        /// </summary>
        public decimal margine_days
        {
            get;
            set;
        }

        /// <summary>
        /// 마진 율
        /// </summary>
        public decimal margine_rate
        {
            get;
            set;
        }

        /// <summary>
        /// 수령 율
        /// </summary>
        public decimal receiving_rate
        {
            get;
            set;
        }

        /// <summary>
        /// 손익분석
        /// </summary>
        public decimal profit_loss
        {
            get;
            set;
        }
    }
}