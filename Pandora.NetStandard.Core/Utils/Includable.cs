using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pandora.NetStandard.Core.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pandora.NetStandard.Core.Utils
{
    internal class Includable<TEntity> : IIncludable<TEntity> where TEntity : class
    {
        internal IQueryable<TEntity> Input { get; }

        internal Includable(IQueryable<TEntity> queryable)
        {
            Input = queryable ?? throw new ArgumentNullException(nameof(queryable));
        }
    }

    internal class Includable<TEntity, TProperty> : Includable<TEntity>, IIncludable<TEntity, TProperty> where TEntity : class
    {
        internal IIncludableQueryable<TEntity, TProperty> IncludableInput { get; }

        internal Includable(IIncludableQueryable<TEntity, TProperty> queryable)
            : base(queryable)
        {
            IncludableInput = queryable;
        }
    }

    public static class IncludableExtensions
    {
        public static IIncludable<TEntity, TProperty> Include<TEntity, TProperty>(
            this IIncludable<TEntity> includes,
            Expression<Func<TEntity, TProperty>> propertySelector) where TEntity : class
        {
            var result = ((Includable<TEntity>)includes)
                .Input
                .Include(propertySelector);

            return new Includable<TEntity, TProperty>(result);
        }

        public static IIncludable<TEntity, TOtherProperty> ThenInclude<TEntity, TOtherProperty, TProperty>(
                this IIncludable<TEntity, TProperty> includes,
                Expression<Func<TProperty, TOtherProperty>> propertySelector) where TEntity : class
        {
            var result = ((Includable<TEntity, TProperty>)includes)
                .IncludableInput
                .ThenInclude(propertySelector);

            return new Includable<TEntity, TOtherProperty>(result);
        }

        public static IIncludable<TEntity, TOtherProperty> ThenInclude<TEntity, TOtherProperty, TProperty>(
                this IIncludable<TEntity, IEnumerable<TProperty>> includes,
                Expression<Func<TProperty, TOtherProperty>> propertySelector) where TEntity : class
        {
            var result = ((Includable<TEntity, IEnumerable<TProperty>>)includes)
                .IncludableInput
                .ThenInclude(propertySelector);

            return new Includable<TEntity, TOtherProperty>(result);
        }
    }

}
