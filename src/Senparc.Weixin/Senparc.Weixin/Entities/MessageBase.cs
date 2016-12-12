/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：MessageBase.cs
    文件功能描述：所有Request和Response消息的基类
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
    
    修改标识：Senparc - 20151205
    修改描述：v4.5.2 将MessageBase设为抽象类
----------------------------------------------------------------*/

using System;

namespace Senparc.Weixin.Entities
{
    /// <summary>
    /// 消息基类接口
    /// </summary>
    public interface IMessageBase : IEntityBase
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        string ToUserName { get; set; }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （最终输出为整型）
        /// </summary>
        DateTime CreateTime { get; set; }
    }

    /// <summary>
    /// （接收和回复）消息的基类
    /// </summary>
    /// <remarks>
    /// 所有Request（接收到的请求消息）和Response（将要发送的回复响应消息）的基类
    /// </remarks>
    public abstract class MessageBase : /*EntityBase, */IMessageBase
    {
        /// <summary>
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （最终输出为整型）
        /// </summary>
        public DateTime CreateTime { get; set; }

        public override string ToString()
        {
            //TODO:直接输出XML


            return base.ToString();
        }
    }
}
