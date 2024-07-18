using System.Linq.Expressions;
using Services.Contracts.Specification;
using Shared.Wrapper;

namespace Services.Contracts.Repositroy;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    Task<IResult> Create(T entity);
    Task<IResult> Update(T entity);
    Task<IResult> Delete(T entity);

    IEnumerable<T> Find(ISpecification<T> specification = null);


    bool Contains(ISpecification<T> specification = null);
    bool Contains(Expression<Func<T, bool>> predicate);

    int Count(ISpecification<T> specification = null);
    int Count(Expression<Func<T, bool>> predicate);
}