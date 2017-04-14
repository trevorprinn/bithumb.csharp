namespace Bithumb.API.Info
{
    /// <summary>
    /// bithumb 거래소 회원 지갑 정보
    /// </summary>
    public class UserBalanceData
    {
        /// <summary>
        /// 전체 BTC
        /// </summary>
        public decimal total_btc
        {
            get;
            set;
        }
        
        /// <summary>
        /// 전체 ETH
        /// </summary>
        public decimal total_eth
        {
            get;
            set;
        }

        /// <summary>
        /// 전체 KRW
        /// </summary>
        public decimal total_krw
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
        /// 사용중 ETH
        /// </summary>
        public decimal in_use_eth
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
        /// 사용 가능 BTC
        /// </summary>
        public decimal available_btc
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 가능 ETH
        /// </summary>
        public decimal available_eth
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
        /// 신용거래 BTC
        /// </summary>
        public decimal misu_btc
        {
            get;
            set;
        }

        /// <summary>
        /// 신용거래 ETH
        /// </summary>
        public decimal misu_eth
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
    }
}