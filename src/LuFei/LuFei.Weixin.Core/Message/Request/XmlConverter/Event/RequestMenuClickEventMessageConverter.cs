using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.Event;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 点击菜单拉取消息时的事件消息转换
    /// </summary>
    public class RequestMenuClickEventMessageConverter : RequestBaseEventMessageConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestMenuClickEventMessage;
            if (msgObj2 != null)
            {
                msgObj2.EventKey = msgDoc.Root.Element("EventKey").Value;
            }
        }

    }
}
