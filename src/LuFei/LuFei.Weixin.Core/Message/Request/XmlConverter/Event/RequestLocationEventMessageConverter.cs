using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.Event;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 位置消息转换
    /// </summary>
    public class RequestLocationEventMessageConverter : RequestBaseEventMessageConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestLocationEventMessage;
            if (msgObj2 != null)
            {
                msgObj2.Latitude = msgDoc.Root.Element("Latitude").Value.ToDouble();
                msgObj2.Longitude = msgDoc.Root.Element("Longitude").Value.ToDouble();
                msgObj2.Precision = msgDoc.Root.Element("Precision").Value.ToDouble();
            }
        }

    }
}
