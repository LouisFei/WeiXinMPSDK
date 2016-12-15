using System;
using LuFei.Weixin.Core.Message.Request;
using LuFei.Weixin.Core.Message.Response;

namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 默认的微信请求消息处理类
    /// </summary>
    public class DefaultRequestMessageHandler : RequestMessageHandler
    {
        public DefaultRequestMessageHandler(WeixinRequestModel wxreq, WeixinConfig wxCfg) : base(wxreq, wxCfg)
        {
        }

        public override ResponseBaseMessage DefaultResponseMessage(RequestBaseMessage reqMsg)
        {
            var rspTextMsg = new ResponseTextMessage();
            rspTextMsg.Content = "我们已经接收到您的消息，稍后回复您！";
            return rspTextMsg;
        }
    }
}
