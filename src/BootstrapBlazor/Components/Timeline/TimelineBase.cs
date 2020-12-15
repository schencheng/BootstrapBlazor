﻿// **********************************
// 框架名称：BootstrapBlazor 
// 框架作者：Argo Zhang
// 开源地址：
// Gitee : https://gitee.com/LongbowEnterprise/BootstrapBlazor
// GitHub: https://github.com/ArgoZhang/BootstrapBlazor 
// 开源协议：Apache-2.0 (https://gitee.com/LongbowEnterprise/BootstrapBlazor/blob/dev/LICENSE)
// **********************************

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components
{
    /// <summary>
    /// 时间线组件基类
    /// </summary>
    public abstract class TimelineBase : BootstrapComponentBase
    {
        /// <summary>
        /// 获得 Timeline 样式
        /// </summary>
        protected string? ClassString => CssBuilder.Default("timeline")
            .AddClass("is-alternate", IsAlternate && !IsLeft)
            .AddClass("is-left", IsLeft)
            .AddClassFromAttributes(AdditionalAttributes)
            .Build();

        /// <summary>
        /// 获得/设置 绑定数据集
        /// </summary>
        [Parameter]
        [NotNull]
        public IEnumerable<TimelineItem>? Items { get; set; }

        /// <summary>
        /// 获得/设置 是否反转
        /// </summary>
        [Parameter]
        public bool IsReverse { get; set; }

        /// <summary>
        /// 获得/设置 是否左右交替出现 默认 false
        /// </summary>
        [Parameter]
        public bool IsAlternate { get; set; }

        /// <summary>
        /// 获得/设置 内容是否出现在时间线左侧 默认为 false
        /// </summary>
        [Parameter]
        public bool IsLeft { get; set; }

        /// <summary>
        /// OnInitializedAsync 方法
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (Items == null)
            {
                Items = Enumerable.Empty<TimelineItem>();
            }
        }

        /// <summary>
        /// OnParametersSet 方法
        /// </summary>
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (IsReverse)
            {
                var arr = Items.Reverse();
                Items = arr;
            }
        }
    }
}
