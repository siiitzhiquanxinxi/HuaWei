using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// w_inout:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class w_inout
    {
        public w_inout()
        { }
        #region Model
        private string _billid;
        private DateTime? _billdate;
        private string _operater;
        private string _sendbillnum;
        private string _inouttype;
        private int? _ioflag;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public string BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BillDate
        {
            set { _billdate = value; }
            get { return _billdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Operater
        {
            set { _operater = value; }
            get { return _operater; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SendBillNum
        {
            set { _sendbillnum = value; }
            get { return _sendbillnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InOutType
        {
            set { _inouttype = value; }
            get { return _inouttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IOFlag
        {
            set { _ioflag = value; }
            get { return _ioflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
