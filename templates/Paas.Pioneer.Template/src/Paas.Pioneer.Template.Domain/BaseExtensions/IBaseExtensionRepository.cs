using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Paas.Pioneer.Template.Domain.BaseExtensions
{
    public interface IBaseExtensionRepository<TEntity> where TEntity : Entity<Guid>
    {
        /// <summary>
        /// 获取单个
        /// </summary>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <returns></returns>
        Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<List<TEntity>>> GetQueryableListAsync(
                    Expression<Func<TEntity, bool>> expression = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<List<TResult>>> GetQueryableListAsync<TResult>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <typeparam name="TResult">返回数据</typeparam>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="selector">返回表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<TResult>>> GetQueryableListAsync<TResult, TPageInput>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<TEntity>>> GetQueryablePageListAsync<TPageInput>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<TEntity>>> GetQueryablePageListAsync<TPageInput>(
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TResult">返回数据</typeparam>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="selector">返回表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<TResult>>> GetQueryablePageListAsync<TResult, TPageInput>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TResult">返回数据</typeparam>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="selector">返回表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<ResponseOutput<Page<TResult>>> GetQueryablePageListAsync<TResult, TPageInput>(
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false);

        /// <summary>
        /// 批量更新,忽略指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        Task BatchIgnoreUpdateAsync(IEnumerable<TEntity> entitys, params Expression<Func<TEntity, object>>[] ignorePropertys);

        /// <summary>
        /// 更新,忽略指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        Task IgnoreUpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] ignorePropertys);

        /// <summary>
        /// 批量更新,只包含指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        Task BatchIncludeUpdateAsync(IEnumerable<TEntity> entitys, params Expression<Func<TEntity, object>>[] includePropertys);

        /// <summary>
        /// 更新,只包含指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        Task IncludeUpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includePropertys);
    }
}
