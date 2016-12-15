using LuFei.Weixin.Core;
using LuFei.Weixin.Core.Message.Request;
using LuFei.Weixin.Core.Message.Request.General;
using LuFei.Weixin.Core.Message.Response;

namespace Senparc.Weixin.MP.Sample
{
    /// <summary>
    /// 自定义微信请求消息处理
    /// </summary>
    public class CustomWeixinMessageRequestHandler : LuFei.Weixin.Core.RequestMessageHandler
    {
        public CustomWeixinMessageRequestHandler(WeixinRequestModel wxreq, WeixinConfig wxCfg) : base(wxreq, wxCfg)
        {
        }

        public override ResponseBaseMessage DefaultResponseMessage(RequestBaseMessage reqMsg)
        {
            var rspTextMsg = new ResponseTextMessage();
            rspTextMsg.Content = "默认消息";
            return rspTextMsg;
        }

        public override ResponseBaseMessage OnTextRequest(RequestTextMessage reqMsg)
        {
            //return base.OnTextRequest(reqMsg);

            return new ResponseTextMessage() { Content = string.Format("收到您的消息：{0}", reqMsg.Content) };
        }
    }
}