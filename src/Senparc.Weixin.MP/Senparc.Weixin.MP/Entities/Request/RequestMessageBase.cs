/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：RequestMessageBase.cs
    文件功能描述：接收到请求的消息基类
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

namespace Senparc.Weixin.MP.Entities
{
    /// <summary>
    /// 请求消息接口
    /// </summary>
    public interface IRequestMessageBase : Weixin.Entities.IRequestMessageBase
    {
        /// <summary>
        /// 请求消息的类型
        /// </summary>
        RequestMsgType MsgType { get; }
        /// <summary>
        /// 消息密文，如果没有启用消息加密，则为Null
        /// </summary>
        string Encrypt { get; set; }
        /// <summary>
        /// 消息编号
        /// </summary>
        long MsgId { get; set; }
    }

    /// <summary>
    /// 接收到请求的消息
    /// </summary>
    public class RequestMessageBase : Weixin.Entities.RequestMessageBase, IRequestMessageBase
    {
        public virtual RequestMsgType MsgType
        {
            get { return RequestMsgType.Text; }
        }

        public string Encrypt { get; set; }

        public RequestMessageBase()
        {

        }

        //public override RequestMsgType MsgType
        //{
        //    get { return RequestMsgType.Text; }
        //}

        public long MsgId { get; set; }
    }
}
