namespace LuFei.Weixin.Core.Message.Response
{
    /// <summary>
    /// 回复语音消息
    /// </summary>
    public class ResponseVoiceMessage : ResponseBaseMessage
    {
        public override ResponseMessageType MsgType
        {
            get { return ResponseMessageType.voice; }
        }

        /// <summary>
        /// 通过素材管理接口上传多媒体文件
        /// </summary>
        public Voice Voice { get; set; }

    }
}
/*
<xml>
    <ToUserName><![CDATA[toUser]]></ToUserName>
    <FromUserName><![CDATA[fromUser]]></FromUserName>
    <CreateTime>12345678</CreateTime>
    <MsgType><![CDATA[voice]]></MsgType>
    <Voice>
        <MediaId><![CDATA[media_id]]></MediaId>
    </Voice>
</xml>
*/
