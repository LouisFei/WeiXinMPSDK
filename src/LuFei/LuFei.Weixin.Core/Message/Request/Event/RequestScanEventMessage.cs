namespace LuFei.Weixin.Core.Message.Request.Event
{
    /// <summary>
    /// 扫描带参数二维码事件消息实体
    /// </summary>
    public class RequestScanEventMessage : RequestBaseEventMessage
    {
        public override RequestEventType Event
        {
            get
            {
                return RequestEventType.SCAN;
            }
        }


        //https://mp.weixin.qq.com/wiki/7/9f89d962eba4c5924ed95b513ba69d9b.html
        //用户扫描带场景值二维码时，可能推送以下两种事件：
        //1、如果用户还未关注公众号，则用户可以关注公众号，关注后微信会将带场景值关注事件推送给开发者。
        //如果用户已经关注公众号，则微信会将带场景值扫描事件推送给开发者。

        /// <summary>
        /// 事件KEY值，是一个32位无符号整数，即创建二维码时的二维码scene_id
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
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
<Event><![CDATA[SCAN]]></Event>
<EventKey><![CDATA[SCENE_VALUE]]></EventKey>
<Ticket><![CDATA[TICKET]]></Ticket>
</xml>
*/
