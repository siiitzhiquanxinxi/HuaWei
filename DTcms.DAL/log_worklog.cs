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
    /// 数据访问类:log_worklog
    /// </summary>
    public partial class log_worklog
    {
        public log_worklog()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from log_worklog");
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
        public bool Add(Model.log_worklog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into log_worklog(");
            strSql.Append("SessionID,ClientType,Type,OpContent,Remark,agentName,agentIdCardNum,Company,OpTime,County,Area,Point,MachineID)");
            strSql.Append(" values (");
            strSql.Append("?SessionID,?ClientType,?Type,?OpContent,?Remark,?agentName,?agentIdCardNum,?Company,?OpTime,?County,?Area,?Point,?MachineID)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SessionID", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ClientType", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Type", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OpContent", MySqlDbType.Text),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentIdCardNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Company", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OpTime", MySqlDbType.Datetime),
                    new MySqlParameter("?County", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Area", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Point", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MachineID", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.SessionID;
            parameters[1].Value = model.ClientType;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.OpContent;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.agentName;
            parameters[6].Value = model.agentIdCardNum;
            parameters[7].Value = model.Company;
            parameters[8].Value = model.OpTime;
            parameters[9].Value = model.County;
            parameters[10].Value = model.Area;
            parameters[11].Value = model.Point;
            parameters[12].Value = model.MachineID;

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
        public bool Update(Model.log_worklog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update log_worklog set ");
            strSql.Append("SessionID=?SessionID,");
            strSql.Append("ClientType=?ClientType,");
            strSql.Append("Type=?Type,");
            strSql.Append("OpContent=?OpContent,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("agentName=?agentName,");
            strSql.Append("agentIdCardNum=?agentIdCardNum,");
            strSql.Append("Company=?Company,");
            strSql.Append("OpTime=?OpTime,");
            strSql.Append("County=?County,");
            strSql.Append("Area=?Area,");
            strSql.Append("Point=?Point,");
            strSql.Append("MachineID=?MachineID");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?SessionID", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ClientType", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Type", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OpContent", MySqlDbType.Text),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentIdCardNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Company", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OpTime", MySqlDbType.Datetime),
                    new MySqlParameter("?County", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Area", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Point", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MachineID", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.SessionID;
            parameters[1].Value = model.ClientType;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.OpContent;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.agentName;
            parameters[6].Value = model.agentIdCardNum;
            parameters[7].Value = model.Company;
            parameters[8].Value = model.OpTime;
            parameters[9].Value = model.County;
            parameters[10].Value = model.Area;
            parameters[11].Value = model.Point;
            parameters[12].Value = model.MachineID;
            parameters[13].Value = model.ID;

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
            strSql.Append("delete from log_worklog ");
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
            strSql.Append("delete from log_worklog ");
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
        public Model.log_worklog GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,SessionID,ClientType,Type,OpContent,Remark,agentName,agentIdCardNum,Company,OpTime,County,Area,Point,MachineID from log_worklog ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            Model.log_worklog model = new Model.log_worklog();
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
        public Model.log_worklog DataRowToModel(DataRow row)
        {
            Model.log_worklog model = new Model.log_worklog();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["SessionID"] != null)
                {
                    model.SessionID = row["SessionID"].ToString();
                }
                if (row["ClientType"] != null)
                {
                    model.ClientType = row["ClientType"].ToString();
                }
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["OpContent"] != null)
                {
                    model.OpContent = row["OpContent"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["agentName"] != null)
                {
                    model.agentName = row["agentName"].ToString();
                }
                if (row["agentIdCardNum"] != null)
                {
                    model.agentIdCardNum = row["agentIdCardNum"].ToString();
                }
                if (row["Company"] != null)
                {
                    model.Company = row["Company"].ToString();
                }
                if (row["OpTime"] != null && row["OpTime"].ToString() != "")
                {
                    model.OpTime = DateTime.Parse(row["OpTime"].ToString());
                }
                if (row["County"] != null)
                {
                    model.County = row["County"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["Point"] != null)
                {
                    model.Point = row["Point"].ToString();
                }
                if (row["MachineID"] != null)
                {
                    model.MachineID = row["MachineID"].ToString();
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
            strSql.Append("select ID,SessionID,ClientType,Type,OpContent,Remark,agentName,agentIdCardNum,Company,OpTime,County,Area,Point,MachineID ");
            strSql.Append(" FROM log_worklog ");
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
            strSql.Append("select count(1) FROM log_worklog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySql.GetSingle(strSql.ToString());
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
            strSql.Append(")AS Row, T.*  from log_worklog T ");
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
			parameters[0].Value = "log_worklog";
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

