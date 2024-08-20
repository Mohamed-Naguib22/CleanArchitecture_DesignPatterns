using CleanArchitecture_DesignPatterns.Application.Contract.IRepositories.ICommon;
using CleanArchitecture_DesignPatterns.Application.Contract.ISpecifications;
using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using CleanArchitecture_DesignPatterns.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Persistence.Repositories.Common
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> Entities;
        
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(IBaseSpecification<TEntity> specification)
        {
            var query = Entities.AsQueryable();

            query = SpecificationElevator<TEntity>.Elevate(query, specification);

            return await query.ToListAsync();
        }
    }
}
