using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Data.Dals
{
    public class EfRepository<TEntity> : IEfRepository<TEntity> where TEntity : class
    {
        protected readonly SchoolDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public EfRepository(SchoolDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> AllAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            return await Task.Run(() =>
            {
                IQueryable<TEntity> entities = _dbSet.IncludeMultiple(includes);

                if (predicate != null)
                {
                    entities = entities.Where(predicate);
                }

                return orderBy != null ? orderBy(entities) : entities;
            });
        }

        public async Task<BLPagedResponse<TEntity>> AllPagedAsync(int skip, int take, int pageSize, int currentPage, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, 
                bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> entities;

            if (predicate == null)
            {
                entities = _dbSet
                   .IncludeMultiple(includes);
            }
            else
            {
                entities = _dbSet
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
                return _dbSet.Find(id);
            });
        }

        public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                .AsNoTracking<TEntity>()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Add(entity);
            });
            return entity;
        }

        public async Task DeleteAsync(object id)
        {
            await this.DeleteAsync(_dbSet.Find(id));
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entityToDelete);
                _dbSet.Remove(entityToDelete);
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
                return _dbSet.Count();
            });
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Count(predicate);
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
                    return _dbSet
                        .IncludeMultiple(includes)
                        .FirstOrDefault();
                }
                else
                {
                    return _dbSet
                        .IncludeMultiple(includes)
                        .Where(predicate)
                        .FirstOrDefault();
                };
            });
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
    }
}
