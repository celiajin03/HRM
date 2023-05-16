using System.Globalization;
using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly OnBoardingDbContext _dbContext;

    public BaseRepository(OnBoardingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null)
    {
        if (filter==null)
        {
            return false;
        }

        return await _dbContext.Set<T>().Where(filter).AnyAsync();
    }
    
    public async Task<T> AddSync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;

    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity==null)
        {
            throw new InvalidOperationException("The entity with the specified ID was not found.");
        }
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return id;
    }
}