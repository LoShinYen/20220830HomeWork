using AutoMapper;
using Services.Interface;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService : IBaseService
    {
        private readonly IRepository _Repository;
        private readonly IMapper _Mapper;

        public BaseService(IRepository repository , IMapper mapper)
        {
            _Repository = repository;
            _Mapper = mapper;
        }

        public IRepository Repostiory { get { return _Repository; } }

        public IMapper Mapper { get { return _Mapper; } }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Create<TEntity>(entity);
            Repostiory.SaveChange();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Delete<TEntity>(entity);
            Repostiory.SaveChange();
        }
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Update<TEntity>(entity);
            Repostiory.SaveChange();
        }
        public IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _Repository.FindBy<TEntity>(predicate);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _Repository.GetAll<TEntity>();
        }


    }
}
