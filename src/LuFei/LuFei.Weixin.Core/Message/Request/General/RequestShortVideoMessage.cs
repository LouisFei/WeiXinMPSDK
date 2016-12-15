namespace LuFei.Weixin.Core.Message.Request.General
{
    /// <summary>
    /// 小视频消息实体
    /// </summary>
    public class RequestShortVideoMessage : RequestVideoMessage
    {
        public override RequestMsgType MsgType
        {
            get { return RequestMsgType.ShortVideo; }
        }
    }
}
/*
 <xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[fromUser]]></FromUserName>
<CreateTime>1357290913</CreateTime>
<MsgType><![CDATA[shortvideo]]></MsgType>
<MediaId><![CDATA[media_id]]></MediaId>
<ThumbMediaId><![CDATA[thumb_media_id]]></ThumbMediaId>
<MsgId>1234567890123456</MsgId>
</xml>
*/
