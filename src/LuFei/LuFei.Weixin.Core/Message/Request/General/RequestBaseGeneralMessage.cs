namespace LuFei.Weixin.Core.Message.Request.General
{
    /// <summary>
    /// 接收到的普通请求消息基类
    /// </summary>
    public abstract class RequestBaseGeneralMessage : RequestBaseMessage
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
    }
}

