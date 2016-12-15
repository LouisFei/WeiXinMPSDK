using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 图片消息转换
    /// </summary>
    public class RequestImageMessageConverter : RequestGeneralMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestImageMessage;
            if (msgObj2 != null)
            {
                msgObj2.PicUrl = msgDoc.Root.Element("PicUrl").Value;
                msgObj2.MediaId = msgDoc.Root.Element("MediaId").Value;
            }
        }

    }
}
