using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 语音消息转换
    /// </summary>
    public class RequestVoiceMessageConverter : RequestGeneralMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestVoiceMessage;
            if (msgObj2 != null)
            {
                msgObj2.MediaId = msgDoc.Root.Element("MediaId").Value;
                msgObj2.Format = msgDoc.Root.Element("Format").Value;
                msgObj2.Recognition = msgDoc.Root.Element("Recognition").Value;
            }
        }

    }
}
