using System;

namespace LuFei.Weixin.Core.Message.Request
{
    /// <summary>
    /// 接收的请求消息类型
    /// </summary>
    /// <remarks>
    /// https://mp.weixin.qq.com/wiki/17/f298879f8fb29ab98b2f2971d42552fd.html
    /// </remarks>
    public enum RequestMsgType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text,
        /// <summary>
        /// 图片消息
        /// </summary>
        Image,
        /// <summary>
        /// 语音消息
        /// </summary>
        Voice,
        /// <summary>
        /// 视频消息
        /// </summary>
        Video,
        /// <summary>
        /// 小视频消息
        /// </summary>
        ShortVideo,
        /// <summary>
        /// 地理位置消息
        /// </summary>
        Location,
        /// <summary>
        /// 链接消息
        /// </summary>
        Link,
        /// <summary>
        /// 事件推送消息
        /// </summary>
        Event,
    }
}
