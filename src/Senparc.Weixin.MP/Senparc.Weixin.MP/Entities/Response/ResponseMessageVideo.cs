/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：ResponseMessageVideo.cs
    文件功能描述：响应回复视频消息
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Senparc.Weixin.MP.Entities
{
    /// <summary>
    /// 回复视频消息
    /// </summary>
    /// <remarks>
    /// 需要预先上传多媒体文件到微信服务器，只支持认证服务号。
    /// </remarks>
    public class ResponseMessageVideo : ResponseMessageBase, IResponseMessageBase
    {
        /// <summary>
        /// 回复消息类型
        /// </summary>
        new public virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Video; }
        }

        /// <summary>
        /// 视频素材
        /// </summary>
        public Video Video { get; set; }

        public ResponseMessageVideo()
        {
            Video = new Video();
        }
    }
}
