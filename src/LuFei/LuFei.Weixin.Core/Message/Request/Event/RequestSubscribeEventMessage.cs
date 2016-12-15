namespace LuFei.Weixin.Core.Message.Request.Event
{
    /// <summary>
    /// 关注事件消息实体
    /// </summary>
    public class RequestSubscribeEventMessage : RequestBaseEventMessage
    {
        public override RequestEventType Event
        {
            get
            {
                return RequestEventType.subscribe;
            }
        }


        //https://mp.weixin.qq.com/wiki/7/9f89d962eba4c5924ed95b513ba69d9b.html
        //用户扫描带场景值二维码时，可能推送以下两种事件：
        //1、如果用户还未关注公众号，则用户可以关注公众号，关注后微信会将带场景值关注事件推送给开发者。

        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值（如果不是扫描场景二维码，此参数为空）
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片（如果不是扫描场景二维码，此参数为空）
        /// </summary>
        public string Ticket { get; set; }
    }
}
/*
 <xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[subscribe]]></Event>
</xml>
*/

/*
 <xml><ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[FromUser]]></FromUserName>
<CreateTime>123456789</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[subscribe]]></Event>

<EventKey><![CDATA[qrscene_123123]]></EventKey>
<Ticket><![CDATA[TICKET]]></Ticket>
</xml>
*/
