using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IBaseService
    {
        public IRepository Repostiory { get; }

        void Create<TEntity> (TEntity entity) where TEntity :class;
        void Delete<TEntity> (TEntity entity) where TEntity :class;
        void Update<TEntity> (TEntity entity) where TEntity :class;

        IQueryable<TEntity> GetAll<TEntity>() where TEntity:class;

        IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity,bool>>predicate) where TEntity : class;

    }
}
