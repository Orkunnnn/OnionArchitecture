﻿using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Repositories.Common;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Persistence.Contexts;

namespace OnionArchitecture.Persistence.Repositories.Common
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly OnionArchitectureDbContext _context;

        public WriteRepository(OnionArchitectureDbContext context)
        {
            this._context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public T Add(T entity) => Table.Add(entity).Entity;

        public bool Remove(T entity) => Table.Remove(entity).State == EntityState.Deleted;

        public int Save() => _context.SaveChanges();

        public Task<int> SaveAsync() => _context.SaveChangesAsync();

        public T Update(T entity) => Table.Update(entity).Entity;
    }
}
