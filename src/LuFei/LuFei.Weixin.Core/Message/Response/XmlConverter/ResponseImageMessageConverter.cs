using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Response.XmlConverter
{
    public  class ResponseImageMessageConverter : ResponseBaseMessageConverter
    {
        public override void Parse(ResponseBaseMessage msgObj, ref XDocument msgDoc)
        {
            base.Parse(msgObj, ref msgDoc);

            var msgObj2 = msgObj as ResponseImageMessage;
            if (msgObj2 != null)
            {
                //msgDoc.Root.Add();
                var imgElement = new XElement("Image");
                imgElement.Add(new XElement("MediaId", new XCData(msgObj2.Image.MediaId)));
                msgDoc.Root.Add(imgElement);
            }
        }
    }
}
