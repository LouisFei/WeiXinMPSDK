namespace LuFei.Weixin.Core.Message.Request.Event
{
    /// <summary>
    /// 接收到的事件推送消息基类
    /// </summary>
    public abstract class RequestBaseEventMessage : RequestBaseMessage
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Event;
            }
        }

        /// <summary>
        /// 事件类型
        /// </summary>
        public abstract RequestEventType Event { get; }

    }
}
