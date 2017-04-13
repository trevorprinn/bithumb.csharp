using System;
using System.Collections.Generic;
using System.Linq;

namespace XCoin.LIB
{
    /// <summary>
    /// 
    /// </summary>
    public static class CExtend
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime ChangeTime(this DateTime dateTime, decimal hours, decimal minutes, decimal seconds, decimal milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                (int)hours,
                (int)minutes,
                (int)seconds,
                (int)milliseconds,
                dateTime.Kind);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ToLogDateTimeString()
        {
            return DateTime.Now.ToLogDateTimeString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToLogDateTimeString(this DateTime datetime)
        {
            return String.Format("{0:yyyy-MM-dd-HH:mm:ss}", datetime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpace(this string self)
        {
            return new string(self.Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="chunkLength"></param>
        /// <returns></returns>
        public static string[] SplitByLength(this string sourceString, int chunkLength)
        {
            var _result = new List<string>();

            for (int i = 0; i < sourceString.Length; i += chunkLength)
            {
                if (chunkLength + i > sourceString.Length)
                    chunkLength = sourceString.Length - i;

                _result.Add(sourceString.Substring(i, chunkLength));
            }

            return _result.ToArray();
        }
    }
}