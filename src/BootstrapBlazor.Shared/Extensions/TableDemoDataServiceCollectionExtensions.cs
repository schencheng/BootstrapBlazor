﻿// **********************************
// 框架名称：BootstrapBlazor 
// 框架作者：Argo Zhang
// 开源地址：
// Gitee : https://gitee.com/LongbowEnterprise/BootstrapBlazor
// GitHub: https://github.com/ArgoZhang/BootstrapBlazor 
// 开源协议：Apache-2.0 (https://gitee.com/LongbowEnterprise/BootstrapBlazor/blob/dev/LICENSE)
// **********************************

using BootstrapBlazor.Components;
using BootstrapBlazor.Shared.Pages;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// BootstrapBlazor 服务扩展类
    /// </summary>
    public static class TableDemoDataServiceCollectionExtensions
    {
        /// <summary>
        /// 增加 PetaPoco 数据库操作服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTableDemoDataService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IDataService<>), typeof(TableDemoDataService<>));
            return services;
        }
    }

    /// <summary>
    /// 演示网站示例数据注入服务实现类
    /// </summary>
    internal class TableDemoDataService<TModel> : DataServiceBase<TModel> where TModel : class, new()
    {
        /// <summary>
        /// 查询操作方法
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Task<QueryData<TModel>> QueryAsync(QueryPageOptions options)
        {
            // 此处代码实战中不可用，仅仅为演示而写

            var items = TablesBase.GenerateItems().Cast<TModel>();

            var total = items.Count();

            // 内存分页
            items = items.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList();

            return Task.FromResult(new QueryData<TModel>()
            {
                Items = items,
                TotalCount = total
            });
        }
    }
}
