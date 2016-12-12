/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：ResponseMessageMusic.cs
    文件功能描述：响应回复音乐消息
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Senparc.Weixin.MP.Entities
{
    /// <summary>
    /// 回复音乐消息
    /// </summary>
    public class ResponseMessageMusic : ResponseMessageBase, IResponseMessageBase
    {
        /// <summary>
        /// 回复消息类型
        /// </summary>
        public override ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Music; }
        }

        /// <summary>
        /// 音乐素材
        /// </summary>
        public Music Music { get; set; }

        public ResponseMessageMusic()
        {
            Music = new Music();
        }
    }
}
