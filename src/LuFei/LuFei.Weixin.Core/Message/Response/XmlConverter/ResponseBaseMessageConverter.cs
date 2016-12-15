using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message.Response.XmlConverter
{
    public abstract class ResponseBaseMessageConverter
    {
        /// <summary>
        /// 序列化（把消息实体对象转到xml字符串）
        /// </summary>
        /// <param name="msgObj">消息实体对象</param>
        /// <param name="msgDoc">消息xml文档</param>
        public virtual void Parse(ResponseBaseMessage msgObj, ref XDocument msgDoc)
        {
            msgDoc.Root.Add(new XElement("ToUserName", new XCData(msgObj.ToUserName)));
            msgDoc.Root.Add(new XElement("FromUserName", new XCData(msgObj.FromUserName)));
            msgDoc.Root.Add(new XElement("CreateTime", new XCData(msgObj.CreateTime.ToUnixTimestamp().ToString())));
            msgDoc.Root.Add(new XElement("MsgType", new XCData(msgObj.MsgType.ToString())));
        }
    }
}
