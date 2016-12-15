using System;
using System.Xml.Linq;
using Tencent;
using LuFei.Weixin.Core.Message;
using LuFei.Weixin.Core.Message.Request;
using LuFei.Weixin.Core.Message.Request.General;
using LuFei.Weixin.Core.Message.Response;
using LuFei.Weixin.Core.Message.Request.Event;
using LuFei.Weixin.Core.Message.Response.XmlConverter;

namespace LuFei.Weixin.Core
{
    /// <summary>
    /// 请求消息处理类（抽象基类提供基础的方法支持，个性的方法由子类自行实现）
    /// </summary>
    public abstract partial class RequestMessageHandler
    {
        /// <summary>
        /// 微信公众号配置
        /// </summary>
        public WeixinConfig WxConfig { get; private set; }

        /// <summary>
        /// 是否使用了加密信息
        /// </summary>
        public bool UsingEcryptMessage { get; private set; }

        /// <summary>
        /// 是否使用了兼容模式加密信息
        /// </summary>
        public bool UsingCompatibilityModelEcryptMessage { get; set; }

        /// <summary>
        /// 原始的加密请求（如果不加密则为null）
        /// </summary>
        public XDocument EcryptRequestDocument { get; private set; }

        /// <summary>
        /// 接收到的微信请求消息解析后的对象形式
        /// </summary>
        public RequestBaseMessage RequestMessage { get; private set; }

        /// <summary>
        /// 请求消息的XML数据形式，明文，（如果之前是加密的则会被解密）
        /// </summary>
        public XDocument RequestDocument { get; private set; }

        /// <summary>
        /// 取消执行Execute()方法。一般在OnExecuting()中用于临时阻止执行Execute()。
        /// 默认为False。
        /// 如果在执行OnExecuting()执行前设为True，则所有OnExecuting()、Execute()、OnExecuted()代码都不会被执行。
        /// 如果在执行OnExecuting()执行过程中设为True，则后续Execute()及OnExecuted()代码不会被执行。
        /// 建议在设为True的时候，给ResponseMessage赋值，以返回友好信息。
        /// </summary>
        public bool CancelExcute { get; set; }

        public RequestMessageHandler()
        {
            ResponseDocument = null;
        }

        /// <summary>
        /// 构造请求消息处理对象
        /// </summary>
        /// <param name="msgRequest">请求主体数据（流对象形式）</param>
        /// <param name="requestParam">请求附带的参数</param>
        public RequestMessageHandler(WeixinRequestModel wxreq, WeixinConfig wxCfg) : this()
        {
            WxConfig = wxCfg;

            //原始请求（xml对象形式）
            XDocument originRequestXmlDoc = wxreq.RequestBodyXmlDoc;

            #region 收到的消息参考
            /*
                消息明文：
                <xml>
                  <ToUserName><![CDATA[gh_38640ec5f978]]></ToUserName>
                  <FromUserName><![CDATA[oqEGWt6BkcPhth9UxiVp63i-BHWI]]></FromUserName>
                  <CreateTime>1481533696</CreateTime>
                  <MsgType><![CDATA[text]]></MsgType>
                  <Content><![CDATA[1]]></Content>
                  <MsgId>6363138772725811838</MsgId>
                </xml>

                消息密文：
                <xml>
                    <ToUserName><![CDATA[gh_38640ec5f978]]></ToUserName>
                    <Encrypt><![CDATA[QXwaewatXgxDm7pVWdxuaBK3oennqb+IoSInlmonL1j/JedhQa48jpgcHSVPqWoEzWE++6965P/wTecjkET4q6/rqolnKLkJMIjA7N7fAni3oaUc4Jc/+uHUoOqpeUvBQ8WLqt8Pkby/d85Ua9JuHP2rUYl+MvHdPHM3I3iLDs4wJpjJaQwbojD3ke3ZVU66iVjF6z/nrEfc4xeYZ6HKQndkv6upQMnVNjbIpaBwkOuyOa5p0vM5TMLfcz+zkd3WqSMztGef7U/e7d2sklccqDtaY218bWSdgSl5gmx1Rrpq7brEmkNtiMl0oxj1j5brqUln2nZvxsAtBhlhtB1zKr9kjqng/5c4ZiB9hw0HfiNOXqwtsVa08/cSHvgvc1P5EFK+Ta4zrvReVI4rY/MnbvTrzs+ILGlqwEA1yeuVb8w=]]></Encrypt>
                </xml>
             */
            #endregion

            //消息明文
            XDocument unencryptedXmlDoc = originRequestXmlDoc;

            #region 进行加密判断并处理
            if (originRequestXmlDoc != null
                && originRequestXmlDoc.Root.Element("Encrypt") != null
                && !string.IsNullOrEmpty(originRequestXmlDoc.Root.Element("Encrypt").Value))
            {
                UsingEcryptMessage = true;
                EcryptRequestDocument = originRequestXmlDoc;

                //解密（解密算法来之微信官方提供的代码）
                WXBizMsgCrypt msgCrype = new WXBizMsgCrypt(wxCfg.Token, wxCfg.EncodingAESKey, wxCfg.AppID);
                string msgXmlString = null;
                var result = msgCrype.DecryptMsg(wxreq.msg_signature, wxreq.Timestamp, wxreq.Nonce, originRequestXmlDoc.ToString(), ref msgXmlString);

                //判断解密结果
                if (result != 0)
                {
                    //验证没有通过，取消执行
                    CancelExcute = true;
                    return;
                }

                if (originRequestXmlDoc.Root.Element("FromUserName") != null
                    && !string.IsNullOrEmpty(originRequestXmlDoc.Root.Element("FromUserName").Value))
                {
                    //TODO：使用了兼容模式，进行验证即可
                    UsingCompatibilityModelEcryptMessage = true;
                }

                //解密后得到明文
                unencryptedXmlDoc = XDocument.Parse(msgXmlString);
            }
            #endregion

            //由xml解析得到请求消息实体对象
            RequestMessage = RequestMessageFactory.GetRequestMessageEntity(unencryptedXmlDoc);

            if (UsingEcryptMessage)
            {
                //原始消息密文
                RequestMessage.Encrypt = originRequestXmlDoc.Root.Element("Encrypt").Value;
            }

            RequestDocument = unencryptedXmlDoc;
        }

