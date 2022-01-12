using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Paas.Pioneer.Domain.Shared.Dto.Input;
using Paas.Pioneer.Domain.Shared.Dto.Output;
using Paas.Pioneer.Domain.Shared.Extensions;
using Paas.Pioneer.Template.Domain.BaseExtensions;
using Paas.Pioneer.Template.EntityFrameworkCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Paas.Pioneer.Template.EntityFrameworkCore.BaseExtensions
{
    public class BaseExtensionsRepository<TEntity> : EfCoreRepository<TemplatesDbContext, TEntity, Guid>, IBaseExtensionRepository<TEntity> where TEntity : Entity<Guid>
    {
        private readonly IDbContextProvider<TemplatesDbContext> _dbContextProvider;

        public BaseExtensionsRepository(IDbContextProvider<TemplatesDbContext> dbContextProvider)
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
            IOrderedQueryable<TEntity>> order,
            bool isTracking = false)
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
            return await dbSet.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order,
            bool isTracking = false)
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
            return await dbSet.Select(selector).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public async Task<ResponseOutput<List<TEntity>>> GetQueryableListAsync(
            Expression<Func<TEntity, bool>> expression,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order,
            bool isTracking = false)
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
            return ResponseOutput.Succees(await dbSet.ToListAsync());
        }

        /// <summary>
        /// 获取列表数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public async Task<ResponseOutput<List<TResult>>> GetQueryableListAsync<TResult>(
            Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order,
            bool isTracking = false)
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
            return ResponseOutput.Succees(await dbSet.Select(selector).ToListAsync());
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
        public async Task<ResponseOutput<Page<TResult>>> GetQueryableListAsync<TResult, TPageInput>(
            Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order,
            bool isTracking = false)
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
            return ResponseOutput.Succees(new Page<TResult>
            {
                Total = await dbSet.CountAsync(),
                List = await dbSet
                    .Select(selector)
                    .ToListAsync()
            });
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<TEntity>>> GetQueryablePageListAsync<TPageInput>(
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order,
            PageInput<TPageInput> input,
            bool isTracking = false)
        {
            IQueryable<TEntity> query = (await BuilderQueryable(isTracking))
             .WhereDynamicFilter(input.DynamicFilter);

            if (order != null)
            {
                query = order(query);
            }
            return ResponseOutput.Succees(new Page<TEntity>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .ToListAsync()
            });
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="TPageInput">分页入参</typeparam>
        /// <param name="expression">表达式</param>
        /// <param name="order">排序</param>
        /// <param name="input">入参</param>
        /// <returns></returns>
        public async Task<ResponseOutput<Page<TEntity>>> GetQueryablePageListAsync<TPageInput>(
            Expression<Func<TEntity, bool>> expression,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order,
            PageInput<TPageInput> input,
            bool isTracking = false)
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
            return ResponseOutput.Succees(new Page<TEntity>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .ToListAsync()
            });
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
        public async Task<ResponseOutput<Page<TResult>>> GetQueryablePageListAsync<TResult, TPageInput>(
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order,
            PageInput<TPageInput> input,
            bool isTracking = false)
        {
            IQueryable<TEntity> query = (await BuilderQueryable(isTracking))
             .WhereDynamicFilter(input.DynamicFilter);

            if (order != null)
            {
                query = order(query);
            }
            return ResponseOutput.Succees(new Page<TResult>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .Select(selector)
                    .ToListAsync()
            });
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
        public async Task<ResponseOutput<Page<TResult>>> GetQueryablePageListAsync<TResult, TPageInput>(
            Expression<Func<TEntity, bool>> expression,
            Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> order,
            PageInput<TPageInput> input,
            bool isTracking = false)
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
            return ResponseOutput.Succees(new Page<TResult>
            {
                Total = await query.CountAsync(),
                List = await query
                    .Page(input.CurrentPage, input.PageSize)
                    .Select(selector)
                    .ToListAsync()
            });
        }

        /// <summary>
        /// 批量更新,忽略指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        public async Task BatchIgnoreUpdateAsync(IEnumerable<TEntity> entitys, params Expression<Func<TEntity, object>>[] ignorePropertys)
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
            await tDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 更新,忽略指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="ignorePropertys">忽略属性</param>
        /// <returns></returns>
        public async Task IgnoreUpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] ignorePropertys)
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
            await tDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 批量更新,只包含指定属性
        /// </summary>
        /// <param name="entitys">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        public async Task BatchIncludeUpdateAsync(IEnumerable<TEntity> entitys, params Expression<Func<TEntity, object>>[] includePropertys)
        {
            var tDbContext = await _dbContextProvider.GetDbContextAsync();
            // 实体加入上下文
            var entityEntry = tDbContext.Entry(entitys);
            // 只包含参与修改的字段
            foreach (var item in includePropertys)
            {
                entityEntry.Property(item.GetMemberAccess().Name).IsModified = true;
            }
            await tDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 更新,只包含指定属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="includePropertys">包含属性</param>
        /// <returns></returns>
        public async Task IncludeUpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] includePropertys)
        {
            var tDbContext = await _dbContextProvider.GetDbContextAsync();
            // 实体进入上下文
            var entityEntry = tDbContext.Entry(entity);
            // 只包含参与修改的字段
            foreach (var item in includePropertys)
            {
                entityEntry.Property(item).IsModified = true;
            }
            await tDbContext.SaveChangesAsync();
        }

        public Task<PageOutput<TResult>> GetPageListAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order, int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }
    }
}
