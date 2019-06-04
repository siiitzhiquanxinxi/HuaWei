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
    /// 数据访问类:w_inout
    /// </summary>
    public partial class w_inout
    {
        public w_inout()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BillID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from w_inout");
            strSql.Append(" where BillID=?BillID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BillID", MySqlDbType.VarChar,50)           };
            parameters[0].Value = BillID;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.w_inout model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into w_inout(");
            strSql.Append("BillID,BillDate,Operater,SendBillNum,InOutType,IOFlag,Remark)");
            strSql.Append(" values (");
            strSql.Append("?BillID,?BillDate,?Operater,?SendBillNum,?InOutType,?IOFlag,?Remark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BillID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?BillDate", MySqlDbType.Datetime),
                    new MySqlParameter("?Operater", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SendBillNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?InOutType", MySqlDbType.VarChar,50),
                    new MySqlParameter("?IOFlag", MySqlDbType.Int32,11),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.BillID;
            parameters[1].Value = model.BillDate;
            parameters[2].Value = model.Operater;
            parameters[3].Value = model.SendBillNum;
            parameters[4].Value = model.InOutType;
            parameters[5].Value = model.IOFlag;
            parameters[6].Value = model.Remark;

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
        public bool Update(DTcms.Model.w_inout model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update w_inout set ");
            strSql.Append("BillDate=?BillDate,");
            strSql.Append("Operater=?Operater,");
            strSql.Append("SendBillNum=?SendBillNum,");
            strSql.Append("InOutType=?InOutType,");
            strSql.Append("IOFlag=?IOFlag,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where BillID=?BillID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BillDate", MySqlDbType.Datetime),
                    new MySqlParameter("?Operater", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SendBillNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?InOutType", MySqlDbType.VarChar,50),
                    new MySqlParameter("?IOFlag", MySqlDbType.Int32,11),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BillID", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.BillDate;
            parameters[1].Value = model.Operater;
            parameters[2].Value = model.SendBillNum;
            parameters[3].Value = model.InOutType;
            parameters[4].Value = model.IOFlag;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.BillID;

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
        public bool Delete(string BillID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from w_inout ");
            strSql.Append(" where BillID=?BillID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BillID", MySqlDbType.VarChar,50)           };
            parameters[0].Value = BillID;

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
        public bool DeleteList(string BillIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from w_inout ");
            strSql.Append(" where BillID in (" + BillIDlist + ")  ");
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
        public DTcms.Model.w_inout GetModel(string BillID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BillID,BillDate,Operater,SendBillNum,InOutType,IOFlag,Remark from w_inout ");
            strSql.Append(" where BillID=?BillID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BillID", MySqlDbType.VarChar,50)           };
            parameters[0].Value = BillID;

            DTcms.Model.w_inout model = new DTcms.Model.w_inout();
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
        public DTcms.Model.w_inout DataRowToModel(DataRow row)
        {
            DTcms.Model.w_inout model = new DTcms.Model.w_inout();
            if (row != null)
            {
                if (row["BillID"] != null)
                {
                    model.BillID = row["BillID"].ToString();
                }
                if (row["BillDate"] != null && row["BillDate"].ToString() != "")
                {
                    model.BillDate = DateTime.Parse(row["BillDate"].ToString());
                }
                if (row["Operater"] != null)
                {
                    model.Operater = row["Operater"].ToString();
                }
                if (row["SendBillNum"] != null)
                {
                    model.SendBillNum = row["SendBillNum"].ToString();
                }
                if (row["InOutType"] != null)
                {
                    model.InOutType = row["InOutType"].ToString();
                }
                if (row["IOFlag"] != null && row["IOFlag"].ToString() != "")
                {
                    model.IOFlag = int.Parse(row["IOFlag"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select BillID,BillDate,Operater,SendBillNum,InOutType,IOFlag,Remark ");
            strSql.Append(" FROM w_inout ");
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
            strSql.Append("select count(1) FROM w_inout ");
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
                strSql.Append("order by T.BillID desc");
            }
            strSql.Append(")AS Row, T.*  from w_inout T ");
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
			parameters[0].Value = "w_inout";
			parameters[1].Value = "BillID";
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
