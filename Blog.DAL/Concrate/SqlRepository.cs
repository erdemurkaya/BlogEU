using Blog.DAL.Abstract;
using Blog.DAL.Context;
using Blog.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Concrate
{
    public class SqlRepository<TEntity>:IRepository<TEntity> where TEntity : BaseEntity
    {


        private readonly BlogDB _db;

        private readonly DbSet<TEntity> _dbSet;

        public SqlRepository(BlogDB db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            

            _db.Update(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);

            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is not null ? _dbSet.Where(predicate) : _dbSet;
        }

        public TEntity GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            

            _db.Update(entity);
            _db.SaveChanges();

        }
    }
}
