using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Request.XmlConverter
{
    /// <summary>
    /// 请求消息基础转换器（从xml形式转到对象形式）
    /// </summary>
    public abstract class RequestMessageBaseConverter
    {
        /// <summary>
        /// 反序列化（从xml字符串转到消息实体对象）
        /// </summary>
        /// <param name="msgDoc">消息xml文档</param>
        /// <param name="msgObj">消息实体对象</param>
        public virtual void Parse(XDocument msgDoc, ref RequestBaseMessage msgObj)
        {
            msgObj.ToUserName = msgDoc.Root.Element("ToUserName").Value;
            msgObj.FromUserName = msgDoc.Root.Element("FromUserName").Value;
            msgObj.CreateTime = long.Parse(msgDoc.Root.Element("CreateTime").Value).ToDateTime();
            //msgObj.MsgType = msgDoc.Root.Element("MsgType").Value.ToEnum<RequestMsgType>().Value;
        }
    }
}
