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
    /// 数据访问类:temp_planorderlist
    /// </summary>
    public partial class temp_planorderlist
    {
        public temp_planorderlist()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from temp_planorderlist");
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
        public bool Add(DTcms.Model.temp_planorderlist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into temp_planorderlist(");
            strSql.Append("PartNum,PartName,MaterialTexture,PlanWorkTime,MachineLathe,OrderReadyState,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("?PartNum,?PartName,?MaterialTexture,?PlanWorkTime,?MachineLathe,?OrderReadyState,?CreateDate)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?PartNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?PartName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MaterialTexture", MySqlDbType.VarChar,255),
                    new MySqlParameter("?PlanWorkTime", MySqlDbType.Datetime),
                    new MySqlParameter("?MachineLathe", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OrderReadyState", MySqlDbType.Int32,11),
                    new MySqlParameter("?CreateDate", MySqlDbType.Datetime)};
            parameters[0].Value = model.PartNum;
            parameters[1].Value = model.PartName;
            parameters[2].Value = model.MaterialTexture;
            parameters[3].Value = model.PlanWorkTime;
            parameters[4].Value = model.MachineLathe;
            parameters[5].Value = model.OrderReadyState;
            parameters[6].Value = model.CreateDate;

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
        public bool Update(DTcms.Model.temp_planorderlist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update temp_planorderlist set ");
            strSql.Append("PartNum=?PartNum,");
            strSql.Append("PartName=?PartName,");
            strSql.Append("MaterialTexture=?MaterialTexture,");
            strSql.Append("PlanWorkTime=?PlanWorkTime,");
            strSql.Append("MachineLathe=?MachineLathe,");
            strSql.Append("OrderReadyState=?OrderReadyState,");
            strSql.Append("CreateDate=?CreateDate");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?PartNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?PartName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MaterialTexture", MySqlDbType.VarChar,255),
                    new MySqlParameter("?PlanWorkTime", MySqlDbType.Datetime),
                    new MySqlParameter("?MachineLathe", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OrderReadyState", MySqlDbType.Int32,11),
                    new MySqlParameter("?CreateDate", MySqlDbType.Datetime),
                    new MySqlParameter("?Id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.PartNum;
            parameters[1].Value = model.PartName;
            parameters[2].Value = model.MaterialTexture;
            parameters[3].Value = model.PlanWorkTime;
            parameters[4].Value = model.MachineLathe;
            parameters[5].Value = model.OrderReadyState;
            parameters[6].Value = model.CreateDate;
            parameters[7].Value = model.Id;

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
            strSql.Append("delete from temp_planorderlist ");
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
            strSql.Append("delete from temp_planorderlist ");
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
        public DTcms.Model.temp_planorderlist GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,PartNum,PartName,MaterialTexture,PlanWorkTime,MachineLathe,OrderReadyState,CreateDate from temp_planorderlist ");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Id", MySqlDbType.Int32)
            };
            parameters[0].Value = Id;

            DTcms.Model.temp_planorderlist model = new DTcms.Model.temp_planorderlist();
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
        public DTcms.Model.temp_planorderlist DataRowToModel(DataRow row)
        {
            DTcms.Model.temp_planorderlist model = new DTcms.Model.temp_planorderlist();
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
                if (row["PartName"] != null)
                {
                    model.PartName = row["PartName"].ToString();
                }
                if (row["MaterialTexture"] != null)
                {
                    model.MaterialTexture = row["MaterialTexture"].ToString();
                }
                if (row["PlanWorkTime"] != null && row["PlanWorkTime"].ToString() != "")
                {
                    model.PlanWorkTime = DateTime.Parse(row["PlanWorkTime"].ToString());
                }
                if (row["MachineLathe"] != null)
                {
                    model.MachineLathe = row["MachineLathe"].ToString();
                }
                if (row["OrderReadyState"] != null && row["OrderReadyState"].ToString() != "")
                {
                    model.OrderReadyState = int.Parse(row["OrderReadyState"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
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
            strSql.Append("select Id,PartNum,PartName,MaterialTexture,PlanWorkTime,MachineLathe,OrderReadyState,CreateDate ");
            strSql.Append(" FROM temp_planorderlist ");
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
            strSql.Append("select count(1) FROM temp_planorderlist ");
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
            strSql.Append(")AS Row, T.*  from temp_planorderlist T ");
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
			parameters[0].Value = "temp_planorderlist";
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
