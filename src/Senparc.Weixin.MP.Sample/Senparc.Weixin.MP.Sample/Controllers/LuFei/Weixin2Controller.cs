using System;
using System.IO;
using System.Web.Configuration;
using System.Web.Mvc;
using LuFei.Weixin.Core;

namespace Senparc.Weixin.MP.Sample.Controllers
{
    /// <summary>
    /// 用于被微信服务器请求，从而为微信公众号提供基础消息管理服务。
    /// </summary>
    public class Weixin2Controller : Controller
    {
        //与微信公众账号后台的Token设置保持一致，区分大小写。
        public static readonly string Token = WebConfigurationManager.AppSettings["WeixinToken"];
        //与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = WebConfigurationManager.AppSettings["WeixinEncodingAESKey"];
        //与微信公众账号后台的AppId设置保持一致，区分大小写。
        public static readonly string AppId = WebConfigurationManager.AppSettings["WeixinAppId"];

        readonly Func<string> _getRandomFileName = () => DateTime.Now.ToString("yyyyMMdd-HHmmss-") + Guid.NewGuid().ToString("n").Substring(0, 6);

        #region weixin server get
        /// <summary>
        /// 供微信服务器验证有效性
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(WeixinRequestModel req, string echostr)
        {
            #region ..
            /*
                https://mp.weixin.qq.com/wiki/8/f9a0b8382e0b77d87b3bcc1ce6fbc104.html
                第二步：验证服务器地址的有效性
                开发者提交信息后，微信服务器将发送GET请求到填写的服务器地址URL上，GET请求携带四个参数：
                signature	微信加密签名，signature结合了开发者填写的token参数和请求中的timestamp参数、nonce参数。
                timestamp	时间戳
                nonce	    随机数
                echostr	    随机字符串

                开发者通过检验signature对请求进行校验（下面有校验方式）。
                若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，成为开发者成功，否则接入失败。

                微信服务器会传入以下请求参数：
             	?signature=2ddf1f2d960f0c10866b4b1f852723b1caeaca92
                &echostr=1109242096751963051
                &timestamp=1481534379
                &nonce=595239645

                加密/校验流程如下：
                1. 将token、timestamp、nonce三个参数进行字典序排序
                2. 将三个参数字符串拼接成一个字符串进行sha1加密
                3. 开发者获得加密后的字符串可与signature对比，标识该请求来源于微信
             */
            #endregion

            if(LuFei.Weixin.Core.CheckSignature.Check(req.Signature, req.Timestamp, req.Nonce, Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" 
                    + req.Signature + "," 
                    + LuFei.Weixin.Core.CheckSignature.GetSignature(req.Timestamp, req.Nonce, Token) + "。" 
                    + "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");

            }
        }
        #endregion

        #region weixin server post
        /// <summary>
        /// 接收微信服务器的请求消息
        /// </summary>
        /// <remarks>
        /// 用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(WeixinRequestModel req)
        {
            #region 参数参考
            /*
                启用消息加密：QueryString
                signature=ffb84c9bf446cfaacd2007fd08b9c6eddec8fa00
                &timestamp=1481620164
                &nonce=1389909255
                &openid=oqEGWt6BkcPhth9UxiVp63i-BHWI
                &encrypt_type=aes
                &msg_signature=be64a47b968a16d37c26f533c777f70be8abf54c


                未启用消息加密：QueryString	
                signature=73f9d9b1dbed2e73186ba764631aa66e2e7ba7a6
                &timestamp=1481621758
                &nonce=412123049
                &openid=oqEGWt6BkcPhth9UxiVp63i-BHWI
            */
            #endregion

            if (!LuFei.Weixin.Core.CheckSignature.Check(req.Signature, req.Timestamp, req.Nonce, Token))
            {
                return Content("参数错误");
            }

            var logPath = Server.MapPath(string.Format("~/App_Data/MP/{0}/", DateTime.Now.ToString("yyyy-MM-dd")));
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            req.RequestBody = Request.InputStream;
            var wxCfg = new LuFei.Weixin.Core.WeixinConfig();
            wxCfg.Token = Token;
            wxCfg.AppID = AppId;
            wxCfg.AppSecret = "";
            wxCfg.EncodingAESKey = EncodingAESKey;

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new CustomWeixinMessageRequestHandler(req, wxCfg);

            try
            {
                #region log
                //测试时可开启此记录，帮助跟踪数据，使用前请确保App_Data文件夹存在，且有读写权限。
                messageHandler.RequestDocument.Save(Path.Combine(logPath, string.Format("{0}_Request_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName)));
                if (messageHandler.UsingEcryptMessage)
                {
                    messageHandler.EcryptRequestDocument.Save(Path.Combine(logPath, string.Format("{0}_Request_Ecrypt_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName)));
                }
                #endregion

                /* 如果需要添加消息去重功能，只需打开OmitRepeatedMessage功能，SDK会自动处理。
                 * 收到重复消息通常是因为微信服务器没有及时收到响应，会持续发送2-5条不等的相同内容的RequestMessage*/
                messageHandler.OmitRepeatedMessage = true;

                //执行微信处理过程
                messageHandler.Execute();

                #region log
                if (messageHandler.ResponseDocument != null)
                {
                    messageHandler.ResponseDocument.Save(Path.Combine(logPath, string.Format("{0}_Response_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName)));
                }

                if (messageHandler.UsingEcryptMessage)
                {
                    //记录加密后的响应信息
                    messageHandler.FinalResponseDocument.Save(Path.Combine(logPath, string.Format("{0}_Response_Final_{1}.txt", _getRandomFileName(), messageHandler.RequestMessage.FromUserName)));
                }
                #endregion

                var output = messageHandler.FinalResponseDocument.ToString();
                return Content(output, "text/xml", System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                #region log error
                using (TextWriter tw = new StreamWriter(Server.MapPath("~/App_Data/Error_" + _getRandomFileName() + ".txt")))
                {
                    tw.WriteLine("ExecptionMessage:" + ex.Message);
                    tw.WriteLine(ex.Source);
                    tw.WriteLine(ex.StackTrace);
                    //tw.WriteLine("InnerExecptionMessage:" + ex.InnerException.Message);

                    if (messageHandler.ResponseDocument != null)
                    {
                        tw.WriteLine(messageHandler.ResponseDocument.ToString());
                    }

                    if (ex.InnerException != null)
                    {
                        tw.WriteLine("========= InnerException =========");
                        tw.WriteLine(ex.InnerException.Message);
                        tw.WriteLine(ex.InnerException.Source);
                        tw.WriteLine(ex.InnerException.StackTrace);
                    }

                    tw.Flush();
                    tw.Close();
                }
                #endregion

                return Content("");
            }
        }
        #endregion
    }
}