using LuFei.Weixin.Core.Message.Request;
using LuFei.Weixin.Core.Message.Request.General;
using LuFei.Weixin.Core.Message.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 请求消息处理类
    /// 部分类，专门用于放置针对普通请求消息的回复处理方法
    /// </summary>
    public abstract partial class RequestMessageHandler
    {
		/// <summary>
        /// 默认的回复消息，强制子类实现
        /// </summary>
        /// <param name="reqMsg"></param>
        /// <returns></returns>
        public abstract ResponseBaseMessage DefaultResponseMessage(RequestBaseMessage reqMsg);


        /// <summary>
        /// 接收到文本消息
        /// </summary>
        /// <param name="reqMsg">文本消息</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnTextRequest(RequestTextMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 接收到图片消息
        /// </summary>
        /// <param name="reqMsg">图片消息</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnImageRequest(RequestImageMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 接收到语音消息
        /// </summary>
        /// <param name="reqMsg">语音消息</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnVoiceRequest(RequestVoiceMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 接收到视频消息
        /// </summary>
        /// <param name="reqMsg">视频消息</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnVideoRequest(RequestVideoMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 接收到小视频消息
        /// </summary>
        /// <param name="reqMsg">小视频消息</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnShortVideoRequest(RequestShortVideoMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 接收到地理位置消息
        /// </summary>
        /// <param name="reqMsg">地理位置消息</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnLocationRequest(RequestLocationMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

        /// <summary>
        /// 接收到链接消息
        /// </summary>
        /// <param name="reqMsg">链接消息</param>
        /// <returns></returns>
        public virtual ResponseBaseMessage OnLinkRequest(RequestLinkMessage reqMsg) { return DefaultResponseMessage(reqMsg); }

    }
}
