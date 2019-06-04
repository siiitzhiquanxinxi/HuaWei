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
	/// 数据访问类:w_inout_barcodedetail
	/// </summary>
	public partial class w_inout_barcodedetail
    {
        public w_inout_barcodedetail()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from w_inout_barcodedetail");
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
        public bool Add(DTcms.Model.w_inout_barcodedetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into w_inout_barcodedetail(");
            strSql.Append("BillID,BarCode,BatchNumber,MaterialID,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Unit,Num,IOFlag,ShelfID,CabinetNo,BoxNo,X,Y,WorkTime)");
            strSql.Append(" values (");
            strSql.Append("?BillID,?BarCode,?BatchNumber,?MaterialID,?MaterialName,?MaterialTypeID,?MaterialType,?SystemNo,?Brand,?Spec,?Unit,?Num,?IOFlag,?ShelfID,?CabinetNo,?BoxNo,?X,?Y,?WorkTime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BillID", MySqlDbType.VarChar,50),
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
                    new MySqlParameter("?ShelfID", MySqlDbType.Int32,50),
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BoxNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?X", MySqlDbType.Int32,10),
                    new MySqlParameter("?Y", MySqlDbType.Int32,10),
                    new MySqlParameter("?WorkTime", MySqlDbType.Int32,10)};
            parameters[0].Value = model.BillID;
            parameters[1].Value = model.BarCode;
            parameters[2].Value = model.BatchNumber;
            parameters[3].Value = model.MaterialID;
            parameters[4].Value = model.MaterialName;
            parameters[5].Value = model.MaterialTypeID;
            parameters[6].Value = model.MaterialType;
            parameters[7].Value = model.SystemNo;
            parameters[8].Value = model.Brand;
            parameters[9].Value = model.Spec;
            parameters[10].Value = model.Unit;
            parameters[11].Value = model.Num;
            parameters[12].Value = model.IOFlag;
            parameters[13].Value = model.ShelfID;
            parameters[14].Value = model.CabinetNo;
            parameters[15].Value = model.BoxNo;
            parameters[16].Value = model.X;
            parameters[17].Value = model.Y;
            parameters[18].Value = model.WorkTime;

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
        public bool Update(DTcms.Model.w_inout_barcodedetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update w_inout_barcodedetail set ");
            strSql.Append("BillID=?BillID,");
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
            strSql.Append("ShelfID=?ShelfID,");
            strSql.Append("CabinetNo=?CabinetNo,");
            strSql.Append("BoxNo=?BoxNo,");
            strSql.Append("X=?X,");
            strSql.Append("Y=?Y,");
            strSql.Append("WorkTime=?WorkTime");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BillID", MySqlDbType.VarChar,50),
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
                    new MySqlParameter("?ShelfID", MySqlDbType.Int32,50),
                    new MySqlParameter("?CabinetNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BoxNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?X", MySqlDbType.Int32,10),
                    new MySqlParameter("?Y", MySqlDbType.Int32,10),
                    new MySqlParameter("?WorkTime", MySqlDbType.Int32,10),
                    new MySqlParameter("?ID", MySqlDbType.Int32,11)};
            parameters[0].Value = model.BillID;
            parameters[1].Value = model.BarCode;
            parameters[2].Value = model.BatchNumber;
            parameters[3].Value = model.MaterialID;
            parameters[4].Value = model.MaterialName;
            parameters[5].Value = model.MaterialTypeID;
            parameters[6].Value = model.MaterialType;
            parameters[7].Value = model.SystemNo;
            parameters[8].Value = model.Brand;
            parameters[9].Value = model.Spec;
            parameters[10].Value = model.Unit;
            parameters[11].Value = model.Num;
            parameters[12].Value = model.IOFlag;
            parameters[13].Value = model.ShelfID;
            parameters[14].Value = model.CabinetNo;
            parameters[15].Value = model.BoxNo;
            parameters[16].Value = model.X;
            parameters[17].Value = model.Y;
            parameters[18].Value = model.WorkTime;
            parameters[19].Value = model.ID;

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
            strSql.Append("delete from w_inout_barcodedetail ");
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
            strSql.Append("delete from w_inout_barcodedetail ");
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
        public DTcms.Model.w_inout_barcodedetail GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BillID,BarCode,BatchNumber,MaterialID,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Unit,Num,IOFlag,ShelfID,CabinetNo,BoxNo,X,Y,WorkTime from w_inout_barcodedetail ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ID", MySqlDbType.Int32)
            };
            parameters[0].Value = ID;

            DTcms.Model.w_inout_barcodedetail model = new DTcms.Model.w_inout_barcodedetail();
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
        public DTcms.Model.w_inout_barcodedetail DataRowToModel(DataRow row)
        {
            DTcms.Model.w_inout_barcodedetail model = new DTcms.Model.w_inout_barcodedetail();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["BillID"] != null)
                {
                    model.BillID = row["BillID"].ToString();
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
                if (row["ShelfID"] != null && row["ShelfID"].ToString() != "")
                {
                    model.ShelfID = int.Parse(row["ShelfID"].ToString());
                }
                if (row["CabinetNo"] != null)
                {
                    model.CabinetNo = row["CabinetNo"].ToString();
                }
                if (row["BoxNo"] != null)
                {
                    model.BoxNo = row["BoxNo"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BillID,BarCode,BatchNumber,MaterialID,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Unit,Num,IOFlag,ShelfID,CabinetNo,BoxNo,X,Y,WorkTime ");
            strSql.Append(" FROM w_inout_barcodedetail ");
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
            strSql.Append("select count(1) FROM w_inout_barcodedetail ");
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
            strSql.Append(")AS Row, T.*  from w_inout_barcodedetail T ");
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
			parameters[0].Value = "w_inout_barcodedetail";
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
