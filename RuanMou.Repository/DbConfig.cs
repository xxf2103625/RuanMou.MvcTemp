using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuanMou.Repository
{
    public class DbConfig
    {
        public static string ConnectionString = "";//连接字符串
        public static SqlSugarClient GetDbInstance()
        {
            try
            {
                //这里可以动态根据cookies或session实现多库切换
                return new SqlSugarClient(ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库出错，请检查您的连接字符串，和网络。 ex:", ex);
            }
        }
    }
}
