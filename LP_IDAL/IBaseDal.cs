using Base_Helper.PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ILP_DAL
{
    public interface IBaseDal<T> where T : class  
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        object Add(T model);

        /// <summary>
        /// 实例
        /// </summary>
        /// <param name="id"></param>

        /// <returns></returns>
        T Single(object id);

        /// <summary>
        /// 实例
        /// </summary>
        /// <param name="id"></param>

        /// <returns></returns>
        T Single(string sql, params object[] args);

        /// <summary>
        /// 删除
        /// </summary>

        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(object id);

        /// <summary>
        /// 删除
        /// </summary>

        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(string sql, params object[] args);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(T model);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int Update(T model, string[] row);

        /// <summary>
        /// 列表
        /// </summary>

        /// <returns></returns>
        IEnumerable<T> List(string sql, params object[] args);

        /// <summary>
        /// 列表
        /// </summary>

        /// <returns></returns>
        IEnumerable<T> List(Sql sql);
        /// <summary>
        /// 分页
        /// </summary>

        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        Page<T> Page(long pageindex, long pagesize, string sql, params object[] args);


        /// <summary>
        /// 使用bootgrid分页
        /// </summary>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">每页行数</param>
        /// <param name="sql">查询</param>
        /// <param name="args">查询参数</param>
        /// <returns></returns>
        PageGrid PageGrid(long pageindex, long pagesize, string sql, params object[] args);
        PageGrid PageGrid(long pageindex, long pagesize, Sql sql);
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        int Execute(string sql, params object[] args);

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="where">where条件，不包含where</param>
        /// <param name="args"></param>
        /// <returns></returns>
        bool Exists(string where, params object[] args);

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        bool Exists(object id);


        /// <summary>
        /// 获取单模型，找不到返回NULL,多个结果会报错
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        T SingleOrDefault(object primaryKey);

        /// <summary>
        /// 获取单模型，找不到返回NULL,多个结果会报错
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        T SingleOrDefault(string sql, params object[] args);

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable Fill(Sql sql);

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        DataTable Fill(string sql, params object[] args);
        /// <summary>
        /// 返回分页的方法
        /// </summary>
        /// <param name="model">分页model</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        PageGrid Get_PageGridByPageModel(LP_Common.PageModel model, params object[] args);
        /// <summary>
        /// 返回一个dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        DataSet FillDataSet(string sql);
        /// <summary>
        /// 返回一个dataset
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        DataSet FillDataSet(string sql, params SqlParameter[] cmdParms);
        DataSet FillDataSet(string sql, params object[] args);
    }
}
