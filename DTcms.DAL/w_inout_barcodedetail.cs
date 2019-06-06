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
    /// 数据访问类:w_inout_detail
    /// </summary>
    public partial class w_inout_detail
    {
        public w_inout_detail()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from w_inout_detail");
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
        public bool Add(DTcms.Model.w_inout_detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into w_inout_detail(");
            strSql.Append("FK_BillID,FK_SendBillNum,FK_ApproveNum,BarCode,BatchNumber,MaterialID,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Unit,Num,IOFlag,InOutType,FK_ShelfID,X,Y,WorkTime,OperatorName,OperatorTime,InOutRemark)");
            strSql.Append(" values (");
            strSql.Append("?FK_BillID,?FK_SendBillNum,?FK_ApproveNum,?BarCode,?BatchNumber,?MaterialID,?MaterialName,?MaterialTypeID,?MaterialType,?SystemNo,?Brand,?Spec,?Unit,?Num,?IOFlag,?InOutType,?FK_ShelfID,?X,?Y,?WorkTime,?OperatorName,?OperatorTime,?InOutRemark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?FK_BillID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?FK_SendBillNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?FK_ApproveNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BarCode", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BatchNumber", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialType", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SystemNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Brand", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Spec", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Unit", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Num", MySqlDbType.Decimal,18),
                    new MySqlParameter("?IOFlag", MySqlDbType.Int32,11),
                    new MySqlParameter("?InOutType", MySqlDbType.VarChar,255),
                    new MySqlParameter("?FK_ShelfID", MySqlDbType.Int32,50),
                    new MySqlParameter("?X", MySqlDbType.Int32,10),
                    new MySqlParameter("?Y", MySqlDbType.Int32,10),
                    new MySqlParameter("?WorkTime", MySqlDbType.Int32,10),
                    new MySqlParameter("?OperatorName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OperatorTime", MySqlDbType.Datetime),
                    new MySqlParameter("?InOutRemark", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.FK_BillID;
            parameters[1].Value = model.FK_SendBillNum;
            parameters[2].Value = model.FK_ApproveNum;
            parameters[3].Value = model.BarCode;
            parameters[4].Value = model.BatchNumber;
            parameters[5].Value = model.MaterialID;
            parameters[6].Value = model.MaterialName;
            parameters[7].Value = model.MaterialTypeID;
            parameters[8].Value = model.MaterialType;
            parameters[9].Value = model.SystemNo;
            parameters[10].Value = model.Brand;
            parameters[11].Value = model.Spec;
            parameters[12].Value = model.Unit;
            parameters[13].Value = model.Num;
            parameters[14].Value = model.IOFlag;
            parameters[15].Value = model.InOutType;
            parameters[16].Value = model.FK_ShelfID;
            parameters[17].Value = model.X;
            parameters[18].Value = model.Y;
            parameters[19].Value = model.WorkTime;
            parameters[20].Value = model.OperatorName;
            parameters[21].Value = model.OperatorTime;
            parameters[22].Value = model.InOutRemark;

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
        public bool Update(DTcms.Model.w_inout_detail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update w_inout_detail set ");
            strSql.Append("FK_BillID=?FK_BillID,");
            strSql.Append("FK_SendBillNum=?FK_SendBillNum,");
            strSql.Append("FK_ApproveNum=?FK_ApproveNum,");
            strSql.Append("BarCode=?BarCode,");
            strSql.Append("BatchNumber=?BatchNumber,");
            strSql.Append("MaterialID=?MaterialID,");
            strSql.Append("MaterialName=?MaterialName,");
            strSql.Append("MaterialTypeID=?MaterialTypeID,");
            strSql.Append("MaterialType=?MaterialType,");
            strSql.Append("SystemNo=?SystemNo,");
            strSql.Append("Brand=?Brand,");
            strSql.Append("Spec=?Spec,");
            strSql.Append("Unit=?Unit,");
            strSql.Append("Num=?Num,");
            strSql.Append("IOFlag=?IOFlag,");
            strSql.Append("InOutType=?InOutType,");
            strSql.Append("FK_ShelfID=?FK_ShelfID,");
            strSql.Append("X=?X,");
            strSql.Append("Y=?Y,");
            strSql.Append("WorkTime=?WorkTime,");
            strSql.Append("OperatorName=?OperatorName,");
            strSql.Append("OperatorTime=?OperatorTime,");
            strSql.Append("InOutRemark=?InOutRemark");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?FK_BillID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?FK_SendBillNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?FK_ApproveNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BarCode", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BatchNumber", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialType", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SystemNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Brand", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Spec", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Unit", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Num", MySqlDbType.Decimal,18),
                    new MySqlParameter("?IOFlag", MySqlDbType.Int32,11),
                    new MySqlParameter("?InOutType", MySqlDbType.VarChar,255),
                    new MySqlParameter("?FK_ShelfID", MySqlDbType.Int32,50),
                    new MySqlParameter("?X", MySqlDbType.Int32,10),
                    new MySqlParameter("?Y", MySqlDbType.Int32,10),
                    new MySqlParameter("?WorkTime", MySqlDbType.Int32,10),
                    new MySqlParameter("?OperatorName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?OperatorTime", MySqlDbType.Datetime),
                    new MySqlParameter("?InOutRemark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?ID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.FK_BillID;
            parameters[1].Value = model.FK_SendBillNum;
            parameters[2].Value = model.FK_ApproveNum;
            parameters[3].Value = model.BarCode;
            parameters[4].Value = model.BatchNumber;
            parameters[5].Value = model.MaterialID;
            parameters[6].Value = model.MaterialName;
            parameters[7].Value = model.MaterialTypeID;
            parameters[8].Value = model.MaterialType;
            parameters[9].Value = model.SystemNo;
            parameters[10].Value = model.Brand;
            parameters[11].Value = model.Spec;
            parameters[12].Value = model.Unit;
            parameters[13].Value = model.Num;
            parameters[14].Value = model.IOFlag;
            parameters[15].Value = model.InOutType;
            parameters[16].Value = model.FK_ShelfID;
            parameters[17].Value = model.X;
            parameters[18].Value = model.Y;
            parameters[19].Value = model.WorkTime;
            parameters[20].Value = model.OperatorName;
            parameters[21].Value = model.OperatorTime;
            parameters[22].Value = model.InOutRemark;
            parameters[23].Value = model.ID;

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
            strSql.Append("delete from w_inout_detail ");
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
            strSql.Append("delete from w_inout_detail ");
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
        public DTcms.Model.w_inout_detail GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,FK_BillID,FK_SendBillNum,FK_ApproveNum,BarCode,BatchNumber,MaterialID,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Unit,Num,IOFlag,InOutType,FK_ShelfID,X,Y,WorkTime,OperatorName,OperatorTime,InOutRemark from w_inout_detail ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            DTcms.Model.w_inout_detail model = new DTcms.Model.w_inout_detail();
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
        public DTcms.Model.w_inout_detail DataRowToModel(DataRow row)
        {
            DTcms.Model.w_inout_detail model = new DTcms.Model.w_inout_detail();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["FK_BillID"] != null)
                {
                    model.FK_BillID = row["FK_BillID"].ToString();
                }
                if (row["FK_SendBillNum"] != null)
                {
                    model.FK_SendBillNum = row["FK_SendBillNum"].ToString();
                }
                if (row["FK_ApproveNum"] != null)
                {
                    model.FK_ApproveNum = row["FK_ApproveNum"].ToString();
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["BatchNumber"] != null)
                {
                    model.BatchNumber = row["BatchNumber"].ToString();
                }
                if (row["MaterialID"] != null)
                {
                    model.MaterialID = row["MaterialID"].ToString();
                }
                if (row["MaterialName"] != null)
                {
                    model.MaterialName = row["MaterialName"].ToString();
                }
                if (row["MaterialTypeID"] != null)
                {
                    model.MaterialTypeID = row["MaterialTypeID"].ToString();
                }
                if (row["MaterialType"] != null)
                {
                    model.MaterialType = row["MaterialType"].ToString();
                }
                if (row["SystemNo"] != null)
                {
                    model.SystemNo = row["SystemNo"].ToString();
                }
                if (row["Brand"] != null)
                {
                    model.Brand = row["Brand"].ToString();
                }
                if (row["Spec"] != null)
                {
                    model.Spec = row["Spec"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Num"] != null && row["Num"].ToString() != "")
                {
                    model.Num = decimal.Parse(row["Num"].ToString());
                }
                if (row["IOFlag"] != null && row["IOFlag"].ToString() != "")
                {
                    model.IOFlag = int.Parse(row["IOFlag"].ToString());
                }
                if (row["InOutType"] != null)
                {
                    model.InOutType = row["InOutType"].ToString();
                }
                if (row["FK_ShelfID"] != null && row["FK_ShelfID"].ToString() != "")
                {
                    model.FK_ShelfID = int.Parse(row["FK_ShelfID"].ToString());
                }
                if (row["X"] != null && row["X"].ToString() != "")
                {
                    model.X = int.Parse(row["X"].ToString());
                }
                if (row["Y"] != null && row["Y"].ToString() != "")
                {
                    model.Y = int.Parse(row["Y"].ToString());
                }
                if (row["WorkTime"] != null && row["WorkTime"].ToString() != "")
                {
                    model.WorkTime = int.Parse(row["WorkTime"].ToString());
                }
                if (row["OperatorName"] != null)
                {
                    model.OperatorName = row["OperatorName"].ToString();
                }
                if (row["OperatorTime"] != null && row["OperatorTime"].ToString() != "")
                {
                    model.OperatorTime = DateTime.Parse(row["OperatorTime"].ToString());
                }
                if (row["InOutRemark"] != null)
                {
                    model.InOutRemark = row["InOutRemark"].ToString();
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
            strSql.Append("select ID,FK_BillID,FK_SendBillNum,FK_ApproveNum,BarCode,BatchNumber,MaterialID,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Unit,Num,IOFlag,InOutType,FK_ShelfID,X,Y,WorkTime,OperatorName,OperatorTime,InOutRemark ");
            strSql.Append(" FROM w_inout_detail ");
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
            strSql.Append("select count(1) FROM w_inout_detail ");
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
            strSql.Append(")AS Row, T.*  from w_inout_detail T ");
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
			parameters[0].Value = "w_inout_detail";
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