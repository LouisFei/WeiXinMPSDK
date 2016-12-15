namespace LuFei.Weixin.Core.Message.Request.Event
{
    /// <summary>
    /// 点击菜单跳转链接时的事件推送
    /// </summary>
    public class RequestMenuViewEventMessage : RequestBaseEventMessage
    {
        public override RequestEventType Event
        {
            get
            {
                return RequestEventType.CLICK;
            }
        }

        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { get; set; }

    }
}
/*
 <xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[VIEW]]></Event>
<EventKey><![CDATA[www.qq.com]]></EventKey>
</xml>
*/
