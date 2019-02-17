using HBSIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HBSIS.Data.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
    }
}
