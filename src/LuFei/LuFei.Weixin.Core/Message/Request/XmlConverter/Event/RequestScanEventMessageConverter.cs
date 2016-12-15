using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.Event;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 取消关注消息转换
    /// </summary>
    public class RequestScanEventMessageConverter : RequestBaseEventMessageConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestScanEventMessage;
            if (msgObj2 != null)
            {
                msgObj2.EventKey = msgDoc.Root.Element("EventKey").Value;
                msgObj2.Ticket = msgDoc.Root.Element("Ticket").Value;
            }
        }

    }
}
