namespace LuFei.Weixin.Core.Message.Request.Event
{
    /// <summary>
    /// 取消关注事件消息实体
    /// </summary>
    public class RequestUnsubscribeEventMessage : RequestBaseEventMessage
    {
        public override RequestEventType Event
        {
            get
            {
                return RequestEventType.unsubscribe;
            }
        }


    }
}
