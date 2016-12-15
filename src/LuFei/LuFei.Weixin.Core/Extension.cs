using System;

namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 各种扩展方法
    /// </summary>
    public static class Extension
    {
        #region string to enum
        /// <summary>
        /// 字符串转换为对应的枚举类型
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="value">包含要转换的值或名称的字符串。</param>
        /// <param name="ignoreCase">true 为忽略大小写；false 为考虑大小写。</param>
        /// <returns></returns>
        public static TEnum? ToEnum<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct
        {
            TEnum result;
            if (Enum.TryParse(value, ignoreCase, out result))
            {
                return result;
            }
            else
            {
                return null;
            }            
        }
        #endregion

        public static long ToLong(this string str)
        {
            return long.Parse(str);
        }

        public static double ToDouble(this string str)
        {
            return double.Parse(str);
        }

        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }


        #region unix时间戳
        //Unix时间戳（英文为Unix epoch, Unix time, POSIX time 或 Unix timestamp）
        //Unix时间戳是从1970年1月1日（UTC/GMT的午夜）开始所经过的秒数，不考虑闰秒

        /// <summary>
        /// 转为Unix时间戳
        /// </summary>
        /// <param name="dt">指定日期时间</param>
        /// <returns></returns>
        public static long ToUnixTimestamp(this DateTime dt)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dt.Kind);
            return Convert.ToInt64((dt - start).TotalSeconds);
        }

        /// <summary>
        /// 从Unix时间戳转换为日期时间
        /// </summary>
        /// <param name="timestamp">Unix时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timestamp)
        {
            var start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0));
            return start.AddSeconds(timestamp);
        }
        #endregion
    }
}
