using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Response.XmlConverter
{
    public  class ResponseNewsMessageConverter : ResponseBaseMessageConverter
    {
        public override void Parse(ResponseBaseMessage msgObj, ref XDocument msgDoc)
        {
            base.Parse(msgObj, ref msgDoc);

            var msgObj2 = msgObj as ResponseNewsMessage;
            if (msgObj2 != null)
            {
                msgDoc.Root.Add(new XElement("ArticleCount", new XCData(msgObj2.ArticleCount.ToString())));

                var el = new XElement("Articles");
                foreach (var item in msgObj2.Articles)
                {
                    var eItem = new XElement("item");
                    eItem.Add(new XElement("Title", new XCData(item.Title)));
                    eItem.Add(new XElement("Description", new XCData(item.Description)));
                    eItem.Add(new XElement("PicUrl", new XCData(item.PicUrl)));
                    eItem.Add(new XElement("Url", new XCData(item.Url)));
                    el.Add(eItem);
                }

                msgDoc.Root.Add(el);
            }
        }
    }
}
