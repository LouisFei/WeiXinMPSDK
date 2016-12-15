using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 文本消息转换
    /// </summary>
    public class RequestTextMessageConverter : RequestGeneralMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestTextMessage;
            if (msgObj2 != null)
            {
                msgObj2.Content = msgDoc.Root.Element("Content").Value;
            }
        }

    }
}
