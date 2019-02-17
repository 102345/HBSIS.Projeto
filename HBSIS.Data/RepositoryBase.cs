using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Dommel;
using HBSIS.Data.Contracts;
using HBSIS.Domain.Entities;

namespace HBSIS.Data
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly string ConnectionString;

        protected RepositoryBase()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<TEntity>();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public virtual void Insert(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var id = db.Insert(entity);

                entity = GetById(id);
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Update(entity);
            }
        }

        public virtual bool Delete(Int32 id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var entity = GetById(id);

                if (entity == null) throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Select(predicate);
            }
        }
    }
}
