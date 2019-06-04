using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// log_errlog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class log_errlog
    {
        public log_errlog()
        { }
        #region Model
        private int _id;
        private string _sessionid;
        private string _clienttype;
        private string _errtype;
        private string _errcontent;
        private string _errremark;
        private string _agentname;
        private string _agentidcardnum;
        private string _company;
        private DateTime _errtime;
        private string _county;
        private string _area;
        private string _point;
        private string _machineid;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SessionID
        {
            set { _sessionid = value; }
            get { return _sessionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClientType
        {
            set { _clienttype = value; }
            get { return _clienttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ErrType
        {
            set { _errtype = value; }
            get { return _errtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ErrContent
        {
            set { _errcontent = value; }
            get { return _errcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ErrRemark
        {
            set { _errremark = value; }
            get { return _errremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentName
        {
            set { _agentname = value; }
            get { return _agentname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentIdCardNum
        {
            set { _agentidcardnum = value; }
            get { return _agentidcardnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ErrTime
        {
            set { _errtime = value; }
            get { return _errtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string County
        {
            set { _county = value; }
            get { return _county; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Point
        {
            set { _point = value; }
            get { return _point; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MachineID
        {
            set { _machineid = value; }
            get { return _machineid; }
        }
        #endregion Model

    }
}
