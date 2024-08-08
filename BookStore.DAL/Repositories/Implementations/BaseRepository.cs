﻿using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
{
    protected readonly BookStoreDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(BookStoreDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual Task Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(id, cancellationToken);
        _dbSet.Remove(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }
    

}