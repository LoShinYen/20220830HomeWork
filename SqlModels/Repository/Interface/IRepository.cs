using _20220830HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.Repository.Interface
{
    public interface IRepository
    {
        public NorthwindContext DbContext { get; }
        //新增
        void Create<TEntity>(TEntity entity) where TEntity : class;

        //更改
        void Update<TEntity>(TEntity entity) where TEntity : class;

        //刪除 
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        //儲存
        void SaveChange();

        //查詢所有資料
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

        //依條件查詢
        IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity , bool>> predicate) where TEntity : class;
    }
}
