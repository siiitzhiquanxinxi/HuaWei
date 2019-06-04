using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using DTcms.DBUtility;
using System.Data;
namespace DTcms.DAL
{
    /// <summary>
	/// 数据访问类:temp_camlist
	/// </summary>
	public partial class temp_camlist
    {
        public temp_camlist()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from temp_camlist");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Id", MySqlDbType.Int32)
            };
            parameters[0].Value = Id;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.temp_camlist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into temp_camlist(");
            strSql.Append("PartNum,ToolName,WorkTime,ToolLevel,ToolReadyState)");
            strSql.Append(" values (");
            strSql.Append("?PartNum,?ToolName,?WorkTime,?ToolLevel,?ToolReadyState)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?PartNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ToolName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?WorkTime", MySqlDbType.Int32,11),
                    new MySqlParameter("?ToolLevel", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ToolReadyState", MySqlDbType.Int32,11)};
            parameters[0].Value = model.PartNum;
            parameters[1].Value = model.ToolName;
            parameters[2].Value = model.WorkTime;
            parameters[3].Value = model.ToolLevel;
            parameters[4].Value = model.ToolReadyState;

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
        public bool Update(DTcms.Model.temp_camlist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update temp_camlist set ");
            strSql.Append("PartNum=?PartNum,");
            strSql.Append("ToolName=?ToolName,");
            strSql.Append("WorkTime=?WorkTime,");
            strSql.Append("ToolLevel=?ToolLevel,");
            strSql.Append("ToolReadyState=?ToolReadyState");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?PartNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ToolName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?WorkTime", MySqlDbType.Int32,11),
                    new MySqlParameter("?ToolLevel", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ToolReadyState", MySqlDbType.Int32,11),
                    new MySqlParameter("?Id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.PartNum;
            parameters[1].Value = model.ToolName;
            parameters[2].Value = model.WorkTime;
            parameters[3].Value = model.ToolLevel;
            parameters[4].Value = model.ToolReadyState;
            parameters[5].Value = model.Id;

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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from temp_camlist ");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Id", MySqlDbType.Int32)
            };
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from temp_camlist ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public DTcms.Model.temp_camlist GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,PartNum,ToolName,WorkTime,ToolLevel,ToolReadyState from temp_camlist ");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Id", MySqlDbType.Int32)
            };
            parameters[0].Value = Id;

            DTcms.Model.temp_camlist model = new DTcms.Model.temp_camlist();
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
        public DTcms.Model.temp_camlist DataRowToModel(DataRow row)
        {
            DTcms.Model.temp_camlist model = new DTcms.Model.temp_camlist();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["PartNum"] != null)
                {
                    model.PartNum = row["PartNum"].ToString();
                }
                if (row["ToolName"] != null)
                {
                    model.ToolName = row["ToolName"].ToString();
                }
                if (row["WorkTime"] != null && row["WorkTime"].ToString() != "")
                {
                    model.WorkTime = int.Parse(row["WorkTime"].ToString());
                }
                if (row["ToolLevel"] != null)
                {
                    model.ToolLevel = row["ToolLevel"].ToString();
                }
                if (row["ToolReadyState"] != null && row["ToolReadyState"].ToString() != "")
                {
                    model.ToolReadyState = int.Parse(row["ToolReadyState"].ToString());
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
            strSql.Append("select Id,PartNum,ToolName,WorkTime,ToolLevel,ToolReadyState ");
            strSql.Append(" FROM temp_camlist ");
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
            strSql.Append("select count(1) FROM temp_camlist ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from temp_camlist T ");
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
			parameters[0].Value = "temp_camlist";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySql.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
