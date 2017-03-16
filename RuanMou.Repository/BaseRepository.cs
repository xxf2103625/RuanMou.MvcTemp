using RuanMou.Interface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.Repository
{
    /// <summary>
    /// 仓储基类(还没想到到底用不用工作单元及实现方式)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRespository<T> : IRepository<T> where T : class, new()
    {
        private SqlSugarClient client = null;
        private bool disposed = false;
        public BaseRespository()
        {
            client = DbConfig.GetDbInstance();
        }
        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            return client.Queryable<T>().Single(exp);
        }

        public bool IsExist(Expression<Func<T, bool>> exp)
        {
            return client.Queryable<T>().Any(exp);
        }

        public Queryable<T> Find(int pageindex, int pagesize, string orderby = "Id desc", Expression<Func<T, bool>> exp = null)
        {
            return client.Queryable<T>().Where(exp).OrderBy(orderby).Skip(pageindex).Take(pagesize);
        }

        public Queryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return client.Queryable<T>().Where(exp);
        }

        public int GetCount(Expression<Func<T, bool>> exp = null)
        {
            return client.Queryable<T>().Where(exp).Count();
        }

        public T Add(T entity)
        {
            return (T)client.Insert(entity);
        }

        public List<T> BatchAdd(T[] entities)
        {
            return client.InsertRange<T>(entities.ToList()) as List<T>;
        }
        #region 释放
        protected virtual void Dispose(bool desposing)
        {
            if (!this.disposed)
            {
                this.Dispose();
            }
        }
        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
            }
        }
        #endregion

    }
}
