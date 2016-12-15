using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 微信服务器请求检验类
    /// </summary>
    /// <remarks>
    /// https://mp.weixin.qq.com/wiki/8/f9a0b8382e0b77d87b3bcc1ce6fbc104.html
    /// 加密/校验流程如下：
    /// 1. 将token、timestamp、nonce三个参数进行字典序排序
    /// 2. 将三个参数字符串拼接成一个字符串进行sha1加密
    /// 3. 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
    /// </remarks>
    public static class CheckSignature
    {
        /// <summary>
        /// 在网站没有提供Token（或传入为null）的情况下的默认Token，建议在网站中进行配置。
        /// </summary>
        public const string Token = "weixin";

        #region Check
        /// <summary>
        /// 检查微信签名
        /// 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
        /// </summary>
        /// <param name="signature">微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="token">开发者在公众平台设置的token</param>
        /// <returns></returns>
        public static bool Check(string signature, string timestamp, string nonce, string token = null)
        {
            return signature == GetSignature(timestamp, nonce, token);
        }
        #endregion

        #region GetSignature
        /// <summary>
        /// 加密获得签名
        /// </summary>
        /// <remarks>
        /// 加密步骤：
        /// 1. 将token、timestamp、nonce三个参数进行字典序排序
        /// 2. 将三个参数字符串拼接成一个字符串进行sha1加密
        /// </remarks>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机数</param>
        /// <param name="token">开发者在公众平台设置的token</param>
        /// <returns></returns>
        public static string GetSignature(string timestamp, string nonce, string token = null)
        {
            token = token ?? Token;
            var arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
            var arrString = string.Join("", arr);
            var sha1 = SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            StringBuilder enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }

            return enText.ToString();
        }
        #endregion
    }
}
