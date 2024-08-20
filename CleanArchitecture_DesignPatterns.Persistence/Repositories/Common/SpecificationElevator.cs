using CleanArchitecture_DesignPatterns.Application.Contract.ISpecifications;
using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Persistence.Repositories.Common
{
    public static class SpecificationElevator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> Elevate(IQueryable<TEntity> inputQuery, IBaseSpecification<TEntity> specification)
        {
            if (specification.Criteria is not null)
            {
                inputQuery = inputQuery.Where(specification.Criteria);
            }

            inputQuery = specification.IncludeExpressions.Aggregate(inputQuery,
                (current, includeExpression) =>
                    current.Include(includeExpression));

            if (specification.OrderByExpression is not null)
            {
                inputQuery = inputQuery.OrderBy(specification.OrderByExpression);
            }

            return inputQuery;
        }
    }
}
