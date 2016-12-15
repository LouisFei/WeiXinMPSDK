namespace LuFei.Weixin.Core.Message.Response
{
    /// <summary>
    /// 回复音乐消息
    /// </summary>
    public class ResponseMusicMessage : ResponseBaseMessage
    {
        public override ResponseMessageType MsgType
        {
            get { return ResponseMessageType.music; }
        }

        /// <summary>
        /// 通过素材管理接口上传多媒体文件
        /// </summary>
        public Music Music { get; set; }

    }
}
/*
<xml>
    <ToUserName><![CDATA[toUser]]></ToUserName>
    <FromUserName><![CDATA[fromUser]]></FromUserName>
    <CreateTime>12345678</CreateTime>
    <MsgType><![CDATA[music]]></MsgType>
    <Music>
        <Title><![CDATA[TITLE]]></Title>
        <Description><![CDATA[DESCRIPTION]]></Description>
        <MusicUrl><![CDATA[MUSIC_Url]]></MusicUrl>
        <HQMusicUrl><![CDATA[HQ_MUSIC_Url]]></HQMusicUrl>
        <ThumbMediaId><![CDATA[media_id]]></ThumbMediaId>
    </Music>
</xml>
*/
