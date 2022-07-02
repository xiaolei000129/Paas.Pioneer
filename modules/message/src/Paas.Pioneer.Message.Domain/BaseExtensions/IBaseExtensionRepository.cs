using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Paas.Pioneer.Domain.Shared.Dto.Output;

namespace Paas.Pioneer.Message.Domain.BaseExtensions
{
    public interface IBaseExtensionRepository<TEntity> where TEntity : Entity<Guid>, ISoftDelete
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 真实删除
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> HardDeleteAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <returns></returns>
        Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<IEnumerable<TResult>> GetListAsync<TResult>(
                    Expression<Func<TEntity, bool>> expression,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<List<TEntity>> GetResponseOutputListAsync(
                    Expression<Func<TEntity, bool>> expression = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<List<TResult>> GetResponseOutputListAsync<TResult>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

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
        Task<Page<TResult>> GetResponseOutputListAsync<TResult, TPageInput>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<Page<TEntity>> GetResponseOutputPageListAsync<TPageInput>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        Task<Page<TEntity>> GetResponseOutputPageListAsync<TPageInput>(
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

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
        Task<Page<TResult>> GetResponseOutputPageListAsync<TResult, TPageInput>(
                    Expression<Func<TEntity, bool>> expression = default,
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

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
        Task<Page<TResult>> GetResponseOutputPageListAsync<TResult, TPageInput>(
                    Expression<Func<TEntity, TResult>> selector = default,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = default,
                    PageInput<TPageInput> input = default,
                    bool isTracking = false,
                    CancellationToken cancellationToken = default);

        /// <summary>
        /// 批量更新,忽略指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        Task BatchIgnoreUpdateAsync(IEnumerable<TEntity> entitys,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] ignorePropertys);

        /// <summary>
        /// 更新,忽略指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        Task IgnoreUpdateAsync(TEntity entity,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] ignorePropertys);

        /// <summary>
        /// 批量更新,只包含指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        Task BatchIncludeUpdateAsync(IEnumerable<TEntity> entitys,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includePropertys);

        /// <summary>
        /// 更新,只包含指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        Task IncludeUpdateAsync(TEntity entity,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includePropertys);
    }
}
