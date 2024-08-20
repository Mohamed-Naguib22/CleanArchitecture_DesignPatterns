using CleanArchitecture_DesignPatterns.Application.Contract.ISpecifications;
using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Specifications.Common
{
    public abstract class BaseSpecification<TEntity> : IBaseSpecification<TEntity>
        where TEntity : BaseEntity
    {
        protected BaseSpecification(Expression<Func<TEntity, bool>>? criteria = null)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>>? Criteria { get; }
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();
        public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

        protected void AddIclude(Expression<Func<TEntity, object>> includeExpression) =>
            IncludeExpressions.Add(includeExpression);

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) =>
           OrderByExpression = orderByExpression;
    }
}
