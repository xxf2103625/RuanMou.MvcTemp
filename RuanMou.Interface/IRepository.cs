using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.Interface
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        /// <summary>
        /// 查找单个
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        T FindSingle(Expression<Func<T, bool>> exp = null);
        /// <summary>
        /// 是否有
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> exp);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="orderby"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        Queryable<T> Find(int pageindex, int pagesize, string orderby, Expression<Func<T, bool>> exp = null);
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        Queryable<T> Find(Expression<Func<T, bool>> exp = null);

        //IQueryable<T> Find(int pageindex = 1, int pagesize = 10, string orderby = "",Expression<Func<T, bool>> exp = null);
        /// <summary>
        /// JqGrid封装分页(移除搜索)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        //JQGridResult<T> JqGridPage(JQGridQuery query, Expression<Func<T, bool>> exp = null);
        //IEnumerable<T> JqGridPageData(JQGridQuery query, out int records, out int total, Expression<Func<T, bool>> exp = null);

        int GetCount(Expression<Func<T, bool>> exp = null);
        /// <summary>
        /// 添加实体,返回该实体(带Id)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);
        /// <summary>
        /// 添加实体列表,返回该列表(带Id)
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        List<T> BatchAdd(T[] entities);

        /// <summary>
        /// 更新一个实体的所有属性
        /// </summary>
        //void Update(T entity);

        //void Delete(T entity);

        /// <summary>
        /// 按指定的ID进行批量更新
        /// </summary>
        //void Update(Expression<Func<T, object>> identityExp, T entity);

        /// <summary>
        /// 实现按需要只更新部分更新
        /// <para>如：Update(u =>u.Id==1,u =>new User{Name="ok"});</para>
        /// </summary>
        /// <param name="where">更新条件</param>
        /// <param name="entity">更新后的实体</param>
        //void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);
        /// <summary>
        /// 批量删除
        /// </summary>
        //void Delete(Expression<Func<T, bool>> exp);
    }
}
