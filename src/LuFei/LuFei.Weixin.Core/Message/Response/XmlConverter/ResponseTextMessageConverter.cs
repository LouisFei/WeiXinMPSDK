using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Response.XmlConverter
{
    public class ResponseTextMessageConverter : ResponseBaseMessageConverter
    {
        public override void Parse(ResponseBaseMessage msgObj, ref XDocument msgDoc)
        {
            base.Parse(msgObj, ref msgDoc);

            var msgObj2 = msgObj as ResponseTextMessage;
            if (msgObj2 != null)
            {
                msgDoc.Root.Add(new XElement("Content", new XCData(msgObj2.Content)));
            }
        }
    }
}
