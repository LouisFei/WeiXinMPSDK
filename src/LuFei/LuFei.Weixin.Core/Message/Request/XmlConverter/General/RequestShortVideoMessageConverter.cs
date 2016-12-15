using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.General;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 小视频消息转换
    /// </summary>
    public class RequestShortVideoMessageConverter : RequestVideoMessageConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            //var msgObj2 = msgObj as RequestShortVideoMessage;
            //if (msgObj2 != null)
            //{
            //}
        }

    }
}
