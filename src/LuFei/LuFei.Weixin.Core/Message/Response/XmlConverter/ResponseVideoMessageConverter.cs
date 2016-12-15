using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Response.XmlConverter
{
    public  class ResponseVideoMessageConverter : ResponseBaseMessageConverter
    {
        public override void Parse(ResponseBaseMessage msgObj, ref XDocument msgDoc)
        {
            base.Parse(msgObj, ref msgDoc);

            var msgObj2 = msgObj as ResponseVideoMessage;
            if (msgObj2 != null)
            {
                //msgDoc.Root.Add();
                var el = new XElement("Video");
                el.Add(new XElement("MediaId", new XCData(msgObj2.Video.MediaId)));
                el.Add(new XElement("Title", new XCData(msgObj2.Video.Title)));
                el.Add(new XElement("Description", new XCData(msgObj2.Video.Description)));
                msgDoc.Root.Add(el);
            }
        }
    }
}
