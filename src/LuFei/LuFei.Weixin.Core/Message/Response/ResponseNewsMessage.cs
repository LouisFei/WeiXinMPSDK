using System.Collections.Generic;

namespace LuFei.Weixin.Core.Message.Response
{
    /// <summary>
    /// 回复图文消息
    /// </summary>
    public class ResponseNewsMessage : ResponseBaseMessage
    {
        public override ResponseMessageType MsgType
        {
            get { return ResponseMessageType.news; }
        }

        /// <summary>
        /// 图文消息个数，限制为10条以内
        /// </summary>
        public int ArticleCount
        {
            get
            {
                return Articles == null ? 0 : Articles.Count;
            }
            set
            {
                //这里开放set只为了逆向从Response的Xml转成实体的操作一致性，没有实际意义。
            }
        }

        public List<Article> Articles { get; set; }

        public ResponseNewsMessage()
        {
            //初始化容器
            Articles = new List<Article>();
        }

    }
}
/*
<xml>
    <ToUserName><![CDATA[toUser]]></ToUserName>
    <FromUserName><![CDATA[fromUser]]></FromUserName>
    <CreateTime>12345678</CreateTime>
    <MsgType><![CDATA[news]]></MsgType>
    <ArticleCount>2</ArticleCount>
    <Articles>
        <item>
            <Title><![CDATA[title1]]></Title> 
            <Description><![CDATA[description1]]></Description>
            <PicUrl><![CDATA[picurl]]></PicUrl>
            <Url><![CDATA[url]]></Url>
        </item>
        <item>
            <Title><![CDATA[title]]></Title>
            <Description><![CDATA[description]]></Description>
            <PicUrl><![CDATA[picurl]]></PicUrl>
            <Url><![CDATA[url]]></Url>
        </item>
    </Articles>
</xml> 
*/
