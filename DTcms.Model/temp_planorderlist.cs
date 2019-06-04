using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private string _machinelathe;
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
        public string MachineLathe
        {
            set { _machinelathe = value; }
            get { return _machinelathe; }
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
