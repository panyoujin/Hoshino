using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hoshino.Entity
{
    /// <summary>
    /// Video 位置
    /// </summary>
    public enum Video_Location
    {
        /// <summary>
        /// 首页
        /// </summary>
        [Description("首页")]
        Index = 0
    }
    /// <summary>
    /// Banner 位置
    /// </summary>
    public enum Banner_Location
    {
        /// <summary>
        /// 首页
        /// </summary>
        [Description("首页")]
        Index = 0
    }
    /// <summary>
    /// 表状态
    /// </summary>
    public enum Table_Status
    {
        /// <summary>
        /// 无效
        /// </summary>
        [Description("无效")]
        Invalid = 0,
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Effective = 1
    }

    /// <summary>
    /// 预约询价处理状态
    /// </summary>
    public enum AC_Status
    {
        /// <summary>
        /// 未处理
        /// </summary>
        [Description("未处理")]
        Invalid = 0,
        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        Effective = 1
    }
    /// <summary>
    /// 联系我们处理状态
    /// </summary>
    public enum Contact_Status
    {
        /// <summary>
        /// 未处理
        /// </summary>
        [Description("未处理")]
        Invalid = 0,
        /// <summary>
        /// 已处理
        /// </summary>
        [Description("已处理")]
        Effective = 1
    }

    public enum Lang
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All = 0,
        /// <summary>
        /// 简体中文
        /// </summary>
        [Description("简体中文")]
        CHS = 1,
        /// <summary>
        /// 繁体中文
        /// </summary>
        [Description("繁体中文")]
        CHT = 2
    }

}
