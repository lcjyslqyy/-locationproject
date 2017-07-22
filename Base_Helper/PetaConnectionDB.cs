using Base_Helper.PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Helper
{
    /// <summary>
    /// 用于作PetaPoco的ORM的Helper类
    /// </summary>
    public class PetaConnectionDB : Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        /// <param name="providerName">System.Data.SqlClient为MSSSQL</param>
        public PetaConnectionDB(string connectionString, string providerName)
            : base(connectionString, providerName)
        {
            //string connectionString, string providerName PubConstant.ConnectionString, "System.Data.SqlClient"
            //CommonConstruct();
        }
        /// <summary>
        /// 构造方法,
        /// </summary>
        /// <param name="connectionStringName">webconfig中的connectstring的Name,默认为MSSQL</param>
        public PetaConnectionDB(string connectionStringName)
            : base(connectionStringName)
        {
            //CommonConstruct();
        }
       // partial void CommonConstruct();

        public interface IFactory
        {
            PetaConnectionDB GetInstance(string connectionStringName);
        }

        public static IFactory Factory { get; set; }
        public static PetaConnectionDB GetInstance(string connectionStringName)
        {
            if (_instance != null)
                return _instance;

            if (Factory != null)
                return Factory.GetInstance(connectionStringName);
            else
                return new PetaConnectionDB(connectionStringName);
        }

        [ThreadStatic]
        static PetaConnectionDB _instance;

        public override void OnBeginTransaction()
        {
            if (_instance == null)
                _instance = this;
        }

        public override void OnEndTransaction()
        {
            if (_instance == this)
                _instance = null;
        }
    }
}
