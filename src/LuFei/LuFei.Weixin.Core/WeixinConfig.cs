namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeixinConfig
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID { get; set; }
        /// <summary>
        /// 应用密钥
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// Token（用于响应微信发送的Token验证）
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 消息加密密钥
        /// </summary>
        public string EncodingAESKey { get; set; }

    }
}
