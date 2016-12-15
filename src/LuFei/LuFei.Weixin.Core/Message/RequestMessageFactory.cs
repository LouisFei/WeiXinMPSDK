using LuFei.Weixin.Core.Message.Request;
using LuFei.Weixin.Core.Message.Request.Event;
using LuFei.Weixin.Core.Message.Request.XmlConverter;
using System;
using System.Xml.Linq;

namespace LuFei.Weixin.Core.Message
{
    /// <summary>
    /// 请求消息工厂
    /// 主要用于从xml消息创建得到消息实体对象
    /// </summary>
    public class RequestMessageFactory
    {
        private RequestMessageFactory() { }

        #region GetRequestMessageEntity
        /// <summary>
        /// 把接收到的消息由xml解析为具体的消息对象。
        /// 获取XDocument转换后的IRequestMessageBase实例。
        /// 如果MsgType不存在，抛出UnknownRequestMsgTypeException异常
        /// </summary>
        /// <param name="msgDoc"></param>
        /// <returns></returns>
        public static RequestBaseMessage GetRequestMessageEntity(XDocument msgDoc)
        {
            RequestBaseMessage reqMsg = null;
            RequestMsgType msgType;

            try
            {
                var msgTypeStr = msgDoc.Root.Element("MsgType").Value;
                msgType = msgTypeStr.ToEnum<RequestMsgType>().Value;

                #region 创建具体的消息实体
                switch (msgType)
                {
                    case RequestMsgType.Text:
                        reqMsg = new Request.General.RequestTextMessage();
                        break;
                    case RequestMsgType.Image:
                        reqMsg = new Request.General.RequestImageMessage();
                        break;
                    case RequestMsgType.Voice:
                        reqMsg = new Request.General.RequestVoiceMessage();
                        break;
                    case RequestMsgType.Video:
                        reqMsg = new Request.General.RequestVideoMessage();
                        break;
                    case RequestMsgType.ShortVideo:
                        reqMsg = new Request.General.RequestShortVideoMessage();
                        break;
                    case RequestMsgType.Location:
                        reqMsg = new Request.General.RequestLocationMessage();
                        break;
                    case RequestMsgType.Link:
                        reqMsg = new Request.General.RequestLinkMessage();
                        break;
                    case RequestMsgType.Event:
                        {
                            #region event message
                            var eventTypeStr = msgDoc.Root.Element("Event").Value;
                            RequestEventType eventType = eventTypeStr.ToEnum<RequestEventType>().Value;

                            switch (eventType)
                            {
                                case RequestEventType.subscribe:
                                    reqMsg = new Request.Event.RequestSubscribeEventMessage();
                                    break;
                                case RequestEventType.unsubscribe:
                                    reqMsg = new Request.Event.RequestUnsubscribeEventMessage();
                                    break;
                                case RequestEventType.SCAN:
                                    reqMsg = new Request.Event.RequestScanEventMessage();
                                    break;
                                case RequestEventType.LOCATION:
                                    reqMsg = new Request.Event.RequestLocationEventMessage();
                                    break;
                                case RequestEventType.CLICK:
                                    reqMsg = new Request.Event.RequestMenuClickEventMessage();
                                    break;
                                case RequestEventType.VIEW:
                                    reqMsg = new Request.Event.RequestMenuViewEventMessage();
                                    break;
                            }
                            #endregion

                            break;
                        }
                }
                #endregion

                //获得请求消息的转换器
                RequestMessageBaseConverter converter = GetRequestMessageConverter(reqMsg);
                converter.Parse(msgDoc, ref reqMsg);

                return reqMsg;
            }
            catch (Exception ex)
            {
                throw new Exception("消息解析失败", ex);
            }
        }
        #endregion

        #region GetRequestMessageConverter
        /// <summary>
        /// 获得请求消息的转换器
        /// 转换器用于解析xml字符串，转为相应的消息实体对象
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static RequestMessageBaseConverter GetRequestMessageConverter(RequestBaseMessage msg)
        {
            RequestMessageBaseConverter converter = null;

            #region 根据消息类型及事件类型，获得相应的消息转换器
            switch (msg.MsgType)
            {
                case RequestMsgType.Text:
                    converter = new RequestTextMessageConverter();
                    break;
                case RequestMsgType.Image:
                    converter = new RequestImageMessageConverter();
                    break;
                case RequestMsgType.Voice:
                    converter = new RequestVoiceMessageConverter();
                    break;
                case RequestMsgType.Video:
                    converter = new RequestVideoMessageConverter();
                    break;
                case RequestMsgType.ShortVideo:
                    converter = new RequestShortVideoMessageConverter();
                    break;
                case RequestMsgType.Location:
                    converter = new RequestLocationMessageConverter();
                    break;
                case RequestMsgType.Link:
                    converter = new RequestLinkMessageConverter();
                    break;
                case RequestMsgType.Event:
                    {
                        var eventMsg = msg as RequestBaseEventMessage;
                        switch (eventMsg.Event)
                        {
                            case RequestEventType.subscribe:
                                converter = new RequestSubscribeEventMessageConverter();
                                break;
                            case RequestEventType.unsubscribe:
                                converter = new RequestUnsubscribeEventMessageConverter();
                                break;
                            case RequestEventType.SCAN:
                                converter = new RequestScanEventMessageConverter();
                                break;
                            case RequestEventType.LOCATION:
                                converter = new RequestLocationEventMessageConverter();
                                break;
                            case RequestEventType.CLICK:
                                converter = new RequestMenuClickEventMessageConverter();
                                break;
                            case RequestEventType.VIEW:
                                converter = new RequestMenuViewEventMessageConverter();
                                break;
                        }
                        break;
                    }                    
            }
            #endregion

            return converter;
        }
        #endregion
    }
}
