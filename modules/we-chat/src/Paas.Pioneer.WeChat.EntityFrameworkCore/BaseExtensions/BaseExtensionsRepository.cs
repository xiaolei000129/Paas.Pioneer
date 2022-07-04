using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.WeChat.EntityFrameworkCore.EntityFrameworkCore;
using Paas.Pioneer.WeChat.Domain.BaseExtensions;

namespace Paas.Pioneer.WeChat.EntityFrameworkCore.BaseExtensions
{
    public class BaseExtensionsRepository<TEntity> : EfCoreRepository<WeChatsDbContext, TEntity, Guid>, IBaseExtensionRepository<TEntity> where TEntity : Entity<Guid>, ISoftDelete
    {
        private readonly IDbContextProvider<WeChatsDbContext> _dbContextProvider;

        public BaseExtensionsRepository(IDbContextProvider<WeChatsDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<IQueryable<TEntity>> BuilderQueryable(bool isTracking)
        {
            var dbSet = await GetDbSetAsync();
            return isTracking ? dbSet : dbSet.AsNoTracking();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await BuilderQueryable(isTracking);

            if (expression != null)
            {
                dbSet = dbSet.Where(expression);
            }
            if (order != null)
            {
                dbSet = order(dbSet);
            }
            return await dbSet.FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await BuilderQueryable(isTracking);

            if (expression != null)
            {
                dbSet = dbSet.Where(expression);
            }
            if (order != null)
            {
                dbSet = order(dbSet);
            }
            return await dbSet.Select(selector).FirstOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, bool>> expression = null,
            Expression<Func<TEntity, TResult>> selector = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await BuilderQueryable(isTracking);

            if (expression != null)
            {
                dbSet = dbSet.Where(expression);
            }
            if (order != null)
            {
                dbSet = order(dbSet);
            }
            return await dbSet.Select(selector).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetResponseOutputListAsync(
            Expression<Func<TEntity, bool>> expression,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await BuilderQueryable(isTracking);

            if (expression != null)
            {
                dbSet = dbSet.Where(expression);
            }
            if (order != null)
            {
                dbSet = order(dbSet);
            }
            return await dbSet.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public async Task<List<TResult>> GetResponseOutputListAsync<TResult>(
            Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await BuilderQueryable(isTracking);

            if (expression != null)
            {
                dbSet = dbSet.Where(expression);
            }
            if (order != null)
            {
                dbSet = order(dbSet);
            }
            return await dbSet.Select(selector).ToListAsync(cancellationToken);
        }

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
        public async Task<Page<TResult>> GetResponseOutputListAsync<TResult, TPageInput>(
            Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await BuilderQueryable(isTracking);
            if (expression != null)
            {
                dbSet = dbSet.Where(expression);
            }
            if (order != null)
            {
                dbSet = order(dbSet);
            }
            return new Page<TResult>
            {
                Total = await dbSet.CountAsync(),
                List = await dbSet
                    .Select(selector)
                    .ToListAsync(cancellationToken)
            };
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<Page<TEntity>> GetResponseOutputPageListAsync<TPageInput>(
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order = null,
            PageInput<TPageInput> input = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = (await BuilderQueryable(isTracking))
             .WhereDynamicFilter(input.DynamicFilter);

            if (order != null)
            {
                query = order(query);
            }
            return new Page<TEntity>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .ToListAsync(cancellationToken)
            };
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<Page<TEntity>> GetResponseOutputPageListAsync<TPageInput>(
            Expression<Func<TEntity, bool>> expression,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order = null,
            PageInput<TPageInput> input = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = (await BuilderQueryable(isTracking))
             .WhereDynamicFilter(input.DynamicFilter);
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (order != null)
            {
                query = order(query);
            }
            return new Page<TEntity>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .ToListAsync(cancellationToken)
            };
        }

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
        public async Task<Page<TResult>> GetResponseOutputPageListAsync<TResult, TPageInput>(
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order = null,
            PageInput<TPageInput> input = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = (await BuilderQueryable(isTracking))
             .WhereDynamicFilter(input.DynamicFilter);

            if (order != null)
            {
                query = order(query);
            }
            return new Page<TResult>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .Select(selector)
                    .ToListAsync(cancellationToken)
            };
        }

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
        public async Task<Page<TResult>> GetResponseOutputPageListAsync<TResult, TPageInput>(
            Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order = null,
            PageInput<TPageInput> input = null,
            bool isTracking = false,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = (await BuilderQueryable(isTracking))
             .WhereDynamicFilter(input.DynamicFilter);
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (order != null)
            {
                query = order(query);
            }
            return new Page<TResult>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .Select(selector)
                    .ToListAsync(cancellationToken)
            };
        }

        /// <summary>
        /// 批量更新,忽略指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        public async Task BatchIgnoreUpdateAsync(IEnumerable<TEntity> entitys,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] ignorePropertys)
        {
            var tDbContext = await GetDbContextAsync();
            // 实体加入上下文
            var entityEntrys = tDbContext.Entry(entitys);
            // 设置跟踪状态
            entityEntrys.State = EntityState.Modified;
            // 只包含参与修改的字段
            foreach (var item in ignorePropertys)
            {
                entityEntrys.Property(item.GetMemberAccess().Name).IsModified = true;
            }
            await tDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 更新,忽略指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        public async Task IgnoreUpdateAsync(TEntity entity,
                        CancellationToken cancellationToken = default,
                        params Expression<Func<TEntity, object>>[] ignorePropertys)
        {
            var tDbContext = await _dbContextProvider.GetDbContextAsync();
            // 实体加入上下文
            var entityEntry = tDbContext.Entry(entity);
            // 设置跟踪状态
            entityEntry.State = EntityState.Modified;
            // 忽略不参与修改的字段
            foreach (var item in ignorePropertys)
            {
                entityEntry.Property(item).IsModified = false;
            }
            await tDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 批量更新,只包含指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        public async Task BatchIncludeUpdateAsync(IEnumerable<TEntity> entitys,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includePropertys)
        {
            var tDbContext = await _dbContextProvider.GetDbContextAsync();
            // 实体加入上下文
            var entityEntry = tDbContext.Entry(entitys);
            // 只包含参与修改的字段
            foreach (var item in includePropertys)
            {
                entityEntry.Property(item.GetMemberAccess().Name).IsModified = true;
            }
            await tDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 更新,只包含指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        public async Task IncludeUpdateAsync(TEntity entity,
                        CancellationToken cancellationToken = default,
                        params Expression<Func<TEntity, object>>[] includePropertys)
        {
            var tDbContext = await _dbContextProvider.GetDbContextAsync();
            // 实体进入上下文
            var entityEntry = tDbContext.Entry(entity);
            // 只包含参与修改的字段
            foreach (var item in includePropertys)
            {
                entityEntry.Property(item).IsModified = true;
            }
            await tDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.AnyAsync(expression, cancellationToken);
        }

        /// <summary>
        /// 真实删除
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> HardDeleteAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            var dbContext = await _dbContextProvider.GetDbContextAsync();
            var dbSet = await GetDbSetAsync();
            dbSet.RemoveRange(dbSet.Where(expression));
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
