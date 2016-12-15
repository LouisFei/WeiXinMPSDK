using System;

namespace LuFei.Weixin.Core.Message.Response
{
    /// <summary>
    /// 回复消息基类
    /// </summary>
    public abstract class ResponseBaseMessage
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public abstract ResponseMessageType MsgType { get; }

    }
}
/*
 <xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[fromUser]]></FromUserName>
<CreateTime>12345678</CreateTime>
<MsgType><![CDATA[text]]></MsgType>
<Content><![CDATA[你好]]></Content>
</xml>
*/
