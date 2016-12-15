using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Response.XmlConverter
{
    public  class ResponseMusicMessageConverter : ResponseBaseMessageConverter
    {
        public override void Parse(ResponseBaseMessage msgObj, ref XDocument msgDoc)
        {
            base.Parse(msgObj, ref msgDoc);

            var msgObj2 = msgObj as ResponseMusicMessage;
            if (msgObj2 != null)
            {
                //msgDoc.Root.Add();
                var el = new XElement("Music");
                el.Add(new XElement("Title", new XCData(msgObj2.Music.Title)));
                el.Add(new XElement("Description", new XCData(msgObj2.Music.Description)));
                el.Add(new XElement("MusicUrl", new XCData(msgObj2.Music.MusicUrl)));
                el.Add(new XElement("HQMusicUrl", new XCData(msgObj2.Music.HQMusicUrl)));
                el.Add(new XElement("ThumbMediaId", new XCData(msgObj2.Music.ThumbMediaId)));
                msgDoc.Root.Add(el);
            }
        }
    }
}
