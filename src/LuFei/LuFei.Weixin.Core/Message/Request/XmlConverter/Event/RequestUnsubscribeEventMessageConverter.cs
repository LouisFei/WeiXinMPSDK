using System.Xml.Linq;
using LuFei.Weixin.Core.Message.Request.Event;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 扫描带参数二维码事件消息转换
    /// </summary>
    public class RequestUnsubscribeEventMessageConverter : RequestBaseEventMessageConverter
    {
        public override void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            base.Parse(msgDoc, ref msgObj);

            
        }

    }
}
