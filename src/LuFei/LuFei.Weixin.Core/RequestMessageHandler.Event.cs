using LuFei.Weixin.Core.Message.Request;
using LuFei.Weixin.Core.Message.Request.Event;
using LuFei.Weixin.Core.Message.Request.General;
using LuFei.Weixin.Core.Message.Response;

namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 请求消息处理类
    /// 部分类，专门用于放置针对事件推送消息的回复处理方法
    /// </summary>
    public abstract partial class RequestMessageHandler
    {
        /// <summary>
        /// 微信事件推送消息分发处理
        /// </summary>
        /// <param name="reqMsg"></param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnEventRequest(RequestBaseEventMessage reqMsg)
        {
            var rspMsg = DefaultResponseMessage(reqMsg);

            switch (reqMsg.Event)
            {
                case RequestEventType.subscribe:
                    rspMsg = OnSubscribeEventRequest(reqMsg as RequestSubscribeEventMessage);
                    break;
                case RequestEventType.unsubscribe:
                    rspMsg = OnUnsubscribeEventRequest(reqMsg as RequestUnsubscribeEventMessage);
                    break;
                case RequestEventType.SCAN:
                    rspMsg = OnScanEventRequest(reqMsg as RequestScanEventMessage);
                    break;
                case RequestEventType.LOCATION:
                    rspMsg = OnLocationEventRequest(reqMsg as RequestLocationEventMessage);
                    break;
                case RequestEventType.CLICK:
                    rspMsg = OnMenuClickEventRequest(reqMsg as RequestMenuClickEventMessage);
                    break;
                case RequestEventType.VIEW:
                    rspMsg = OnMenuViewEventRequest(reqMsg as RequestMenuViewEventMessage);
                    break;
                default:
                    break;
            }

            return rspMsg;
        }

        /// <summary>
        /// 关注/订阅事件处理
        /// </summary>
        /// <param name="reqMsg">关注/订阅事件消息实体</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnSubscribeEventRequest(RequestSubscribeEventMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 取消关注/订阅事件
        /// </summary>
        /// <param name="reqMsg">取消关注/订阅事件</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnUnsubscribeEventRequest(RequestUnsubscribeEventMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 扫描带参数二维码事件
        /// </summary>
        /// <param name="reqMsg">扫描带参数二维码事件</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnScanEventRequest(RequestScanEventMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        /// <param name="reqMsg">上报地理位置事件</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnLocationEventRequest(RequestLocationEventMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 点击菜单拉取消息时的事件推送
        /// </summary>
        /// <param name="reqMsg"></param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnMenuClickEventRequest(RequestMenuClickEventMessage reqMsg) { return DefaultResponseMessage(reqMsg); }


        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        /// <param name="reqMsg"></param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnMenuViewEventRequest(RequestMenuViewEventMessage reqMsg) { return DefaultResponseMessage(reqMsg); }



    }
}
