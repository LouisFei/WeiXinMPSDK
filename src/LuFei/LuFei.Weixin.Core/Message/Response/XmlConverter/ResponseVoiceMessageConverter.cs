using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Response.XmlConverter
{
    public  class ResponseVoiceMessageConverter : ResponseBaseMessageConverter
    {
        public override void Parse(ResponseBaseMessage msgObj, ref XDocument msgDoc)
        {
            base.Parse(msgObj, ref msgDoc);

            var msgObj2 = msgObj as ResponseVoiceMessage;
            if (msgObj2 != null)
            {
                //msgDoc.Root.Add();
                var el = new XElement("Voice");
                el.Add(new XElement("MediaId", new XCData(msgObj2.Voice.MediaId)));
                msgDoc.Root.Add(el);
            }
        }
    }
}
