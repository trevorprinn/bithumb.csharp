namespace XCT.BaseLib.API.Bithumb.User
{
    /// <summary>
    /// bithumb 거래소 회원 지갑 정보
    /// </summary>
    public class UserBalanceData
    {
        /// <summary>
        /// 전체 KRW
        /// </summary>
        public decimal total_krw
        {
            get;
            set;
        }

        /// <summary>
        /// 사용중 KRW
        /// </summary>
        public decimal in_use_krw
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 KRW
        /// </summary>
        public decimal available_krw
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 KRW
        /// </summary>
        public decimal misu_krw
        {
            get;
            set;
        }

        /// <summary>
        /// 전체 BTC
        /// </summary>
        public decimal total_btc
        {
            get;
            set;
        }

        /// <summary>
        /// 사용중 BTC
        /// </summary>
        public decimal in_use_btc
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 BTC
        /// </summary>
        public decimal available_btc
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 BTC
        /// </summary>
        public decimal misu_btc
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal xcoin_last_btc
        {
            get;
            set;
        }


        /// <summary>
        /// 전체 eth
        /// </summary>
        public decimal total_eth
        {
            get;
            set;
        }

        /// <summary>
        /// 사용중 eth
        /// </summary>
        public decimal in_use_eth
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 eth
        /// </summary>
        public decimal available_eth
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 eth
        /// </summary>
        public decimal misu_eth
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal xcoin_last_eth
        {
            get;
            set;
        }


        /// <summary>
        /// 전체 dash
        /// </summary>
        public decimal total_dash
        {
            get;
            set;
        }

        /// <summary>
        /// 사용중 dash
        /// </summary>
        public decimal in_use_dash
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 dash
        /// </summary>
        public decimal available_dash
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 dash
        /// </summary>
        public decimal misu_dash
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal xcoin_last_dash
        {
            get;
            set;
        }


        /// <summary>
        /// 전체 ltc
        /// </summary>
        public decimal total_ltc
        {
            get;
            set;
        }

        /// <summary>
        /// 사용중 ltc
        /// </summary>
        public decimal in_use_ltc
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 ltc
        /// </summary>
        public decimal available_ltc
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 ltc
        /// </summary>
        public decimal misu_ltc
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal xcoin_last_ltc
        {
            get;
            set;
        }


        /// <summary>
        /// 전체 etc
        /// </summary>
        public decimal total_etc
        {
            get;
            set;
        }

        /// <summary>
        /// 사용중 etc
        /// </summary>
        public decimal in_use_etc
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 etc
        /// </summary>
        public decimal available_etc
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 etc
        /// </summary>
        public decimal misu_etc
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal xcoin_last_etc
        {
            get;
            set;
        }

        /// <summary>
        /// 전체 xrp
        /// </summary>
        public decimal total_xrp
        {
            get;
            set;
        }

        /// <summary>
        /// 사용중 xrp
        /// </summary>
        public decimal in_use_xrp
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 xrp
        /// </summary>
        public decimal available_xrp
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 xrp
        /// </summary>
        public decimal misu_xrp
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal xcoin_last_xrp
        {
            get;
            set;
        }

        /// <summary>
        /// bithumb 마지막 거래체결 금액
        /// </summary>
        public decimal xcoin_last
        {
            get;
            set;
        }

        /// <summary>
        /// 미수 증거금
        /// </summary>
        public decimal misu_depo_krw
        {
            get;
            set;
        }
    }

    /// <summary>
    /// bithumb 거래소 회원 지갑 정보
    /// </summary>
    public class UserBalance : ApiResult<UserBalanceData>
    {
        public UserBalance()
        {
            this.data = new UserBalanceData();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string currency
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 전체 QTY
        ///// </summary>
        //public decimal total_qty
        //{
        //    get
        //    {
        //        if (this.currency == "BTC")
        //            return this.data.total_btc;
        //        return this.data.total_eth;
        //    }
        //}

        ///// <summary>
        ///// 사용중 QTY
        ///// </summary>
        //public decimal in_use_qty
        //{
        //    get
        //    {
        //        if (this.currency == "BTC")
        //            return this.data.in_use_btc;
        //        return this.data.in_use_eth;
        //    }
        //}

        ///// <summary>
        ///// 사용 가능 QTY
        ///// </summary>
        //public decimal available_qty
        //{
        //    get
        //    {
        //        if (this.currency == "BTC")
        //            return this.data.available_btc;
        //        return this.data.available_eth;
        //    }
        //}

        ///// <summary>
        ///// 신용거래 QTY
        ///// </summary>
        //public decimal misu_qty
        //{
        //    get
        //    {
        //        if (this.currency == "BTC")
        //            return this.data.misu_btc;
        //        return this.data.misu_eth;
        //    }
        //}
    }
}