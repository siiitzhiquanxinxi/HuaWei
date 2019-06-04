using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// sy_material:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class sy_material
    {
        public sy_material()
        { }
        #region Model
        private string _materialid;
        private string _materialname;
        private string _materialtypeid;
        private string _materialtype;
        private string _systemno;
        private string _brand;
        private string _spec;
        private decimal? _long;
        private decimal? _wide;
        private decimal? _high;
        private string _unit;
        private string _supplier;
        private int? _state;
        private string _remark;
        private byte[] _pic;
        private decimal? _minimum;
        private int? _totaltime;
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
        public decimal? Long
        {
            set { _long = value; }
            get { return _long; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Wide
        {
            set { _wide = value; }
            get { return _wide; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? High
        {
            set { _high = value; }
            get { return _high; }
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
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
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
        public byte[] Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Minimum
        {
            set { _minimum = value; }
            get { return _minimum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TotalTime
        {
            set { _totaltime = value; }
            get { return _totaltime; }
        }
        #endregion Model

    }
}
