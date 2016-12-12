/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：EncryptPostModel.cs
    文件功能描述：加解密消息统一基类 接口
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Senparc.Weixin
{
    /// <summary>
    /// 接收加密信息统一接口
    /// </summary>
    public interface IEncryptPostModel
    {
        string Signature { get; set; }
        string Msg_Signature { get; set; }
        string Timestamp { get; set; }
        string Nonce { get; set; }

        //以下信息不会出现在微信发过来的信息中，都是企业号后台需要设置（获取的）的信息，用于扩展传参使用
        string Token { get; set; }
        string EncodingAESKey { get; set; }
    }

    /// <summary>
    /// 接收加密信息统一基类
    /// </summary>
    /// <remarks>
    /// https://mp.weixin.qq.com/wiki/8/f9a0b8382e0b77d87b3bcc1ce6fbc104.html
    /// </remarks>
    public class EncryptPostModel : IEncryptPostModel
    {
        /* 虽然是post请求，但发现下面的这些参数其实还是通过url查询字符串传输的。
            
            消息加解密方式为安全模式：
            signature=bf7eaeba8166f87fdc9f4eaf6bf4ffff160a632a
            &timestamp=1481530338
            &nonce=151616710
            &openid=oqEGWt6BkcPhth9UxiVp63i-BHWI
            &encrypt_type=aes
            &msg_signature=e27e488513a86b49709c27fd19c2f289100d877f

            消息加解密方式为明文模式：
            signature=10cb3ea9502c1829292104cc6c7a9a0d3c43d0ef
            &timestamp=1481531851
            &nonce=1804449730
            &openid=oqEGWt6BkcPhth9UxiVp63i-BHWI
        */

        /// <summary>
        /// 微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }
        /// <summary>
        /// 应该是消息加密签名吧？
        /// </summary>
        public string Msg_Signature { get; set; }

        //以下信息不会出现在微信发过来的信息中，都是企业号后台需要设置（获取的）的信息，用于扩展传参使用
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 消息加密密钥
        /// </summary>
        public string EncodingAESKey { get; set; }

        /// <summary>
        /// 设置服务器内部保密信息
        /// </summary>
        /// <param name="token">令牌</param>
        /// <param name="encodingAESKey">消息加解密密钥</param>
        /// <param name="appId">应用ID</param>
        public virtual void SetSecretInfo(string token, string encodingAESKey)
        {
            Token = token;
            EncodingAESKey = encodingAESKey;
        }
    }
}
