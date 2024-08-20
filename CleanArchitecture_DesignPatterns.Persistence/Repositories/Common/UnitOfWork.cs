using CleanArchitecture_DesignPatterns.Application.Contract.IRepositories.ICommon;
using CleanArchitecture_DesignPatterns.Domain.Entities.Common;
using CleanArchitecture_DesignPatterns.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_DesignPatterns.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _currentTransaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction == null)
            {
                _currentTransaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public void Rollback()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                _currentTransaction = null;
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                _currentTransaction = null;
            }
        }
    }
}
