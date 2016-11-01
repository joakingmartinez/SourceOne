using OFUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SourceOneDental.BO.Framework
{
    public class BaseRepository<T> where T : class
    {
        internal SourceOneDentalEntities context;
        internal DbSet<T> dbSet;

        public BaseRepository()
        {
            context = new SourceOneDentalEntities();
            this.dbSet = context.Set<T>();
        }

        public BaseRepository(SourceOneDentalEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public BaseRepository(SourceOneDentalEntities context, bool ProxyCreationEnabled = true)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
            this.context.Configuration.ProxyCreationEnabled = ProxyCreationEnabled;
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public T Find(Expression<Func<T, bool>> specification)
        {
            return context.Set<T>().SingleOrDefault(specification);
        }

        public bool Insert(T entity)
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Added;
                return context.SaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public virtual bool Update(T entity)
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public virtual bool Delete(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return context.SaveChanges() > 0;
        }

        public virtual IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> specification)
        {
            return context.Set<T>().Where(specification);
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }
    }
}
