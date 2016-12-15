using System;

namespace LuFei.Weixin.Core.Message.Request
{
    /// <summary>
    /// 接收到的事件推送消息的事件类型
    /// </summary>
    /// <remarks>
    /// https://mp.weixin.qq.com/wiki/7/9f89d962eba4c5924ed95b513ba69d9b.html
    /// </remarks>
    public enum RequestEventType
    {
        /// <summary>
        /// 关注/订阅事件
        /// </summary>
        subscribe,
        /// <summary>
        /// 取消关注/订阅事件
        /// </summary>
        unsubscribe,
        /// <summary>
        /// 扫描带参数二维码事件
        /// </summary>
        SCAN,
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        LOCATION,
        /// <summary>
        /// 点击菜单拉取消息时的事件推送
        /// </summary>
        CLICK,
        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        VIEW,
    }
}
