using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using WebApiRepository.Api.Models;

namespace WebApiRepository.Api.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDBContext RepositoryContext { get; set; }

        public RepositoryBase(ApplicationDBContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext;
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            RepositoryContext.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindbyCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();
        }
    }
}
