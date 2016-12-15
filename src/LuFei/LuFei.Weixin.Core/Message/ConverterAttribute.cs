using System;

namespace LuFei.Weixin.Core.Message
{
    /// <summary>
    /// 转换器属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [Obsolete("暂时未使用")]
    public class ConverterAttribute : Attribute
    {
        /// <summary>
        /// 转换器类型
        /// </summary>
        public Type ConverterType { get; private set; }

        public ConverterAttribute(Type converterType)
        {
            ConverterType = converterType;
        }
    }
}
