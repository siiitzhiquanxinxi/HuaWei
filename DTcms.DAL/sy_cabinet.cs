using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
	/// 数据访问类:sy_cabinet
	/// </summary>
	public partial class sy_cabinet
    {
        public sy_cabinet()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CabinetNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sy_cabinet");
            strSql.Append(" where CabinetNo=?CabinetNo ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255)           };
            parameters[0].Value = CabinetNo;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.sy_cabinet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sy_cabinet(");
            strSql.Append("CabinetNo,IP,Port,CardAddr,Location,Manager,Phone)");
            strSql.Append(" values (");
            strSql.Append("?CabinetNo,?IP,?Port,?CardAddr,?Location,?Manager,?Phone)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?IP", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Port", MySqlDbType.VarChar,255),
                    new MySqlParameter("?CardAddr", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Location", MySqlDbType.VarChar,100),
                    new MySqlParameter("?Manager", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Phone", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.CabinetNo;
            parameters[1].Value = model.IP;
            parameters[2].Value = model.Port;
            parameters[3].Value = model.CardAddr;
            parameters[4].Value = model.Location;
            parameters[5].Value = model.Manager;
            parameters[6].Value = model.Phone;

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
        public bool Update(DTcms.Model.sy_cabinet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sy_cabinet set ");
            strSql.Append("IP=?IP,");
            strSql.Append("Port=?Port,");
            strSql.Append("CardAddr=?CardAddr,");
            strSql.Append("Location=?Location,");
            strSql.Append("Manager=?Manager,");
            strSql.Append("Phone=?Phone");
            strSql.Append(" where CabinetNo=?CabinetNo ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?IP", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Port", MySqlDbType.VarChar,255),
                    new MySqlParameter("?CardAddr", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Location", MySqlDbType.VarChar,100),
                    new MySqlParameter("?Manager", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Phone", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.IP;
            parameters[1].Value = model.Port;
            parameters[2].Value = model.CardAddr;
            parameters[3].Value = model.Location;
            parameters[4].Value = model.Manager;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.CabinetNo;

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
        public bool Delete(string CabinetNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_cabinet ");
            strSql.Append(" where CabinetNo=?CabinetNo ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255)           };
            parameters[0].Value = CabinetNo;

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
        public bool DeleteList(string CabinetNolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_cabinet ");
            strSql.Append(" where CabinetNo in (" + CabinetNolist + ")  ");
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
        public DTcms.Model.sy_cabinet GetModel(string CabinetNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CabinetNo,IP,Port,CardAddr,Location,Manager,Phone from sy_cabinet ");
            strSql.Append(" where CabinetNo=?CabinetNo ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255)           };
            parameters[0].Value = CabinetNo;

            DTcms.Model.sy_cabinet model = new DTcms.Model.sy_cabinet();
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
        public DTcms.Model.sy_cabinet DataRowToModel(DataRow row)
        {
            DTcms.Model.sy_cabinet model = new DTcms.Model.sy_cabinet();
            if (row != null)
            {
                if (row["CabinetNo"] != null)
                {
                    model.CabinetNo = row["CabinetNo"].ToString();
                }
                if (row["IP"] != null)
                {
                    model.IP = row["IP"].ToString();
                }
                if (row["Port"] != null)
                {
                    model.Port = row["Port"].ToString();
                }
                if (row["CardAddr"] != null)
                {
                    model.CardAddr = row["CardAddr"].ToString();
                }
                if (row["Location"] != null)
                {
                    model.Location = row["Location"].ToString();
                }
                if (row["Manager"] != null)
                {
                    model.Manager = row["Manager"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
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
            strSql.Append("select CabinetNo,IP,Port,CardAddr,Location,Manager,Phone ");
            strSql.Append(" FROM sy_cabinet ");
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
            strSql.Append("select count(1) FROM sy_cabinet ");
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
                strSql.Append("order by T.CabinetNo desc");
            }
            strSql.Append(")AS Row, T.*  from sy_cabinet T ");
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
			parameters[0].Value = "sy_cabinet";
			parameters[1].Value = "CabinetNo";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
