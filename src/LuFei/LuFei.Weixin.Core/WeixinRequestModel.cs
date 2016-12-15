using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 来自微信服务器的请求
    /// </summary>
    public class WeixinRequestModel
    {
        //https://mp.weixin.qq.com/wiki/8/f9a0b8382e0b77d87b3bcc1ce6fbc104.html
        /* 在微信服务器请求第三方应用服务器时会附带以下参数，并且是放在Request.QueryString里。

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
        /// 微信用户OpenID
        /// </summary>
        public string OpenID { get; set; }

        /// <summary>
        /// 加密方式
        /// </summary>
        public string encrypt_type { get; set; }
        /// <summary>
        /// 消息加密签名
        /// </summary>
        public string msg_signature { get; set; }

        /// <summary>
        /// 请求主体
        /// </summary>
        public Stream RequestBody { get; set; }

        private XDocument _RequestBodyXmlDoc = null;
        /// <summary>
        /// 请求主体（xml对象形式）
        /// </summary>
        public XDocument RequestBodyXmlDoc
        {
            get
            {
                if (_RequestBodyXmlDoc == null)
                {
                    if (RequestBody != null)
                    {
                        //序列化将流转成XML字符串
                        RequestBody.Seek(0, SeekOrigin.Begin);//强制调整指针位置
                        using (XmlReader xReader = XmlReader.Create(RequestBody))
                        {
                            _RequestBodyXmlDoc = XDocument.Load(xReader);
                        }
                    }
                }

                return _RequestBodyXmlDoc;
            }
        }
    }
}
