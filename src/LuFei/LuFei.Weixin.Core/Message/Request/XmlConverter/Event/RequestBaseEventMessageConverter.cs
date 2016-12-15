using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;
using LuFei.Weixin.Core.Message.Request.Event;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 位置消息转换
    /// </summary>
    public class RequestBaseEventMessageConverter : RequestMessageBaseConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            //var msgObj2 = msgObj as RequestLocationEventMessage;
            //if (msgObj2 != null)
            //{
            //    //msgObj2.Content = msgDoc.Root.Element("Content").Value;
            //}
        }

    }
}