        public bool OmitRepeatedMessage { get; set; }

        /// <summary>
        /// 执行微信请求，创建相应的回复响应消息
        /// </summary>
        public void Execute()
        {
            if (CancelExcute)
            {
                return;
            }

            OnExecuting();

            if (CancelExcute)
            {
                return;
            }

            try
            {
                if (RequestMessage == null)
                {
                    return;
                }

                #region 请求消息分发处理，得到回复消息实体
                switch (RequestMessage.MsgType)
                {
                    case RequestMsgType.Text:
                        ResponseMessage = OnTextRequest(RequestMessage as RequestTextMessage);
                        break;
                    case RequestMsgType.Image:
                        ResponseMessage = OnImageRequest(RequestMessage as RequestImageMessage);
                        break;
                    case RequestMsgType.Voice:
                        ResponseMessage = OnVoiceRequest(RequestMessage as RequestVoiceMessage);
                        break;
                    case RequestMsgType.Video:
                        ResponseMessage = OnVideoRequest(RequestMessage as RequestVideoMessage);
                        break;
                    case RequestMsgType.ShortVideo:
                        ResponseMessage = OnShortVideoRequest(RequestMessage as RequestShortVideoMessage);
                        break;
                    case RequestMsgType.Location:
                        ResponseMessage = OnLocationRequest(RequestMessage as RequestLocationMessage);
                        break;
                    case RequestMsgType.Link:
                        ResponseMessage = OnTextRequest(RequestMessage as RequestTextMessage);
                        break;
                    case RequestMsgType.Event:
                        ResponseMessage = OnEventRequest(RequestMessage as RequestBaseEventMessage);
                        break;
                    default:
                        ResponseMessage = DefaultResponseMessage(RequestMessage);
                        break;
                }
                #endregion

                ResponseMessage.ToUserName = RequestMessage.FromUserName;
                ResponseMessage.FromUserName = RequestMessage.ToUserName;
                ResponseMessage.CreateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception("根据微信请求消息创建回复消息过程中报错：", ex);
            }
            finally
            {
                OnExecuted();
            }
        }

        /// <summary>
        /// 解析完微信请求消息，准备生成回复消息
        /// </summary>
        public virtual void OnExecuting()
        {
        }

        /// <summary>
        /// 回复消息生成完成
        /// </summary>
        public virtual void OnExecuted()
        {
        }

        /// <summary>
        /// 回复消息实体
        /// </summary>
        /// <remarks>
        /// 正常情况下只有当执行Execute()方法后才可能有值。
        /// 也可以结合Cancel，提前给ResponseMessage赋值。
        /// </remarks>
        public ResponseBaseMessage ResponseMessage { get; private set; }

        private XDocument _responseDocument = null;
        /// <summary>
        /// 回复消息实体（xml文档形式）
        /// </summary>
        public XDocument ResponseDocument
        {
            get
            {
                if (_responseDocument == null)
                {
                    _responseDocument = new XDocument();
                    _responseDocument.Add(new XElement("xml"));

                    ResponseBaseMessageConverter converter = null;

                    #region 根据消息类型，得到相应的序列化处理器
                    switch (ResponseMessage.MsgType)
                    {
                        case ResponseMessageType.text:
                            converter = new ResponseTextMessageConverter();
                            break;
                        case ResponseMessageType.image:
                            converter = new ResponseImageMessageConverter();
                            break;
                        case ResponseMessageType.voice:
                            converter = new ResponseVoiceMessageConverter();
                            break;
                        case ResponseMessageType.video:
                            converter = new ResponseVideoMessageConverter();
                            break;
                        case ResponseMessageType.music:
                            converter = new ResponseMusicMessageConverter();
                            break;
                        case ResponseMessageType.news:
                            converter = new ResponseNewsMessageConverter();
                            break;
                        default:
                            break;
                    }
                    #endregion

                    converter.Parse(ResponseMessage, ref _responseDocument);
                }

                return _responseDocument;
            }
            private set
            {
                _responseDocument = value;
            }
        }

        /// <summary>
        /// 最终回复消息实体（xml文档形式，在ResponseDocment基础上根据设置进行选择性加密）
        /// </summary>
        public XDocument FinalResponseDocument
        {
            get
            {
                if (ResponseDocument == null)
                {
                    return null;
                }

                if (!UsingEcryptMessage)
                {
                    return ResponseDocument;
                }

                var timeStamp = DateTime.Now.Ticks.ToString();
                var nonce = DateTime.Now.Ticks.ToString();

                WXBizMsgCrypt msgCrype = new WXBizMsgCrypt(WxConfig.Token, WxConfig.EncodingAESKey, WxConfig.AppID);
                string finalResponseXml = null;
                msgCrype.EncryptMsg(ResponseDocument.ToString().Replace("\r\n", "\n")/* 替换\r\n是为了处理iphone设备上换行bug */, 
                    timeStamp, 
                    nonce, 
                    ref finalResponseXml);//TODO:这里官方的方法已经把EncryptResponseMessage对应的XML输出出来了

                return XDocument.Parse(finalResponseXml);
            }
        }

    }
}
