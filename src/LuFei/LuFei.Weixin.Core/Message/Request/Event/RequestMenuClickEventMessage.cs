namespace LuFei.Weixin.Core.Message.Request.Event
{
    /// <summary>
    /// 点击菜单拉取消息时的事件推送
    /// </summary>
    public class RequestMenuClickEventMessage : RequestBaseEventMessage
    {
        public override RequestEventType Event
        {
            get
            {
                return RequestEventType.CLICK;
            }
        }

        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
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
<Event><![CDATA[CLICK]]></Event>
<EventKey><![CDATA[EVENTKEY]]></EventKey>
</xml>
*/
