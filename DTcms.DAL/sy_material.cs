﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using DTcms.DBUtility;
using System.Data;
using DTcms.Common;
namespace DTcms.DAL
{
    /// <summary>
	/// 数据访问类:sy_material
	/// </summary>
	public partial class sy_material
    {
        public sy_material()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MaterialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sy_material");
            strSql.Append(" where MaterialID=?MaterialID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialID", MySqlDbType.VarChar,50)           };
            parameters[0].Value = MaterialID;

            return DbHelperMySql.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DTcms.Model.sy_material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sy_material(");
            strSql.Append("MaterialID,Code,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Deep,Wide,High,Unit,Supplier,State,Remark,Pic,Minimum,TotalTime,IsCanRepair,Appearance)");
            strSql.Append(" values (");
            strSql.Append("?MaterialID,?Code,?MaterialName,?MaterialTypeID,?MaterialType,?SystemNo,?Brand,?Spec,?Deep,?Wide,?High,?Unit,?Supplier,?State,?Remark,?Pic,?Minimum,?TotalTime,?IsCanRepair,?Appearance)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Code", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialType", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SystemNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Brand", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Spec", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Deep", MySqlDbType.Decimal,10),
                    new MySqlParameter("?Wide", MySqlDbType.Decimal,10),
                    new MySqlParameter("?High", MySqlDbType.Decimal,10),
                    new MySqlParameter("?Unit", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Supplier", MySqlDbType.VarChar,50),
                    new MySqlParameter("?State", MySqlDbType.Int32,10),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Pic", MySqlDbType.MediumBlob),
                    new MySqlParameter("?Minimum", MySqlDbType.Decimal,10),
                    new MySqlParameter("?TotalTime", MySqlDbType.Int32,10),
                    new MySqlParameter("?IsCanRepair", MySqlDbType.Int32,10),
                    new MySqlParameter("?Appearance", MySqlDbType.Int32,10)};
            parameters[0].Value = model.MaterialID;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.MaterialName;
            parameters[3].Value = model.MaterialTypeID;
            parameters[4].Value = model.MaterialType;
            parameters[5].Value = model.SystemNo;
            parameters[6].Value = model.Brand;
            parameters[7].Value = model.Spec;
            parameters[8].Value = model.Deep;
            parameters[9].Value = model.Wide;
            parameters[10].Value = model.High;
            parameters[11].Value = model.Unit;
            parameters[12].Value = model.Supplier;
            parameters[13].Value = model.State;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.Pic;
            parameters[16].Value = model.Minimum;
            parameters[17].Value = model.TotalTime;
            parameters[18].Value = model.IsCanRepair;
            parameters[19].Value = model.Appearance;
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
        public bool Update(DTcms.Model.sy_material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sy_material set ");
            strSql.Append("Code=?Code,");
            strSql.Append("MaterialName=?MaterialName,");
            strSql.Append("MaterialTypeID=?MaterialTypeID,");
            strSql.Append("MaterialType=?MaterialType,");
            strSql.Append("SystemNo=?SystemNo,");
            strSql.Append("Brand=?Brand,");
            strSql.Append("Spec=?Spec,");
            strSql.Append("Deep=?Deep,");
            strSql.Append("Wide=?Wide,");
            strSql.Append("High=?High,");
            strSql.Append("Unit=?Unit,");
            strSql.Append("Supplier=?Supplier,");
            strSql.Append("State=?State,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("Pic=?Pic,");
            strSql.Append("Minimum=?Minimum,");
            strSql.Append("TotalTime=?TotalTime,");
            strSql.Append("IsCanRepair=?IsCanRepair,");
            strSql.Append("Appearance=?Appearance");
            strSql.Append(" where MaterialID=?MaterialID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Code", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialTypeID", MySqlDbType.VarChar,50),
                    new MySqlParameter("?MaterialType", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SystemNo", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Brand", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Spec", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Deep", MySqlDbType.Decimal,10),
                    new MySqlParameter("?Wide", MySqlDbType.Decimal,10),
                    new MySqlParameter("?High", MySqlDbType.Decimal,10),
                    new MySqlParameter("?Unit", MySqlDbType.VarChar,50),
                    new MySqlParameter("?Supplier", MySqlDbType.VarChar,50),
                    new MySqlParameter("?State", MySqlDbType.Int32,10),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Pic", MySqlDbType.MediumBlob),
                    new MySqlParameter("?Minimum", MySqlDbType.Decimal,10),
                    new MySqlParameter("?TotalTime", MySqlDbType.Int32,10),
                    new MySqlParameter("?IsCanRepair", MySqlDbType.Int32,10),
                    new MySqlParameter("?Appearance", MySqlDbType.Int32,10),
                    new MySqlParameter("?MaterialID", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.MaterialName;
            parameters[2].Value = model.MaterialTypeID;
            parameters[3].Value = model.MaterialType;
            parameters[4].Value = model.SystemNo;
            parameters[5].Value = model.Brand;
            parameters[6].Value = model.Spec;
            parameters[7].Value = model.Deep;
            parameters[8].Value = model.Wide;
            parameters[9].Value = model.High;
            parameters[10].Value = model.Unit;
            parameters[11].Value = model.Supplier;
            parameters[12].Value = model.State;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.Pic;
            parameters[15].Value = model.Minimum;
            parameters[16].Value = model.TotalTime;
            parameters[17].Value = model.IsCanRepair;
            parameters[18].Value = model.Appearance;
            parameters[19].Value = model.MaterialID;

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
        public bool Delete(string MaterialID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_material ");
            strSql.Append(" where MaterialID=?MaterialID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialID", MySqlDbType.VarChar,50)           };
            parameters[0].Value = MaterialID;

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
        public bool DeleteList(string MaterialIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sy_material ");
            strSql.Append(" where MaterialID in (" + MaterialIDlist + ")  ");
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
        public DTcms.Model.sy_material GetModel(string MaterialID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MaterialID,Code,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Deep,Wide,High,Unit,Supplier,State,Remark,Pic,Minimum,TotalTime,IsCanRepair,Appearance from sy_material ");
            strSql.Append(" where MaterialID=?MaterialID ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?MaterialID", MySqlDbType.VarChar,50)           };
            parameters[0].Value = MaterialID;

            DTcms.Model.sy_material model = new DTcms.Model.sy_material();
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
        public DTcms.Model.sy_material DataRowToModel(DataRow row)
        {
            DTcms.Model.sy_material model = new DTcms.Model.sy_material();
            if (row != null)
            {
                if (row["MaterialID"] != null)
                {
                    model.MaterialID = row["MaterialID"].ToString();
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
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
                if (row["Deep"] != null && row["Deep"].ToString() != "")
                {
                    model.Deep = decimal.Parse(row["Deep"].ToString());
                }
                if (row["Wide"] != null && row["Wide"].ToString() != "")
                {
                    model.Wide = decimal.Parse(row["Wide"].ToString());
                }
                if (row["High"] != null && row["High"].ToString() != "")
                {
                    model.High = decimal.Parse(row["High"].ToString());
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Supplier"] != null)
                {
                    model.Supplier = row["Supplier"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Pic"] != System.DBNull.Value)
                    model.Pic=(byte[])row["Pic"];
                if (row["Minimum"] != null && row["Minimum"].ToString() != "")
                {
                    model.Minimum = decimal.Parse(row["Minimum"].ToString());
                }
                if (row["TotalTime"] != null && row["TotalTime"].ToString() != "")
                {
                    model.TotalTime = int.Parse(row["TotalTime"].ToString());
                }
                if (row["IsCanRepair"] != null && row["IsCanRepair"].ToString() != "")
                {
                    model.IsCanRepair = int.Parse(row["IsCanRepair"].ToString());
                }
                if (row["Appearance"] != null && row["Appearance"].ToString() != "")
                {
                    model.Appearance = int.Parse(row["Appearance"].ToString());
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
            strSql.Append("select MaterialID,Code,MaterialName,MaterialTypeID,MaterialType,SystemNo,Brand,Spec,Deep,Wide,High,Unit,Supplier,State,Remark,Pic,Minimum,TotalTime,IsCanRepair,Appearance ");
            strSql.Append(" FROM sy_material ");
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
            strSql.Append("select count(1) FROM sy_material ");
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
                strSql.Append("order by T.MaterialID desc");
            }
            strSql.Append(")AS Row, T.*  from sy_material T ");
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
			parameters[0].Value = "sy_material";
			parameters[1].Value = "MaterialID";
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
            strSql.Append("select * FROM sy_material");
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
