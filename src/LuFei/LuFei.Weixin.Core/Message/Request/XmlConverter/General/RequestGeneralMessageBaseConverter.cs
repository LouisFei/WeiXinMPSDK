using LuFei.Weixin.Core.Message.Request.General;
using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 普通请求消息基础转换器（从xml形式转到对象形式）
    /// </summary>
    public abstract class RequestGeneralMessageBaseConverter : RequestMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            var msgObj2 = msgObj as RequestBaseGeneralMessage;
            if (msgObj2 != null)
            {
                msgObj2.MsgId = msgDoc.Root.Element("MsgId").Value.ToLong();
            }
        }
    }
}
