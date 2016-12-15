namespace LuFei.Weixin.Core.Message.Response
{
    /// <summary>
    /// 回复文本消息
    /// </summary>
    public class ResponseTextMessage : ResponseBaseMessage
    {
        public override ResponseMessageType MsgType
        {
            get { return ResponseMessageType.text; }
        }

        /// <summary>
        /// 回复的消息内容（换行：在content中能够换行，微信客户端就支持换行显示）
        /// </summary>
        public string Content { get; set; }

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
