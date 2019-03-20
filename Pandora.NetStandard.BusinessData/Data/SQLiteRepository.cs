using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;

namespace Pandora.NetStandard.BusinessData.Data
{
    public class SQLiteRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public SQLiteRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IQueryable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Task.Run(() =>
            {
                IQueryable<TEntity> entities = _dbContext.Set<TEntity>().IncludeMultiple(includes);

                if (predicate != null)
                {
                    entities = entities.Where(predicate);
                }

                return orderBy != null ? orderBy(entities) : entities;
            });
        }

        public async Task<BLPagedResponse<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> entities;

            if (predicate == null)
            {
                entities = _dbContext.Set<TEntity>()
                   .IncludeMultiple(includes);
            }
            else
            {
                entities = _dbContext.Set<TEntity>()
                    .IncludeMultiple(includes).Where(predicate);
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

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Task.Run(() =>
            {
                return _dbContext.Set<TEntity>().Find(id);
            });
        }

        public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>()
                .AsNoTracking<TEntity>()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbContext.Set<TEntity>().Add(entity);
            });
            return entity;
        }

        public async Task DeleteAsync(object id)
        {
            await this.DeleteAsync(_dbContext.Set<TEntity>().Find(id));
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                _dbContext.Set<TEntity>().Attach(entityToDelete);
                _dbContext.Set<TEntity>().Remove(entityToDelete);
            });
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                _dbContext.Entry<TEntity>(entityToUpdate).State = EntityState.Modified;
            });
        }

        public async Task<int> GetCountAsync()
        {
            return await Task.Run(() =>
            {
                return _dbContext.Set<TEntity>().Count();
            });
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbContext.Set<TEntity>().Count(predicate);
            });
        }

        public async Task<int> ExecuteQueryAsync(string query, params object[] paramaters)
        {
            return await Task.Run(() =>
            {
                return 1;
            });
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Task.Run(() =>
            {
                if (predicate == null)
                {
                    return _dbContext.Set<TEntity>()
                        .IncludeMultiple(includes)
                        .FirstOrDefault();
                }
                else
                {
                    return _dbContext.Set<TEntity>()
                        .IncludeMultiple(includes)
                        .Where(predicate)
                        .FirstOrDefault();
                };
            });
        }

        public async Task<List<TEntity>> ExecSp(string spName, params object[] parameters)
        {
            var tEntity = new List<TEntity>();
            var spResult = await Task.Run(() => _dbContext.Set<TEntity>().FromSql(spName, parameters));
            foreach (var item in spResult)
            {
                tEntity.Add(item);
            }

            return tEntity;
        }
    }
}
