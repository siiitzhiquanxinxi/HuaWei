using System;
namespace DTcms.Model
{
    /// <summary>
    /// w_inout_operate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class w_inout_operate
    {
        public w_inout_operate()
        { }
        #region Model
        private string _billid;
        private DateTime? _billdate;
        private int? _fk_operator;
        private string _operatorname;
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
        public int? FK_Operator
        {
            set { _fk_operator = value; }
            get { return _fk_operator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperatorName
        {
            set { _operatorname = value; }
            get { return _operatorname; }
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

