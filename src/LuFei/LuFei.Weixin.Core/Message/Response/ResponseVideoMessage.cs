namespace LuFei.Weixin.Core.Message.Response
{
    /// <summary>
    /// 回复视频消息
    /// </summary>
    public class ResponseVideoMessage : ResponseBaseMessage
    {
        public override ResponseMessageType MsgType
        {
            get { return ResponseMessageType.video; }
        }

        /// <summary>
        /// 通过素材管理接口上传多媒体文件
        /// </summary>
        public Video Video { get; set; }

    }
}
/*
    <xml>
        <ToUserName><![CDATA[toUser]]></ToUserName>
        <FromUserName><![CDATA[fromUser]]></FromUserName>
        <CreateTime>12345678</CreateTime>
        <MsgType><![CDATA[video]]></MsgType>
        <Video>
            <MediaId><![CDATA[media_id]]></MediaId>
            <Title><![CDATA[title]]></Title>
            <Description><![CDATA[description]]></Description>
        </Video> 
    </xml>
*/
