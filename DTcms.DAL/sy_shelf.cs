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
    /// 数据访问类:sy_shelf
    /// </summary>
    public partial class sy_shelf
    {
        public sy_shelf()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sy_shelf");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.sy_shelf model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sy_shelf(");
            strSql.Append("CabinetNo,BoxNo,Long,Wide,High,X,Y,Type)");
            strSql.Append(" values (");
            strSql.Append("?CabinetNo,?BoxNo,?Long,?Wide,?High,?X,?Y,?Type)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BoxNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Long", MySqlDbType.Decimal,10),
                    new MySqlParameter("?Wide", MySqlDbType.Decimal,10),
                    new MySqlParameter("?High", MySqlDbType.Decimal,10),
                    new MySqlParameter("?X", MySqlDbType.Int32,11),
                    new MySqlParameter("?Y", MySqlDbType.Int32,11),
                    new MySqlParameter("?Type", MySqlDbType.Int32,11)};
            parameters[0].Value = model.CabinetNo;
            parameters[1].Value = model.BoxNo;
            parameters[2].Value = model.Long;
            parameters[3].Value = model.Wide;
            parameters[4].Value = model.High;
            parameters[5].Value = model.X;
            parameters[6].Value = model.Y;
            parameters[7].Value = model.Type;

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
        public bool Update(DTcms.Model.sy_shelf model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sy_shelf set ");
            strSql.Append("CabinetNo=?CabinetNo,");
            strSql.Append("BoxNo=?BoxNo,");
            strSql.Append("Long=?Long,");
            strSql.Append("Wide=?Wide,");
            strSql.Append("High=?High,");
            strSql.Append("X=?X,");
            strSql.Append("Y=?Y,");
            strSql.Append("Type=?Type");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BoxNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Long", MySqlDbType.Decimal,10),
                    new MySqlParameter("?Wide", MySqlDbType.Decimal,10),
                    new MySqlParameter("?High", MySqlDbType.Decimal,10),
                    new MySqlParameter("?X", MySqlDbType.Int32,11),
                    new MySqlParameter("?Y", MySqlDbType.Int32,11),
                    new MySqlParameter("?Type", MySqlDbType.Int32,11),
                    new MySqlParameter("?ID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.CabinetNo;
            parameters[1].Value = model.BoxNo;
            parameters[2].Value = model.Long;
            parameters[3].Value = model.Wide;
            parameters[4].Value = model.High;
            parameters[5].Value = model.X;
            parameters[6].Value = model.Y;
            parameters[7].Value = model.Type;
            parameters[8].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_shelf ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_shelf ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public DTcms.Model.sy_shelf GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CabinetNo,BoxNo,Long,Wide,High,X,Y,Type from sy_shelf ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            DTcms.Model.sy_shelf model = new DTcms.Model.sy_shelf();
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
        public DTcms.Model.sy_shelf DataRowToModel(DataRow row)
        {
            DTcms.Model.sy_shelf model = new DTcms.Model.sy_shelf();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["CabinetNo"] != null)
                {
                    model.CabinetNo = row["CabinetNo"].ToString();
                }
                if (row["BoxNo"] != null)
                {
                    model.BoxNo = row["BoxNo"].ToString();
                }
                if (row["Long"] != null && row["Long"].ToString() != "")
                {
                    model.Long = decimal.Parse(row["Long"].ToString());
                }
                if (row["Wide"] != null && row["Wide"].ToString() != "")
                {
                    model.Wide = decimal.Parse(row["Wide"].ToString());
                }
                if (row["High"] != null && row["High"].ToString() != "")
                {
                    model.High = decimal.Parse(row["High"].ToString());
                }
                if (row["X"] != null && row["X"].ToString() != "")
                {
                    model.X = int.Parse(row["X"].ToString());
                }
                if (row["Y"] != null && row["Y"].ToString() != "")
                {
                    model.Y = int.Parse(row["Y"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
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
            strSql.Append("select ID,CabinetNo,BoxNo,Long,Wide,High,X,Y,Type ");
            strSql.Append(" FROM sy_shelf ");
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
            strSql.Append("select count(1) FROM sy_shelf ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from sy_shelf T ");
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
			parameters[0].Value = "sy_shelf";
			parameters[1].Value = "ID";
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
