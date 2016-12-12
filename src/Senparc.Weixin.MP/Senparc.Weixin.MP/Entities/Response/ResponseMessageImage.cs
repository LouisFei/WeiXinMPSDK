/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：ResponseMessageImage.cs
    文件功能描述：响应回复图片消息
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Senparc.Weixin.MP.Entities
{
    /// <summary>
    /// 回复图片消息
    /// </summary>
    public class ResponseMessageImage : ResponseMessageBase, IResponseMessageBase
    {
        /// <summary>
        /// 回复消息类型
        /// </summary>
        new public virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Image; }
        }

        /// <summary>
        /// 图片素材
        /// </summary>
        public Image Image { get; set; }

        public ResponseMessageImage()
        {
            Image = new Image();
        }
    }
}
