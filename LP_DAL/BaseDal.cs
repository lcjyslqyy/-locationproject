using Base_Helper;
using Base_Helper.PetaPoco;
using ILP_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP_DAL
{
    public class BaseDal<T> : IBaseDal<T> where T : class  
    {
        private string _connectionName;
        public BaseDal()
        {
            _connectionName = LP_Common.BaseConfig.DBConName;
        }
        /// <summary>
        /// petapoco的数据库
        /// </summary>
        protected PetaConnectionDB PCDb
        {
            get
            {
                return PetaConnectionDB.GetInstance(_connectionName);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual object Add(T model)
        {
            return PCDb.Insert(model);
        }

        /// <summary>
        /// 实例
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cfcode"></param>
        /// <returns></returns>
        public virtual T Single(object id)
        {
            return PCDb.SingleOrDefault<T>(id);
        }

        /// <summary>
        /// 实例
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cfcode"></param>
        /// <returns></returns>
        public virtual T Single(string sql, params object[] args)
        {
            return PCDb.SingleOrDefault<T>(sql, args);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cfcode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual int Delete(object id)
        {
            return PCDb.Delete<T>(id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cfcode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual int Delete(string sql, params object[] args)
        {
            return PCDb.Delete<T>(sql, args);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Update(T model)
        {
            return PCDb.Update(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Update(T model, string[] row)
        {
            return PCDb.Update(model, row);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="cfcode"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> List(string sql, params object[] args)
        {
            return PCDb.Query<T>(sql, args);
        }


        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="cfcode"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> List(Sql sql)
        {
            return PCDb.Query<T>(sql);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="cfcode"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public virtual Page<T> Page(long pageindex, long pagesize, string sql, params object[] args)
        {
            return PCDb.Page<T>(pageindex, pagesize, sql, args);
        }

        /// <summary>
        /// 使用bootgrid分页
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页行数</param>
        /// <param name="sql">查询</param>
        /// <param name="args">查询参数</param>
        /// <returns></returns>
        public virtual PageGrid PageGrid(long pageindex, long pagesize, string sql, params object[] args)
        {
            return PCDb.PageGrid(pageindex, pagesize, sql, args);
        }

        public virtual PageGrid PageGrid(long pageindex, long pagesize, Sql sql)
        {
            return PCDb.PageGrid(pageindex, pagesize, sql);
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual int Execute(string sql, params object[] args)
        {
            return PCDb.Execute(sql, args);
        }

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="where">where条件，不包含where</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual bool Exists(string where, params object[] args)
        {
            return PCDb.Exists<T>(where, args);
        }

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="where">where条件，不包含where</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual bool Exists(object id)
        {
            return PCDb.Exists<T>(id);
        }

        /// <summary>
        /// 获取单模型，找不到返回NULL,多个结果会报错
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public virtual T SingleOrDefault(object primaryKey)
        {
            return PCDb.SingleOrDefault<T>(primaryKey);
        }

        /// <summary>
        /// 获取单模型，找不到返回NULL,多个结果会报错
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public virtual T SingleOrDefault(string sql, params object[] args)
        {
            return PCDb.SingleOrDefault<T>(sql, args);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable Fill(Sql sql)
        {
            return Fill(sql.SQL, sql.Arguments);
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable Fill(string sql, params object[] args)
        {
            return PCDb.Fill(sql, args);
        }
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataSet FillDataSet(string sql, params object[] args)
        {
            return PCDb.FillDataSet(sql, args);
        }
        /// <summary>
        /// 返回一个dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataSet FillDataSet(string sql, params SqlParameter[] cmdParms)
        {
            return PetaSQLHelper.Query(PCDb, sql, cmdParms);
        }
        /// <summary>
        /// 返回一个dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataSet FillDataSet(string sql)
        {
            return PetaSQLHelper.Query(PCDb, sql);
        }
        /// <summary>
        /// 返回一个分页
        /// </summary>
        /// <param name="model"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public PageGrid Get_PageGridByPageModel(LP_Common.PageModel model, params object[] args)
        {
            var sql = new StringBuilder();
            sql.AppendFormat("select {0}  from {1} ", model.Columns, model.TableName);
            if (!String.IsNullOrEmpty(model.Where))
            {
                sql.AppendFormat(" where {0} ", model.Where);
            }
            if (!String.IsNullOrEmpty(model.OrderBy))
            {
                sql.AppendFormat(" order by {0} ", model.OrderBy);
            }
            return PCDb.PageGrid(model.current, model.rowCount, sql.ToString(), args);
        }
    }
}
