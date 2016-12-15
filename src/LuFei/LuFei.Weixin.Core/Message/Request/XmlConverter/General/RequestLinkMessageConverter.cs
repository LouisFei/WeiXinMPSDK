using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 链接消息转换
    /// </summary>
    public class RequestLinkMessageConverter : RequestGeneralMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestLinkMessage;
            if (msgObj2 != null)
            {
                msgObj2.Title = msgDoc.Root.Element("Title").Value;
                msgObj2.Description = msgDoc.Root.Element("Description").Value;
                msgObj2.Url = msgDoc.Root.Element("Url").Value;
            }
        }

    }
}
