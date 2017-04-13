﻿using System;
using System.Drawing;

namespace XCoin.API.Trader.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionTypeData
    {
        /// <summary>
        /// 
        /// </summary>
        public string KindName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Color KindColor
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal KrwFee
        {
            get;
            set;
        }
    }
}