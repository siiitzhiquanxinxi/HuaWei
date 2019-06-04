using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// w_barcode:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class w_barcode
    {
        public w_barcode()
        { }
        #region Model
        private string _barcode;
        private string _batchnumber;
        private string _materialid;
        private string _materialname;
        private string _materialtypeid;
        private string _materialtype;
        private string _systemno;
        private string _brand;
        private string _spec;
        private string _unit;
        private int? _num;
        private int? _shelfid;
        private string _cabinetno;
        private string _boxno;
        private int? _x;
        private int? _y;
        private int? _remaintime;
        private string _toollevel;
        private int? _state;
        /// <summary>
        /// 
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BatchNumber
        {
            set { _batchnumber = value; }
            get { return _batchnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialID
        {
            set { _materialid = value; }
            get { return _materialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialTypeID
        {
            set { _materialtypeid = value; }
            get { return _materialtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialType
        {
            set { _materialtype = value; }
            get { return _materialtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SystemNo
        {
            set { _systemno = value; }
            get { return _systemno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Spec
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ShelfID
        {
            set { _shelfid = value; }
            get { return _shelfid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CabinetNo
        {
            set { _cabinetno = value; }
            get { return _cabinetno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BoxNo
        {
            set { _boxno = value; }
            get { return _boxno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? X
        {
            set { _x = value; }
            get { return _x; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Y
        {
            set { _y = value; }
            get { return _y; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RemainTime
        {
            set { _remaintime = value; }
            get { return _remaintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolLevel
        {
            set { _toollevel = value; }
            get { return _toollevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}
