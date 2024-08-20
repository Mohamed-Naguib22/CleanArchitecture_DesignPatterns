using CleanArchitecture_DesignPatterns.Application.Contract.ISpecifications;
using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Application.Contract.IRepositories.ICommon
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(IBaseSpecification<TEntity> specification);
    }
}
