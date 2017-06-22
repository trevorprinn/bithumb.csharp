using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bithumb.LIB.Configuration
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toSearch"></param>
        /// <param name="toFind"></param>
        /// <returns></returns>
        public static bool Like(this string toSearch, string toFind)
        {
            return new Regex(
                                @"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z",
                                RegexOptions.Singleline
                            )
                .IsMatch(toSearch);
        }

        /// <summary>
        /// 연-월-일(yyyy-MM-dd) 형식으로 변환 합니다.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime d)
        {
            return d.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 연월일(yyyyMMdd) 형식으로 변환 합니다.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateString2(this DateTime d)
        {
            return d.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 연-월-일 시:분:초(yyyy-MM-dd HH:mm:ss) 형식으로 변환 합니다.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime d)
        {
            return d.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 연-월-일T시:분:초.Zone(yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK) 형식으로 변환 합니다.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateTimeZoneString(this DateTime d)
        {
            return d.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK");
        }

        /// <summary>
        /// 연-월-일 시:분(yyyy-MM-dd HH:mm) 형식으로 변환 합니다.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToDateHHmmString(this DateTime d)
        {
            return d.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// 시:분:초(HH:mm:ss) 형식으로 변환 합니다.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToTimeHHmmssString(this DateTime d)
        {
            return d.ToString("HH:mm:ss");
        }
    }
}