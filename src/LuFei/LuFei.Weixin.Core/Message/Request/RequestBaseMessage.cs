using System;

namespace LuFei.Weixin.Core.Message.Request
{
    /// <summary>
    /// 接收到的请求消息基类
    /// 接收到的请求消息分普通消息和事件推送两大类。
    /// </summary>
    public abstract class RequestBaseMessage
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public abstract RequestMsgType MsgType { get; }

        /// <summary>
        /// 消息密文，如果没有启用消息加密，则为Null
        /// </summary>
        public string Encrypt { get; set; }
    }
}

/*
<xml>
 <ToUserName><![CDATA[toUser]]></ToUserName>
 <FromUserName><![CDATA[fromUser]]></FromUserName> 
 <CreateTime>1348831860</CreateTime>
 <MsgType><![CDATA[text]]></MsgType>
 <Content><![CDATA[this is a test]]></Content>
 <MsgId>1234567890123456</MsgId>
</xml>
 
    
参数	        描述
ToUserName	    开发者微信号
FromUserName	发送方帐号（一个OpenID）
CreateTime	    消息创建时间 （整型）
MsgType	        text
Content	        文本消息内容
MsgId	        消息id，64位整型

 */
