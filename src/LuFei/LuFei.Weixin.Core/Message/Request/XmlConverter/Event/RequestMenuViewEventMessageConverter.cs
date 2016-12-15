using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.Event;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 点击菜单跳转链接时的事件消息转换
    /// </summary>
    public class RequestMenuViewEventMessageConverter : RequestBaseEventMessageConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestMenuViewEventMessage;
            if (msgObj2 != null)
            {
                msgObj2.EventKey = msgDoc.Root.Element("EventKey").Value;
            }
        }

    }
}
