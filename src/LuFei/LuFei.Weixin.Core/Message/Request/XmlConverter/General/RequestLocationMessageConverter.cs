using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 位置消息转换
    /// </summary>
    public class RequestLocationMessageConverter : RequestGeneralMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestLocationMessage;
            if (msgObj2 != null)
            {
                msgObj2.Location_X = msgDoc.Root.Element("Location_X").Value.ToDouble();
                msgObj2.Location_Y = msgDoc.Root.Element("Location_Y").Value.ToDouble();
                msgObj2.Scale = msgDoc.Root.Element("Scale").Value.ToInt();
                msgObj2.Label = msgDoc.Root.Element("Label").Value;
            }
        }

    }
}
