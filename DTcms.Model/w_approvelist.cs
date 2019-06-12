using System;
namespace DTcms.Model
{
    /// <summary>
    /// w_approvelist:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class w_approvelist
    {
        public w_approvelist()
        { }
        #region Model
        private string _approvenum;
        private DateTime? _createdate;
        private int? _createbyid;
        private string _createbyname;
        private string _applyremark;
        private int? _isplanapprove;
        private int? _approvestate;
        private string _applypartnum;
        private string _applytoolname;
        private int? _applyworktime;
        private string _applytoollevel;
        private string _applyoldtoolbarcode;
        private int? _approvebyid;
        private string _approvebyname;
        private DateTime? _approvedate;
        private string _approvenewtoolbarcode;
        private string _approveremark;
        /// <summary>
        /// 
        /// </summary>
        public string ApproveNum
        {
            set { _approvenum = value; }
            get { return _approvenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreateById
        {
            set { _createbyid = value; }
            get { return _createbyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateByName
        {
            set { _createbyname = value; }
            get { return _createbyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApplyRemark
        {
            set { _applyremark = value; }
            get { return _applyremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsPlanApprove
        {
            set { _isplanapprove = value; }
            get { return _isplanapprove; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ApproveState
        {
            set { _approvestate = value; }
            get { return _approvestate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApplyPartNum
        {
            set { _applypartnum = value; }
            get { return _applypartnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApplyToolName
        {
            set { _applytoolname = value; }
            get { return _applytoolname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ApplyWorkTime
        {
            set { _applyworktime = value; }
            get { return _applyworktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApplyToolLevel
        {
            set { _applytoollevel = value; }
            get { return _applytoollevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApplyOldToolBarCode
        {
            set { _applyoldtoolbarcode = value; }
            get { return _applyoldtoolbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ApproveById
        {
            set { _approvebyid = value; }
            get { return _approvebyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApproveByName
        {
            set { _approvebyname = value; }
            get { return _approvebyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ApproveDate
        {
            set { _approvedate = value; }
            get { return _approvedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApproveNewToolBarCode
        {
            set { _approvenewtoolbarcode = value; }
            get { return _approvenewtoolbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApproveRemark
        {
            set { _approveremark = value; }
            get { return _approveremark; }
        }
        #endregion Model

    }
}

