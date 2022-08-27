using _20220830HomeWork.Models;
using Microsoft.EntityFrameworkCore;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.Repository
{
    public class Repository : IRepository
    {
        #region --DB --
        private readonly NorthwindContext _DbContext;

        public Repository(NorthwindContext dbContext)
        {
            _DbContext = dbContext;
        }

        public NorthwindContext DbContext { get { return _DbContext; } }
        #endregion

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Added;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void SaveChange()
        {
            _DbContext.SaveChanges();
        }

        public IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _DbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _DbContext.Set<TEntity>().AsQueryable();
        }


    }
}
