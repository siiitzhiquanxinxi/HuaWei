using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data;
namespace DTcms.DAL
{
    /// <summary>
	/// 数据访问类:sy_materialtype
	/// </summary>
	public partial class sy_materialtype
    {
        public sy_materialtype()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int MaterialTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sy_materialtype");
            strSql.Append(" where MaterialTypeID=?MaterialTypeID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.Int32)
            };
            parameters[0].Value = MaterialTypeID;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.sy_materialtype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sy_materialtype(");
            strSql.Append("MaterialTypeName,Code)");
            strSql.Append(" values (");
            strSql.Append("?MaterialTypeName,?Code)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialTypeName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Code", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.MaterialTypeName;
            parameters[1].Value = model.Code;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.sy_materialtype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sy_materialtype set ");
            strSql.Append("MaterialTypeName=?MaterialTypeName,");
            strSql.Append("Code=?Code");
            strSql.Append(" where MaterialTypeID=?MaterialTypeID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialTypeName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Code", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.MaterialTypeName;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.MaterialTypeID;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MaterialTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_materialtype ");
            strSql.Append(" where MaterialTypeID=?MaterialTypeID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.Int32)
            };
            parameters[0].Value = MaterialTypeID;

            int rows = DbHelperMySql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string MaterialTypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_materialtype ");
            strSql.Append(" where MaterialTypeID in (" + MaterialTypeIDlist + ")  ");
            int rows = DbHelperMySql.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.sy_materialtype GetModel(int MaterialTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MaterialTypeID,MaterialTypeName,Code from sy_materialtype ");
            strSql.Append(" where MaterialTypeID=?MaterialTypeID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.Int32)
            };
            parameters[0].Value = MaterialTypeID;

            DTcms.Model.sy_materialtype model = new DTcms.Model.sy_materialtype();
            DataSet ds = DbHelperMySql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.sy_materialtype DataRowToModel(DataRow row)
        {
            DTcms.Model.sy_materialtype model = new DTcms.Model.sy_materialtype();
            if (row != null)
            {
                if (row["MaterialTypeID"] != null && row["MaterialTypeID"].ToString() != "")
                {
                    model.MaterialTypeID = int.Parse(row["MaterialTypeID"].ToString());
                }
                if (row["MaterialTypeName"] != null)
                {
                    model.MaterialTypeName = row["MaterialTypeName"].ToString();
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MaterialTypeID,MaterialTypeName,Code ");
            strSql.Append(" FROM sy_materialtype ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySql.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM sy_materialtype ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.MaterialTypeID desc");
            }
            strSql.Append(")AS Row, T.*  from sy_materialtype T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySql.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("?PageSize", MySqlDbType.Int32),
					new MySqlParameter("?PageIndex", MySqlDbType.Int32),
					new MySqlParameter("?IsReCount", MySqlDbType.Bit),
					new MySqlParameter("?OrderType", MySqlDbType.Bit),
					new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sy_materialtype";
			parameters[1].Value = "MaterialTypeID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySql.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM sy_materialtype");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperMySql.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperMySql.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion  ExtensionMethod
    }
}
