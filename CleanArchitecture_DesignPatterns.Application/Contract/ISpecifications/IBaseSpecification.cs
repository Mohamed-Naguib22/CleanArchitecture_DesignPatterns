using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Contract.ISpecifications
{
    public interface IBaseSpecification<TEntity> where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        Expression<Func<TEntity, object>>? OrderByExpression { get; }
    }
}
