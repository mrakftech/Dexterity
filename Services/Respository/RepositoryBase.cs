using System.Linq.Expressions;
using Database;
using Microsoft.EntityFrameworkCore;
using Services.Contracts.Repositroy;
using Services.Contracts.Specification;
using Services.Specifications;
using Shared.Wrapper;

namespace Services.Respository;

public abstract class RepositoryBase<T>(ApplicationDbContext context) : IRepositoryBase<T>
    where T : class
{
    public IQueryable<T> FindAll() => context.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        context.Set<T>().Where(expression).AsNoTracking();

    public async Task<IResult> Create(T entity)
    {
        context.Set<T>().Add(entity);
        return await Result.SuccessAsync($"{nameof(T)} is created.");
    }

    public async Task<IResult> Update(T entity)
    {
        context.Set<T>().Update(entity);
        return await Result.SuccessAsync($"{nameof(T)} is updated.");
    }

    public async Task<IResult> Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        return await Result.SuccessAsync($"{nameof(T)} is deleted.");
    }

    public IEnumerable<T> Find(ISpecification<T> specification = null)
    {
        return ApplySpecification(specification);
    }

    public bool Contains(ISpecification<T> specification = null)
    {
        return Count(specification) > 0 ? true : false;
    }

    public bool Contains(Expression<Func<T, bool>> predicate)
    {
        
        return Count(predicate) > 0 ? true : false;
    }

    public int Count(ISpecification<T> specification = null)
    {
        return ApplySpecification(specification).Count();
    }

    public int Count(Expression<Func<T, bool>> predicate)
    {
        return context.Set<T>().Where(predicate).Count();
    }
    
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
    }
}