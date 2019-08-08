using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Interfaces.Data;
using Pandora.NetStandard.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Data.Dals
{
    public class EfRepository<TEntity> : IEfRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public EfRepository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy, params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes)
        {
            return await Task.Run(() =>
            {
                IQueryable<TEntity> entities = _dbSet.IncludeMultiple(includes).AsNoTracking();

                if (predicate != null)
                {
                    entities = entities.Where(predicate);
                }

                return orderBy != null ? orderBy(entities) : entities;
            });
        }

        public async Task<BLPagedResponse<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage,
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes)
        {
            IQueryable<TEntity> entities = _dbSet.IncludeMultiple(includes).AsNoTracking();

            if (predicate != null)
            {
                entities = entities.Where(predicate);
            }

            var totalCount = entities.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            return await Task.Run(() =>
            {
                return new BLPagedResponse<TEntity>
                {
                    Data = orderBy != null
                        ? orderBy(entities).Skip(skip).Take(take)
                        : entities.Skip(skip).Take(take),
                    CollectionLength = totalCount,
                    CurrentPage = currentPage,
                    RowsPerPage = pageSize,
                    TotalPages = totalPages
                };
            });
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<IIncludable<TEntity>, IIncludable>>[] includes)
        {
            return await _dbSet.IncludeMultiple(includes).AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await Task.Run(() =>
            {
                return _dbSet.Add(entity);
            });
            return result.Entity;
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            //Remove logically
            if (entityToDelete is TrackedEntity)
            {
                ((TrackedEntity)entityToDelete).Deleted = true;
                await UpdateAsync(entityToDelete);
            }
            else
            {
                await Task.Run(() =>
                {
                    _dbSet.Attach(entityToDelete);
                    _dbSet.Remove(entityToDelete);
                });
            }
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            });
        }

        public async Task<int> GetCountAsync()
        {
            return await Task.Run(() =>
            {
                return _dbSet.Count();
            });
        }

        public async Task<int> GetCountByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Count(predicate);
            });
        }

        public async Task<int> ExecuteQueryAsync(string query, params object[] paramaters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(query, paramaters);
        }

        public async Task<List<TEntity>> ExecSp(string spName, params object[] parameters)
        {
            var tEntity = new List<TEntity>();
            var spResult = await Task.Run(() => _dbSet.FromSql(spName, parameters));
            foreach (var item in spResult)
            {
                tEntity.Add(item);
            }

            return tEntity;
        }

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}
