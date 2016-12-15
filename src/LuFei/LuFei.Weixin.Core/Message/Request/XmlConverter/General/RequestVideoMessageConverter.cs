using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 视频消息转换
    /// </summary>
    public class RequestVideoMessageConverter : RequestGeneralMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestVideoMessage;
            if (msgObj2 != null)
            {
                msgObj2.MediaId = msgDoc.Root.Element("MediaId").Value;
                msgObj2.ThumbMediaId = msgDoc.Root.Element("ThumbMediaId").Value;
            }
        }

    }
}
