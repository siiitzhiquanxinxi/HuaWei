using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// sy_shelf:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class sy_shelf
    {
        public sy_shelf()
        { }
        #region Model
        private int _id;
        private string _fk_cabinetno;
        private string _boxno;
        private string _boxaddr;
        private decimal? _deep;
        private decimal? _wide;
        private decimal? _high;
        private int? _x;
        private int? _y;
        private int? _type;
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
        public string FK_CabinetNo
        {
            set { _fk_cabinetno = value; }
            get { return _fk_cabinetno; }
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
        public string BoxAddr
        {
            set { _boxaddr = value; }
            get { return _boxaddr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Deep
        {
            set { _deep = value; }
            get { return _deep; }
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
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model

    }
}
