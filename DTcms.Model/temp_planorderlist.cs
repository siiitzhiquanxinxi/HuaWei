using System;
namespace DTcms.Model
{
    /// <summary>
    /// temp_planorderlist:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class temp_planorderlist
    {
        public temp_planorderlist()
        { }
        #region Model
        private int _id;
        private string _partnum;
        private string _partname;
        private string _materialtexture;
        private DateTime? _planworktime;
        private DateTime? _delayworktime;
        private string _machinelathe;
        private string _workprocedure;
        private string _planno;
        private string _componentno;
        private int? _orderreadystate;
        private DateTime? _createdate;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PartNum
        {
            set { _partnum = value; }
            get { return _partnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PartName
        {
            set { _partname = value; }
            get { return _partname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialTexture
        {
            set { _materialtexture = value; }
            get { return _materialtexture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PlanWorkTime
        {
            set { _planworktime = value; }
            get { return _planworktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DelayWorkTime
        {
            set { _delayworktime = value; }
            get { return _delayworktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MachineLathe
        {
            set { _machinelathe = value; }
            get { return _machinelathe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WorkProcedure
        {
            set { _workprocedure = value; }
            get { return _workprocedure; }
        }
        /// <summary>
		/// 
		/// </summary>
		public string PlanNo
        {
            set { _planno = value; }
            get { return _planno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ComponentNo
        {
            set { _componentno = value; }
            get { return _componentno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderReadyState
        {
            set { _orderreadystate = value; }
            get { return _orderreadystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model

    }
}

