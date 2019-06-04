using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// log_worklog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class log_worklog
    {
        public log_worklog()
        { }
        #region Model
        private int _id;
        private string _sessionid;
        private string _clienttype;
        private string _type;
        private string _opcontent;
        private string _remark;
        private string _agentname;
        private string _agentidcardnum;
        private string _company;
        private DateTime _optime;
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
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpContent
        {
            set { _opcontent = value; }
            get { return _opcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public DateTime OpTime
        {
            set { _optime = value; }
            get { return _optime; }
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
