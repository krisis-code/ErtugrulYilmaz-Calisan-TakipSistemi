using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeManagement.Data.Implementaion
{
    public class Repository<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly EmployeeManagementContext _ctx;
        internal DbSet<T> dbset;
        public Repository(EmployeeManagementContext ctx)
        {
                _ctx = ctx;
            this.dbset = _ctx.Set<T>();
             

        }

        /// <summary>
        /// Add to T type entity / Gelen tipte veriyi kaydeder
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
                  query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            if (orderBy !=null)
            {
                return orderBy(query);
            }
            return query;
        }

        public T GetFirtsOfDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
           
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}
