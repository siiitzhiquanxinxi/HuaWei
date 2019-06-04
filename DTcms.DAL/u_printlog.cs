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
    /// 数据访问类:u_printlog
    /// </summary>
    public partial class u_printlog
    {
        public u_printlog()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from u_printlog");
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
        public bool Add(Model.u_printlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into u_printlog(");
            strSql.Append("legalpersonName,legalpersonIdCardNum,agentName,agentIdCardNum,companyName,socialNum,printZhengbendate,printFubenDate,PicIDcardFace,PicFinger,PicFaceRGB,PicFaceIR,PicTakeAway,RGBScore,IRScore,CompareScore,BussinessType,Remark,PrinterType,UploadDatetime1,UploadDatetime2,County,Point,Area,MachineId,SessionId,CreateSessionDate,IsZhengbenLightCheck,IsFubenLightCheck,IsZhengbenTCPIP,IsFubenTCPIP,IsZhengbenPrintCheck,IsFubenPrintCheck,IsZhengbenSuccessed,IsFubenSuccessed,FubenCount)");
            strSql.Append(" values (");
            strSql.Append("?legalpersonName,?legalpersonIdCardNum,?agentName,?agentIdCardNum,?companyName,?socialNum,?printZhengbendate,?printFubenDate,?PicIDcardFace,?PicFinger,?PicFaceRGB,?PicFaceIR,?PicTakeAway,?RGBScore,?IRScore,?CompareScore,?BussinessType,?Remark,?PrinterType,?UploadDatetime1,?UploadDatetime2,?County,?Point,?Area,?MachineId,?SessionId,?CreateSessionDate,?IsZhengbenLightCheck,?IsFubenLightCheck,?IsZhengbenTCPIP,?IsFubenTCPIP,?IsZhengbenPrintCheck,?IsFubenPrintCheck,?IsZhengbenSuccessed,?IsFubenSuccessed,?FubenCount)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?legalpersonName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?legalpersonIdCardNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentIdCardNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?companyName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?socialNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?printZhengbendate", MySqlDbType.Datetime),
                    new MySqlParameter("?printFubenDate", MySqlDbType.Datetime),
                    new MySqlParameter("?PicIDcardFace", MySqlDbType.MediumBlob),
                    new MySqlParameter("?PicFinger", MySqlDbType.MediumBlob),
                    new MySqlParameter("?PicFaceRGB", MySqlDbType.MediumBlob),
                    new MySqlParameter("?PicFaceIR", MySqlDbType.MediumBlob),
                    new MySqlParameter("?PicTakeAway", MySqlDbType.MediumBlob),
                    new MySqlParameter("?RGBScore", MySqlDbType.VarChar,255),
                    new MySqlParameter("?IRScore", MySqlDbType.VarChar,255),
                    new MySqlParameter("?CompareScore", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BussinessType", MySqlDbType.Int32,11),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?PrinterType", MySqlDbType.Int32,11),
                    new MySqlParameter("?UploadDatetime1", MySqlDbType.Datetime),
                    new MySqlParameter("?UploadDatetime2", MySqlDbType.Datetime),
                    new MySqlParameter("?County", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Point", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Area", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MachineId", MySqlDbType.VarChar,255),
                    new MySqlParameter("?SessionId", MySqlDbType.VarChar,255),
                    new MySqlParameter("?CreateSessionDate", MySqlDbType.Datetime),
                    new MySqlParameter("?IsZhengbenLightCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenLightCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsZhengbenTCPIP", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenTCPIP", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsZhengbenPrintCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenPrintCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsZhengbenSuccessed", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenSuccessed", MySqlDbType.Int32,11),
                    new MySqlParameter("?FubenCount", MySqlDbType.Int32,11)};
            parameters[0].Value = model.legalpersonName;
            parameters[1].Value = model.legalpersonIdCardNum;
            parameters[2].Value = model.agentName;
            parameters[3].Value = model.agentIdCardNum;
            parameters[4].Value = model.companyName;
            parameters[5].Value = model.socialNum;
            parameters[6].Value = model.printZhengbendate;
            parameters[7].Value = model.printFubenDate;
            parameters[8].Value = model.PicIDcardFace;
            parameters[9].Value = model.PicFinger;
            parameters[10].Value = model.PicFaceRGB;
            parameters[11].Value = model.PicFaceIR;
            parameters[12].Value = model.PicTakeAway;
            parameters[13].Value = model.RGBScore;
            parameters[14].Value = model.IRScore;
            parameters[15].Value = model.CompareScore;
            parameters[16].Value = model.BussinessType;
            parameters[17].Value = model.Remark;
            parameters[18].Value = model.PrinterType;
            parameters[19].Value = model.UploadDatetime1;
            parameters[20].Value = model.UploadDatetime2;
            parameters[21].Value = model.County;
            parameters[22].Value = model.Point;
            parameters[23].Value = model.Area;
            parameters[24].Value = model.MachineId;
            parameters[25].Value = model.SessionId;
            parameters[26].Value = model.CreateSessionDate;
            parameters[27].Value = model.IsZhengbenLightCheck;
            parameters[28].Value = model.IsFubenLightCheck;
            parameters[29].Value = model.IsZhengbenTCPIP;
            parameters[30].Value = model.IsFubenTCPIP;
            parameters[31].Value = model.IsZhengbenPrintCheck;
            parameters[32].Value = model.IsFubenPrintCheck;
            parameters[33].Value = model.IsZhengbenSuccessed;
            parameters[34].Value = model.IsFubenSuccessed;
            parameters[35].Value = model.FubenCount;

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
        public bool Update(Model.u_printlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update u_printlog set ");
            strSql.Append("legalpersonName=?legalpersonName,");
            strSql.Append("legalpersonIdCardNum=?legalpersonIdCardNum,");
            strSql.Append("agentName=?agentName,");
            strSql.Append("agentIdCardNum=?agentIdCardNum,");
            strSql.Append("companyName=?companyName,");
            strSql.Append("socialNum=?socialNum,");
            strSql.Append("printZhengbendate=?printZhengbendate,");
            strSql.Append("printFubenDate=?printFubenDate,");
            //strSql.Append("PicIDcardFace=?PicIDcardFace,");
            //strSql.Append("PicFinger=?PicFinger,");
            //strSql.Append("PicFaceRGB=?PicFaceRGB,");
            //strSql.Append("PicFaceIR=?PicFaceIR,");
            //strSql.Append("PicTakeAway=?PicTakeAway,");
            strSql.Append("RGBScore=?RGBScore,");
            strSql.Append("IRScore=?IRScore,");
            strSql.Append("CompareScore=?CompareScore,");
            strSql.Append("BussinessType=?BussinessType,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("PrinterType=?PrinterType,");
            strSql.Append("UploadDatetime1=?UploadDatetime1,");
            strSql.Append("UploadDatetime2=?UploadDatetime2,");
            strSql.Append("County=?County,");
            strSql.Append("Point=?Point,");
            strSql.Append("Area=?Area,");
            strSql.Append("MachineId=?MachineId,");
            strSql.Append("SessionId=?SessionId,");
            strSql.Append("CreateSessionDate=?CreateSessionDate,");
            strSql.Append("IsZhengbenLightCheck=?IsZhengbenLightCheck,");
            strSql.Append("IsFubenLightCheck=?IsFubenLightCheck,");
            strSql.Append("IsZhengbenTCPIP=?IsZhengbenTCPIP,");
            strSql.Append("IsFubenTCPIP=?IsFubenTCPIP,");
            strSql.Append("IsZhengbenPrintCheck=?IsZhengbenPrintCheck,");
            strSql.Append("IsFubenPrintCheck=?IsFubenPrintCheck,");
            strSql.Append("IsZhengbenSuccessed=?IsZhengbenSuccessed,");
            strSql.Append("IsFubenSuccessed=?IsFubenSuccessed,");
            strSql.Append("FubenCount=?FubenCount");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?legalpersonName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?legalpersonIdCardNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?agentIdCardNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?companyName", MySqlDbType.VarChar,255),
                    new MySqlParameter("?socialNum", MySqlDbType.VarChar,255),
                    new MySqlParameter("?printZhengbendate", MySqlDbType.Datetime),
                    new MySqlParameter("?printFubenDate", MySqlDbType.Datetime),
                    //new MySqlParameter("?PicIDcardFace", MySqlDbType.MediumBlob),
                    //new MySqlParameter("?PicFinger", MySqlDbType.MediumBlob),
                    //new MySqlParameter("?PicFaceRGB", MySqlDbType.MediumBlob),
                    //new MySqlParameter("?PicFaceIR", MySqlDbType.MediumBlob),
                    //new MySqlParameter("?PicTakeAway", MySqlDbType.MediumBlob),
                    new MySqlParameter("?RGBScore", MySqlDbType.VarChar,255),
                    new MySqlParameter("?IRScore", MySqlDbType.VarChar,255),
                    new MySqlParameter("?CompareScore", MySqlDbType.VarChar,255),
                    new MySqlParameter("?BussinessType", MySqlDbType.Int32,11),
                    new MySqlParameter("?Remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("?PrinterType", MySqlDbType.Int32,11),
                    new MySqlParameter("?UploadDatetime1", MySqlDbType.Datetime),
                    new MySqlParameter("?UploadDatetime2", MySqlDbType.Datetime),
                    new MySqlParameter("?County", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Point", MySqlDbType.VarChar,255),
                    new MySqlParameter("?Area", MySqlDbType.VarChar,255),
                    new MySqlParameter("?MachineId", MySqlDbType.VarChar,255),
                    new MySqlParameter("?SessionId", MySqlDbType.VarChar,255),
                    new MySqlParameter("?CreateSessionDate", MySqlDbType.Datetime),
                    new MySqlParameter("?IsZhengbenLightCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenLightCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsZhengbenTCPIP", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenTCPIP", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsZhengbenPrintCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenPrintCheck", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsZhengbenSuccessed", MySqlDbType.Int32,11),
                    new MySqlParameter("?IsFubenSuccessed", MySqlDbType.Int32,11),
                    new MySqlParameter("?FubenCount", MySqlDbType.Int32,11),
                    new MySqlParameter("?Id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.legalpersonName;
            parameters[1].Value = model.legalpersonIdCardNum;
            parameters[2].Value = model.agentName;
            parameters[3].Value = model.agentIdCardNum;
            parameters[4].Value = model.companyName;
            parameters[5].Value = model.socialNum;
            parameters[6].Value = model.printZhengbendate;
            parameters[7].Value = model.printFubenDate;
            //parameters[8].Value = model.PicIDcardFace;
            //parameters[9].Value = model.PicFinger;
            //parameters[10].Value = model.PicFaceRGB;
            //parameters[11].Value = model.PicFaceIR;
            //parameters[12].Value = model.PicTakeAway;
            parameters[8].Value = model.RGBScore;
            parameters[9].Value = model.IRScore;
            parameters[10].Value = model.CompareScore;
            parameters[11].Value = model.BussinessType;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.PrinterType;
            parameters[14].Value = model.UploadDatetime1;
            parameters[15].Value = model.UploadDatetime2;
            parameters[16].Value = model.County;
            parameters[17].Value = model.Point;
            parameters[18].Value = model.Area;
            parameters[19].Value = model.MachineId;
            parameters[20].Value = model.SessionId;
            parameters[21].Value = model.CreateSessionDate;
            parameters[22].Value = model.IsZhengbenLightCheck;
            parameters[23].Value = model.IsFubenLightCheck;
            parameters[24].Value = model.IsZhengbenTCPIP;
            parameters[25].Value = model.IsFubenTCPIP;
            parameters[26].Value = model.IsZhengbenPrintCheck;
            parameters[27].Value = model.IsFubenPrintCheck;
            parameters[28].Value = model.IsZhengbenSuccessed;
            parameters[29].Value = model.IsFubenSuccessed;
            parameters[30].Value = model.FubenCount;
            parameters[31].Value = model.Id;

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
            strSql.Append("delete from u_printlog ");
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
            strSql.Append("delete from u_printlog ");
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
        public Model.u_printlog GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,legalpersonName,legalpersonIdCardNum,agentName,agentIdCardNum,companyName,socialNum,printZhengbendate,printFubenDate,PicIDcardFace,PicFinger,PicFaceRGB,PicFaceIR,PicTakeAway,RGBScore,IRScore,CompareScore,BussinessType,Remark,PrinterType,UploadDatetime1,UploadDatetime2,County,Point,Area,MachineId,SessionId,CreateSessionDate,IsZhengbenLightCheck,IsFubenLightCheck,IsZhengbenTCPIP,IsFubenTCPIP,IsZhengbenPrintCheck,IsFubenPrintCheck,IsZhengbenSuccessed,IsFubenSuccessed,FubenCount from u_printlog ");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?Id", MySqlDbType.Int32)
            };
            parameters[0].Value = Id;

            Model.u_printlog model = new Model.u_printlog();
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
        public Model.u_printlog GetModelBySession(string sessionid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,legalpersonName,legalpersonIdCardNum,agentName,agentIdCardNum,companyName,socialNum,printZhengbendate,printFubenDate,PicIDcardFace,PicFinger,PicFaceRGB,PicFaceIR,PicTakeAway,RGBScore,IRScore,CompareScore,BussinessType,Remark,PrinterType,UploadDatetime1,UploadDatetime2,County,Point,Area,MachineId,SessionId,CreateSessionDate,IsZhengbenLightCheck,IsFubenLightCheck,IsZhengbenTCPIP,IsFubenTCPIP,IsZhengbenPrintCheck,IsFubenPrintCheck,IsZhengbenSuccessed,IsFubenSuccessed,FubenCount from u_printlog ");
            strSql.Append(" where sessionid=?sessionid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?sessionid", MySqlDbType.VarChar,255)
            };
            parameters[0].Value = sessionid;

            Model.u_printlog model = new Model.u_printlog();
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
        public Model.u_printlog DataRowToModel(DataRow row)
        {
            Model.u_printlog model = new Model.u_printlog();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["legalpersonName"] != null)
                {
                    model.legalpersonName = row["legalpersonName"].ToString();
                }
                if (row["legalpersonIdCardNum"] != null)
                {
                    model.legalpersonIdCardNum = row["legalpersonIdCardNum"].ToString();
                }
                if (row["agentName"] != null)
                {
                    model.agentName = row["agentName"].ToString();
                }
                if (row["agentIdCardNum"] != null)
                {
                    model.agentIdCardNum = row["agentIdCardNum"].ToString();
                }
                if (row["companyName"] != null)
                {
                    model.companyName = row["companyName"].ToString();
                }
                if (row["socialNum"] != null)
                {
                    model.socialNum = row["socialNum"].ToString();
                }
                if (row["printZhengbendate"] != null && row["printZhengbendate"].ToString() != "")
                {
                    model.printZhengbendate = DateTime.Parse(row["printZhengbendate"].ToString());
                }
                if (row["printFubenDate"] != null && row["printFubenDate"].ToString() != "")
                {
                    model.printFubenDate = DateTime.Parse(row["printFubenDate"].ToString());
                }
                if (row["PicIDcardFace"] != null)
                {
                    try
                    {
                        model.PicIDcardFace = (byte[])row["PicIDcardFace"];
                    }
                    catch (Exception)
                    {
                        model.PicIDcardFace = null;
                    }
                }
                if (row["PicFinger"] != null)
                {
                    try
                    {
                        model.PicFinger = (byte[])row["PicFinger"];
                    }
                    catch (Exception)
                    {
                        model.PicFinger = null;
                    }
                }
                if (row["PicFaceRGB"] != null)
                {
                    try
                    {
                        model.PicFaceRGB = (byte[])row["PicFaceRGB"];
                    }
                    catch (Exception)
                    {
                        model.PicFaceRGB = null;
                    }
                }
                if (row["PicFaceIR"] != null)
                {
                    try
                    {
                        model.PicFaceIR = (byte[])row["PicFaceIR"];
                    }
                    catch (Exception)
                    {
                        model.PicFaceIR = null;
                    }
                }
                //model.PicIDcardFace=row["PicIDcardFace"].ToString();
                //model.PicFinger=row["PicFinger"].ToString();
                //model.PicFaceRGB=row["PicFaceRGB"].ToString();
                //model.PicFaceIR=row["PicFaceIR"].ToString();
                //model.PicTakeAway=row["PicTakeAway"].ToString();
                if (row["RGBScore"] != null)
                {
                    model.RGBScore = row["RGBScore"].ToString();
                }
                if (row["IRScore"] != null)
                {
                    model.IRScore = row["IRScore"].ToString();
                }
                if (row["CompareScore"] != null)
                {
                    model.CompareScore = row["CompareScore"].ToString();
                }
                if (row["BussinessType"] != null && row["BussinessType"].ToString() != "")
                {
                    model.BussinessType = int.Parse(row["BussinessType"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["PrinterType"] != null && row["PrinterType"].ToString() != "")
                {
                    model.PrinterType = int.Parse(row["PrinterType"].ToString());
                }
                if (row["UploadDatetime1"] != null && row["UploadDatetime1"].ToString() != "")
                {
                    model.UploadDatetime1 = DateTime.Parse(row["UploadDatetime1"].ToString());
                }
                if (row["UploadDatetime2"] != null && row["UploadDatetime2"].ToString() != "")
                {
                    model.UploadDatetime2 = DateTime.Parse(row["UploadDatetime2"].ToString());
                }
                if (row["County"] != null)
                {
                    model.County = row["County"].ToString();
                }
                if (row["Point"] != null)
                {
                    model.Point = row["Point"].ToString();
                }
                if (row["Area"] != null)
                {
                    model.Area = row["Area"].ToString();
                }
                if (row["MachineId"] != null)
                {
                    model.MachineId = row["MachineId"].ToString();
                }
                if (row["SessionId"] != null)
                {
                    model.SessionId = row["SessionId"].ToString();
                }
                if (row["CreateSessionDate"] != null && row["CreateSessionDate"].ToString() != "")
                {
                    model.CreateSessionDate = DateTime.Parse(row["CreateSessionDate"].ToString());
                }
                if (row["IsZhengbenLightCheck"] != null && row["IsZhengbenLightCheck"].ToString() != "")
                {
                    model.IsZhengbenLightCheck = int.Parse(row["IsZhengbenLightCheck"].ToString());
                }
                if (row["IsFubenLightCheck"] != null && row["IsFubenLightCheck"].ToString() != "")
                {
                    model.IsFubenLightCheck = int.Parse(row["IsFubenLightCheck"].ToString());
                }
                if (row["IsZhengbenTCPIP"] != null && row["IsZhengbenTCPIP"].ToString() != "")
                {
                    model.IsZhengbenTCPIP = int.Parse(row["IsZhengbenTCPIP"].ToString());
                }
                if (row["IsFubenTCPIP"] != null && row["IsFubenTCPIP"].ToString() != "")
                {
                    model.IsFubenTCPIP = int.Parse(row["IsFubenTCPIP"].ToString());
                }
                if (row["IsZhengbenPrintCheck"] != null && row["IsZhengbenPrintCheck"].ToString() != "")
                {
                    model.IsZhengbenPrintCheck = int.Parse(row["IsZhengbenPrintCheck"].ToString());
                }
                if (row["IsFubenPrintCheck"] != null && row["IsFubenPrintCheck"].ToString() != "")
                {
                    model.IsFubenPrintCheck = int.Parse(row["IsFubenPrintCheck"].ToString());
                }
                if (row["IsZhengbenSuccessed"] != null && row["IsZhengbenSuccessed"].ToString() != "")
                {
                    model.IsZhengbenSuccessed = int.Parse(row["IsZhengbenSuccessed"].ToString());
                }
                if (row["IsFubenSuccessed"] != null && row["IsFubenSuccessed"].ToString() != "")
                {
                    model.IsFubenSuccessed = int.Parse(row["IsFubenSuccessed"].ToString());
                }
                if (row["FubenCount"] != null && row["FubenCount"].ToString() != "")
                {
                    model.FubenCount = int.Parse(row["FubenCount"].ToString());
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
            strSql.Append("select Id,legalpersonName,legalpersonIdCardNum,agentName,agentIdCardNum,companyName,socialNum,printZhengbendate,printFubenDate,PicIDcardFace,PicFinger,PicFaceRGB,PicFaceIR,PicTakeAway,RGBScore,IRScore,CompareScore,BussinessType,Remark,PrinterType,UploadDatetime1,UploadDatetime2,County,Point,Area,MachineId,SessionId,CreateSessionDate,IsZhengbenLightCheck,IsFubenLightCheck,IsZhengbenTCPIP,IsFubenTCPIP,IsZhengbenPrintCheck,IsFubenPrintCheck,IsZhengbenSuccessed,IsFubenSuccessed,FubenCount ");
            strSql.Append(" FROM u_printlog ");
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
            strSql.Append("select count(1) FROM u_printlog ");
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from u_printlog T ");
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
			parameters[0].Value = "u_printlog";
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