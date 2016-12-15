namespace LuFei.Weixin.Core.Message.Response
{
    /// <summary>
    /// 回复图片消息
    /// </summary>
    public class ResponseImageMessage : ResponseBaseMessage
    {
        public override ResponseMessageType MsgType
        {
            get { return ResponseMessageType.image; }
        }

        /// <summary>
        /// 通过素材管理接口上传多媒体文件
        /// </summary>
        public Image Image { get; set; }

    }
}
/*
 <xml>
<ToUserName><![CDATA[toUser]]></ToUserName>
<FromUserName><![CDATA[fromUser]]></FromUserName>
<CreateTime>12345678</CreateTime>
<MsgType><![CDATA[image]]></MsgType>
<Image>
<MediaId><![CDATA[media_id]]></MediaId>
</Image>
</xml>
*/
