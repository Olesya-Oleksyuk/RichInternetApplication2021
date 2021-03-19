using ToDoList.Core.Entities.Base;
using ToDoList.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDoList.Core.Repositories.Base {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : Entity {
        /// <summary>
        /// 
        /// </summary>
        Task<IReadOnlyList<T>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        IQueryable<T> GetAsyncIQueryable(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeString"></param>
        /// <param name="disableTracking"></param>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <param name="disableTracking"></param>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<Expression<Func<T, object>>> includes = null,
                                        bool disableTracking = true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        Task<T> GetByIdAsync(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task<T> AddAsync(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(T entity);

        Task UpdateAsync(IReadOnlyList<T> entites);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        Task DeleteAsync(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        Task<int> CountAsync(ISpecification<T> spec);

        IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null,
                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = null, int? take = null);
    }
}