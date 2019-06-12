using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:w_approvelist
    /// </summary>
    public partial class w_approvelist
    {
        public w_approvelist()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ApproveNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from w_approvelist");
            strSql.Append(" where ApproveNum=?ApproveNum ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ApproveNum", MySqlDbType.VarChar,255)          };
            parameters[0].Value = ApproveNum;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.w_approvelist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into w_approvelist(");
            strSql.Append("ApproveNum,CreateDate,CreateById,CreateByName,ApplyRemark,IsPlanApprove,ApproveState,ApplyPartNum,ApplyToolName,ApplyWorkTime,ApplyToolLevel,ApplyOldToolBarCode,ApproveById,ApproveByName,ApproveDate,ApproveNewToolBarCode,ApproveRemark)");
            strSql.Append(" values (");
            strSql.Append("?ApproveNum,?CreateDate,?CreateById,?CreateByName,?ApplyRemark,?IsPlanApprove,?ApproveState,?ApplyPartNum,?ApplyToolName,?ApplyWorkTime,?ApplyToolLevel,?ApplyOldToolBarCode,?ApproveById,?ApproveByName,?ApproveDate,?ApproveNewToolBarCode,?ApproveRemark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ApproveNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?CreateDate", MySqlDbType.Datetime),
                    new MySqlParameter("?CreateById", MySqlDbType.Int32,255),
                    new MySqlParameter("?CreateByName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyRemark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?IsPlanApprove", MySqlDbType.Int32,255),
                    new MySqlParameter("?ApproveState", MySqlDbType.Int32,11),
                    new MySqlParameter("?ApplyPartNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyToolName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyWorkTime", MySqlDbType.Int32,11),
                    new MySqlParameter("?ApplyToolLevel", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyOldToolBarCode", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApproveById", MySqlDbType.Int32,11),
                    new MySqlParameter("?ApproveByName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApproveDate", MySqlDbType.Datetime),
                    new MySqlParameter("?ApproveNewToolBarCode", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApproveRemark", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.ApproveNum;
            parameters[1].Value = model.CreateDate;
            parameters[2].Value = model.CreateById;
            parameters[3].Value = model.CreateByName;
            parameters[4].Value = model.ApplyRemark;
            parameters[5].Value = model.IsPlanApprove;
            parameters[6].Value = model.ApproveState;
            parameters[7].Value = model.ApplyPartNum;
            parameters[8].Value = model.ApplyToolName;
            parameters[9].Value = model.ApplyWorkTime;
            parameters[10].Value = model.ApplyToolLevel;
            parameters[11].Value = model.ApplyOldToolBarCode;
            parameters[12].Value = model.ApproveById;
            parameters[13].Value = model.ApproveByName;
            parameters[14].Value = model.ApproveDate;
            parameters[15].Value = model.ApproveNewToolBarCode;
            parameters[16].Value = model.ApproveRemark;

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
        public bool Update(DTcms.Model.w_approvelist model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update w_approvelist set ");
            strSql.Append("CreateDate=?CreateDate,");
            strSql.Append("CreateById=?CreateById,");
            strSql.Append("CreateByName=?CreateByName,");
            strSql.Append("ApplyRemark=?ApplyRemark,");
            strSql.Append("IsPlanApprove=?IsPlanApprove,");
            strSql.Append("ApproveState=?ApproveState,");
            strSql.Append("ApplyPartNum=?ApplyPartNum,");
            strSql.Append("ApplyToolName=?ApplyToolName,");
            strSql.Append("ApplyWorkTime=?ApplyWorkTime,");
            strSql.Append("ApplyToolLevel=?ApplyToolLevel,");
            strSql.Append("ApplyOldToolBarCode=?ApplyOldToolBarCode,");
            strSql.Append("ApproveById=?ApproveById,");
            strSql.Append("ApproveByName=?ApproveByName,");
            strSql.Append("ApproveDate=?ApproveDate,");
            strSql.Append("ApproveNewToolBarCode=?ApproveNewToolBarCode,");
            strSql.Append("ApproveRemark=?ApproveRemark");
            strSql.Append(" where ApproveNum=?ApproveNum ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?CreateDate", MySqlDbType.Datetime),
                    new MySqlParameter("?CreateById", MySqlDbType.Int32,255),
                    new MySqlParameter("?CreateByName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyRemark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?IsPlanApprove", MySqlDbType.Int32,255),
                    new MySqlParameter("?ApproveState", MySqlDbType.Int32,11),
                    new MySqlParameter("?ApplyPartNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyToolName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyWorkTime", MySqlDbType.Int32,11),
                    new MySqlParameter("?ApplyToolLevel", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApplyOldToolBarCode", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApproveById", MySqlDbType.Int32,11),
                    new MySqlParameter("?ApproveByName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApproveDate", MySqlDbType.Datetime),
                    new MySqlParameter("?ApproveNewToolBarCode", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApproveRemark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ApproveNum", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.CreateDate;
            parameters[1].Value = model.CreateById;
            parameters[2].Value = model.CreateByName;
            parameters[3].Value = model.ApplyRemark;
            parameters[4].Value = model.IsPlanApprove;
            parameters[5].Value = model.ApproveState;
            parameters[6].Value = model.ApplyPartNum;
            parameters[7].Value = model.ApplyToolName;
            parameters[8].Value = model.ApplyWorkTime;
            parameters[9].Value = model.ApplyToolLevel;
            parameters[10].Value = model.ApplyOldToolBarCode;
            parameters[11].Value = model.ApproveById;
            parameters[12].Value = model.ApproveByName;
            parameters[13].Value = model.ApproveDate;
            parameters[14].Value = model.ApproveNewToolBarCode;
            parameters[15].Value = model.ApproveRemark;
            parameters[16].Value = model.ApproveNum;

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
        public bool Delete(string ApproveNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from w_approvelist ");
            strSql.Append(" where ApproveNum=?ApproveNum ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ApproveNum", MySqlDbType.VarChar,255)          };
            parameters[0].Value = ApproveNum;

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
        public bool DeleteList(string ApproveNumlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from w_approvelist ");
            strSql.Append(" where ApproveNum in (" + ApproveNumlist + ")  ");
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
        public DTcms.Model.w_approvelist GetModel(string ApproveNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ApproveNum,CreateDate,CreateById,CreateByName,ApplyRemark,IsPlanApprove,ApproveState,ApplyPartNum,ApplyToolName,ApplyWorkTime,ApplyToolLevel,ApplyOldToolBarCode,ApproveById,ApproveByName,ApproveDate,ApproveNewToolBarCode,ApproveRemark from w_approvelist ");
            strSql.Append(" where ApproveNum=?ApproveNum ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ApproveNum", MySqlDbType.VarChar,255)          };
            parameters[0].Value = ApproveNum;

            DTcms.Model.w_approvelist model = new DTcms.Model.w_approvelist();
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
        public DTcms.Model.w_approvelist DataRowToModel(DataRow row)
        {
            DTcms.Model.w_approvelist model = new DTcms.Model.w_approvelist();
            if (row != null)
            {
                if (row["ApproveNum"] != null)
                {
                    model.ApproveNum = row["ApproveNum"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CreateById"] != null && row["CreateById"].ToString() != "")
                {
                    model.CreateById = int.Parse(row["CreateById"].ToString());
                }
                if (row["CreateByName"] != null)
                {
                    model.CreateByName = row["CreateByName"].ToString();
                }
                if (row["ApplyRemark"] != null)
                {
                    model.ApplyRemark = row["ApplyRemark"].ToString();
                }
                if (row["IsPlanApprove"] != null && row["IsPlanApprove"].ToString() != "")
                {
                    model.IsPlanApprove = int.Parse(row["IsPlanApprove"].ToString());
                }
                if (row["ApproveState"] != null && row["ApproveState"].ToString() != "")
                {
                    model.ApproveState = int.Parse(row["ApproveState"].ToString());
                }
                if (row["ApplyPartNum"] != null)
                {
                    model.ApplyPartNum = row["ApplyPartNum"].ToString();
                }
                if (row["ApplyToolName"] != null)
                {
                    model.ApplyToolName = row["ApplyToolName"].ToString();
                }
                if (row["ApplyWorkTime"] != null && row["ApplyWorkTime"].ToString() != "")
                {
                    model.ApplyWorkTime = int.Parse(row["ApplyWorkTime"].ToString());
                }
                if (row["ApplyToolLevel"] != null)
                {
                    model.ApplyToolLevel = row["ApplyToolLevel"].ToString();
                }
                if (row["ApplyOldToolBarCode"] != null)
                {
                    model.ApplyOldToolBarCode = row["ApplyOldToolBarCode"].ToString();
                }
                if (row["ApproveById"] != null && row["ApproveById"].ToString() != "")
                {
                    model.ApproveById = int.Parse(row["ApproveById"].ToString());
                }
                if (row["ApproveByName"] != null)
                {
                    model.ApproveByName = row["ApproveByName"].ToString();
                }
                if (row["ApproveDate"] != null && row["ApproveDate"].ToString() != "")
                {
                    model.ApproveDate = DateTime.Parse(row["ApproveDate"].ToString());
                }
                if (row["ApproveNewToolBarCode"] != null)
                {
                    model.ApproveNewToolBarCode = row["ApproveNewToolBarCode"].ToString();
                }
                if (row["ApproveRemark"] != null)
                {
                    model.ApproveRemark = row["ApproveRemark"].ToString();
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
            strSql.Append("select ApproveNum,CreateDate,CreateById,CreateByName,ApplyRemark,IsPlanApprove,ApproveState,ApplyPartNum,ApplyToolName,ApplyWorkTime,ApplyToolLevel,ApplyOldToolBarCode,ApproveById,ApproveByName,ApproveDate,ApproveNewToolBarCode,ApproveRemark ");
            strSql.Append(" FROM w_approvelist ");
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
            strSql.Append("select count(1) FROM w_approvelist ");
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
                strSql.Append("order by T.ApproveNum desc");
            }
            strSql.Append(")AS Row, T.*  from w_approvelist T ");
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
			parameters[0].Value = "w_approvelist";
			parameters[1].Value = "ApproveNum";
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

