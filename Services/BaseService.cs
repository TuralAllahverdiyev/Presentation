using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService
    {

    }

    public class BaseService<TModel> : BaseService, IBaseService<TModel> where TModel : class
    {
        protected readonly AppDbContext _db;

        protected DbSet<TModel> _dbSet;
        public BaseService(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TModel>();
        }

        public TModel Create(TModel model)
        {
            _dbSet.Add(model);
            _db.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            var item = Get(id);
            _dbSet.Remove(item);
            _db.SaveChanges();

        }

        public TModel Get(int id)
        {
            var res=_dbSet.Find(id);
            _db.SaveChanges();
            return res;
        }

        public IEnumerable<TModel> Get()
        {
            return _dbSet;
        }

        public TModel Update(TModel model)
        {
            var res=_dbSet.Update(model);
            _db.SaveChanges();
            return model;
        }
    }
}
